using System;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instace;
            Console.WriteLine(db.GetPopulation("Tokyo"));


            var ceo = new CEO();
            ceo.Name = "Jon";
            Console.WriteLine(ceo);
            var ceo2 = new CEO();
            Console.WriteLine(ceo2);


            var t1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"T1: {Person.GetPerson().ThreadId}");
                Console.WriteLine($"T1: {Person.GetPerson().ThreadId}");
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"T2: {Person.Instance.ThreadId}");
                Console.WriteLine($"T2: {Person.Instance.ThreadId}");
            });

            Thread thread = new Thread((t) =>
            {
                Console.WriteLine($"T2: {Person.GetPerson().ThreadId}");
            });
            thread.Start();
            

            Task.WaitAll(t1, t2);



            var singeltonTester = SingletonTester.IsSingleton(() =>  Person.Instance);

            Console.WriteLine(singeltonTester);
        }
    }
}
