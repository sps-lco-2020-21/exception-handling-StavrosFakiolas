using Geometry.Lib; //HELL YEAH
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics; // this has to be used for Debug.Assert();
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.App
{
    
    class Program2
    {
        public static void Test()
        {
            //Testing function

            Point origin = new Point(0, 0);
            Point point1 = new Point(0, 3);
            Point point2 = new Point(5, 0);
            Point point3 = new Point(10, 0);
            Point point4 = new Point(0, 10);

            Point point5 = new Point(1, 1);
            Point point6 = new Point(3, 5);
            Point point7 = new Point(-2, -2);
            
            Triangle t1 = new Triangle(origin, point1, point2);
            Triangle t2 = new Triangle(point3, origin, point4);
            Triangle t3 = new Triangle(point5, point6, point7);
            Triangle t4 = new Triangle(point5, point7, point6);

            Console.ReadKey();

            Console.WriteLine(t1.CompareTo(t2));
            Console.WriteLine(t3.CompareTo(t4));

            

            List<IShape> shapes = new List<IShape>();
            shapes.Add(t1);
            shapes.Add(t2);
            shapes.Add(t3);

            foreach (IShape shape in shapes)
                Console.WriteLine(shape.Area);
            Console.WriteLine(shapes[0].CompareTo(shapes[1]));
            
            Console.ReadKey();
            
            Debug.Assert(t1.Perimeter == 20);
            
            if (t1.IsRightAngled())
                Console.WriteLine("This is a right angled triangle");
            if (t2.IsEquilateral())
                Console.WriteLine("This is an equilateral triangle");
            if (t1.IsIsosceles())
                Console.WriteLine("the function is wrong");
            if (t2.IsIsosceles())
                Console.WriteLine("The function is wrong");
            if (t3.IsIsosceles())
                Console.WriteLine("The function is correct");

            if (t1.IsValid())
                Console.WriteLine("t1 is valid");
            if (t2.IsValid())
                Console.WriteLine("t2 is valid");
            if (t3.IsValid())
                Console.WriteLine("t3 is valid");

            Console.WriteLine(t1.Area);
            List<double> a = t1.SideLengths();
            foreach(double item in a)
            {
                Console.WriteLine(item);
            }
            List<double> b = t1.AngleSizes();
            foreach (double item in b)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(t1.IsCongruent(t1, t2)); 
            Console.ReadKey();
        }
    }
}
