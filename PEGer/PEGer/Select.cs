using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEGer
{
    public class Select<P0, T0, R> : IExpression<R>
        where P0 : IExpression<T0>
        where T0 : class
        where R : class
    {
        P0 expr0;
        Func<T0, R> func0;

        public Select(P0 expr0, Func<T0, R> func0)
        {
            this.expr0 = expr0;
            this.func0 = func0;
        }

        public R Parse(string line, ref int index)
        {
            if (this.expr0.Parse(line, ref index) is T0 val)
            {
                return this.func0(val);
            }
            return null;
        }
    }
    public class Select<P0, T0, P1, T1, R> : IExpression<R>
        where P0 : IExpression<T0>
        where T0 : class
        where P1 : IExpression<T1>
        where T1 : class
        where R : class
    {
        P0 expr0;
        Func<T0, R> func0;
        P1 expr1;
        Func<T1, R> func1;
        public Select(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1)
        {
            this.expr0 = expr0;
            this.func0 = func0;
            this.expr1 = expr1;
            this.func1 = func1;
        }
        public R Parse(string line, ref int index)
        {
            if (this.expr0.Parse(line, ref index) is T0 val0)
            {
                return this.func0(val0);
            }
            if (this.expr1.Parse(line, ref index) is T1 val1)
            {
                return this.func1(val1);
            }
            return null;
        }
    }
    public class Select<P0, T0, P1, T1, P2, T2, R> : IExpression<R>
    where P0 : IExpression<T0>
    where T0 : class
    where P1 : IExpression<T1>
    where T1 : class
    where P2 : IExpression<T2>
    where T2 : class
    where R : class
    {
        P0 expr0;
        Func<T0, R> func0;
        P1 expr1;
        Func<T1, R> func1;
        P2 expr2;
        Func<T2, R> func2;
        public Select(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1, P2 expr2, Func<T2, R> func2)
        {
            this.expr0 = expr0;
            this.func0 = func0;
            this.expr1 = expr1;
            this.func1 = func1;
            this.expr2 = expr2;
            this.func2 = func2;
        }
        public R Parse(string line, ref int index)
        {
            if (this.expr0.Parse(line, ref index) is T0 val0)
            {
                return this.func0(val0);
            }
            if (this.expr1.Parse(line, ref index) is T1 val1)
            {
                return this.func1(val1);
            }
            if (this.expr2.Parse(line, ref index) is T2 val2)
            {
                return this.func2(val2);
            }
            return null;
        }
    }
    public class Select<P0, T0, P1, T1, P2, T2, P3, T3, R> : IExpression<R>
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
        P0 expr0;
        Func<T0, R> func0;
        P1 expr1;
        Func<T1, R> func1;
        P2 expr2;
        Func<T2, R> func2;
        P3 expr3;
        Func<T3, R> func3;
        public Select(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1, P2 expr2, Func<T2, R> func2, P3 expr3, Func<T3, R> func3)
        {
            this.expr0 = expr0;
            this.func0 = func0;
            this.expr1 = expr1;
            this.func1 = func1;
            this.expr2 = expr2;
            this.func2 = func2;
            this.expr3 = expr3;
            this.func3 = func3;
        }
        public R Parse(string line, ref int index)
        {
            if (this.expr0.Parse(line, ref index) is T0 val0)
            {
                return this.func0(val0);
            }
            if (this.expr1.Parse(line, ref index) is T1 val1)
            {
                return this.func1(val1);
            }
            if (this.expr2.Parse(line, ref index) is T2 val2)
            {
                return this.func2(val2);
            }
            if (this.expr3.Parse(line, ref index) is T3 val3)
            {
                return this.func3(val3);
            }
            return null;
        }
    }
    public class Select<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, R> : IExpression<R>
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
        P0 expr0;
        Func<T0, R> func0;
        P1 expr1;
        Func<T1, R> func1;
        P2 expr2;
        Func<T2, R> func2;
        P3 expr3;
        Func<T3, R> func3;
        P4 expr4;
        Func<T4, R> func4;
        public Select(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1, P2 expr2, Func<T2, R> func2, P3 expr3, Func<T3, R> func3, P4 expr4, Func<T4, R> func4)
        {
            this.expr0 = expr0;
            this.func0 = func0;
            this.expr1 = expr1;
            this.func1 = func1;
            this.expr2 = expr2;
            this.func2 = func2;
            this.expr3 = expr3;
            this.func3 = func3;
            this.expr4 = expr4;
            this.func4 = func4;
        }
        public R Parse(string line, ref int index)
        {
            if (this.expr0.Parse(line, ref index) is T0 val0)
            {
                return this.func0(val0);
            }
            if (this.expr1.Parse(line, ref index) is T1 val1)
            {
                return this.func1(val1);
            }
            if (this.expr2.Parse(line, ref index) is T2 val2)
            {
                return this.func2(val2);
            }
            if (this.expr3.Parse(line, ref index) is T3 val3)
            {
                return this.func3(val3);
            }
            if (this.expr4.Parse(line, ref index) is T4 val4)
            {
                return this.func4(val4);
            }
            return null;
        }
    }
    public class Select<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, R> : IExpression<R>
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
        P0 expr0;
        Func<T0, R> func0;
        P1 expr1;
        Func<T1, R> func1;
        P2 expr2;
        Func<T2, R> func2;
        P3 expr3;
        Func<T3, R> func3;
        P4 expr4;
        Func<T4, R> func4;
        P5 expr5;
        Func<T5, R> func5;
        public Select(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1, P2 expr2, Func<T2, R> func2, P3 expr3, Func<T3, R> func3, P4 expr4, Func<T4, R> func4, P5 expr5, Func<T5, R> func5)
        {
            this.expr0 = expr0;
            this.func0 = func0;
            this.expr1 = expr1;
            this.func1 = func1;
            this.expr2 = expr2;
            this.func2 = func2;
            this.expr3 = expr3;
            this.func3 = func3;
            this.expr4 = expr4;
            this.func4 = func4;
            this.expr5 = expr5;
            this.func5 = func5;
        }
        public R Parse(string line, ref int index)
        {
            if (this.expr0.Parse(line, ref index) is T0 val0)
            {
                return this.func0(val0);
            }
            if (this.expr1.Parse(line, ref index) is T1 val1)
            {
                return this.func1(val1);
            }
            if (this.expr2.Parse(line, ref index) is T2 val2)
            {
                return this.func2(val2);
            }
            if (this.expr3.Parse(line, ref index) is T3 val3)
            {
                return this.func3(val3);
            }
            if (this.expr4.Parse(line, ref index) is T4 val4)
            {
                return this.func4(val4);
            }
            if (this.expr5.Parse(line, ref index) is T5 val5)
            {
                return this.func5(val5);
            }
            return null;
        }
    }
    public class Select<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, R> : IExpression<R>
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
        P0 expr0;
        Func<T0, R> func0;
        P1 expr1;
        Func<T1, R> func1;
        P2 expr2;
        Func<T2, R> func2;
        P3 expr3;
        Func<T3, R> func3;
        P4 expr4;
        Func<T4, R> func4;
        P5 expr5;
        Func<T5, R> func5;
        P6 expr6;
        Func<T6, R> func6;
        public Select(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1, P2 expr2, Func<T2, R> func2, P3 expr3, Func<T3, R> func3, P4 expr4, Func<T4, R> func4, P5 expr5, Func<T5, R> func5, P6 expr6, Func<T6, R> func6)
        {
            this.expr0 = expr0;
            this.func0 = func0;
            this.expr1 = expr1;
            this.func1 = func1;
            this.expr2 = expr2;
            this.func2 = func2;
            this.expr3 = expr3;
            this.func3 = func3;
            this.expr4 = expr4;
            this.func4 = func4;
            this.expr5 = expr5;
            this.func5 = func5;
            this.expr6 = expr6;
            this.func6 = func6;
        }
        public R Parse(string line, ref int index)
        {
            if (this.expr0.Parse(line, ref index) is T0 val0)
            {
                return this.func0(val0);
            }
            if (this.expr1.Parse(line, ref index) is T1 val1)
            {
                return this.func1(val1);
            }
            if (this.expr2.Parse(line, ref index) is T2 val2)
            {
                return this.func2(val2);
            }
            if (this.expr3.Parse(line, ref index) is T3 val3)
            {
                return this.func3(val3);
            }
            if (this.expr4.Parse(line, ref index) is T4 val4)
            {
                return this.func4(val4);
            }
            if (this.expr5.Parse(line, ref index) is T5 val5)
            {
                return this.func5(val5);
            }
            if (this.expr6.Parse(line, ref index) is T6 val6)
            {
                return this.func6(val6);
            }
            return null;
        }
    }
    public class Select<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, P7, T7, R> : IExpression<R>
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
        P0 expr0;
        Func<T0, R> func0;
        P1 expr1;
        Func<T1, R> func1;
        P2 expr2;
        Func<T2, R> func2;
        P3 expr3;
        Func<T3, R> func3;
        P4 expr4;
        Func<T4, R> func4;
        P5 expr5;
        Func<T5, R> func5;
        P6 expr6;
        Func<T6, R> func6;
        P7 expr7;
        Func<T7, R> func7;
        public Select(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1, P2 expr2, Func<T2, R> func2, P3 expr3, Func<T3, R> func3, P4 expr4, Func<T4, R> func4, P5 expr5, Func<T5, R> func5, P6 expr6, Func<T6, R> func6, P7 expr7, Func<T7, R> func7)
        {
            this.expr0 = expr0;
            this.func0 = func0;
            this.expr1 = expr1;
            this.func1 = func1;
            this.expr2 = expr2;
            this.func2 = func2;
            this.expr3 = expr3;
            this.func3 = func3;
            this.expr4 = expr4;
            this.func4 = func4;
            this.expr5 = expr5;
            this.func5 = func5;
            this.expr6 = expr6;
            this.func6 = func6;
            this.expr7 = expr7;
            this.func7 = func7;
        }
        public R Parse(string line, ref int index)
        {
            if (this.expr0.Parse(line, ref index) is T0 val0)
            {
                return this.func0(val0);
            }
            if (this.expr1.Parse(line, ref index) is T1 val1)
            {
                return this.func1(val1);
            }
            if (this.expr2.Parse(line, ref index) is T2 val2)
            {
                return this.func2(val2);
            }
            if (this.expr3.Parse(line, ref index) is T3 val3)
            {
                return this.func3(val3);
            }
            if (this.expr4.Parse(line, ref index) is T4 val4)
            {
                return this.func4(val4);
            }
            if (this.expr5.Parse(line, ref index) is T5 val5)
            {
                return this.func5(val5);
            }
            if (this.expr6.Parse(line, ref index) is T6 val6)
            {
                return this.func6(val6);
            }
            if (this.expr7.Parse(line, ref index) is T7 val7)
            {
                return this.func7(val7);
            }
            return null;
        }
    }
    public static class Select
    {
        static public Select<P0, T0, R> Create<P0, T0, R>(P0 expr0, Func<T0, R> func0)
            where P0 : IExpression<T0>
            where T0 : class
            where R : class
        {
            return new Select<P0, T0, R>(expr0, func0);
        }
        static public Select<P0, T0, P1, T1, R> Create<P0, T0, P1, T1, R>(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1)
            where P0 : IExpression<T0>
            where T0 : class
            where P1 : IExpression<T1>
            where T1 : class
            where R : class
        {
            return new Select<P0, T0, P1, T1, R>(expr0, func0, expr1, func1);
        }
        static public Select<P0, T0, P1, T1, P2, T2, R> Create<P0, T0, P1, T1, P2, T2, R>(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1, P2 expr2, Func<T2, R> func2)
        where P0 : IExpression<T0>
        where T0 : class
        where P1 : IExpression<T1>
        where T1 : class
        where P2 : IExpression<T2>
        where T2 : class
        where R : class
        {
            return new Select<P0, T0, P1, T1, P2, T2, R>(expr0, func0, expr1, func1, expr2, func2);
        }
        static public Select<P0, T0, P1, T1, P2, T2, P3, T3, R> Create<P0, T0, P1, T1, P2, T2, P3, T3, R>(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1, P2 expr2, Func<T2, R> func2, P3 expr3, Func<T3, R> func3)
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
            return new Select<P0, T0, P1, T1, P2, T2, P3, T3, R>(expr0, func0, expr1, func1, expr2, func2, expr3, func3);
        }
        static public Select<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, R> Create<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, R>(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1, P2 expr2, Func<T2, R> func2, P3 expr3, Func<T3, R> func3, P4 expr4, Func<T4, R> func4)
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
            return new Select<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, R>(expr0, func0, expr1, func1, expr2, func2, expr3, func3, expr4, func4);
        }
        static public Select<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, R> Create<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, R>(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1, P2 expr2, Func<T2, R> func2, P3 expr3, Func<T3, R> func3, P4 expr4, Func<T4, R> func4, P5 expr5, Func<T5, R> func5)
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
            return new Select<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, R>(expr0, func0, expr1, func1, expr2, func2, expr3, func3, expr4, func4, expr5, func5);
        }
        static public Select<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, R> Create<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, R>(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1, P2 expr2, Func<T2, R> func2, P3 expr3, Func<T3, R> func3, P4 expr4, Func<T4, R> func4, P5 expr5, Func<T5, R> func5, P6 expr6, Func<T6, R> func6)
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
            return new Select<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, R>(expr0, func0, expr1, func1, expr2, func2, expr3, func3, expr4, func4, expr5, func5, expr6, func6);
        }
        static public Select<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, P7, T7, R> Create<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, P7, T7, R>(P0 expr0, Func<T0, R> func0, P1 expr1, Func<T1, R> func1, P2 expr2, Func<T2, R> func2, P3 expr3, Func<T3, R> func3, P4 expr4, Func<T4, R> func4, P5 expr5, Func<T5, R> func5, P6 expr6, Func<T6, R> func6, P7 expr7, Func<T7, R> func7)
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
            return new Select<P0, T0, P1, T1, P2, T2, P3, T3, P4, T4, P5, T5, P6, T6, P7, T7, R>(expr0, func0, expr1, func1, expr2, func2, expr3, func3, expr4, func4, expr5, func5, expr6, func6, expr7, func7);
        }
    }
}
