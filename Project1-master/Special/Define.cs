// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            Console.Write("".PadLeft(n));
            Console.Write("(define ");
            
            Node name = t.getCdr().getCar();
            name.print(n);
            
            Console.Write(" ");
            
            Node definition = t.getCdr().getCdr().getCar();
            if (definition.isNull()) 
            {
                Console.Error.Write("Syntax error with DEFINE-definition");
            }
            else if (definition.isPair())
            {
                Console.WriteLine();
                //  Console.Write("".PadLeft(n+4));
                definition.print(n+4);
            }
            else 
            {
                definition.print(n);
            }
            // made n to 0
            //  Console.WriteLine();
            Console.WriteLine("".PadLeft(n) + ")");
        }
    }
}


