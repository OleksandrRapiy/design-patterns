using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private Person()
        {

        }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}}}";
        }
    }

    public class PersonFactory
    {
        private List<Person> people;
        public PersonFactory()
        {
            people = new();
        }

        public Person CreatePerson(string name)
        {
            var person = new Person(people.Count, name);
            people.Add(person);

            return person;
        }
    }
}
