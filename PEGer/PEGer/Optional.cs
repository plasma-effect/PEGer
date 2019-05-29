using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEGer
{
    public class Optional<P, R> : IExpression<R>
        where P : IExpression<R>
        where R : class
    {
        P expr;
        R failure;

        public Optional(P expr, R failure)
        {
            this.expr = expr;
            this.failure = failure;
        }

        public R Parse(string line, ref int index)
        {
            return this.expr.Parse(line, ref index) ?? this.failure;
        }
    }
    public static class Optional
    {
        public static Optional<P, R> Create<P, R>(P expr, R failure)
            where P : IExpression<R>
            where R : class
        {
            return new Optional<P, R>(expr, failure);
        }
    }
}
