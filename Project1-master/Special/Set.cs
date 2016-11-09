// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        {
            Console.Write("".PadLeft(n));
           if ( p != true)
           {
               Console.Write("(");
           }
           if(t.getCar().isPair())
           {
               t.getCar().print(0);
           }
           else 
           {
               t.getCar().print(0, true);
           }
           Console.Write(" ");
           
            if(t.getCdr() is Nil)
            {
                Console.WriteLine(")");
            }
            else 
            {
                t.getCdr().print(0, true);
            }
            //  Console.WriteLine();
        }
    }
}

