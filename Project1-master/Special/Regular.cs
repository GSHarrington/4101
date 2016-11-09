// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        // TODO: Add any fields needed.
    
        // TODO: Add an appropriate constructor.
        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            //  Console.Write("".PadLeft(n));
            if (!p)
            {
                Console.Write("".PadLeft(n) + '(');
            }
            t.getCar().print(0, !p);
            //  if(!t.getCdr().isNull())
            //  {
            //      Console.Write(" ");
            //  }
            if(t.getCdr().isNull())
            {
                t.getCdr().print(0, true);
                //  Console.WriteLine();
            }
            else {
                Console.Write(" ");
                t.getCdr().print(n, true);
            }
            
            //  if(t.getCdr().isNull())
            //  {
            //      Console.WriteLine();
            //  }
        }
    }
}


