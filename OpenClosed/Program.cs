using System;

namespace OpenClosed
{
    class Program
    {
        static void Main(string[] args)
        {
            // Open-Closed Responsibility
            var apple = new Product("apple", Color.Blue, Size.Medium);
            var bananna = new Product("bananna", Color.Red, Size.Large);
            var potato = new Product("potato", Color.Green, Size.Small);
            var watermelon = new Product("watermelon", Color.Red, Size.Large);

            Product[] products = { apple, bananna, potato, watermelon };

            Console.WriteLine("Old version, which brokes Open-Closed Principle");
            foreach (var item in products.FilterBySize(Size.Small))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("New version of filtering, aceptable for Open-Closed Principle");
            foreach (var item in new ProductFilter().Filter(products,
                   new ProductSizeAndColorSpecification(Size.Large, Color.Red)
                ))
            {
                Console.WriteLine(item);
            }
        }
    }
}
