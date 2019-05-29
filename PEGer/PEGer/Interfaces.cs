using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEGer
{
    public interface IExpression<T>
        where T : class
    {
        T Parse(string line, ref int index);
    }
}
