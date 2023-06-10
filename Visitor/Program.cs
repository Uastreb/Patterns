using System.Text;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public abstract class ExpressionVisitor
    {
        public abstract void Visit(Value value);

        public abstract void Visit(AdditionExpression ae);

        public abstract void Visit(MultiplicationExpression me);

        public abstract string ToString();
    }

    public abstract class Expression
    {
        public abstract void Accept(ExpressionVisitor ev);
    }

    public class Value : Expression
    {
        public readonly int TheValue;

        public Value(int value)
        {
            TheValue = value;
        }

        public override void Accept(ExpressionVisitor ev)
        {
            ev.Visit(this);
        }
    }

    public class AdditionExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public AdditionExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Accept(ExpressionVisitor ev)
        {
            ev.Visit(this);
        }
    }

    public class MultiplicationExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public MultiplicationExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Accept(ExpressionVisitor ev)
        {
            ev.Visit(this);
        }
    }

    public class ExpressionPrinter : ExpressionVisitor
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public override void Visit(Value value)
        {
            _sb.Append(value.TheValue);
        }

        public override void Visit(AdditionExpression ae)
        {
            _sb.Append("(");
            ae.LHS.Accept(this);
            _sb.Append("+");
            ae.RHS.Accept(this);
            _sb.Append(")");
        }

        public override void Visit(MultiplicationExpression me)
        {
            _sb.Append("(");
            me.LHS.Accept(this);
            _sb.Append("*");
            me.RHS.Accept(this);
            _sb.Append(")");
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}