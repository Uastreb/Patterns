using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ChainOfResponsibility
{
    class Program
    {
        public abstract class Creature
        {
            public int Attack { get; set; }
            public int Defense { get; set; }
        }

        public class Goblin : Creature
        {
            public Goblin(Game game) 
            {
                Attack = 1;
                Defense = 1;

                if (game.Creatures.Where(x => x is Goblin).Any())
                {
                    foreach(var creature in game.Creatures)
                    {
                        creature.Defense += 1;
                        Defense += 1;
                    }
                }
            }

            public override string ToString()
            {
                return $"Goblin has {Attack} {nameof(Attack)} and {Defense} {nameof(Defense)} ";
            }
        }

        public class GoblinKing : Goblin
        {
            public GoblinKing(Game game) : base (game)
            {
                Attack = 3;
                Defense = 3;

                if (game.Creatures.Where(x => x is Goblin).Any())
                {
                    foreach (var creature in game.Creatures)
                    {
                        creature.Attack += 1;

                        Defense += 1;
                    }
                }
            }

            public override string ToString()
            {
                return $"GoblinKing has {Attack} {nameof(Attack)} and {Defense} {nameof(Defense)} ";
            }
        }

        public class Game
        {
            public IList<Creature> Creatures;

            public Game()
            {
                Creatures = new List<Creature>();
            }
        }

        static void Main(string[] args)
        {
            var game = new Game();

            game.Creatures.Add(new Goblin(game));
            game.Creatures.Add(new Goblin(game));
            game.Creatures.Add(new Goblin(game));
            game.Creatures.Add(new GoblinKing(game));

            foreach(var creature in game.Creatures)
            {
                WriteLine(creature);
            }

            Console.ReadLine();
        }
    }
}
