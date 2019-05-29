using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEGer
{
    public interface IVariable<T> : IExpression<T>
       where T : class
    {

    }
    public class RepeatVariable<R> : IVariable<List<R>>
        where R : class
    {
        IExpression<R> expr;
        int min;
        bool spaceIgnore;
        public RepeatVariable(IExpression<R> expr, int min = 0, bool spaceIgnore = true)
        {
            this.expr = expr;
            this.min = min;
            this.spaceIgnore = spaceIgnore;
        }

        public List<R> Parse(string line, ref int index)
        {
            var ret = new List<R>();
            while (index != line.Length)
            {
                if (this.spaceIgnore)
                {
                    while (index != line.Length && char.IsWhiteSpace(line[index]))
                    {
                        ++index;
                    }
                    if (index == line.Length)
                    {
                        break;
                    }
                }
                var dummy = index;
                var val = this.expr.Parse(line, ref dummy);
                if (val is null)
                {
                    break;
                }
                ret.Add(val);
                index = dummy;
            }
            return ret.Count < this.min ? null : ret;
        }
    }

    public class SequenceVariable<P0, T0, R> : IVariable<R>
        where P0 : IExpression<T0>
        where T0 : class
        where R : class
    {
        P0 expr0;
        Func<T0, R> func;
        bool spaceIgnore;
        void SpaceIgnore(string line, ref int index)
        {
            if (this.spaceIgnore)
            {
                while (line.Length != index)
                {
                    if (!char.IsWhiteSpace(line[index]))
                    {
                        break;
                    }
                    ++index;
                }
            }
        }
        public SequenceVariable(P0 expr0, Func<T0, R> func, bool spaceIgnore)
        {
            this.expr0 = expr0;
            this.func = func;
            this.spaceIgnore = spaceIgnore;
        }

        public R Parse(string line, ref int index)
        {
            SpaceIgnore(line, ref index);
            var val0 = this.expr0.Parse(line, ref index);
            if (val0 is null)
            {
                return null;
            }
            return this.func(val0);
        }
    }
    public class SequenceVariable<P0, T0, P1, T1, R> : IVariable<R>
    where P0 : IExpression<T0>
where T0 : class
where P1 : IExpression<T1>
where T1 : class
    where R : class
    {
        P0 expr0; P1 expr1;
        Func<T0, T1, R> func;
        bool spaceIgnore;
        void SpaceIgnore(string line, ref int index)
        {
            if (this.spaceIgnore)
            {
                while (line.Length != index)
                {
                    if (!char.IsWhiteSpace(line[index]))
                    {
                        break;
                    }
                    ++index;
                }
            }
        }
        public SequenceVariable(P0 expr0, P1 expr1, Func<T0, T1, R> func, bool spaceIgnore)
        {
            this.expr0 = expr0;
            this.expr1 = expr1;

            this.func = func;
            this.spaceIgnore = spaceIgnore;
        }

        public R Parse(string line, ref int index)
        {
            SpaceIgnore(line, ref index);
            var val0 = this.expr0.Parse(line, ref index);
            if (val0 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val1 = this.expr1.Parse(line, ref index);
            if (val1 is null)
            {
                return null;
            }

            return this.func(val0, val1);
        }
    }
    public class SequenceVariable<P0, T0, P1, T1, P2, T2, R> : IVariable<R>
        where P0 : IExpression<T0>
where T0 : class
where P1 : IExpression<T1>
where T1 : class
where P2 : IExpression<T2>
where T2 : class
        where R : class
    {
        P0 expr0; P1 expr1; P2 expr2;
        Func<T0, T1, T2, R> func;
        bool spaceIgnore;
        void SpaceIgnore(string line, ref int index)
        {
            if (this.spaceIgnore)
            {
                while (line.Length != index)
                {
                    if (!char.IsWhiteSpace(line[index]))
                    {
                        break;
                    }
                    ++index;
                }
            }
        }
        public SequenceVariable(P0 expr0, P1 expr1, P2 expr2, Func<T0, T1, T2, R> func, bool spaceIgnore)
        {
            this.expr0 = expr0;
            this.expr1 = expr1;
            this.expr2 = expr2;

            this.func = func;
            this.spaceIgnore = spaceIgnore;
        }

        public R Parse(string line, ref int index)
        {
            SpaceIgnore(line, ref index);
            var val0 = this.expr0.Parse(line, ref index);
            if (val0 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val1 = this.expr1.Parse(line, ref index);
            if (val1 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val2 = this.expr2.Parse(line, ref index);
            if (val2 is null)
            {
                return null;
            }

            return this.func(val0, val1, val2);
        }
    }
    public class SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, R> : IVariable<R>
        where P0 : IExpression<T0>
where T0 : class
where P1 : IExpression<T1>
where T1 : class
where P2 : IExpression<T2>
where T2 : class
where P3 : IExpression<T3>
where T3 : class
        where R : class
    {
        P0 expr0; P1 expr1; P2 expr2; P3 expr3;
        Func<T0, T1, T2, T3, R> func;
        bool spaceIgnore;
        void SpaceIgnore(string line, ref int index)
        {
            if (this.spaceIgnore)
            {
                while (line.Length != index)
                {
                    if (!char.IsWhiteSpace(line[index]))
                    {
                        break;
                    }
                    ++index;
                }
            }
        }
        public SequenceVariable(P0 expr0, P1 expr1, P2 expr2, P3 expr3, Func<T0, T1, T2, T3, R> func, bool spaceIgnore)
        {
            this.expr0 = expr0;
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;

            this.func = func;
            this.spaceIgnore = spaceIgnore;
        }

        public R Parse(string line, ref int index)
        {
            SpaceIgnore(line, ref index);
            var val0 = this.expr0.Parse(line, ref index);
            if (val0 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val1 = this.expr1.Parse(line, ref index);
            if (val1 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val2 = this.expr2.Parse(line, ref index);
            if (val2 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val3 = this.expr3.Parse(line, ref index);
            if (val3 is null)
            {
                return null;
            }

            return this.func(val0, val1, val2, val3);
        }
    }
    public class SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, R> : IVariable<R>
        where P0 : IExpression<T0>
where T0 : class
where P1 : IExpression<T1>
where T1 : class
where P2 : IExpression<T2>
where T2 : class
where P3 : IExpression<T3>
where T3 : class
where P4 : IExpression<T4>
where T4 : class
        where R : class
    {
        P0 expr0; P1 expr1; P2 expr2; P3 expr3; P4 expr4;
        Func<T0, T1, T2, T3, T4, R> func;
        bool spaceIgnore;
        void SpaceIgnore(string line, ref int index)
        {
            if (this.spaceIgnore)
            {
                while (line.Length != index)
                {
                    if (!char.IsWhiteSpace(line[index]))
                    {
                        break;
                    }
                    ++index;
                }
            }
        }
        public SequenceVariable(P0 expr0, P1 expr1, P2 expr2, P3 expr3, P4 expr4, Func<T0, T1, T2, T3, T4, R> func, bool spaceIgnore)
        {
            this.expr0 = expr0;
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;

            this.func = func;
            this.spaceIgnore = spaceIgnore;
        }

        public R Parse(string line, ref int index)
        {
            SpaceIgnore(line, ref index);
            var val0 = this.expr0.Parse(line, ref index);
            if (val0 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val1 = this.expr1.Parse(line, ref index);
            if (val1 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val2 = this.expr2.Parse(line, ref index);
            if (val2 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val3 = this.expr3.Parse(line, ref index);
            if (val3 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val4 = this.expr4.Parse(line, ref index);
            if (val4 is null)
            {
                return null;
            }

            return this.func(val0, val1, val2, val3, val4);
        }
    }
    public class SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, R> : IVariable<R>
        where P0 : IExpression<T0>
where T0 : class
where P1 : IExpression<T1>
where T1 : class
where P2 : IExpression<T2>
where T2 : class
where P3 : IExpression<T3>
where T3 : class
where P4 : IExpression<T4>
where T4 : class
where P5 : IExpression<T5>
where T5 : class
        where R : class
    {
        P0 expr0; P1 expr1; P2 expr2; P3 expr3; P4 expr4; P5 expr5;
        Func<T0, T1, T2, T3, T4, T5, R> func;
        bool spaceIgnore;
        void SpaceIgnore(string line, ref int index)
        {
            if (this.spaceIgnore)
            {
                while (line.Length != index)
                {
                    if (!char.IsWhiteSpace(line[index]))
                    {
                        break;
                    }
                    ++index;
                }
            }
        }
        public SequenceVariable(P0 expr0, P1 expr1, P2 expr2, P3 expr3, P4 expr4, P5 expr5, Func<T0, T1, T2, T3, T4, T5, R> func, bool spaceIgnore)
        {
            this.expr0 = expr0;
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;

            this.func = func;
            this.spaceIgnore = spaceIgnore;
        }

        public R Parse(string line, ref int index)
        {
            SpaceIgnore(line, ref index);
            var val0 = this.expr0.Parse(line, ref index);
            if (val0 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val1 = this.expr1.Parse(line, ref index);
            if (val1 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val2 = this.expr2.Parse(line, ref index);
            if (val2 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val3 = this.expr3.Parse(line, ref index);
            if (val3 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val4 = this.expr4.Parse(line, ref index);
            if (val4 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val5 = this.expr5.Parse(line, ref index);
            if (val5 is null)
            {
                return null;
            }

            return this.func(val0, val1, val2, val3, val4, val5);
        }
    }
    public class SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, R> : IVariable<R>
        where P0 : IExpression<T0>
where T0 : class
where P1 : IExpression<T1>
where T1 : class
where P2 : IExpression<T2>
where T2 : class
where P3 : IExpression<T3>
where T3 : class
where P4 : IExpression<T4>
where T4 : class
where P5 : IExpression<T5>
where T5 : class
where P6 : IExpression<T6>
where T6 : class
        where R : class
    {
        P0 expr0; P1 expr1; P2 expr2; P3 expr3; P4 expr4; P5 expr5; P6 expr6;
        Func<T0, T1, T2, T3, T4, T5, T6, R> func;
        bool spaceIgnore;
        void SpaceIgnore(string line, ref int index)
        {
            if (this.spaceIgnore)
            {
                while (line.Length != index)
                {
                    if (!char.IsWhiteSpace(line[index]))
                    {
                        break;
                    }
                    ++index;
                }
            }
        }
        public SequenceVariable(P0 expr0, P1 expr1, P2 expr2, P3 expr3, P4 expr4, P5 expr5, P6 expr6, Func<T0, T1, T2, T3, T4, T5, T6, R> func, bool spaceIgnore)
        {
            this.expr0 = expr0;
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;

            this.func = func;
            this.spaceIgnore = spaceIgnore;
        }

        public R Parse(string line, ref int index)
        {
            SpaceIgnore(line, ref index);
            var val0 = this.expr0.Parse(line, ref index);
            if (val0 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val1 = this.expr1.Parse(line, ref index);
            if (val1 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val2 = this.expr2.Parse(line, ref index);
            if (val2 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val3 = this.expr3.Parse(line, ref index);
            if (val3 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val4 = this.expr4.Parse(line, ref index);
            if (val4 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val5 = this.expr5.Parse(line, ref index);
            if (val5 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val6 = this.expr6.Parse(line, ref index);
            if (val6 is null)
            {
                return null;
            }

            return this.func(val0, val1, val2, val3, val4, val5, val6);
        }
    }
    public class SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, P7, T7, R> : IVariable<R>
        where P0 : IExpression<T0>
where T0 : class
where P1 : IExpression<T1>
where T1 : class
where P2 : IExpression<T2>
where T2 : class
where P3 : IExpression<T3>
where T3 : class
where P4 : IExpression<T4>
where T4 : class
where P5 : IExpression<T5>
where T5 : class
where P6 : IExpression<T6>
where T6 : class
where P7 : IExpression<T7>
where T7 : class
        where R : class
    {
        P0 expr0; P1 expr1; P2 expr2; P3 expr3; P4 expr4; P5 expr5; P6 expr6; P7 expr7;
        Func<T0, T1, T2, T3, T4, T5, T6, T7, R> func;
        bool spaceIgnore;
        void SpaceIgnore(string line, ref int index)
        {
            if (this.spaceIgnore)
            {
                while (line.Length != index)
                {
                    if (!char.IsWhiteSpace(line[index]))
                    {
                        break;
                    }
                    ++index;
                }
            }
        }
        public SequenceVariable(P0 expr0, P1 expr1, P2 expr2, P3 expr3, P4 expr4, P5 expr5, P6 expr6, P7 expr7, Func<T0, T1, T2, T3, T4, T5, T6, T7, R> func, bool spaceIgnore)
        {
            this.expr0 = expr0;
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;

            this.func = func;
            this.spaceIgnore = spaceIgnore;
        }

        public R Parse(string line, ref int index)
        {
            SpaceIgnore(line, ref index);
            var val0 = this.expr0.Parse(line, ref index);
            if (val0 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val1 = this.expr1.Parse(line, ref index);
            if (val1 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val2 = this.expr2.Parse(line, ref index);
            if (val2 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val3 = this.expr3.Parse(line, ref index);
            if (val3 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val4 = this.expr4.Parse(line, ref index);
            if (val4 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val5 = this.expr5.Parse(line, ref index);
            if (val5 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val6 = this.expr6.Parse(line, ref index);
            if (val6 is null)
            {
                return null;
            }
            SpaceIgnore(line, ref index);
            var val7 = this.expr7.Parse(line, ref index);
            if (val7 is null)
            {
                return null;
            }

            return this.func(val0, val1, val2, val3, val4, val5, val6, val7);
        }
    }

    public static class Sequence
    {
        public static SequenceVariable<P0, T0, R> Create<P0, T0, R>(P0 expr0, Func<T0, R> func, bool spaceIgnore = true)
            where P0 : IExpression<T0>
            where T0 : class
            where R : class
        {
            return new SequenceVariable<P0, T0, R>(expr0, func, spaceIgnore);
        }
        public static SequenceVariable<P0, T0, P1, T1, R> Create<P0, T0, P1, T1, R>(P0 expr0, P1 expr1, Func<T0, T1, R> func, bool spaceIgnore = true)
            where P0 : IExpression<T0>
            where T0 : class
            where P1 : IExpression<T1>
            where T1 : class
            where R : class
        {
            return new SequenceVariable<P0, T0, P1, T1, R>(expr0, expr1, func, spaceIgnore);
        }
        public static SequenceVariable<P0, T0, P1, T1, P2, T2, R> Create<P0, T0, P1, T1, P2, T2, R>(P0 expr0, P1 expr1, P2 expr2, Func<T0, T1, T2, R> func, bool spaceIgnore = true)
        where P0 : IExpression<T0>
        where T0 : class
        where P1 : IExpression<T1>
        where T1 : class
        where P2 : IExpression<T2>
        where T2 : class
        where R : class
        {
            return new SequenceVariable<P0, T0, P1, T1, P2, T2, R>(expr0, expr1, expr2, func, spaceIgnore);
        }
        public static SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, R> Create<P0, T0, P1, T1, P2, T2, P3, T3, R>(P0 expr0, P1 expr1, P2 expr2, P3 expr3, Func<T0, T1, T2, T3, R> func, bool spaceIgnore = true)
        where P0 : IExpression<T0>
        where T0 : class
        where P1 : IExpression<T1>
        where T1 : class
        where P2 : IExpression<T2>
        where T2 : class
        where P3 : IExpression<T3>
        where T3 : class
        where R : class
        {
            return new SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, R>(expr0, expr1, expr2, expr3, func, spaceIgnore);
        }
        public static SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, R> Create<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, R>(P0 expr0, P1 expr1, P2 expr2, P3 expr3, P4 expr4, Func<T0, T1, T2, T3, T4, R> func, bool spaceIgnore = true)
        where P0 : IExpression<T0>
        where T0 : class
        where P1 : IExpression<T1>
        where T1 : class
        where P2 : IExpression<T2>
        where T2 : class
        where P3 : IExpression<T3>
        where T3 : class
        where P4 : IExpression<T4>
        where T4 : class
        where R : class
        {
            return new SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, R>(expr0, expr1, expr2, expr3, expr4, func, spaceIgnore);
        }
        public static SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, R> Create<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, R>(P0 expr0, P1 expr1, P2 expr2, P3 expr3, P4 expr4, P5 expr5, Func<T0, T1, T2, T3, T4, T5, R> func, bool spaceIgnore = true)
        where P0 : IExpression<T0>
        where T0 : class
        where P1 : IExpression<T1>
        where T1 : class
        where P2 : IExpression<T2>
        where T2 : class
        where P3 : IExpression<T3>
        where T3 : class
        where P4 : IExpression<T4>
        where T4 : class
        where P5 : IExpression<T5>
        where T5 : class
        where R : class
        {
            return new SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, R>(expr0, expr1, expr2, expr3, expr4, expr5, func, spaceIgnore);
        }
        public static SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, R> Create<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, R>(P0 expr0, P1 expr1, P2 expr2, P3 expr3, P4 expr4, P5 expr5, P6 expr6, Func<T0, T1, T2, T3, T4, T5, T6, R> func, bool spaceIgnore = true)
        where P0 : IExpression<T0>
        where T0 : class
        where P1 : IExpression<T1>
        where T1 : class
        where P2 : IExpression<T2>
        where T2 : class
        where P3 : IExpression<T3>
        where T3 : class
        where P4 : IExpression<T4>
        where T4 : class
        where P5 : IExpression<T5>
        where T5 : class
        where P6 : IExpression<T6>
        where T6 : class
        where R : class
        {
            return new SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, R>(expr0, expr1, expr2, expr3, expr4, expr5, expr6, func, spaceIgnore);
        }
        public static SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, P7, T7, R> Create<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, P7, T7, R>(P0 expr0, P1 expr1, P2 expr2, P3 expr3, P4 expr4, P5 expr5, P6 expr6, P7 expr7, Func<T0, T1, T2, T3, T4, T5, T6, T7, R> func, bool spaceIgnore = true)
        where P0 : IExpression<T0>
        where T0 : class
        where P1 : IExpression<T1>
        where T1 : class
        where P2 : IExpression<T2>
        where T2 : class
        where P3 : IExpression<T3>
        where T3 : class
        where P4 : IExpression<T4>
        where T4 : class
        where P5 : IExpression<T5>
        where T5 : class
        where P6 : IExpression<T6>
        where T6 : class
        where P7 : IExpression<T7>
        where T7 : class
        where R : class
        {
            return new SequenceVariable<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, P7, T7, R>(expr0, expr1, expr2, expr3, expr4, expr5, expr6, expr7, func, spaceIgnore);
        }
    }
}
