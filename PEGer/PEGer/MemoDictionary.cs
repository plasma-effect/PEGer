//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace PEGer
{
    internal class MemoDictionary
    {
        SortedDictionary<int, SortedDictionary<int, (int Index, Expected<object, ParsingException> Value)>> memo;
        public bool TryGet(int dim0, int dim1, out int index, out Expected<object, ParsingException> value)
        {
            if (this.memo.ContainsKey(dim0) && this.memo[dim0].ContainsKey(dim1))
            {
                (index, value) = this.memo[dim0][dim1];
                return true;
            }
            else
            {
                (index, value) = (-1, default);
                return false;
            }
        }
        public void Add(int dim0, int dim1, int index, Expected<object,ParsingException> value)
        {
            if (!this.memo.ContainsKey(dim0))
            {
                this.memo[dim0] = new SortedDictionary<int, (int Index, Expected<object, ParsingException> Value)>();
            }
            this.memo[dim0][dim1] = (index, value);
        }

        public MemoDictionary()
        {
            this.memo = new SortedDictionary<int, SortedDictionary<int, (int Index, Expected<object, ParsingException> Value)>>();
        }
    }
}
