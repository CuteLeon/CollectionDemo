using System.Collections.Generic;
using System.Linq;

namespace CollectionDemo
{
    public class HashDemo : IDemo
    {
        public void Run()
        {
            var models = HashModel.GetHashModels();

            TraceHelper.WriteLine("实体相等比较：");
            HashSet<HashModel> defaultHashset = new HashSet<HashModel>(models);

            TraceHelper.WriteLine(">>>增加相同名称的不同实例：");
            defaultHashset.Add(new HashModel() { Name = models.First().Name });

            TraceHelper.WriteLine(">>>增加已经存在相同实例：");
            defaultHashset.Add(models.First());

            TraceHelper.WriteLine($">>>defaultHashset：共 {defaultHashset.Count} 个元素\n\t{string.Join("\n\t", defaultHashset.Select(model => model.ToString()))}");

            TraceHelper.WriteHr();
            TraceHelper.WriteLine("自定义相等比较器：");
            HashSet<HashModel> customeHashset = new HashSet<HashModel>(models, new HashModelEqualityComparer());

            TraceHelper.WriteLine(">>>增加相同名称的不同实例：");
            customeHashset.Add(new HashModel() { Name = models.First().Name });

            TraceHelper.WriteLine(">>>增加已经存在相同实例：");
            customeHashset.Add(models.First());

            TraceHelper.WriteLine($">>>customeHashset：共 {customeHashset.Count} 个元素\n\t{string.Join("\n\t", customeHashset.Select(model => model.ToString()))}");
            TraceHelper.WriteHr();
        }
    }
}
