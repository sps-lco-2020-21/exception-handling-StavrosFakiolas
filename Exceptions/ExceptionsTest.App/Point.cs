using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Lib
{
    public class Point
    {
        double xValue;
        double yValue;

        public Point(double x, double y)
        {
            SetPoint(x, y);
        }

        public Point()
        {
            SetPoint(0, 0);
        }

        public void SetPoint(double x, double y)
        {
            xValue = x;
            yValue = y;
        }
        public double Xvalue
        {
            get { return xValue; }
        }
        public double YValue
        {
            get { return yValue; }
        }  
    }
}
