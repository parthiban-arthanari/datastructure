using System;
namespace Sample.Queue
{
    public class QueueDriver
    {
        Queue queue = new Queue(5);

        public QueueDriver()
        {
            Initialize();
        }

        public void Initialize()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
        }

        public void DoOperation()
        {
            while(!queue.IsEmpty())
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
