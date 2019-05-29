using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEGer
{
    public class AndPred<T, R> : IExpression<R>
        where T : IExpression<R>
        where R : class
    {
        T expr;

        public AndPred(T expr)
        {
            this.expr = expr;
        }

        public R Parse(string line, ref int index)
        {
            var dummy = index;
            return this.expr.Parse(line, ref dummy);
        }
    }
    public class NotPred<T, R0, R1> : IExpression<R1>
        where T : IExpression<R0>
        where R0 : class
        where R1 : class
    {
        T expr;
        R1 failure;

        public NotPred(T expr, R1 failure)
        {
            this.expr = expr;
            this.failure = failure;
        }

        public R1 Parse(string line, ref int index)
        {
            var dummy = index;
            if (this.expr.Parse(line, ref dummy) is null)
            {
                return this.failure;
            }
            return null;
        }
    }

    public static class Predicate
    {
        public static AndPred<T, R> AndCreate<T, R>(T expr)
            where T : IExpression<R>
            where R : class
        {
            return new AndPred<T, R>(expr);
        }
        public static NotPred<T, R0, R1> NotCreate<T, R0, R1>(T expr, R1 failure)
            where T : IExpression<R0>
            where R0 : class
            where R1 : class
        {
            return new NotPred<T, R0, R1>(expr, failure);
        }
    }
}
