using System;

namespace CollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IDemo hashDemo = new HashDemo();
            hashDemo.Run();
            Console.Read();

            IDemo concurrentDemo = new ConcurrentDemo();
            concurrentDemo.Run();

            Console.Read();
        }
    }
}
