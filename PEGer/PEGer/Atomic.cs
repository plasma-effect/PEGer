using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Linq.Enumerable;

namespace PEGer
{
    public class Atomic : IExpression<string>
    {
        public Atomic(Func<char, bool> initCheck, Func<char, bool> loopCheck)
        {
            this.InitCheck = initCheck;
            this.LoopCheck = loopCheck;
        }

        Func<char, bool> InitCheck { get; }
        Func<char, bool> LoopCheck { get; }
        public string Parse(string line, ref int index)
        {
            if (!this.InitCheck(line[index]))
            {
                return null;
            }
            var start = index;
            for (++index; index < line.Length; ++index)
            {
                if (!this.LoopCheck(line[index]))
                {
                    break;
                }
            }
            return line.Substring(start, index - start);
        }
    }
    public class Letters : Atomic
    {
        static bool Check(char c)
        {
            if (c == '_')
            {
                return true;
            }
            else
            {
                return char.IsLetter(c);
            }
        }
        public Letters() : base(Check, Check)
        {

        }
    }
    public class Numbers : Atomic
    {
        public Numbers() : base(char.IsDigit, char.IsDigit)
        {

        }
    }
    public class Name : Atomic
    {
        static bool InitCheck(char c)
        {
            if (c == '_')
            {
                return true;
            }
            else
            {
                return char.IsLetter(c);
            }
        }
        static bool LoopCheck(char c)
        {
            if (c == '_')
            {
                return true;
            }
            else
            {
                return char.IsLetterOrDigit(c);
            }
        }
        public Name() : base(InitCheck, LoopCheck)
        {

        }
    }
    public class Char : IExpression<string>
    {
        readonly char[] candidate;

        public Char(params char[] candidate)
        {
            this.candidate = candidate;
        }

        public string Parse(string line, ref int index)
        {
            if (this.candidate.Contains(line[index]))
            {
                var ret = line.Substring(index, 1);
                ++index;
                return ret;
            }
            else
            {
                return null;
            }
        }
    }
    public class RepeatChars : Atomic
    {
        public RepeatChars(params char[] candidate) : base(candidate.Contains, candidate.Contains)
        {

        }
    }
    public class KeyWord : IExpression<string>
    {
        string str;

        public KeyWord(string str)
        {
            this.str = str;
        }

        public string Parse(string line, ref int index)
        {
            if (this.str.Length + index > line.Length)
            {
                return null;
            }
            foreach (var i in Range(0, this.str.Length))
            {
                if (this.str[i] != line[i + index])
                {
                    return null;
                }
            }
            index += this.str.Length;
            return this.str;
        }
    }

}
