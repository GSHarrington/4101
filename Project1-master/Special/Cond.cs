// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Cond() { }

        public override void print(Node t, int n, bool p)
        { 
            // TODO: Implement this function.
            Console.Write("".PadLeft(n));
            Console.WriteLine("(cond");
            if (t.getCdr().isPair()) 
            {
                t.getCdr().print(n + 4, p);
            }
            else 
            {
                Console.Error.WriteLine("Syntax error for COND");
            }
            //  Console.Write("".PadLeft(n) + ")");
        }
    }
}


