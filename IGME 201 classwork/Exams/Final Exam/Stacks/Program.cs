using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    internal class Program
    {
        // Class: MyStack
        // Author: Kashaf Ahmed
        // Purpose: Creates a list called stack and has a push method
        // to add a value to the list, a pop method to take a value out of a list
        // and if the list has nothing in it we say the stack is empty, otherwise
        // we remove the last value from the list. There is also a peek method and if 
        // the list is empty we say the stack is empty, otherwise we return the last value in the
        // list.
        // Restrictions: None
        public class MyStack 
        {
            //create the list
            public List<int?> stack = new List<int?>();

            // Method: Push
            // Author: Kashaf Ahmed
            // Purpose: Adds the value to the end of the list and returns the added value.
            // Restrictions: None
            public int? Push(int? n)
            {
               stack.Add(n);
               return n;
            }

            // Method: Pop
            // Author: Kashaf Ahmed
            // Purpose: If the list has nothing in it we say the stack is empty and return -1, otherwise
            // we get the last value of the list, remove it from the list, and return the removed value.
            // Restrictions: None
            public int? Pop()
            {
                if(stack.Count == 0)
                {
                    Console.WriteLine("Stack is empty");
                    return null;
                }

                int? removeItem = stack.Last();
                stack.Remove(removeItem);
                return removeItem;

            }

            // Method: Pop
            // Author: Kashaf Ahmed
            // Purpose: If the list has nothing in it then we say the stack is empty,
            // otherwise we return the last value in the list.
            // Restrictions: None
            public int? Peek()
            {
                if(stack.Count == 0)
                {
                    Console.WriteLine("Stack is empty"); //we can throw an error if the stack is empty or could do int? to return null if there is nothing in the stack**
                    return null;
                }

                return stack.Last();
            }

        }

        // Method: Main
        // Author: Kashaf Ahmed
        // Purpose: Adds 1,2,3,4,5 in the list then pops off 5,4,3,2, then
        // does the peek method which returns 1 then adds 4 and 5, then
        // we pop off all of the values and pop off on an empty list to check
        // as well as peek on the empty list to check.
        // Restrictions: None
        static void Main(string[] args)
        {
            MyStack stackClass = new MyStack();
            Console.WriteLine(stackClass.Push(1));
            Console.WriteLine(stackClass.Push(2));
            Console.WriteLine(stackClass.Push(3));
            Console.WriteLine(stackClass.Push(4));
            Console.WriteLine(stackClass.Push(5));
            Console.WriteLine("Popped: " + stackClass.Pop());
            Console.WriteLine("Popped: " + stackClass.Pop());
            Console.WriteLine("Popped: " + stackClass.Pop());
            Console.WriteLine("Popped: " + stackClass.Pop());
            Console.WriteLine(stackClass.Peek()); //1
            Console.WriteLine(stackClass.Push(4)); //4
            Console.WriteLine(stackClass.Push(5)); //5
            Console.WriteLine("Popped: " + stackClass.Pop());
            Console.WriteLine("Popped: " + stackClass.Pop());
            Console.WriteLine("Popped: " + stackClass.Pop());
            Console.WriteLine("Popped: " + stackClass.Pop());
            Console.WriteLine(stackClass.Peek());


        }
    }
}
