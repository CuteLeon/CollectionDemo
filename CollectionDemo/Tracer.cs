using System;

namespace CollectionDemo
{
    public class Tracer : ITracer
    {
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="message"></param>
        public void WriteLine(string message)
            => Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")} {message}");
    }
}
