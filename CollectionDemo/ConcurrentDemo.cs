using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionDemo
{
    public class ConcurrentDemo : IDemo
    {
        public void Run()
        {
            var models = HashModel.GetHashModels();
            object lockSeed = new object();

            TraceHelper.WriteLine("同步字典：");
            Dictionary<string, HashModel> dictionary = new Dictionary<string, HashModel>();
            TraceHelper.WriteLine(">>>并发写入：");
            Parallel.ForEach(
                models,
                (model) =>
                {
                    lock (lockSeed)
                    {
                        dictionary.Add(model.Name, model);
                    }
                });
            TraceHelper.WriteLine($">>>dictionary：共 {dictionary.Count} 个元素\n\t{string.Join("\n\t", dictionary.Select(model => model.ToString()))}");
            dictionary.Clear();

            TraceHelper.WriteHr();
            TraceHelper.WriteLine("并发字典：");
            ConcurrentDictionary<string, HashModel> concurrentDictionary = new ConcurrentDictionary<string, HashModel>();
            Parallel.ForEach(
                models,
                (model) =>
                {
                    concurrentDictionary.TryAdd(model.Name, model);
                });
            TraceHelper.WriteLine($">>>concurrentDictionary：共 {concurrentDictionary.Count} 个元素\n\t{string.Join("\n\t", concurrentDictionary.Select(model => model.ToString()))}");
            concurrentDictionary.Clear();

            TraceHelper.WriteHr();
            TraceHelper.WriteLine(">>>写入字典性能测试：");
            Stopwatch stopwatch = new Stopwatch();
            int count = 5000000;

            stopwatch.Start();
            Parallel.For(0, count, (index) =>
             {
                 var model = new HashModel(index);
                 lock (lockSeed)
                 {
                     dictionary.Add(model.Name, model);
                 }
             });
            stopwatch.Stop();
            TraceHelper.WriteLine($"同步字典并发写入 {count} 次，耗时：{stopwatch.ElapsedMilliseconds.ToString("N")} 毫秒");

            stopwatch.Reset();
            stopwatch.Start();
            Parallel.For(0, count, (index) =>
            {
                var model = new HashModel(index);
                concurrentDictionary.TryAdd(model.Name, model);
            });
            stopwatch.Stop();
            TraceHelper.WriteLine($"并发字典并发写入 {count} 次，耗时：{stopwatch.ElapsedMilliseconds.ToString("N")} 毫秒");

            TraceHelper.WriteHr();
            TraceHelper.WriteLine(">>>读取字典性能测试：");

            stopwatch.Reset();
            stopwatch.Start();
            Parallel.For(0, count, (index) =>
            {
                lock (lockSeed)
                {
                    dictionary.TryGetValue($"model_{index}", out _);
                }
            });
            stopwatch.Stop();
            TraceHelper.WriteLine($"同步字典并发读取 {count} 次，耗时：{stopwatch.ElapsedMilliseconds.ToString("N")} 毫秒");

            stopwatch.Reset();
            stopwatch.Start();
            Parallel.For(0, count, (index) =>
            {
                concurrentDictionary.TryGetValue($"model_{index}", out _);
            });
            stopwatch.Stop();
            TraceHelper.WriteLine($"并发字典并发读取 {count} 次，耗时：{stopwatch.ElapsedMilliseconds.ToString("N")} 毫秒");

            TraceHelper.WriteHr();
        }
    }
}
