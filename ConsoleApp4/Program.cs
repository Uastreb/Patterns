namespace ConsoleApp4
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        private static int _counter = 0;

        public Person Create(string name)
        {
            var person = new Person()
            {
                Id = _counter,
                Name = name
            };
            _counter++;

            return person;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var personFactory = new PersonFactory();

            var human = personFactory.Create("Human");
            var woman = personFactory.Create("Woman");



        }
    }
}
