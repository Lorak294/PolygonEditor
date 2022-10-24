using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektNaGK
{
    internal class Polygon
    {
        public List<Edge> edges;
        public List<Vert> verts;

        public Polygon()
        {
            verts = new List<Vert>();
            edges = new List<Edge>();
        }
        public Polygon(List<Edge> edges, List<Vert> verts)
        {
            this.verts = new List<Vert>(verts);
            this.edges = new List<Edge>(edges);
        }
        public void Draw(Bitmap canvas, bool bresenham)
        {
            foreach (Vert v in verts)
            {
                v.Draw(canvas);
            }
            foreach (Edge e in edges)
            {
                e.Draw(canvas, bresenham);
            }
        }
        public void DeleteVert(Vert v)
        {
            // determine vert number
            int vertNo = verts.FindIndex(x => x == v);

            // delete v form verts
            v.e1!.DeleteRelation();
            v.e2!.DeleteRelation();
            edges.Remove(v.e1!);
            edges.Remove(v.e2!);
            verts.Remove(v);

            // it can be made into one case probably
            Edge newEdge;
            if (vertNo == 0 || vertNo == verts.Count)
            {
                newEdge = new Edge(verts.Last(), verts.First());
                edges.Add(newEdge);
            }
            else
            {
                newEdge = new Edge(verts[vertNo - 1], verts[vertNo]);
                edges.Insert(vertNo - 1, newEdge);
            }
            newEdge.v1.e2 = newEdge;
            newEdge.v2.e1 = newEdge;
        }
        public void AddVertOnEdge(Edge e, int newVertX, int newVertY)
        {
            e.DeleteRelation();
            int edgeIdx = verts.FindIndex(x => x == e.v1);
            edges.RemoveAt(edgeIdx);

            Vert addedVert = new Vert(newVertX, newVertY);

            Edge newEdge1 = new Edge(e.v1, addedVert);  // 
            Edge newEdge2 = new Edge(addedVert, e.v2);   // 
            e.v1.e2 = newEdge1;                         //
            addedVert.e1 = newEdge1;                    //         e1      e2       e1            e2        e1     e2
            addedVert.e2 = newEdge2;                    //  ...-----> e.v1 <---------> addedVert  <---------> e.v2 <----...
            e.v2.e1 = newEdge2;                         //                   newEdge1               newEdge2  

            edges.Insert(edgeIdx, newEdge1);
            edges.Insert(edgeIdx + 1, newEdge2);
            verts.Insert(edgeIdx + 1, addedVert);
        }
    }
}
