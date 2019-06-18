//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;

namespace PEGer
{
    public class ParsingException : Exception
    {
        public int Index { get; }
        public Exception Exception { get; }

        public ParsingException(int index, Exception exception)
        {
            this.Index = index;
            this.Exception = exception;
        }
    }

    public class DontReachEndOfStringException : Exception
    {
        public DontReachEndOfStringException() : base("parse end point didn't reach end of string")
        {

        }
    }

}
