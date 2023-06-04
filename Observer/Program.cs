namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Game game = new Game();

            Rat rat1 = new Rat(game);
            Rat rat2 = new Rat(game);
            Rat rat3 = new Rat(game);
            rat2.Dispose();
            rat3.Dispose();
        }
    }

    public class Game
    {
        public event EventHandler AttackUpdated;

        public void UpdateAttack()
        {
            AttackUpdated?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Rat : IDisposable
    {
        private readonly Game _game;
        private static int _ratCount = 0;

        public int Attack = 1;

        public Rat(Game game)
        {
            _game = game;
            _ratCount++;
            _game.AttackUpdated += UpdateAttack;
            _game.UpdateAttack();
        }

        private void UpdateAttack(object sender, EventArgs e)
        {
            Attack = _ratCount;
        }

        public void Dispose()
        {
            _ratCount--;
            _game.UpdateAttack();
            _game.AttackUpdated -= UpdateAttack;
        }
    }
}