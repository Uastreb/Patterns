using System;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var acc = new Account();

            var cmd1 = new Command()
            {
                Amount = 100,
                TheAction = Command.Action.Withdraw
            };

            var cmd2 = new Command()
            {
                Amount = 50,
                TheAction = Command.Action.Deposit
            };

            var cmd3 = new Command()
            {
                Amount = 70,
                TheAction = Command.Action.Deposit
            };

            var cmd4 = new Command()
            {
                Amount = 100,
                TheAction = Command.Action.Withdraw
            };

            acc.Process(cmd1);
            acc.Process(cmd2);
            acc.Process(cmd3);
            acc.Process(cmd4);

            Console.WriteLine(acc.Balance);

            Console.ReadKey();
        }
    }
    public class Command
    {
        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success;
    }

    public class Account
    {
        public int Balance { get; set; }

        public void Process(Command c)
        {
            switch (c.TheAction)
            {
                case Command.Action.Deposit:
                    {
                        if (Balance - c.Amount <= 0)
                        {
                            c.Success = false;
                        }
                        else
                        {
                            Balance -= c.Amount;
                            c.Success = true;
                        }

                        break;
                    }
                case Command.Action.Withdraw:
                    {
                        Balance += c.Amount;
                        c.Success = true;

                        break;
                    }
            }
        }
    }
}
