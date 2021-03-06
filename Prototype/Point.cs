using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Point
    {
        public int X, Y;

        public Point DeepCopy()
        {
            return new Point()
            {
                X = X,
                Y = Y
            };
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            //return this.DeepCopySerialization();

            return new Line()
            {
                Start = Start.DeepCopy(),
                End = End.DeepCopy()
            };
        }
    }
}
