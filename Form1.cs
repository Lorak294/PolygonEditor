using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;

namespace ProjektNaGK
{
    public enum EditionMode{
        NewPolygon,
        AddingFixedLength,
        AddingParallel,
        DeleteRelation,
        FreeEdit
    }

    public enum Relation
    {
        Parallel,
        FixedLength,
        NoRelation
    }

    public partial class Form1 : Form
    {
        private Bitmap canvas;
        private List<Vert> tmpVertList;
        private List<Edge> tmpEdgeList;
        private List<Polygon> polygons;

        private EditionMode editionMode;
        private Vert? selectedVert = null;
        private Edge? selectedEdge = null;
        private Edge? parrarelEdgeReference = null;
        private Polygon? selectedPolygon = null;
        private Point oldMousePosition;


        // ------------------- CONSTRUCTOR --------------------------------------------
        public Form1()
        {
            InitializeComponent();
            canvas = new Bitmap(drawArea.Width, drawArea.Height);
            drawArea.Image = canvas; 
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
            }

            editionMode = EditionMode.FreeEdit;
            tmpVertList = new List<Vert>();
            tmpEdgeList = new List<Edge>();
            polygons = new List<Polygon>();
        }

        // ------------------- EVENT FUNCTIONS --------------------------------------------
        private void drawArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (editionMode == EditionMode.NewPolygon) // addning new polygon
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (MathFunctions.CLickedOnVert(tmpVertList.First(), e.X, e.Y) && tmpVertList.Count > 1) // finishing the polygon
                    {
                        if(tmpVertList.Count > 3)
                        {
                            // clean vert on mouse position
                            tmpEdgeList.RemoveAt(tmpEdgeList.Count - 1);
                            tmpVertList.RemoveAt(tmpVertList.Count - 1);

                            FinishPolygon();
                        }
                        else
                        {
                            MessageBox.Show("New polygon has to have more then two vertices.");
                        }
                        ChangeEditionMode(EditionMode.FreeEdit);
                        CleanTmpLists();
                    }
                    else // adding new vert to polygon
                    {
                        AddNewTmpVertWithEdges(e.X, e.Y);
                    }
                    DrawAll();
                }
            }
            else if (polygons.Count > 0)// editing existing polygons
            {
                foreach (Polygon p in polygons)
                {
                    // click on one of the verts in the polygon
                    foreach (Vert v in p.verts)
                    {
                        if (MathFunctions.PointInsideCircle(v.x, v.y, Vert.DRAWRADIUS, e.X, e.Y))
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                // start vert movement
                                selectedVert = v;
                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                                // delete vert
                                

                                if (p.verts.Count > 3)
                                    p.DeleteVert(v);
                                else
                                {
                                    var confirmResult = MessageBox.Show("Are you sure you want to delete this polygon?", "",
                                    MessageBoxButtons.YesNo);
                                    if (confirmResult == DialogResult.Yes)
                                        polygons.Remove(p);
                                }

                            }
                            DrawAll();
                            return;
                        }
                    }

                    // click on one of the edges
                    foreach(Edge edge in p.edges)
                    {
                        if (MathFunctions.PointOnTheEdge(new Point(e.X, e.Y), edge))
                        {
                            switch (editionMode)
                            {
                                case EditionMode.FreeEdit:
                                    {
                                        if (e.Button == MouseButtons.Left) // starting edge movement
                                        {
                                            oldMousePosition = new Point(e.X, e.Y);
                                            selectedEdge = edge;
                                            return;
                                        }
                                        else if (e.Button == MouseButtons.Right) // adding new Vert on edge
                                        {
                                            p.AddVertOnEdge(edge, e.X, e.Y);
                                            DrawAll();
                                            return;
                                        }
                                        break;
                                    }
                                case EditionMode.AddingFixedLength:
                                    {
                                        // adding fixed length if possible
                                        if (edge.ActiveRelation != Relation.NoRelation) 
                                            return;

                                        edge.AddFixedLength(null);
                                        ChangeEditionMode(EditionMode.FreeEdit);
                                        DrawAll();
                                        return;
                                    }
                                case EditionMode.AddingParallel:
                                    {
                                        // adding parrarel if possible
                                        if (edge.ActiveRelation != Relation.NoRelation)
                                            return;

                                        if (parrarelEdgeReference == null)
                                        {
                                            parrarelEdgeReference = edge;
                                            edge.Mark();
                                        }
                                        else
                                        {
                                            if(edge != parrarelEdgeReference)
                                            {
                                                MakeEdgesParrarel(edge, parrarelEdgeReference);
                                                ChangeEditionMode(EditionMode.FreeEdit);
                                            }
                                            parrarelEdgeReference.Unmark();
                                            parrarelEdgeReference = null;
                                        }
                                        DrawAll();
                                        break;
                                    }
                                case EditionMode.DeleteRelation:
                                    {
                                        // deleting relation from edge
                                        edge.DeleteRelation();
                                        DrawAll();
                                        break;
                                    }
                            }
                            
                        }
                    }

                    // click indide polygon
                    if (MathFunctions.PointInsidePolygon(new Point(e.X, e.Y), p))
                    {
                        if(editionMode == EditionMode.FreeEdit)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                // start polygon movement
                                oldMousePosition = new Point(e.X, e.Y);
                                selectedPolygon = p;

                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                                // delete polygon
                                var confirmResult = MessageBox.Show("Are you sure you want to delete this polygon?", "",
                                    MessageBoxButtons.YesNo);
                                if (confirmResult == DialogResult.Yes)
                                    polygons.Remove(p);
                            }
                            DrawAll();
                            return;
                        }
                    }
                }
            }
        }
        private void drawArea_MouseUp(object sender, MouseEventArgs e)
        {
            selectedVert = null;
            selectedEdge = null;
            selectedPolygon = null;
        }
        private void drawArea_MouseMove(object sender, MouseEventArgs e)
        {
            switch (editionMode)
            {
                case EditionMode.NewPolygon:
                    {
                        // moving vert together with mouse
                        tmpVertList.Last().MoveTo(e.X, e.Y);
                        break;
                    }
                case EditionMode.FreeEdit:
                    {
                        if (selectedVert is not null && selectedVert.CanBeMovedTo(e.X, e.Y)) // moving single vert
                        {
                            selectedVert.MoveTo(e.X, e.Y);
                        }
                        else if (selectedPolygon != null) // moving whole polygon
                        {
                            foreach (Vert v in selectedPolygon.verts)
                            {
                                v.MoveBy(e.X - oldMousePosition.X, e.Y - oldMousePosition.Y);
                            }
                        }
                        else if (selectedEdge != null) // moving single edge
                        {
                            selectedEdge.MoveBy(e.X - oldMousePosition.X, e.Y - oldMousePosition.Y);
                        }
                        oldMousePosition.X = e.X;
                        oldMousePosition.Y = e.Y;
                        break;
                    }
            }
            DrawAll();
            
            // mark all edges as unModiefied for next relation enforcement
            foreach(Polygon p in polygons)
            {
                foreach( Edge edge in p.edges)
                {
                    edge.alreadyModified = false;
                }  
            }
        }
        private void drawArea_SizeChanged(object sender, EventArgs e)
        {
            canvas = new Bitmap(drawArea.Size.Width, drawArea.Size.Height);
            drawArea.Image = canvas;
            if(polygons != null || tmpVertList != null) DrawAll();
        }
        private void addPolygonButton_Click(object sender, EventArgs e)
        {
            // add new vert on temporary position which will immediately move to mouse position
            tmpVertList.Add(new Vert(-10, -10));
            ChangeEditionMode(EditionMode.NewPolygon);
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (parrarelEdgeReference != null)
            {
                parrarelEdgeReference.Unmark();
                parrarelEdgeReference = null;
            }

            ChangeEditionMode(EditionMode.FreeEdit);
            CleanTmpLists();
            DrawAll();
        }
        private void lengthRelButton_Click(object sender, EventArgs e)
        {
            ChangeEditionMode(EditionMode.AddingFixedLength);
        }
        private void parallelRelButton_Click(object sender, EventArgs e)
        {
            ChangeEditionMode(EditionMode.AddingParallel);
        }
        private void deleteRelButton_Click(object sender, EventArgs e)
        {
            ChangeEditionMode(EditionMode.DeleteRelation);
        }
        private void generateSceneButton_Click(object sender, EventArgs e)
        {
            // Points coordinates
            Point[,] vertCoords = new Point[,]{
                { new Point(44,34),new Point(109,190), new Point(309,160), new Point(244,35)},
                { new Point(140,472),new Point(83,243), new Point(382,255), new Point(214,343)},
                { new Point(430,227),new Point(392,44), new Point(533,72), new Point(579,257)}
            };

            // cleaning current scene
            polygons.Clear();
            CleanTmpLists();

            // genertating polygons form vertCoords
            for (int i = 0; i < vertCoords.GetLength(0); i++)
            {             
                for (int j = 0; j < vertCoords.GetLength(1); j++)
                {
                    Vert newVert = new Vert(vertCoords[i, j]);
                    if (tmpVertList.Count > 0)
                    {
                        Edge newEdge = new Edge(tmpVertList.Last(), newVert);
                        tmpEdgeList.Add(newEdge);
                        newVert.e1 = newEdge;            // N
                        tmpVertList.Last().e2 = newEdge; // N
                    }
                    tmpVertList.Add(newVert);
                }
                // final edge
                Edge finalEdge = new Edge(tmpVertList.Last(), tmpVertList.First());
                tmpEdgeList.Add(finalEdge);
                tmpVertList.Last().e2 = finalEdge;
                tmpVertList.First().e1 = finalEdge;

                // add new polygon
                polygons.Add(new Polygon(tmpEdgeList, tmpVertList));
                CleanTmpLists();
            }

            // adding relations
            polygons[0].edges[1].AddFixedLength(200);
            polygons[1].edges[3].AddFixedLength(150);
            MakeEdgesParrarel(polygons[0].edges[0],polygons[0].edges[2]);
            MakeEdgesParrarel(polygons[1].edges[0], polygons[2].edges[2]);
            MakeEdgesParrarel(polygons[2].edges[1], polygons[2].edges[3]);


            // set correct state and draw
            ChangeEditionMode(EditionMode.FreeEdit);
            DrawAll();

        }

        // ------------------- IMAGE UPDATING FUNCTIONS -------------------------------
        private void DrawAll()
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
                foreach (Vert v in tmpVertList)
                {
                    v.Draw(canvas);
                }

                foreach (Edge e in tmpEdgeList)
                {
                    e.Draw(canvas, bresenhamOption.Checked);
                }

                foreach (Polygon p in polygons)
                {
                    p.Draw(canvas, bresenhamOption.Checked);
                }
            }
            drawArea.Refresh();
        }

        // ------------------- UTILITY FUNCTIONS --------------------------------------
        private void AddNewTmpVertWithEdges(int x, int y)
        {
            Vert newVert = new Vert(x, y);
            if (tmpVertList.Count > 0)
            {
                Edge newEdge = new Edge(tmpVertList.Last(), newVert);
                tmpEdgeList.Add(newEdge);
                newVert.e1 = newEdge;
                tmpVertList.Last().e2 = newEdge;
            }
            tmpVertList.Add(newVert);
        }
        private void FinishPolygon()
        {
            // add completing edge
            Edge newEdge = new Edge(tmpVertList.Last(), tmpVertList.First());
            tmpEdgeList.Add(newEdge);
            tmpVertList.Last().e2 = newEdge;
            tmpVertList.First().e1 = newEdge;

            // add new polygon
            polygons.Add(new Polygon(tmpEdgeList, tmpVertList));
        } 
        private void ChangeEditionMode(EditionMode newEditionMode)
        {
            ChangeActionButtons(newEditionMode == EditionMode.FreeEdit);
            editionMode = newEditionMode;
        }
        private void ChangeActionButtons(bool newState)
        {
            addPolygonButton.Enabled = newState;
            lengthRelButton.Enabled = newState;
            parallelRelButton.Enabled = newState;
            deleteRelButton.Enabled = newState;
            generateSceneButton.Enabled = newState;
            cancelButton.Enabled = !newState;
        }
        private static void MakeEdgesParrarel(Edge e1,Edge e2)
        {
            e1.AddParallel(e2);
            e2.AddParallel(e1);
            e2.DrawBrush = e1.DrawBrush = ColorBrushesContainer.GetBrush();
            e1.EnforceRelations(e1.v1);
            e2.EnforceRelations(e1.v2);
        }
        private void CleanTmpLists()
        {
            tmpEdgeList.Clear();
            tmpVertList.Clear();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"../../../instructions.txt");
            MessageBox.Show(text,"Usage instructions");
            
        }
    }
}