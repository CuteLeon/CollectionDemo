using System;

namespace CollectionDemo
{
    public static class TraceHelper
    {
        private static Lazy<ITracer> tracer = new Lazy<ITracer>(new Tracer());

        public static void WriteLine(string message)
            => tracer?.Value.WriteLine(message);

        public static void WriteEmptyLine()
            => tracer?.Value.WriteLine(string.Empty);

        public static void WriteHr()
            => tracer?.Value.WriteLine("<<<—————— 分割线 ——————>>>");
    }
}
