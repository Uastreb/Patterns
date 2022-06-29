using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var personName = new PersonName() { Name = "new person" };

            var person1 = new Person() { PersonName = personName };
            var person2 = new Person() { PersonName = personName };
            var person3 = new Person() { PersonName = personName };
            var person4 = new Person() { PersonName = personName };
            var person5 = new Person() { PersonName = personName };

            personName.Name = "modified person";

            Console.WriteLine($@"
{person1.PersonName.Name} 
{person2.PersonName.Name} 
{person3.PersonName.Name} 
{person4.PersonName.Name} 
{person5.PersonName.Name}");
            Console.ReadLine();

        }
    }

    class Person
    {
        public PersonName PersonName {get; set;}
    }

    class PersonName 
    {
        public string Name { get; set; }
    }
}
