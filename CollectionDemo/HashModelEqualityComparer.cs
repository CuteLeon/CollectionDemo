using System;
using System.Collections.Generic;

namespace CollectionDemo
{
    /// <summary>
    /// Hash模型相等比较器
    /// </summary>
    public class HashModelEqualityComparer : IEqualityComparer<HashModel>
    {
        /// <summary>
        /// 自定义相等比较方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(HashModel x, HashModel y)
        {
            bool equals = string.Equals(x?.Name, y.Name, StringComparison.OrdinalIgnoreCase);
            TraceHelper.WriteLine($"自定义相等比较器相等比较：{x.Name} {(equals ? "=" : "!=")} {y.Name}");

            return equals;
        }

        /// <summary>
        /// 自定义Hash计算方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(HashModel obj)
        {
            int hash = obj.Name.GetHashCode();
            TraceHelper.WriteLine($"自定义相等比较器Hash计算：{obj.Name} => {hash.ToString("X")}");

            return hash;
        }
    }
}
