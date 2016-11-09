// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            Console.Write("".PadLeft(n));
            Console.WriteLine("(begin");
            if (t.getCdr().isPair()) 
            {
                t.getCdr().print(n + 4, p);
            }
            else 
            {
                Console.Error.WriteLine("Syntax error for BEGIN");
            }
            Console.WriteLine();
            //  Console.Write("".PadLeft(n) + ")");
        }
    }
}

