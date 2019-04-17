using System;

namespace CollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IDemo hashDemo = new HashDemo();
            hashDemo.Run();

            IDemo concurrentDemo = new ConcurrentDemo();
            concurrentDemo.Run();

            Console.Read();
        }
    }
}
