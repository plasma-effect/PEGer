using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PEGer;
using static System.Linq.Enumerable;

namespace ParserTest
{
    class Program
    {
        static T Echo<T>(T v)
        {
            return v;
        }
        interface Expr
        {
            int Eval();
        }
        class Add : Expr
        {
            Expr[] exprs;

            public Add(Expr[] exprs)
            {
                this.exprs = exprs;
            }

            public int Eval()
            {
                var ret = 0;
                foreach(var e in this.exprs)
                {
                    ret += e.Eval();
                }
                return ret;
            }
        }
        class Mul : Expr
        {
            Expr[] exprs;

            public Mul(Expr[] exprs)
            {
                this.exprs = exprs;
            }

            public int Eval()
            {
                var ret = 1;
                foreach(var e in this.exprs)
                {
                    ret *= e.Eval();
                }
                return ret;
            }
        }
        class Atomic : Expr
        {
            int v;

            public Atomic(int v)
            {
                this.v = v;
            }

            public int Eval()
            {
                return this.v;
            }
        }

        static Add CreateAdd(Expr lhs,List<Expr> rhs)
        {
            var ret = new Expr[rhs.Count + 1];
            ret[0] = lhs;
            foreach(var i in Range(1, rhs.Count))
            {
                ret[i] = rhs[i - 1];
            }
            return new Add(ret);
        }
        static Mul CreateMul(Expr lhs,List<Expr> rhs)
        {
            var ret = new Expr[rhs.Count + 1];
            ret[0] = lhs;
            foreach (var i in Range(1, rhs.Count))
            {
                ret[i] = rhs[i - 1];
            }
            return new Mul(ret);
        }
        static Atomic CreateAtomic(string str)
        {
            return new Atomic(int.Parse(str));
        }
        static void Main(string[] args)
        {

        }
    }
}
