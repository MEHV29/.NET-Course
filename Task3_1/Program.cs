using System.Collections;
using System.Numerics;

namespace Task3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            Console.WriteLine(queue.ToString());
            Console.WriteLine($"Is an empty queue?: {queue.IsEmpty()}");
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine($"Is an empty queue?: {queue.IsEmpty()}");

            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            Console.WriteLine(queue.ToString());
            Queue<int> tail = queue.Tail();
            Console.WriteLine(tail.ToString());

            Queue<string> queue2 = new Queue<string>(3);
            queue2.Enqueue("Hello");
            queue2.Enqueue("World");
            Console.WriteLine(queue2.ToString());
            Console.WriteLine($"Is an empty queue?: {queue2.IsEmpty()}");
            queue2.Dequeue();
            queue2.Dequeue();
            Console.WriteLine($"Is an empty queue?: {queue2.IsEmpty()}");

            queue2.Enqueue("Hello2");
            queue2.Enqueue("World2");
            queue2.Enqueue("World5");
            Console.WriteLine(queue2.ToString());
            Queue<string> tail2 = queue2.Tail();
            Console.WriteLine(tail2.ToString());
        }
    }
}