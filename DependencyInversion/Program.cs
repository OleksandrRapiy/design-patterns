using System;

namespace DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "- High-level modules should not depend on low-level modules. Both should depend on the abstraction." +
                "- Abstractions should not depend on details.Details should depend on abstractions.");
        }
    }
}
