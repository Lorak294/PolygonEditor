using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektNaGK
{
    internal class Vert
    {
        public const int DRAWRADIUS = 5;
        public int x;
        public int y;
        public Edge? e1;
        public Edge? e2;

        public int Id { get; }
        private static int idProvider = 0;
        
        public Vert(int x, int y)
        {
            this.x = x;
            this.y = y;
            Id = idProvider++;
        }

        public Vert(Point p)
        {
            x = p.X;
            y = p.Y;
            Id = idProvider++;
        }
        public Vert(Vert otherVert)
        {
            x = otherVert.x;
            y = otherVert.y;
            Id = idProvider++;
        }
        
        public static bool operator ==(Vert v1, Vert v2)
        {
            return (v1.Id == v2.Id && v1.x == v2.x && v1.y == v2.y);
        }
        public static bool operator !=(Vert v1, Vert v2)
        { 
            return !(v1==v2);
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var b2 = (Vert)obj;
            return (Id == b2.Id && x == b2.x && y == b2.y);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ x.GetHashCode() ^ y.GetHashCode();
        }

        public void Draw(Bitmap canvas)
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                 g.FillEllipse(Brushes.Black, x - DRAWRADIUS, y - DRAWRADIUS, DRAWRADIUS * 2, DRAWRADIUS * 2);
            }
        }
        public void MoveTo(int xPos, int yPos)
        {
            x = xPos;
            y = yPos;
            if(e1 != null)
                e1.EnforceRelations(this);
            if(e2 != null)
                e2.EnforceRelations(this);
        }
        public void MoveBy(int dx, int dy)
        {
            x += dx;
            y += dy;
            if (e1 != null)
                e1.EnforceRelations(this);
            if (e2 != null)
                e2.EnforceRelations(this);
        }
        public bool CanBeMovedTo(int xPos,int yPos)
        {
            return (MathFunctions.CalculateDistance(xPos, yPos, e1!.v1.x, e1!.v1.y) > 2 * DRAWRADIUS &&
                    MathFunctions.CalculateDistance(xPos, yPos, e2!.v2.x, e2!.v2.y) > 2 * DRAWRADIUS);
        }
    }
}
