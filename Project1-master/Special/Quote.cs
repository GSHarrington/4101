// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {
        // TODO: Add any fields needed.
  
        // TODO: Add an appropriate constructor.
	public Quote() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            Console.Write("".PadLeft(n));
            Console.Write("\'(");
            Node quote = t.getCdr();
            //  Console.WriteLine(quote);
            if (quote is Nil)
            {
                Console.Write("");
            }
            else
            {
                t.getCdr().print(0, true);
            }
            Console.WriteLine();
        }
    }
}

