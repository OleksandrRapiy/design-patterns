using System;

namespace LiskovSubstitution
{
    class Program
    {
        static public int Area(Rectangle rectangle) => rectangle.Width * rectangle.Height;
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(1, 3);
            Console.WriteLine(rectangle);
            Console.WriteLine($"Area - {Area(rectangle)}");

             
            Rectangle square = new Square();
            square.Width = 4;
            Console.WriteLine(square);
            Console.WriteLine($"Area - {Area(square)}");
        }
    }
}
