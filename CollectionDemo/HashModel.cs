using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionDemo
{
    /// <summary>
    /// Hash演示模型
    /// </summary>
    public class HashModel : IEquatable<HashModel>
    {
        /// <summary>
        /// 创建Hash演示模型数组
        /// </summary>
        /// <returns></returns>
        public static List<HashModel> GetHashModels()
            => Enumerable.Range(1, 10).Select(index => new HashModel(index)).ToList();

        public HashModel()
        {
        }

        public HashModel(int index)
        {
            this.Name = $"model_{index}";
            this.Worth = index * 100;
        }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 价值
        /// </summary>
        public int Worth { get; set; }

        /// <summary>
        /// 默认相等比较算法
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(HashModel other)
        {
            bool equals = ReferenceEquals(this, other);
            TraceHelper.WriteLine($"实体相等比较：{this.Name} {(equals ? "=" : "!=")} {other.Name}");

            return equals;
        }

        /// <summary>
        /// 默认Hash计算方法
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = base.GetHashCode();
            TraceHelper.WriteLine($"实体Hash计算：{this.Name} => {hash.ToString("X")}");

            return hash;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"I'm {this.Name}, worth = {this.Worth}";
    }
}
