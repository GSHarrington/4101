// Nil -- Parse tree node class for representing the empty list

using System;

namespace Tree
{
    public class Nil : Node
    {
        //  private static Nil instance;
        //  private Nil() {}

        //  public static Nil Instance
        //  {
        //      get 
        //      { 
        //          if (instance == null)
        //          {
        //              instance = new Nil();
        //          }
        //          return instance;
        //      }
        //  }
        public Nil() { }
  
        public override void print(int n)
        {
            print(n, false);
        }

        public override void print(int n, bool p) {
	    // There got to be a more efficient way to print n spaces.
	    //  for (int i = 0; i < n; i++)
        //          Console.Write(" ");

            if (p)
                Console.Write("".PadLeft(n) + ")");
            else
                Console.Write("".PadLeft(n) + "()");
        }
        public override bool isNull()
        {
            return true;
        }
    }
}
