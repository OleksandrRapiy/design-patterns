using System;

namespace SingleResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Single Responsibility

            var journal = new Journal();
            journal.AddEntry("Test of data");
            journal.AddEntry("Test of second data");
            Console.WriteLine(journal);

            var persistence = new Persistence();
            var fileName = @"C:\Personal\DesignPatterns\TxtFiles\journal.txt";
            persistence.SaveToFile(journal, fileName, true);

        }
    }
}
