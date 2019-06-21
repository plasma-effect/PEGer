//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;

namespace PEGer
{
    /// <summary>
    /// Sequence Expression
    /// </summary>
    /// <typeparam name="TResult">Return Type</typeparam>
    public static class Sequence<TResult>
    {
        /// <summary>
        /// Create 2 Length Sequence Expression with Custom Error
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <param name="func"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static Sequence<T1, T2, TResult> Create<T1, T2>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, Func<T1, T2, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, TResult>(expr1, expr2, func, error);
        }

        public static Sequence<T1, T2, TResult> Create<T1, T2>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, Func<T1, T2, TResult> func)
        {
            return Create(expr1, expr2, func, null);
        }
        public static Sequence<T1, T2, T3, TResult> Create<T1, T2, T3>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, Func<T1, T2, T3, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, TResult>(expr1, expr2, expr3, func, error);
        }

        public static Sequence<T1, T2, T3, TResult> Create<T1, T2, T3>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, Func<T1, T2, T3, TResult> func)
        {
            return Create(expr1, expr2, expr3, func, null);
        }

        public static Sequence<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, Func<T1, T2, T3, T4, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, TResult>(expr1, expr2, expr3, expr4, func, error);
        }

        public static Sequence<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, Func<T1, T2, T3, T4, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, func, null);
        }

        public static Sequence<T1, T2, T3, T4, T5, TResult> Create<T1, T2, T3, T4, T5>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, Func<T1, T2, T3, T4, T5, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, TResult>(expr1, expr2, expr3, expr4, expr5, func, error);
        }

        public static Sequence<T1, T2, T3, T4, T5, TResult> Create<T1, T2, T3, T4, T5>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, Func<T1, T2, T3, T4, T5, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, func, null);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, TResult> Create<T1, T2, T3, T4, T5, T6>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, Func<T1, T2, T3, T4, T5, T6, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, func, error);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, TResult> Create<T1, T2, T3, T4, T5, T6>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, Func<T1, T2, T3, T4, T5, T6, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, func, null);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, TResult> Create<T1, T2, T3, T4, T5, T6, T7>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, func, error);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, TResult> Create<T1, T2, T3, T4, T5, T6, T7>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, func, null);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, func, error);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, func, null);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, func, error);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, func, null);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, func, error);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, func, null);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, expr21, func, error);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, expr21, func, null);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, expr21, expr22, func, error);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, expr21, expr22, func, null);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, ExpressionBase<T13> expr23, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, expr21, expr22, expr23, func, error);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, ExpressionBase<T13> expr23, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, expr21, expr22, expr23, func, null);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, ExpressionBase<T13> expr23, ExpressionBase<T14> expr24, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, expr21, expr22, expr23, expr24, func, error);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, ExpressionBase<T13> expr23, ExpressionBase<T14> expr24, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, expr21, expr22, expr23, expr24, func, null);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, ExpressionBase<T13> expr23, ExpressionBase<T14> expr24, ExpressionBase<T15> expr25, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, expr21, expr22, expr23, expr24, expr25, func, error);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, ExpressionBase<T13> expr23, ExpressionBase<T14> expr24, ExpressionBase<T15> expr25, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, expr21, expr22, expr23, expr24, expr25, func, null);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, ExpressionBase<T13> expr23, ExpressionBase<T14> expr24, ExpressionBase<T15> expr25, ExpressionBase<T16> expr26, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, expr21, expr22, expr23, expr24, expr25, expr26, func, error);
        }

        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, ExpressionBase<T13> expr23, ExpressionBase<T14> expr24, ExpressionBase<T15> expr25, ExpressionBase<T16> expr26, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr20, expr21, expr22, expr23, expr24, expr25, expr26, func, null);
        }
    }

    public class Sequence<T1, T2, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        Func<T1, T2, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, Func<T1, T2, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<Func<T1, T2, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 2052636279;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[2];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;

        Func<T1, T2, T3, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, Func<T1, T2, T3, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<Func<T1, T2, T3, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 423434595;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[3];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;

        Func<T1, T2, T3, T4, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, Func<T1, T2, T3, T4, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<Func<T1, T2, T3, T4, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 1414244722;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[4];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, T5, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;

        Func<T1, T2, T3, T4, T5, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, Func<T1, T2, T3, T4, T5, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 564251152;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[5];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, T5, T6, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;
        ExpressionBase<T6> expr6;

        Func<T1, T2, T3, T4, T5, T6, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, Func<T1, T2, T3, T4, T5, T6, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, T6, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, sequence.expr6) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, T6, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = -240706143;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, T6, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[6];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);
            thisExprs[5] = this.expr6.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4], (T6)objs[5]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, T5, T6, T7, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;
        ExpressionBase<T6> expr6;
        ExpressionBase<T7> expr7;

        Func<T1, T2, T3, T4, T5, T6, T7, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, T6, T7, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, sequence.expr6) &&
                   EqualityComparer<ExpressionBase<T7>>.Default.Equals(this.expr7, sequence.expr7) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 1033287697;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T7>>.Default.GetHashCode(this.expr7);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[7];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);
            thisExprs[5] = this.expr6.Instance(parser, exprs);
            thisExprs[6] = this.expr7.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4], (T6)objs[5], (T7)objs[6]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;
        ExpressionBase<T6> expr6;
        ExpressionBase<T7> expr7;
        ExpressionBase<T8> expr8;

        Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;
            this.expr8 = expr8;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, T6, T7, T8, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, sequence.expr6) &&
                   EqualityComparer<ExpressionBase<T7>>.Default.Equals(this.expr7, sequence.expr7) &&
                   EqualityComparer<ExpressionBase<T8>>.Default.Equals(this.expr8, sequence.expr8) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 375212100;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T7>>.Default.GetHashCode(this.expr7);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T8>>.Default.GetHashCode(this.expr8);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[8];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);
            thisExprs[5] = this.expr6.Instance(parser, exprs);
            thisExprs[6] = this.expr7.Instance(parser, exprs);
            thisExprs[7] = this.expr8.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4], (T6)objs[5], (T7)objs[6], (T8)objs[7]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;
        ExpressionBase<T6> expr6;
        ExpressionBase<T7> expr7;
        ExpressionBase<T8> expr8;
        ExpressionBase<T9> expr9;

        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;
            this.expr8 = expr8;
            this.expr9 = expr9;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, sequence.expr6) &&
                   EqualityComparer<ExpressionBase<T7>>.Default.Equals(this.expr7, sequence.expr7) &&
                   EqualityComparer<ExpressionBase<T8>>.Default.Equals(this.expr8, sequence.expr8) &&
                   EqualityComparer<ExpressionBase<T9>>.Default.Equals(this.expr9, sequence.expr9) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 2116772518;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T7>>.Default.GetHashCode(this.expr7);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T8>>.Default.GetHashCode(this.expr8);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T9>>.Default.GetHashCode(this.expr9);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[9];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);
            thisExprs[5] = this.expr6.Instance(parser, exprs);
            thisExprs[6] = this.expr7.Instance(parser, exprs);
            thisExprs[7] = this.expr8.Instance(parser, exprs);
            thisExprs[8] = this.expr9.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4], (T6)objs[5], (T7)objs[6], (T8)objs[7], (T9)objs[8]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;
        ExpressionBase<T6> expr6;
        ExpressionBase<T7> expr7;
        ExpressionBase<T8> expr8;
        ExpressionBase<T9> expr9;
        ExpressionBase<T10> expr20;

        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;
            this.expr8 = expr8;
            this.expr9 = expr9;
            this.expr20 = expr20;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, sequence.expr6) &&
                   EqualityComparer<ExpressionBase<T7>>.Default.Equals(this.expr7, sequence.expr7) &&
                   EqualityComparer<ExpressionBase<T8>>.Default.Equals(this.expr8, sequence.expr8) &&
                   EqualityComparer<ExpressionBase<T9>>.Default.Equals(this.expr9, sequence.expr9) &&
                   EqualityComparer<ExpressionBase<T10>>.Default.Equals(this.expr20, sequence.expr20) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 594135707;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T7>>.Default.GetHashCode(this.expr7);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T8>>.Default.GetHashCode(this.expr8);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T9>>.Default.GetHashCode(this.expr9);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T10>>.Default.GetHashCode(this.expr20);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[10];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);
            thisExprs[5] = this.expr6.Instance(parser, exprs);
            thisExprs[6] = this.expr7.Instance(parser, exprs);
            thisExprs[7] = this.expr8.Instance(parser, exprs);
            thisExprs[8] = this.expr9.Instance(parser, exprs);
            thisExprs[9] = this.expr20.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4], (T6)objs[5], (T7)objs[6], (T8)objs[7], (T9)objs[8], (T10)objs[9]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;
        ExpressionBase<T6> expr6;
        ExpressionBase<T7> expr7;
        ExpressionBase<T8> expr8;
        ExpressionBase<T9> expr9;
        ExpressionBase<T10> expr20;
        ExpressionBase<T11> expr21;

        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;
            this.expr8 = expr8;
            this.expr9 = expr9;
            this.expr20 = expr20;
            this.expr21 = expr21;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, sequence.expr6) &&
                   EqualityComparer<ExpressionBase<T7>>.Default.Equals(this.expr7, sequence.expr7) &&
                   EqualityComparer<ExpressionBase<T8>>.Default.Equals(this.expr8, sequence.expr8) &&
                   EqualityComparer<ExpressionBase<T9>>.Default.Equals(this.expr9, sequence.expr9) &&
                   EqualityComparer<ExpressionBase<T10>>.Default.Equals(this.expr20, sequence.expr20) &&
                   EqualityComparer<ExpressionBase<T11>>.Default.Equals(this.expr21, sequence.expr21) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = -1551346422;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T7>>.Default.GetHashCode(this.expr7);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T8>>.Default.GetHashCode(this.expr8);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T9>>.Default.GetHashCode(this.expr9);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T10>>.Default.GetHashCode(this.expr20);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T11>>.Default.GetHashCode(this.expr21);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[11];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);
            thisExprs[5] = this.expr6.Instance(parser, exprs);
            thisExprs[6] = this.expr7.Instance(parser, exprs);
            thisExprs[7] = this.expr8.Instance(parser, exprs);
            thisExprs[8] = this.expr9.Instance(parser, exprs);
            thisExprs[9] = this.expr20.Instance(parser, exprs);
            thisExprs[10] = this.expr21.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4], (T6)objs[5], (T7)objs[6], (T8)objs[7], (T9)objs[8], (T10)objs[9], (T11)objs[10]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;
        ExpressionBase<T6> expr6;
        ExpressionBase<T7> expr7;
        ExpressionBase<T8> expr8;
        ExpressionBase<T9> expr9;
        ExpressionBase<T10> expr20;
        ExpressionBase<T11> expr21;
        ExpressionBase<T12> expr22;

        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;
            this.expr8 = expr8;
            this.expr9 = expr9;
            this.expr20 = expr20;
            this.expr21 = expr21;
            this.expr22 = expr22;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, sequence.expr6) &&
                   EqualityComparer<ExpressionBase<T7>>.Default.Equals(this.expr7, sequence.expr7) &&
                   EqualityComparer<ExpressionBase<T8>>.Default.Equals(this.expr8, sequence.expr8) &&
                   EqualityComparer<ExpressionBase<T9>>.Default.Equals(this.expr9, sequence.expr9) &&
                   EqualityComparer<ExpressionBase<T10>>.Default.Equals(this.expr20, sequence.expr20) &&
                   EqualityComparer<ExpressionBase<T11>>.Default.Equals(this.expr21, sequence.expr21) &&
                   EqualityComparer<ExpressionBase<T12>>.Default.Equals(this.expr22, sequence.expr22) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 609138574;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T7>>.Default.GetHashCode(this.expr7);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T8>>.Default.GetHashCode(this.expr8);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T9>>.Default.GetHashCode(this.expr9);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T10>>.Default.GetHashCode(this.expr20);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T11>>.Default.GetHashCode(this.expr21);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T12>>.Default.GetHashCode(this.expr22);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[12];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);
            thisExprs[5] = this.expr6.Instance(parser, exprs);
            thisExprs[6] = this.expr7.Instance(parser, exprs);
            thisExprs[7] = this.expr8.Instance(parser, exprs);
            thisExprs[8] = this.expr9.Instance(parser, exprs);
            thisExprs[9] = this.expr20.Instance(parser, exprs);
            thisExprs[10] = this.expr21.Instance(parser, exprs);
            thisExprs[11] = this.expr22.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4], (T6)objs[5], (T7)objs[6], (T8)objs[7], (T9)objs[8], (T10)objs[9], (T11)objs[10], (T12)objs[11]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;
        ExpressionBase<T6> expr6;
        ExpressionBase<T7> expr7;
        ExpressionBase<T8> expr8;
        ExpressionBase<T9> expr9;
        ExpressionBase<T10> expr20;
        ExpressionBase<T11> expr21;
        ExpressionBase<T12> expr22;
        ExpressionBase<T13> expr23;

        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, ExpressionBase<T13> expr23, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;
            this.expr8 = expr8;
            this.expr9 = expr9;
            this.expr20 = expr20;
            this.expr21 = expr21;
            this.expr22 = expr22;
            this.expr23 = expr23;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, sequence.expr6) &&
                   EqualityComparer<ExpressionBase<T7>>.Default.Equals(this.expr7, sequence.expr7) &&
                   EqualityComparer<ExpressionBase<T8>>.Default.Equals(this.expr8, sequence.expr8) &&
                   EqualityComparer<ExpressionBase<T9>>.Default.Equals(this.expr9, sequence.expr9) &&
                   EqualityComparer<ExpressionBase<T10>>.Default.Equals(this.expr20, sequence.expr20) &&
                   EqualityComparer<ExpressionBase<T11>>.Default.Equals(this.expr21, sequence.expr21) &&
                   EqualityComparer<ExpressionBase<T12>>.Default.Equals(this.expr22, sequence.expr22) &&
                   EqualityComparer<ExpressionBase<T13>>.Default.Equals(this.expr23, sequence.expr23) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 1785544571;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T7>>.Default.GetHashCode(this.expr7);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T8>>.Default.GetHashCode(this.expr8);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T9>>.Default.GetHashCode(this.expr9);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T10>>.Default.GetHashCode(this.expr20);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T11>>.Default.GetHashCode(this.expr21);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T12>>.Default.GetHashCode(this.expr22);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T13>>.Default.GetHashCode(this.expr23);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[13];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);
            thisExprs[5] = this.expr6.Instance(parser, exprs);
            thisExprs[6] = this.expr7.Instance(parser, exprs);
            thisExprs[7] = this.expr8.Instance(parser, exprs);
            thisExprs[8] = this.expr9.Instance(parser, exprs);
            thisExprs[9] = this.expr20.Instance(parser, exprs);
            thisExprs[10] = this.expr21.Instance(parser, exprs);
            thisExprs[11] = this.expr22.Instance(parser, exprs);
            thisExprs[12] = this.expr23.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4], (T6)objs[5], (T7)objs[6], (T8)objs[7], (T9)objs[8], (T10)objs[9], (T11)objs[10], (T12)objs[11], (T13)objs[12]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;
        ExpressionBase<T6> expr6;
        ExpressionBase<T7> expr7;
        ExpressionBase<T8> expr8;
        ExpressionBase<T9> expr9;
        ExpressionBase<T10> expr20;
        ExpressionBase<T11> expr21;
        ExpressionBase<T12> expr22;
        ExpressionBase<T13> expr23;
        ExpressionBase<T14> expr24;

        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, ExpressionBase<T13> expr23, ExpressionBase<T14> expr24, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;
            this.expr8 = expr8;
            this.expr9 = expr9;
            this.expr20 = expr20;
            this.expr21 = expr21;
            this.expr22 = expr22;
            this.expr23 = expr23;
            this.expr24 = expr24;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, sequence.expr6) &&
                   EqualityComparer<ExpressionBase<T7>>.Default.Equals(this.expr7, sequence.expr7) &&
                   EqualityComparer<ExpressionBase<T8>>.Default.Equals(this.expr8, sequence.expr8) &&
                   EqualityComparer<ExpressionBase<T9>>.Default.Equals(this.expr9, sequence.expr9) &&
                   EqualityComparer<ExpressionBase<T10>>.Default.Equals(this.expr20, sequence.expr20) &&
                   EqualityComparer<ExpressionBase<T11>>.Default.Equals(this.expr21, sequence.expr21) &&
                   EqualityComparer<ExpressionBase<T12>>.Default.Equals(this.expr22, sequence.expr22) &&
                   EqualityComparer<ExpressionBase<T13>>.Default.Equals(this.expr23, sequence.expr23) &&
                   EqualityComparer<ExpressionBase<T14>>.Default.Equals(this.expr24, sequence.expr24) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 20189485;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T7>>.Default.GetHashCode(this.expr7);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T8>>.Default.GetHashCode(this.expr8);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T9>>.Default.GetHashCode(this.expr9);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T10>>.Default.GetHashCode(this.expr20);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T11>>.Default.GetHashCode(this.expr21);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T12>>.Default.GetHashCode(this.expr22);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T13>>.Default.GetHashCode(this.expr23);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T14>>.Default.GetHashCode(this.expr24);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[14];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);
            thisExprs[5] = this.expr6.Instance(parser, exprs);
            thisExprs[6] = this.expr7.Instance(parser, exprs);
            thisExprs[7] = this.expr8.Instance(parser, exprs);
            thisExprs[8] = this.expr9.Instance(parser, exprs);
            thisExprs[9] = this.expr20.Instance(parser, exprs);
            thisExprs[10] = this.expr21.Instance(parser, exprs);
            thisExprs[11] = this.expr22.Instance(parser, exprs);
            thisExprs[12] = this.expr23.Instance(parser, exprs);
            thisExprs[13] = this.expr24.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4], (T6)objs[5], (T7)objs[6], (T8)objs[7], (T9)objs[8], (T10)objs[9], (T11)objs[10], (T12)objs[11], (T13)objs[12], (T14)objs[13]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;
        ExpressionBase<T6> expr6;
        ExpressionBase<T7> expr7;
        ExpressionBase<T8> expr8;
        ExpressionBase<T9> expr9;
        ExpressionBase<T10> expr20;
        ExpressionBase<T11> expr21;
        ExpressionBase<T12> expr22;
        ExpressionBase<T13> expr23;
        ExpressionBase<T14> expr24;
        ExpressionBase<T15> expr25;

        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, ExpressionBase<T13> expr23, ExpressionBase<T14> expr24, ExpressionBase<T15> expr25, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;
            this.expr8 = expr8;
            this.expr9 = expr9;
            this.expr20 = expr20;
            this.expr21 = expr21;
            this.expr22 = expr22;
            this.expr23 = expr23;
            this.expr24 = expr24;
            this.expr25 = expr25;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, sequence.expr6) &&
                   EqualityComparer<ExpressionBase<T7>>.Default.Equals(this.expr7, sequence.expr7) &&
                   EqualityComparer<ExpressionBase<T8>>.Default.Equals(this.expr8, sequence.expr8) &&
                   EqualityComparer<ExpressionBase<T9>>.Default.Equals(this.expr9, sequence.expr9) &&
                   EqualityComparer<ExpressionBase<T10>>.Default.Equals(this.expr20, sequence.expr20) &&
                   EqualityComparer<ExpressionBase<T11>>.Default.Equals(this.expr21, sequence.expr21) &&
                   EqualityComparer<ExpressionBase<T12>>.Default.Equals(this.expr22, sequence.expr22) &&
                   EqualityComparer<ExpressionBase<T13>>.Default.Equals(this.expr23, sequence.expr23) &&
                   EqualityComparer<ExpressionBase<T14>>.Default.Equals(this.expr24, sequence.expr24) &&
                   EqualityComparer<ExpressionBase<T15>>.Default.Equals(this.expr25, sequence.expr25) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = 857181024;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T7>>.Default.GetHashCode(this.expr7);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T8>>.Default.GetHashCode(this.expr8);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T9>>.Default.GetHashCode(this.expr9);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T10>>.Default.GetHashCode(this.expr20);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T11>>.Default.GetHashCode(this.expr21);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T12>>.Default.GetHashCode(this.expr22);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T13>>.Default.GetHashCode(this.expr23);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T14>>.Default.GetHashCode(this.expr24);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T15>>.Default.GetHashCode(this.expr25);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[15];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);
            thisExprs[5] = this.expr6.Instance(parser, exprs);
            thisExprs[6] = this.expr7.Instance(parser, exprs);
            thisExprs[7] = this.expr8.Instance(parser, exprs);
            thisExprs[8] = this.expr9.Instance(parser, exprs);
            thisExprs[9] = this.expr20.Instance(parser, exprs);
            thisExprs[10] = this.expr21.Instance(parser, exprs);
            thisExprs[11] = this.expr22.Instance(parser, exprs);
            thisExprs[12] = this.expr23.Instance(parser, exprs);
            thisExprs[13] = this.expr24.Instance(parser, exprs);
            thisExprs[14] = this.expr25.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4], (T6)objs[5], (T7)objs[6], (T8)objs[7], (T9)objs[8], (T10)objs[9], (T11)objs[10], (T12)objs[11], (T13)objs[12], (T14)objs[13], (T15)objs[14]),
              this.error, parser, thisIndex);
        }
    }

    public class Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> : ExpressionBase<TResult>
    {
        ExpressionBase<T1> expr1;
        ExpressionBase<T2> expr2;
        ExpressionBase<T3> expr3;
        ExpressionBase<T4> expr4;
        ExpressionBase<T5> expr5;
        ExpressionBase<T6> expr6;
        ExpressionBase<T7> expr7;
        ExpressionBase<T8> expr8;
        ExpressionBase<T9> expr9;
        ExpressionBase<T10> expr20;
        ExpressionBase<T11> expr21;
        ExpressionBase<T12> expr22;
        ExpressionBase<T13> expr23;
        ExpressionBase<T14> expr24;
        ExpressionBase<T15> expr25;
        ExpressionBase<T16> expr26;

        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func;
        Func<ParsingException, int, Exception> error;

        public Sequence(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr20, ExpressionBase<T11> expr21, ExpressionBase<T12> expr22, ExpressionBase<T13> expr23, ExpressionBase<T14> expr24, ExpressionBase<T15> expr25, ExpressionBase<T16> expr26, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func, Func<ParsingException, int, Exception> error)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.expr3 = expr3;
            this.expr4 = expr4;
            this.expr5 = expr5;
            this.expr6 = expr6;
            this.expr7 = expr7;
            this.expr8 = expr8;
            this.expr9 = expr9;
            this.expr20 = expr20;
            this.expr21 = expr21;
            this.expr22 = expr22;
            this.expr23 = expr23;
            this.expr24 = expr24;
            this.expr25 = expr25;
            this.expr26 = expr26;

            this.func = func;
            this.error = error;
        }

        public override bool Equals(object obj)
        {
            return obj is Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> sequence &&
                   EqualityComparer<ExpressionBase<T1>>.Default.Equals(this.expr1, sequence.expr1) &&
                   EqualityComparer<ExpressionBase<T2>>.Default.Equals(this.expr2, sequence.expr2) &&
                   EqualityComparer<ExpressionBase<T3>>.Default.Equals(this.expr3, sequence.expr3) &&
                   EqualityComparer<ExpressionBase<T4>>.Default.Equals(this.expr4, sequence.expr4) &&
                   EqualityComparer<ExpressionBase<T5>>.Default.Equals(this.expr5, sequence.expr5) &&
                   EqualityComparer<ExpressionBase<T6>>.Default.Equals(this.expr6, sequence.expr6) &&
                   EqualityComparer<ExpressionBase<T7>>.Default.Equals(this.expr7, sequence.expr7) &&
                   EqualityComparer<ExpressionBase<T8>>.Default.Equals(this.expr8, sequence.expr8) &&
                   EqualityComparer<ExpressionBase<T9>>.Default.Equals(this.expr9, sequence.expr9) &&
                   EqualityComparer<ExpressionBase<T10>>.Default.Equals(this.expr20, sequence.expr20) &&
                   EqualityComparer<ExpressionBase<T11>>.Default.Equals(this.expr21, sequence.expr21) &&
                   EqualityComparer<ExpressionBase<T12>>.Default.Equals(this.expr22, sequence.expr22) &&
                   EqualityComparer<ExpressionBase<T13>>.Default.Equals(this.expr23, sequence.expr23) &&
                   EqualityComparer<ExpressionBase<T14>>.Default.Equals(this.expr24, sequence.expr24) &&
                   EqualityComparer<ExpressionBase<T15>>.Default.Equals(this.expr25, sequence.expr25) &&
                   EqualityComparer<ExpressionBase<T16>>.Default.Equals(this.expr26, sequence.expr26) &&
                   EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>>.Default.Equals(this.func, sequence.func) &&
                   EqualityComparer<Func<ParsingException, int, Exception>>.Default.Equals(this.error, sequence.error);
        }

        public override int GetHashCode()
        {
            var hashCode = -2145884088;
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T1>>.Default.GetHashCode(this.expr1);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T2>>.Default.GetHashCode(this.expr2);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T3>>.Default.GetHashCode(this.expr3);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T4>>.Default.GetHashCode(this.expr4);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T5>>.Default.GetHashCode(this.expr5);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T6>>.Default.GetHashCode(this.expr6);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T7>>.Default.GetHashCode(this.expr7);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T8>>.Default.GetHashCode(this.expr8);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T9>>.Default.GetHashCode(this.expr9);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T10>>.Default.GetHashCode(this.expr20);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T11>>.Default.GetHashCode(this.expr21);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T12>>.Default.GetHashCode(this.expr22);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T13>>.Default.GetHashCode(this.expr23);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T14>>.Default.GetHashCode(this.expr24);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T15>>.Default.GetHashCode(this.expr25);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpressionBase<T16>>.Default.GetHashCode(this.expr26);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>>.Default.GetHashCode(this.func);
            hashCode = hashCode * -1521134295 + EqualityComparer<Func<ParsingException, int, Exception>>.Default.GetHashCode(this.error);
            return hashCode;
        }

        internal override IInstancedExpression<ParseResult> InstanceImplement<ParseResult>(Parser<ParseResult> parser, List<IExpression> exprs, int thisIndex)
        {
            var thisExprs = new int[16];
            thisExprs[0] = this.expr1.Instance(parser, exprs);
            thisExprs[1] = this.expr2.Instance(parser, exprs);
            thisExprs[2] = this.expr3.Instance(parser, exprs);
            thisExprs[3] = this.expr4.Instance(parser, exprs);
            thisExprs[4] = this.expr5.Instance(parser, exprs);
            thisExprs[5] = this.expr6.Instance(parser, exprs);
            thisExprs[6] = this.expr7.Instance(parser, exprs);
            thisExprs[7] = this.expr8.Instance(parser, exprs);
            thisExprs[8] = this.expr9.Instance(parser, exprs);
            thisExprs[9] = this.expr20.Instance(parser, exprs);
            thisExprs[10] = this.expr21.Instance(parser, exprs);
            thisExprs[11] = this.expr22.Instance(parser, exprs);
            thisExprs[12] = this.expr23.Instance(parser, exprs);
            thisExprs[13] = this.expr24.Instance(parser, exprs);
            thisExprs[14] = this.expr25.Instance(parser, exprs);
            thisExprs[15] = this.expr26.Instance(parser, exprs);

            return new SequenceInstancedClass<TResult, ParseResult>(thisExprs, objs =>
              this.func((T1)objs[0], (T2)objs[1], (T3)objs[2], (T4)objs[3], (T5)objs[4], (T6)objs[5], (T7)objs[6], (T8)objs[7], (T9)objs[8], (T10)objs[9], (T11)objs[10], (T12)objs[11], (T13)objs[12], (T14)objs[13], (T15)objs[14], (T16)objs[15]),
              this.error, parser, thisIndex);
        }
    }

    internal class SequenceInstancedClass<TResult, ParseResult> : InstanceBase<TResult, ParseResult>
    {
        int[] exprs;
        Func<object[], TResult> func;
        Func<ParsingException, int, Exception> error;

        public SequenceInstancedClass(int[] exprs, Func<object[], TResult> func, Func<ParsingException, int, Exception> error, Parser<ParseResult> parser, int thisIndex) : base(parser, thisIndex)
        {
            this.exprs = exprs;
            this.func = func;
            this.error = error;
        }

        protected override TResult ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
        {
            var start = index;
            var eind = -1;
            try
            {
                var objs = new object[this.exprs.Length];
                foreach (var e in this.exprs)
                {
                    ++eind;
                    objs[eind] = this.Parser[e].Parse(str, ref index, exceptions, memo);
                }
                return this.func(objs);
            }
            catch(ParsingException exc)
            {
                index = start;
                if(this.error is null)
                {
                    throw exc;
                }
                else
                {
                    throw new ParsingException(start, this.error(exc, eind));
                }
            }
        }
    }
}
