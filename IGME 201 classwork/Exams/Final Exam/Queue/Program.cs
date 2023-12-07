using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    internal class Program
    {
        // Class: MyQueue
        // Author: Kashaf Ahmed
        // Purpose: Creates a list called queue and has a enqueue method
        // to add a value to the list, a dequeue method to take a value out of a list
        // and if the list has nothing in it we say the queue is empty, otherwise
        // we remove the oldest data from the list. There is also a peek method and if 
        // the list is empty we say the queue is empty, otherwise we return the last value in the
        // list.
        // Restrictions: None
        public class MyQueue
        {
            //create the list
            public List<int?> queue = new List<int?>();

            // Method: Enqueue
            // Author: Kashaf Ahmed
            // Purpose: Adds the value to the start of the list and returns the added value.
            // Restrictions: None
            public int? Enqueue(int? n)
            {
                queue.Insert(0,n);
                return n;
            }

            // Method: Dequeue
            // Author: Kashaf Ahmed
            // Purpose: If the list has nothing in it we say the queue is empty and return -1, otherwise
            // we get the oldest data from the list, remove it from the list, and return the removed value.
            // Restrictions: None
            public int? Dequeue()
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("Queue is empty");
                    return null;
                }

                int? removeItem = queue.Last();
                queue.Remove(removeItem);
                return removeItem;

            }

            // Method: Dequeue
            // Author: Kashaf Ahmed
            // Purpose: If the list has nothing in it then we say the queue is empty,
            // otherwise we return the first value in the list.
            // Restrictions: None
            public int? Peek()
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("Queue is empty"); 
                    return null;
                }

                return queue.First();
            }

        }

        // Method: Main
        // Author: Kashaf Ahmed
        // Purpose: Enqueues 1,2,3,4,5 in the list then dequeues 1,2,3,4, then
        // does the peek method which returns 5 then enqueues 4 and 1, then
        // we dequeue off all of the values and dequeue off the empty list to check
        // as well as peek on the empty list to check.
        // Restrictions: None
        static void Main(string[] args)
        {
            MyQueue queueClass = new MyQueue();
            Console.WriteLine(queueClass.Enqueue(1));
            Console.WriteLine(queueClass.Enqueue(2));
            Console.WriteLine(queueClass.Enqueue(3));
            Console.WriteLine(queueClass.Enqueue(4));
            Console.WriteLine(queueClass.Enqueue(5));
            Console.WriteLine("Dequeued: " + queueClass.Dequeue()); 
            Console.WriteLine("Dequeued: " + queueClass.Dequeue());
            Console.WriteLine("Dequeued: " + queueClass.Dequeue());
            Console.WriteLine("Dequeued: " + queueClass.Dequeue());
            Console.WriteLine(queueClass.Peek()); //5
            Console.WriteLine(queueClass.Enqueue(4)); //4
            Console.WriteLine(queueClass.Enqueue(1)); //1 
            Console.WriteLine("Dequeued: " + queueClass.Dequeue()); //5
            Console.WriteLine("Dequeued: " + queueClass.Dequeue()); //4
            Console.WriteLine("Dequeued: " + queueClass.Dequeue()); //1
            Console.WriteLine("Dequeued: " + queueClass.Dequeue());
            Console.WriteLine(queueClass.Peek());


        }
    }
}
