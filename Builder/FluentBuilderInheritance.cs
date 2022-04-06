using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public string[] Positions { get; set; }

        public static Builder Build => new Builder();

        public Person()
        {
            Positions = new string[] { };
        }

        public override string ToString()
        {
            return $"Name = {Name}, Last name = {LastName}, Positions = {string.Join(", ", Positions)}";
        }
    }

    public class Builder : PersonDataBuilder<Builder>
    {

    }

    public abstract class PersonBuidler
    {
        protected Person Person = new Person();

        public Person Buid()
        {
            return Person;
        }
    }

    public class PersonInfoBuilder<SELF> :
        PersonBuidler
        where SELF : PersonInfoBuilder<SELF>
    {
        public SELF BuildCredentials(string name, string lastName)
        {
            Person = new Person() { Name = name, LastName = lastName };
            return (SELF)this;
        }

        public override string ToString()
        {
            return Person.ToString();
        }
    }

    public class PersonJobBuilder<SELF> :
        PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {

        public SELF BuildJob(string[] position)
        {
            Person.Positions = position;
            return (SELF)this;
        }
    }

    public class PersonDataBuilder<SELF> :
        PersonJobBuilder<SELF>
        where SELF : PersonDataBuilder<SELF>
    {

        public SELF BuilPersonWithData(string name, string lastName, string[] positions)
        {
            Person.Name = name;
            Person.LastName = lastName;
            Person.Positions = positions;

            return (SELF)this;
        }

    }
}
