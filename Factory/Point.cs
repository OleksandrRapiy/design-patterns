using System;
using System.Threading.Tasks;

namespace Factory
{
    public enum Coordinates
    {
        Cartesian,
        Polar
    }

    public class Point
    {
        private readonly double x;
        private readonly double y;


        private Point() { }

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// Example of constructor without factory pattern
        //public Point(double a, double b, Coordinates coordinates = Coordinates.Cartesian)
        //{
        //    switch (coordinates)
        //    {
        //        case Coordinates.Cartesian:
        //            x = a;
        //            y = b;
        //            break;
        //        case Coordinates.Polar:
        //            x = a * Math.Cos(b);
        //            y = a * Math.Sin(b);
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(coordinates));
        //    }
        //}



        public override string ToString()
        {
            return $"{nameof(x)}: {x}\n{nameof(y)}: {y}";
        }

        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }

            // Work with async factory
            public static async Task<Point> CreatePolarCoordinatesAsync(double rho, double theta)
            {
                var polar = NewPolarPoint(rho, theta);

                await Task.Delay(1000);

                return polar;
            }
        }
    }
}
