using ExceptionsTest.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Lib
{
    public interface IShape : IComparable<IShape>
    {
        double Area { get; }

        double Perimeter { get; }

        int NumberOfSides { get; }
    }
    public class Triangle : IShape
    {
        //this data is private
        double sideA;
        double sideB;
        double sideC;
        double angleARad;
        double angleBRad;
        double angleCRad;
        double angleA;
        double angleB;
        double angleC;
        Point VertexA; 
        Point VertexB;
        Point VertexC;

        public Triangle(Point A, Point B, Point C)
        {
            SetVertices(A, B, C);

        }

        public void SetVertices(Point A, Point B, Point C)
        {
            sideA = Math.Sqrt((B.Xvalue - C.Xvalue) * (B.Xvalue - C.Xvalue) + (B.YValue - C.YValue) * (B.YValue - C.YValue));
            sideB = Math.Sqrt((A.Xvalue - C.Xvalue) * (A.Xvalue - C.Xvalue) + (A.YValue - C.YValue) * (A.YValue - C.YValue));
            sideC = Math.Sqrt((B.Xvalue - A.Xvalue) * (B.Xvalue - A.Xvalue) + (B.YValue - A.YValue) * (B.YValue - A.YValue));
            angleARad = Math.Acos((sideB * sideB + sideC * sideC - sideA * sideA) / (2 * sideB * sideC));
            angleBRad = Math.Acos((sideA * sideA + sideC * sideC - sideB * sideB) / (2 * sideA * sideC));
            angleCRad = Math.Acos((sideA * sideA + sideB * sideB - sideC * sideC) / (2 * sideA * sideB));
            angleA = (angleARad / Math.PI) * 180;
            angleB = (angleBRad / Math.PI) * 180;
            angleC = (angleCRad / Math.PI) * 180;
            VertexA = A;
            VertexB = B;
            VertexC = C;

            if(!IsValid())
            {
                throw new TriangleException();
            }

        }

        public int NumberOfSides
        {
            get { return 3; }
        }
        public double Perimeter
        {
            get { return sideA + sideB + sideC; }
        }

        public bool IsRightAngled()
        {
            return (sideA * sideA == sideB * sideB + sideC * sideC || sideA * sideA + sideB * sideB == sideC * sideC || sideA * sideA + sideC * sideC == sideB * sideB);
        }

        public bool IsEquilateral()
        {
            return (sideA == sideB && sideB == sideC);
        }

        public bool IsIsosceles()
        {
            if (IsEquilateral() == false && (sideA == sideB || sideB == sideC || sideA == sideC)) //Isosceles meaning two equal sides - not equilateral
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsCongruent(Triangle triangle1,Triangle triangle2) //broken rip
        {
            if ((triangle1.sideA == triangle2.sideA) && (triangle1.sideB == triangle2.sideB) && (triangle1.sideC == triangle2.sideC))
            {
                return true; //SSS
            }
            else if (((triangle1.sideA == triangle2.sideA) && (triangle1.sideB == triangle2.sideB) && (triangle1.angleC == triangle2.angleC)) || ((triangle1.sideB == triangle2.sideB) && (triangle1.sideC == triangle2.sideC) && (triangle1.angleA == triangle2.angleA)) || ((triangle1.sideA == triangle2.sideA) && (triangle1.sideC == triangle2.sideC) && (triangle1.angleB == triangle2.angleB)))
            {
                return true; //SAS
            }
            else if (((triangle1.angleA == triangle2.angleA) && (triangle1.angleB == triangle2.angleB) && (triangle1.sideC == triangle2.sideC)) || ((triangle1.angleB == triangle2.angleB) && (triangle1.angleC == triangle2.angleC) && (triangle1.sideA == triangle2.sideA)) || ((triangle1.angleA == triangle2.angleA) && (triangle1.angleC == triangle2.angleC) && (triangle1.sideA == triangle2.sideA)))
            {
                return true; //ASA
            }
            else
            {
                return false; //Not Congruent
            }
        }
        
        public double Area
        {
            get {return 0.5 * sideA * sideB * Math.Sin(angleCRad); }
        }
        
        public List<double> SideLengths()
        {
            List<double> sideLengths = new List<double> { sideA, sideB, sideC };
            return sideLengths;
        }
        
        public List<double> AngleSizes()
        {
            List<double> angleSizes = new List<double> { angleA, angleB, angleC };
            return angleSizes;
        }
        
        public bool IsValid()
        {
            if ((sideA <= 0) || (sideB <= 0) || (sideC <= 0))
                return false;
            else if (Math.Round(angleA,5)  + Math.Round(angleB,5) + Math.Round(angleC,5) == 180 || IsEquilateral()) //floating point inaccuracy
            {
                return true;
            }
            else
                return false;
        }

        public int CompareTo(IShape other)
        {
            if (other == null)
                return 1;
            if (Area.CompareTo(other.Area) == 0)
                return NumberOfSides.CompareTo(other.NumberOfSides);
            else
                return Area.CompareTo(other.Area);       
        }
    }
}
