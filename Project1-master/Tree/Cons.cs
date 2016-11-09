// Cons -- Parse tree node class for representing a Cons node

using System;

namespace Tree
{
    public class Cons : Node
    {
        private Node car;
        private Node cdr;
        private Special form;
    
        public Cons(Node a, Node d)
        {
            car = a;
            cdr = d;
            parseList();
        }
    
        // parseList() `parses' special forms, constructs an appropriate
        // object of a subclass of Special, and stores a pointer to that
        // object in variable form.  It would be possible to fully parse
        // special forms at this point.  Since this causes complications
        // when using (incorrect) programs as data, it is easiest to let
        // parseList only look at the car for selecting the appropriate
        // object from the Special hierarchy and to leave the rest of
        // parsing up to the interpreter.
        void parseList()
        {
            // TODO: implement this function and any helper functions
            // you might need.
            if(car.isSymbol())
            {
                switch(car.getName())
                {
                    case "\'":
                        form = new Quote();
                        break;
                    case "lambda":
                        form = new Lambda();
                        break;
                    case "begin":
                        form = new Begin();
                        break;
                    case "if":
                        form = new If();
                        break;
                    case "let":
                        form = new Let();
                        break;
                    case "cond":
                        form = new Cond();
                        break;
                    case "define":
                        form = new Define();
                        break;
                    case "set!":
                        form = new Set();
                        break;
                    default:
                        form = new Regular();
                        break;
                } 
            }
            else 
            {
                form = new Regular();
            }
        }
 
        public override void print(int n)
        {
            form.print(this, n, false);
        }

        public override void print(int n, bool p)
        {
            form.print(this, n, p);
        }
        
        public override bool isPair()
        {
            return true;
        }
        
        public override Node getCar() 
        {
            if (car != null) 
            {
                return this.car;
            }
            else {
                //REPORT ERROR
                Console.Error.WriteLine("Unexpected null in car of a cons node");
                return null; 
            }
            
        }
        
        public override Node getCdr() 
        {
            if (car != null) 
            {
                return this.cdr;
            }
            else {
                //REPORT ERROR
                Console.Error.WriteLine("Unexpected null in car of a cons node");
                return null; 
            }
        }
            
    }
}

