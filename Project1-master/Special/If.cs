// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public If() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            Console.Write("".PadLeft(n));
            Console.Write("(if ");
            
            Node ifStart = t.getCdr().getCar();
            if(ifStart.isPair())
            {
                ifStart.print(0, p);
            }
            else 
            {
                Console.Error.Write("Syntax error with IF start");
            }
            
            Console.WriteLine();
            
            Node thenStart = t.getCdr().getCdr().getCar();
            if( !thenStart.isNull())
            {
                thenStart.print(n+4, p);
            }
            else
            {
                Console.Error.Write("Syntax error with THEN start");
            }
            
            Console.WriteLine();
            
            Node elseStart = t.getCdr().getCdr().getCdr().getCar();
            if( !thenStart.isNull())
            {
                Console.Write("".PadLeft(n+4));
                elseStart.print(0, p);
            }
            else
            {
                Console.Error.Write("Syntax error with ELSE start");
            }
            Console.WriteLine();
            Console.WriteLine("".PadLeft(n) + ")");
        }
    }
}

