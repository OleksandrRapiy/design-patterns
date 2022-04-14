using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    public class Person
    {
        public int ThreadId { get; set; }

        private static object obj = new object();

        private static ThreadLocal<Person> threadInstance = new ThreadLocal<Person>(() => new Person());

        private static Person person;
        private Person()
        {
            ThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        public static Person Instance => threadInstance.Value;

        public static Person GetPerson()
        {
            lock (obj)
            {

                if (person is null)
                {
                    person = new Person();
                }

                return person;
            }
        }
    }
}
