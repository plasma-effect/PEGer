//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;

namespace PEGer
{
    internal class MemoDictionary
    {
        SortedDictionary<int, object> memo;
        public bool TryGet<T>(int dim0, int dim1, out int index, out T ret)
        {
            if (this.memo.ContainsKey(dim0) &&
                this.memo[dim0] is SortedDictionary<int, (int, T)> dict &&
                dict.ContainsKey(dim1))
            {
                var (i, r) = dict[dim1];
                index = i;
                ret = r;
                return true;
            }
            else
            {
                index = -1;
                ret = default;
                return false;
            }
        }
        public void Add<T>(int dim0, int dim1, int index, T value)
        {
            if (!this.memo.ContainsKey(dim0))
            {
                this.memo[dim0] = new SortedDictionary<int, (int, T)>();
            }
            if (this.memo[dim0] is SortedDictionary<int, (int, T)> dict)
            {
                dict[dim1] = (index, value);
            }
        }

        public MemoDictionary()
        {
            this.memo = new SortedDictionary<int, object>();
        }
    }
}
