using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjektNaGK
{
    internal abstract class MathFunctions
    {
        public static bool PointInsideCircle(double circle_x, double circle_y,
                                  double radius, double x, double y)
        {
             
            // Compare radius of circle with distance of its center from given point
            if ((x - circle_x) * (x - circle_x) +
                (y - circle_y) * (y - circle_y) <= radius * radius)
                return true;
            else
                return false;
        }
        public static bool CLickedOnVert(Vert v, double x, double y)
        {
            return PointInsideCircle(v.x,v.y,Vert.DRAWRADIUS,x,y);
        }
        public static bool PointInsidePolygon(Point p, Polygon polygon)
        {
            bool inside = false;
            Point p1, p2;

            Point oldPoint = new Point(polygon.verts.Last().x,polygon.verts.Last().y);

            for(int i=0; i< polygon.verts.Count; i++)
            {
                Point newPoint = new Point(polygon.verts[i].x, polygon.verts[i].y);

                if(newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }

                if((newPoint.X < p.X)==(p.X <= oldPoint.X)
                    && (p.Y - (long)p1.Y) * (p2.X - p1.X) 
                    < (p2.Y - (long)p1.Y) * (p.X - p1.X))
                {
                    inside = !inside;
                }

                oldPoint = newPoint;
            }
            return inside;
        }
        public static bool PointOnTheEdge(Point p, Edge edge)
        {
            const int TOLERANCE = 3;

            using (var path = new GraphicsPath())
            {
                using (var pen = new Pen(Brushes.Black, TOLERANCE))
                {
                    path.AddLine(new Point(edge.v1.x,edge.v1.y), new Point(edge.v2.x,edge.v2.y));
                    return path.IsOutlineVisible(p, pen);
                }
            }
        }
        public static double CalculateDistance(Point p1, Point p2)
        {
            return CalculateDistance(p1.X, p1.Y, p2.X, p2.Y);
        }
        public static double CalculateDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
        public static void PutPixel(Bitmap canvas,int x, int y, Brush colorBrush)
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.FillRectangle(colorBrush, x, y, 1, 1);
            }
        }
        public static void BresenhamDraw(Bitmap canvas,int x, int y, int x2, int y2, Brush colorBrush)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                PutPixel(canvas,x, y, colorBrush);
                
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }
    }
}
