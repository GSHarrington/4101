// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            Console.Write("".PadLeft(n));
            Console.WriteLine("(let");
            Node bindings = t.getCdr().getCar();
            
            if (bindings.isPair()) 
            {
                bindings.print(0,false);
            }
            else 
            {
                Console.Error.WriteLine("Syntax error for LET-BINDINGS");
            }
            
            Console.Write("".PadLeft(n));
            Node body = t.getCdr().getCdr();
            
            if (body.isPair())
            {
                body.print(n+4, true);
            }
            else
            {
                Console.Error.WriteLine("Syntax error for LET-BODY");   
            }
            Console.Write("".PadLeft(n)+ ")");
        }
    }
}


