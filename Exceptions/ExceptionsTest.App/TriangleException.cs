using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsTest.App
{
    class TriangleException : Exception
    {
        public TriangleException():
            base("Invalid Triangle")
        { }
    }
}
