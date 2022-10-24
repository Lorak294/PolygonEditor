using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektNaGK
{
    internal class Edge
    {
        public Vert v1;
        public Vert v2;
        public Edge? parrarelEdge;

        private double? fixedLength;
        public bool alreadyModified;
        private bool marked;
        private static int idProvider = 0;

        public int Id { get; }
        public Brush DrawBrush { get; set; }
        public Relation ActiveRelation { get; private set; }
        public (int dx, int dy) Vector { get => (v2.x - v1.x, v2.y - v1.y); }
        public (double dx, double dy) NormVector { get => (Vector.dx / Length, Vector.dy / Length); }

        public double Length { get => Math.Max(1, MathFunctions.CalculateDistance(v1.x, v1.y, v2.x, v2.y)); }  
     
        public Edge(Vert v1, Vert v2)
        {
            this.v1 = v1;
            this.v2 = v2;
            ActiveRelation = Relation.NoRelation;
            parrarelEdge = null;
            fixedLength = null;
            alreadyModified = false;
            marked = false;
            Id = idProvider++;
            DrawBrush = Brushes.Black;

        }
        
        public void Draw(Bitmap canvas, bool bresenham = false)
        {
            Brush brush = marked ? Brushes.Red : DrawBrush;
            using (Graphics g = Graphics.FromImage(canvas))
            {
                Point textPos = new Point(v1.x + (Vector.dx / 2), v1.y + (Vector.dy / 2));
                if (ActiveRelation == Relation.FixedLength)
                {
                    g.DrawString(fixedLength.ToString(), SystemFonts.DefaultFont, brush, textPos);
                }
                else if (ActiveRelation == Relation.Parallel)
                {
                    g.DrawString("R", SystemFonts.DefaultFont, brush, textPos);
                }

                if (bresenham)
                {
                    MathFunctions.BresenhamDraw(canvas, v1.x, v1.y, v2.x, v2.y, brush);
                }
                else
                {
                    g.DrawLine(new Pen(brush), v1.x, v1.y, v2.x, v2.y);
                }

            }
        }
        public void MoveBy(int dx, int dy)
        {
            v1.x += dx;
            v1.y += dy;
            v2.x += dx;
            v2.y += dy;
            v1.e1!.EnforceRelations(v1);
            v2.e2!.EnforceRelations(v2);
        }
        public void AddFixedLength(double? newLengthN)
        {
            double newLength = 0;
            if (newLengthN == null || newLengthN < 1)
            {
                // getting user input
                bool correctInupt = false;
                while (!correctInupt)
                {
                    string newLengthStr = InputBoxPrompt.ShowDialog("Provide new length in pixels (>= 1):", "");
                    correctInupt = double.TryParse(newLengthStr, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out newLength) && newLength >= 1;
                }
            }
            else
                newLength = newLengthN.Value;

            // updating fields and moving the vert
            fixedLength = newLength;
            ActiveRelation = Relation.FixedLength;
            v2.MoveTo(v1.x + (int)(NormVector.dx * newLength), v1.y + (int)(NormVector.dy * newLength));
        }
        public void AddParallel(Edge otherEdge)
        {
            parrarelEdge = otherEdge;
            ActiveRelation = Relation.Parallel;
        }
        public void Mark()
        {
            marked = true;
        }
        public void Unmark()
        {
            marked = false;
        }
        public void EnforceRelations(Vert movedVert)
        {
            if (alreadyModified)
                return;

            alreadyModified = true;
            switch (ActiveRelation)
            {
                case Relation.NoRelation:
                    alreadyModified = true;
                    return;
                case Relation.FixedLength:
                    {
                        // move the other vert to position: movedVert +- NormalizedVector * fixedLength
                        if (movedVert == v1)
                        {
                            v2.MoveTo(v1.x + (int)(NormVector.dx * fixedLength!), v1.y + (int)(NormVector.dy * fixedLength!));
                        }
                        else if (movedVert == v2)
                        {
                            v1.MoveTo(v2.x - (int)(NormVector.dx * fixedLength!), v2.y - (int)(NormVector.dy * fixedLength!));
                        }
                        break;
                    }
                case Relation.Parallel:
                    {
                        if (movedVert == v1)
                        {
                            v2.e2!.EnforceRelations(v2);
                        }
                        else
                        {
                            v1.e1!.EnforceRelations(v1);
                        }
                        parrarelEdge!.MakeParallel();
                        break;

                    }
            }

        }
        public void MakeParallel()
        {
            if (ActiveRelation != Relation.Parallel || parrarelEdge == null)
                return;

            (int dx, int dy) newVector = ((int)Math.Round(parrarelEdge!.NormVector.dx * Length), (int)Math.Round(parrarelEdge!.NormVector.dy * Length));

            if (Vector.dx * newVector.dx < 0 || Vector.dy * newVector.dy < 0)
            {
                // reversed vector
                v1.MoveTo(v2.x + newVector.dx, v2.y + newVector.dy);
            }
            else
            {
                // same vector
                v2.MoveTo(v1.x + newVector.dx, v1.y + newVector.dy);
            }
        }
        public void DeleteRelation()
        {
            switch (ActiveRelation)
            {
                case Relation.NoRelation:
                    return;
                case Relation.Parallel:
                    {
                        ActiveRelation = Relation.NoRelation; // has to be here to prevent envoking cycle
                        parrarelEdge!.DeleteRelation();
                        DrawBrush = Brushes.Black;
                        parrarelEdge = null;
                        break;
                    }
                case Relation.FixedLength:
                    {
                        ActiveRelation = Relation.NoRelation;
                        fixedLength = null;
                        break;
                    }
            }
        }
    }
}
