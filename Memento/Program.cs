using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var tokenMachine = new TokenMachine();
            var token1 = new Token(111);
            var memento1 = tokenMachine.AddToken(token1);
            token1.Value = 333;
            var token2 = new Token(112);
            var token3 = new Token(113);
            var token4 = new Token(114);

            var memento2 = tokenMachine.AddToken(token2);
            var memento3 = tokenMachine.AddToken(token3);
            var memento4 = tokenMachine.AddToken(token4);

            tokenMachine.Revert(memento2);

            //var tokenList = new List<Token>();
            //tokenList.Add(token1);
            //token1.Value = 333;
        }
    }

    public class Token
    {
        private int _value = 0;

        public Token(int value)
        {
            _value = value;
        }
    }

    public class Memento
    {
        public Token Token;

        public Memento(Token token)
        {
            Token=token;
        }
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            var token = new Token(value);
            var memento = new Memento(token);
            Tokens.Add(token);

            return memento;
        }

        public Memento AddToken(Token token)
        {
            var memnto = new Memento(token);
            Tokens.Add(token);

            return memnto;
        }

        public void Revert(Memento m)
        {
            var ind = Tokens.IndexOf(m.Token);
            Tokens.RemoveRange(ind+1, Tokens.Count - ind - 1);
        }
    }
}