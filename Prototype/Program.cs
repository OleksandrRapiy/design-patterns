using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var jhon = Person.Builder
                .BuildPersonName("Jhon")
                .BuildPersonAddress(new Address("Washingthon", 12))
                .Build();

            Person jane = jhon.DeepCopy();
            jane.Name = "Jane";
            jane.Address.HouseNumber = 3212;

            Console.WriteLine(jhon);
            Console.WriteLine(jane);


            Employee employee = new Employee("Eml Jhon", jane.Address.DeepCopy(), 123.2F);
            var smithEmpl = employee.DeepCopy();
            smithEmpl.Name = "Smith Empl";
            smithEmpl.Salary = 21321;
            Console.WriteLine(employee);
            Console.WriteLine(smithEmpl);


            // Deep copy through serialization 
            var employeeCopyFromPerson = jane.DeepCopySerialization<Person, Employee>();
            employeeCopyFromPerson.Address.HouseNumber = 21;
            employeeCopyFromPerson.Salary = 122;
            Console.WriteLine(employeeCopyFromPerson);
        }
    }
}
