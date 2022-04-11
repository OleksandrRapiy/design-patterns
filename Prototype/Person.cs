using System.Text;
using System.Text.Json;

namespace Prototype
{
    public static class Extentions
    {
        public static T DeepCopySerialization<T>(this T self)
        {
            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(self));
            return JsonSerializer.Deserialize<T>(bytes);
        }

        public static Derived DeepCopySerialization<Base, Derived>(this Base obj) where Derived : Base
        {
            var copyObj = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));
            return JsonSerializer.Deserialize<Derived>(copyObj);

        }
    }
    public interface IPrototype<T>
    {
        T DeepCopy();
    }
    public class Person : IPrototype<Person>
    {
        public Person()
        {

        }

        public Person(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public Address Address { get; set; }

        public static PersonBuilder Builder => new();

        public override string ToString()
        {
            return $"Name - {Name}, {Address}";
        }

        public Person DeepCopy()
        {
            return Builder
                .BuildPersonName(Name)
                .BuildPersonAddress(Address.DeepCopy())
                .Build();
        }

        /// <summary>
        /// It's shallow copy of object, so it doesn't copy complex object inside object
        /// </summary>
        /// <returns>Shallow copy of Person</returns>
        //public object Clone()
        //{
        //    return (Person)MemberwiseClone();
        //}

    }

    public class Address : IPrototype<Address>
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public Address()
        {

        }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"Address - {StreetName}, {HouseNumber}";
        }

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }
    }

    public class Employee : Person, IPrototype<Employee>
    {
        public float Salary { get; set; }

        public Employee()
        {

        }

        public Employee(string name, Address address, float salary) : base(name, address)
        {
            Name = name;
            Address = address;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Salary - {Salary}";
        }

        public Employee DeepCopy()
        {
            return new Employee((string)Name.Clone(), Address.DeepCopy(), Salary);
        }
    }


    #region Builders

    public class PersonBuilder
    {
        readonly Person person = new();

        public PersonBuilder BuildPersonName(string name)
        {
            person.Name = name;
            return this;
        }

        public PersonBuilder BuildPersonAddress(Address address)
        {
            person.Address = address;
            return this;
        }

        public Person Build()
        {
            return person;
        }
    }
    #endregion
}
