using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var responsiblePerson = new ResponsiblePerson(new Person() { Age = 14 });

            Console.WriteLine(responsiblePerson.Drink());
            Console.WriteLine(responsiblePerson.Drive());
            Console.WriteLine(responsiblePerson.DrinkAndDrive());

            Console.ReadLine();
        }
    }

    public interface IPerson
    {
        int Age { get; set; }

        string Drink();
        string DrinkAndDrive();
        string Drive();
    }

    public class Person : IPerson
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson : IPerson
    {
        private Person _person;

        public ResponsiblePerson(Person person)
        {
            _person = person;
        }

        public int Age 
        {
            get { return _person.Age; }
            set { _person.Age = value; }
        }

        public string Drink()
        {
            if (_person.Age < 16)
            {
                return "too young";
            }

            return _person.Drink();
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }

        public string Drive()
        {
            if (_person.Age < 16)
            {
                return "too young";
            }

            return _person.Drive();
        }
    }
}
