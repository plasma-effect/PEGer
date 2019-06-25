//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;
using static UtilityLibrary.Expected<PEGer.ParsingException>;

namespace PEGer
{
    /// <summary>
    /// Sequence Expression
    /// </summary>
    public static class Sequence
    {
        /// <summary>
        /// Create 2 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, TResult> Create<T1, T2, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, Func<T1, T2, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, TResult>(expr1, expr2, func, error);
        }

        /// <summary>
        /// Create 2 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, TResult> Create<T1, T2, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, Func<T1, T2, TResult> func)
        {
            return Create(expr1, expr2, func, null);
        }

        /// <summary>
        /// Create 3 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, TResult> Create<T1, T2, T3, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, Func<T1, T2, T3, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, TResult>(expr1, expr2, expr3, func, error);
        }

        /// <summary>
        /// Create 3 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, TResult> Create<T1, T2, T3, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, Func<T1, T2, T3, TResult> func)
        {
            return Create(expr1, expr2, expr3, func, null);
        }

        /// <summary>
        /// Create 4 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, Func<T1, T2, T3, T4, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, TResult>(expr1, expr2, expr3, expr4, func, error);
        }

        /// <summary>
        /// Create 4 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, Func<T1, T2, T3, T4, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, func, null);
        }

        /// <summary>
        /// Create 5 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, TResult> Create<T1, T2, T3, T4, T5, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, Func<T1, T2, T3, T4, T5, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, TResult>(expr1, expr2, expr3, expr4, expr5, func, error);
        }

        /// <summary>
        /// Create 5 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, TResult> Create<T1, T2, T3, T4, T5, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, Func<T1, T2, T3, T4, T5, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, func, null);
        }

        /// <summary>
        /// Create 6 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, TResult> Create<T1, T2, T3, T4, T5, T6, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, Func<T1, T2, T3, T4, T5, T6, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, func, error);
        }

        /// <summary>
        /// Create 6 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, TResult> Create<T1, T2, T3, T4, T5, T6, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, Func<T1, T2, T3, T4, T5, T6, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, func, null);
        }

        /// <summary>
        /// Create 7 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, TResult> Create<T1, T2, T3, T4, T5, T6, T7, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, func, error);
        }

        /// <summary>
        /// Create 7 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, TResult> Create<T1, T2, T3, T4, T5, T6, T7, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, func, null);
        }

        /// <summary>
        /// Create 8 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, func, error);
        }

        /// <summary>
        /// Create 8 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, func, null);
        }

        /// <summary>
        /// Create 9 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, func, error);
        }

        /// <summary>
        /// Create 9 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, func, null);
        }

        /// <summary>
        /// Create 10 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, func, error);
        }

        /// <summary>
        /// Create 10 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, func, null);
        }

        /// <summary>
        /// Create 11 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="T11">11th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="expr11">11th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, func, error);
        }

        /// <summary>
        /// Create 11 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="T11">11th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="expr11">11th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, func, null);
        }

        /// <summary>
        /// Create 12 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="T11">11th Expression Return Type</typeparam>
        /// <typeparam name="T12">12th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="expr11">11th Expression</param>
        /// <param name="expr12">12th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, func, error);
        }

        /// <summary>
        /// Create 12 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="T11">11th Expression Return Type</typeparam>
        /// <typeparam name="T12">12th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="expr11">11th Expression</param>
        /// <param name="expr12">12th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, func, null);
        }

        /// <summary>
        /// Create 13 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="T11">11th Expression Return Type</typeparam>
        /// <typeparam name="T12">12th Expression Return Type</typeparam>
        /// <typeparam name="T13">13th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="expr11">11th Expression</param>
        /// <param name="expr12">12th Expression</param>
        /// <param name="expr13">13th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, func, error);
        }

        /// <summary>
        /// Create 13 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="T11">11th Expression Return Type</typeparam>
        /// <typeparam name="T12">12th Expression Return Type</typeparam>
        /// <typeparam name="T13">13th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="expr11">11th Expression</param>
        /// <param name="expr12">12th Expression</param>
        /// <param name="expr13">13th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, func, null);
        }

        /// <summary>
        /// Create 14 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="T11">11th Expression Return Type</typeparam>
        /// <typeparam name="T12">12th Expression Return Type</typeparam>
        /// <typeparam name="T13">13th Expression Return Type</typeparam>
        /// <typeparam name="T14">14th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="expr11">11th Expression</param>
        /// <param name="expr12">12th Expression</param>
        /// <param name="expr13">13th Expression</param>
        /// <param name="expr14">14th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, func, error);
        }

        /// <summary>
        /// Create 14 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="T11">11th Expression Return Type</typeparam>
        /// <typeparam name="T12">12th Expression Return Type</typeparam>
        /// <typeparam name="T13">13th Expression Return Type</typeparam>
        /// <typeparam name="T14">14th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="expr11">11th Expression</param>
        /// <param name="expr12">12th Expression</param>
        /// <param name="expr13">13th Expression</param>
        /// <param name="expr14">14th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, func, null);
        }

        /// <summary>
        /// Create 15 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="T11">11th Expression Return Type</typeparam>
        /// <typeparam name="T12">12th Expression Return Type</typeparam>
        /// <typeparam name="T13">13th Expression Return Type</typeparam>
        /// <typeparam name="T14">14th Expression Return Type</typeparam>
        /// <typeparam name="T15">15th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="expr11">11th Expression</param>
        /// <param name="expr12">12th Expression</param>
        /// <param name="expr13">13th Expression</param>
        /// <param name="expr14">14th Expression</param>
        /// <param name="expr15">15th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, ExpressionBase<T15> expr15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, expr15, func, error);
        }

        /// <summary>
        /// Create 15 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="T11">11th Expression Return Type</typeparam>
        /// <typeparam name="T12">12th Expression Return Type</typeparam>
        /// <typeparam name="T13">13th Expression Return Type</typeparam>
        /// <typeparam name="T14">14th Expression Return Type</typeparam>
        /// <typeparam name="T15">15th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="expr11">11th Expression</param>
        /// <param name="expr12">12th Expression</param>
        /// <param name="expr13">13th Expression</param>
        /// <param name="expr14">14th Expression</param>
        /// <param name="expr15">15th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, ExpressionBase<T15> expr15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, expr15, func, null);
        }

        /// <summary>
        /// Create 16 Length Sequence Expression with Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="T11">11th Expression Return Type</typeparam>
        /// <typeparam name="T12">12th Expression Return Type</typeparam>
        /// <typeparam name="T13">13th Expression Return Type</typeparam>
        /// <typeparam name="T14">14th Expression Return Type</typeparam>
        /// <typeparam name="T15">15th Expression Return Type</typeparam>
        /// <typeparam name="T16">16th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="expr11">11th Expression</param>
        /// <param name="expr12">12th Expression</param>
        /// <param name="expr13">13th Expression</param>
        /// <param name="expr14">14th Expression</param>
        /// <param name="expr15">15th Expression</param>
        /// <param name="expr16">16th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, ExpressionBase<T15> expr15, ExpressionBase<T16> expr16, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func, Func<ParsingException, int, Exception> error)
        {
            return new Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, expr15, expr16, func, error);
        }

        /// <summary>
        /// Create 16 Length Sequence Expression
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <typeparam name="T9">9th Expression Return Type</typeparam>
        /// <typeparam name="T10">10th Expression Return Type</typeparam>
        /// <typeparam name="T11">11th Expression Return Type</typeparam>
        /// <typeparam name="T12">12th Expression Return Type</typeparam>
        /// <typeparam name="T13">13th Expression Return Type</typeparam>
        /// <typeparam name="T14">14th Expression Return Type</typeparam>
        /// <typeparam name="T15">15th Expression Return Type</typeparam>
        /// <typeparam name="T16">16th Expression Return Type</typeparam>
        /// <typeparam name="TResult">Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="expr10">10th Expression</param>
        /// <param name="expr11">11th Expression</param>
        /// <param name="expr12">12th Expression</param>
        /// <param name="expr13">13th Expression</param>
        /// <param name="expr14">14th Expression</param>
        /// <param name="expr15">15th Expression</param>
        /// <param name="expr16">16th Expression</param>
        /// <param name="func">Transform Function</param>
        /// <returns>Sequence Expression</returns>
        public static Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, ExpressionBase<T15> expr15, ExpressionBase<T16> expr16, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, expr15, expr16, func, null);
        }
    }

    internal class SequenceInstancedClass<TResult, ParseResult> : InstanceBase<TResult, ParseResult>
    {
        int[] exprIndexes;
        Func<object[], TResult> func;
        Func<ParsingException, int, Exception> error;

        public SequenceInstancedClass(int[] exprIndexes, Func<object[], TResult> func, Func<ParsingException, int, Exception> error, Parser<ParseResult> parser, int thisIndex) : base(parser, thisIndex)
        {
            this.exprIndexes = exprIndexes;
            this.func = func;
            this.error = error;
        }

        protected override Expected<TResult, ParsingException> ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
        {
            var start = index;
            var eind = -1;
            var objes = new object[this.exprIndexes.Length];
            var @continue = false;
            foreach (var e in this.exprIndexes)
            {
                var now = index;
                ++eind;
                var val = this.Parser[e].Parse(str, ref index, exceptions, memo);
                if (val.TryGet(out var obj))
                {
                    objes[eind] = obj;
                }
                else if (val.GetException() is Continue.ContinueException exc)
                {
                    @continue = true;
                    exceptions.Add(exc);
                }
                else
                {
                    if (this.error is null)
                    {
                        return Failure<TResult>(val.GetException());
                    }
                    else
                    {
                        return Failure<TResult>(new ParsingException(now, this.error(val.GetException(), eind)));
                    }
                }
            }
            if (@continue)
            {
                return Failure<TResult>(new Continue.ContinueException(index, new Continue.ContinueExceptionTag()));
            }
            else
            {
                return Success(this.func(objes));
            }
        }
    }
}
