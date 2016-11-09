// Lambda -- Parse tree node strategy for printing the special form lambda

using System;

namespace Tree
{
    public class Lambda : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Lambda() { }

        public override void print(Node t, int n, bool p)
        {
           Console.Write("".PadLeft(n));
           Console.Write("(lambda");
           
           Node Num2Node = t.getCdr().getCar();
           if (Num2Node.isPair())
           {
             Num2Node.print(0,false);    
           }
           else 
           {
              Console.Error.Write("Syntax Error with Lambda (Num2Node)");
           }
           
           Console.Write("".PadLeft(n));
           
           Node Num3Node = t.getCdr().getCdr().getCar();
           
           if( Num3Node.isPair())
           { 
               Num3Node.print(n+4, false);
           }
           else
           {
               Console.Error.Write("Syntax Error with Lambda (Num3Node)");
           }
           Console.Write("".PadLeft(n));
  	}
    }
}

