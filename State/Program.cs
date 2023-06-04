namespace State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var cl = new CombinationLock(new[] { 1, 2, 3, 4, 5 });
            cl.EnterDigit(1);
            cl.EnterDigit(2);
            cl.EnterDigit(3);
            cl.EnterDigit(4);
            cl.EnterDigit(4);
        }
    }

    public class CombinationLock
    {
        private List<int> _enteredDigids = new List<int>();
        private int[] _combination;

        public CombinationLock(int[] combination)
        {
            _combination = combination;
        }

        // you need to be changing this on user input
        public string Status = "LOCKED";

        public void EnterDigit(int digit)
        {
            Console.Write(digit);
            var currCodePosition = _enteredDigids.Count;
            if (_combination[currCodePosition] == digit)
            {
                _enteredDigids.Add(digit);
                Status = "LOCKED";
            }
            else
            {
                Status = "ERROR";
            }

            if (_enteredDigids.Count == _combination.Length)
            {
                Status = "OPEN";
            }
        }
    }
}