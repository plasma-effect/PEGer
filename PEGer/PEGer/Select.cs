//Copyright (c) 2019 plasma_effect
//This source code is under MIT License. See ./LICENSE
using System;
using System.Collections.Generic;
using System.Text;
using static UtilityLibrary.IntegerEnumerable;
using static PEGer.Utility;
using UtilityLibrary;
using static UtilityLibrary.Expected<PEGer.ParsingException>;

namespace PEGer
{
    /// <summary>
    /// Select Expression
    /// </summary>
    /// <typeparam name="TResult">Return Type</typeparam>
    public static class Select<TResult>
    {
        /// <summary>
        /// Create 2-Select Expression with Transform Functions and Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, TResult> Create<T1, T2>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, TResult>(expr1, expr2, func1, func2, error);
        }

        /// <summary>
        /// Create 2-Select Expression with Transform Functions
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, TResult> Create<T1, T2>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, Func<T1, TResult> func1, Func<T2, TResult> func2)
        {
            return Create(expr1, expr2, func1, func2, null);
        }

        /// <summary>
        /// Create 2-Select Expression with Custom Exception
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, Func<ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, Echo, Echo, error);
        }

        /// <summary>
        /// Create 2-Select Expression
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2)
        {
            return Create(expr1, expr2, Echo, Echo, null);
        }

        /// <summary>
        /// Create 3-Select Expression with Transform Functions and Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        public static Select<T1, T2, T3, TResult> Create<T1, T2, T3>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, TResult>(expr1, expr2, expr3, func1, func2, func3, error);
        }

        /// <summary>
        /// Create 3-Select Expression with Transform Functions
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        public static Select<T1, T2, T3, TResult> Create<T1, T2, T3>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3)
        {
            return Create(expr1, expr2, expr3, func1, func2, func3, null);
        }

        /// <summary>
        /// Create 3-Select Expression with Custom Exception
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="error">Function that return Custom Exception</param>
        public static Select<TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, Func<ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 3-Select Expression
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        public static Select<TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3)
        {
            return Create(expr1, expr2, expr3, Echo, Echo, Echo, null);
        }


        /// <summary>
        /// Create 4-Select Expression with Transform Functions and Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, TResult>(expr1, expr2, expr3, expr4, func1, func2, func3, func4, error);
        }

        /// <summary>
        /// Create 4-Select Expression with Transform Functions
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4)
        {
            return Create(expr1, expr2, expr3, expr4, func1, func2, func3, func4, null);
        }

        /// <summary>
        /// Create 4-Select Expression with Custom Exception
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, Func<ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 4-Select Expression
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4)
        {
            return Create(expr1, expr2, expr3, expr4, Echo, Echo, Echo, Echo, null);
        }

        /// <summary>
        /// Create 5-Select Expression with Transform Functions and Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, TResult> Create<T1, T2, T3, T4, T5>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, T5, TResult>(expr1, expr2, expr3, expr4, expr5, func1, func2, func3, func4, func5, error);
        }

        /// <summary>
        /// Create 5-Select Expression with Transform Functions
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, TResult> Create<T1, T2, T3, T4, T5>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, func1, func2, func3, func4, func5, null);
        }

        /// <summary>
        /// Create 5-Select Expression with Custom Exception
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, Echo, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 5-Select Expression
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, Echo, Echo, Echo, Echo, Echo, null);
        }

        /// <summary>
        /// Create 6-Select Expression with Transform Functions and Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, TResult> Create<T1, T2, T3, T4, T5, T6>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, T5, T6, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, func1, func2, func3, func4, func5, func6, error);
        }

        /// <summary>
        /// Create 6-Select Expression with Transform Functions
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, TResult> Create<T1, T2, T3, T4, T5, T6>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, func1, func2, func3, func4, func5, func6, null);
        }

        /// <summary>
        /// Create 6-Select Expression with Custom Exception
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, Echo, Echo, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 6-Select Expression
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, Echo, Echo, Echo, Echo, Echo, Echo, null);
        }

        /// <summary>
        /// Create 7-Select Expression with Transform Functions and Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, TResult> Create<T1, T2, T3, T4, T5, T6, T7>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, T5, T6, T7, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, func1, func2, func3, func4, func5, func6, func7, error);
        }

        /// <summary>
        /// Create 7-Select Expression with Transform Functions
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, TResult> Create<T1, T2, T3, T4, T5, T6, T7>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, func1, func2, func3, func4, func5, func6, func7, null);
        }

        /// <summary>
        /// Create 7-Select Expression with Custom Exception
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, Echo, Echo, Echo, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 7-Select Expression
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, Echo, Echo, Echo, Echo, Echo, Echo, Echo, null);
        }

        /// <summary>
        /// Create 8-Select Expression with Transform Functions and Custom Exception
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, func1, func2, func3, func4, func5, func6, func7, func8, error);
        }

        /// <summary>
        /// Create 8-Select Expression with Transform Functions
        /// </summary>
        /// <typeparam name="T1">1st Expression Return Type</typeparam>
        /// <typeparam name="T2">2nd Expression Return Type</typeparam>
        /// <typeparam name="T3">3rd Expression Return Type</typeparam>
        /// <typeparam name="T4">4th Expression Return Type</typeparam>
        /// <typeparam name="T5">5th Expression Return Type</typeparam>
        /// <typeparam name="T6">6th Expression Return Type</typeparam>
        /// <typeparam name="T7">7th Expression Return Type</typeparam>
        /// <typeparam name="T8">8th Expression Return Type</typeparam>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, func1, func2, func3, func4, func5, func6, func7, func8, null);
        }

        /// <summary>
        /// Create 8-Select Expression with Custom Exception
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 8-Select Expression
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, null);
        }

        /// <summary>
        /// Create 9-Select Expression with Transform Functions and Custom Exception
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
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, func1, func2, func3, func4, func5, func6, func7, func8, func9, error);
        }

        /// <summary>
        /// Create 9-Select Expression with Transform Functions
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
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, func1, func2, func3, func4, func5, func6, func7, func8, func9, null);
        }

        /// <summary>
        /// Create 9-Select Expression with Custom Exception
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 9-Select Expression
        /// </summary>
        /// <param name="expr1">1st Expression</param>
        /// <param name="expr2">2nd Expression</param>
        /// <param name="expr3">3rd Expression</param>
        /// <param name="expr4">4th Expression</param>
        /// <param name="expr5">5th Expression</param>
        /// <param name="expr6">6th Expression</param>
        /// <param name="expr7">7th Expression</param>
        /// <param name="expr8">8th Expression</param>
        /// <param name="expr9">9th Expression</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, null);
        }

        /// <summary>
        /// Create 10-Select Expression with Transform Functions and Custom Exception
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, error);
        }

        /// <summary>
        /// Create 10-Select Expression with Transform Functions
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, null);
        }

        /// <summary>
        /// Create 10-Select Expression with Custom Exception
        /// </summary>
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
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 10-Select Expression
        /// </summary>
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
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, null);
        }

        /// <summary>
        /// Create 11-Select Expression with Transform Functions and Custom Exception
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="func11">Transform Function that transform Return Value of 11th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, error);
        }

        /// <summary>
        /// Create 11-Select Expression with Transform Functions
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="func11">Transform Function that transform Return Value of 11th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, null);
        }

        /// <summary>
        /// Create 11-Select Expression with Custom Exception
        /// </summary>
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
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, ExpressionBase<TResult> expr11, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 11-Select Expression
        /// </summary>
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
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, ExpressionBase<TResult> expr11)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, null);
        }

        /// <summary>
        /// Create 12-Select Expression with Transform Functions and Custom Exception
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="func11">Transform Function that transform Return Value of 11th Expression to Result Value</param>
        /// <param name="func12">Transform Function that transform Return Value of 12th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<T12, TResult> func12, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, func12, error);
        }

        /// <summary>
        /// Create 12-Select Expression with Transform Functions
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="func11">Transform Function that transform Return Value of 11th Expression to Result Value</param>
        /// <param name="func12">Transform Function that transform Return Value of 12th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<T12, TResult> func12)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, func12, null);
        }

        /// <summary>
        /// Create 12-Select Expression with Custom Exception
        /// </summary>
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
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, ExpressionBase<TResult> expr11, ExpressionBase<TResult> expr12, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 12-Select Expression
        /// </summary>
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
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, ExpressionBase<TResult> expr11, ExpressionBase<TResult> expr12)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, null);
        }

        /// <summary>
        /// Create 13-Select Expression with Transform Functions and Custom Exception
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="func11">Transform Function that transform Return Value of 11th Expression to Result Value</param>
        /// <param name="func12">Transform Function that transform Return Value of 12th Expression to Result Value</param>
        /// <param name="func13">Transform Function that transform Return Value of 13th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<T12, TResult> func12, Func<T13, TResult> func13, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, func12, func13, error);
        }

        /// <summary>
        /// Create 13-Select Expression with Transform Functions
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="func11">Transform Function that transform Return Value of 11th Expression to Result Value</param>
        /// <param name="func12">Transform Function that transform Return Value of 12th Expression to Result Value</param>
        /// <param name="func13">Transform Function that transform Return Value of 13th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<T12, TResult> func12, Func<T13, TResult> func13)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, func12, func13, null);
        }

        /// <summary>
        /// Create 13-Select Expression with Custom Exception
        /// </summary>
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
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, ExpressionBase<TResult> expr11, ExpressionBase<TResult> expr12, ExpressionBase<TResult> expr13, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 13-Select Expression
        /// </summary>
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
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, ExpressionBase<TResult> expr11, ExpressionBase<TResult> expr12, ExpressionBase<TResult> expr13)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, null);
        }

        /// <summary>
        /// Create 14-Select Expression with Transform Functions and Custom Exception
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="func11">Transform Function that transform Return Value of 11th Expression to Result Value</param>
        /// <param name="func12">Transform Function that transform Return Value of 12th Expression to Result Value</param>
        /// <param name="func13">Transform Function that transform Return Value of 13th Expression to Result Value</param>
        /// <param name="func14">Transform Function that transform Return Value of 14th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<T12, TResult> func12, Func<T13, TResult> func13, Func<T14, TResult> func14, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, func12, func13, func14, error);
        }

        /// <summary>
        /// Create 14-Select Expression with Transform Functions
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="func11">Transform Function that transform Return Value of 11th Expression to Result Value</param>
        /// <param name="func12">Transform Function that transform Return Value of 12th Expression to Result Value</param>
        /// <param name="func13">Transform Function that transform Return Value of 13th Expression to Result Value</param>
        /// <param name="func14">Transform Function that transform Return Value of 14th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<T12, TResult> func12, Func<T13, TResult> func13, Func<T14, TResult> func14)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, func12, func13, func14, null);
        }

        /// <summary>
        /// Create 14-Select Expression with Custom Exception
        /// </summary>
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
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, ExpressionBase<TResult> expr11, ExpressionBase<TResult> expr12, ExpressionBase<TResult> expr13, ExpressionBase<TResult> expr14, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 14-Select Expression
        /// </summary>
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
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, ExpressionBase<TResult> expr11, ExpressionBase<TResult> expr12, ExpressionBase<TResult> expr13, ExpressionBase<TResult> expr14)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, null);
        }

        /// <summary>
        /// Create 15-Select Expression with Transform Functions and Custom Exception
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="func11">Transform Function that transform Return Value of 11th Expression to Result Value</param>
        /// <param name="func12">Transform Function that transform Return Value of 12th Expression to Result Value</param>
        /// <param name="func13">Transform Function that transform Return Value of 13th Expression to Result Value</param>
        /// <param name="func14">Transform Function that transform Return Value of 14th Expression to Result Value</param>
        /// <param name="func15">Transform Function that transform Return Value of 15th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, ExpressionBase<T15> expr15, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<T12, TResult> func12, Func<T13, TResult> func13, Func<T14, TResult> func14, Func<T15, TResult> func15, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, expr15, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, func12, func13, func14, func15, error);
        }

        /// <summary>
        /// Create 15-Select Expression with Transform Functions
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="func11">Transform Function that transform Return Value of 11th Expression to Result Value</param>
        /// <param name="func12">Transform Function that transform Return Value of 12th Expression to Result Value</param>
        /// <param name="func13">Transform Function that transform Return Value of 13th Expression to Result Value</param>
        /// <param name="func14">Transform Function that transform Return Value of 14th Expression to Result Value</param>
        /// <param name="func15">Transform Function that transform Return Value of 15th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, ExpressionBase<T15> expr15, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<T12, TResult> func12, Func<T13, TResult> func13, Func<T14, TResult> func14, Func<T15, TResult> func15)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, expr15, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, func12, func13, func14, func15, null);
        }

        /// <summary>
        /// Create 15-Select Expression with Custom Exception
        /// </summary>
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
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, ExpressionBase<TResult> expr11, ExpressionBase<TResult> expr12, ExpressionBase<TResult> expr13, ExpressionBase<TResult> expr14, ExpressionBase<TResult> expr15, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, expr15, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 15-Select Expression
        /// </summary>
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
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, ExpressionBase<TResult> expr11, ExpressionBase<TResult> expr12, ExpressionBase<TResult> expr13, ExpressionBase<TResult> expr14, ExpressionBase<TResult> expr15)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, expr15, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, null);
        }

        /// <summary>
        /// Create 16-Select Expression with Transform Functions and Custom Exception
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="func11">Transform Function that transform Return Value of 11th Expression to Result Value</param>
        /// <param name="func12">Transform Function that transform Return Value of 12th Expression to Result Value</param>
        /// <param name="func13">Transform Function that transform Return Value of 13th Expression to Result Value</param>
        /// <param name="func14">Transform Function that transform Return Value of 14th Expression to Result Value</param>
        /// <param name="func15">Transform Function that transform Return Value of 15th Expression to Result Value</param>
        /// <param name="func16">Transform Function that transform Return Value of 16th Expression to Result Value</param>
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, ExpressionBase<T15> expr15, ExpressionBase<T16> expr16, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<T12, TResult> func12, Func<T13, TResult> func13, Func<T14, TResult> func14, Func<T15, TResult> func15, Func<T16, TResult> func16, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return new Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, expr15, expr16, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, func12, func13, func14, func15, func16, error);
        }

        /// <summary>
        /// Create 16-Select Expression with Transform Functions
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
        /// <param name="func1">Transform Function that transform Return Value of 1st Expression to Result Value</param>
        /// <param name="func2">Transform Function that transform Return Value of 2nd Expression to Result Value</param>
        /// <param name="func3">Transform Function that transform Return Value of 3rd Expression to Result Value</param>
        /// <param name="func4">Transform Function that transform Return Value of 4th Expression to Result Value</param>
        /// <param name="func5">Transform Function that transform Return Value of 5th Expression to Result Value</param>
        /// <param name="func6">Transform Function that transform Return Value of 6th Expression to Result Value</param>
        /// <param name="func7">Transform Function that transform Return Value of 7th Expression to Result Value</param>
        /// <param name="func8">Transform Function that transform Return Value of 8th Expression to Result Value</param>
        /// <param name="func9">Transform Function that transform Return Value of 9th Expression to Result Value</param>
        /// <param name="func10">Transform Function that transform Return Value of 10th Expression to Result Value</param>
        /// <param name="func11">Transform Function that transform Return Value of 11th Expression to Result Value</param>
        /// <param name="func12">Transform Function that transform Return Value of 12th Expression to Result Value</param>
        /// <param name="func13">Transform Function that transform Return Value of 13th Expression to Result Value</param>
        /// <param name="func14">Transform Function that transform Return Value of 14th Expression to Result Value</param>
        /// <param name="func15">Transform Function that transform Return Value of 15th Expression to Result Value</param>
        /// <param name="func16">Transform Function that transform Return Value of 16th Expression to Result Value</param>
        /// <returns>Select Expression</returns>
        public static Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ExpressionBase<T1> expr1, ExpressionBase<T2> expr2, ExpressionBase<T3> expr3, ExpressionBase<T4> expr4, ExpressionBase<T5> expr5, ExpressionBase<T6> expr6, ExpressionBase<T7> expr7, ExpressionBase<T8> expr8, ExpressionBase<T9> expr9, ExpressionBase<T10> expr10, ExpressionBase<T11> expr11, ExpressionBase<T12> expr12, ExpressionBase<T13> expr13, ExpressionBase<T14> expr14, ExpressionBase<T15> expr15, ExpressionBase<T16> expr16, Func<T1, TResult> func1, Func<T2, TResult> func2, Func<T3, TResult> func3, Func<T4, TResult> func4, Func<T5, TResult> func5, Func<T6, TResult> func6, Func<T7, TResult> func7, Func<T8, TResult> func8, Func<T9, TResult> func9, Func<T10, TResult> func10, Func<T11, TResult> func11, Func<T12, TResult> func12, Func<T13, TResult> func13, Func<T14, TResult> func14, Func<T15, TResult> func15, Func<T16, TResult> func16)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, expr15, expr16, func1, func2, func3, func4, func5, func6, func7, func8, func9, func10, func11, func12, func13, func14, func15, func16, null);
        }

        /// <summary>
        /// Create 16-Select Expression with Custom Exception
        /// </summary>
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
        /// <param name="error">Function that return Custom Exception</param>
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, ExpressionBase<TResult> expr11, ExpressionBase<TResult> expr12, ExpressionBase<TResult> expr13, ExpressionBase<TResult> expr14, ExpressionBase<TResult> expr15, ExpressionBase<TResult> expr16, Func<ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, ParsingException, Exception> error)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, expr15, expr16, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, error);
        }

        /// <summary>
        /// Create 16-Select Expression
        /// </summary>
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
        /// <returns>Select Expression</returns>
        public static Select<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult, TResult> Create(ExpressionBase<TResult> expr1, ExpressionBase<TResult> expr2, ExpressionBase<TResult> expr3, ExpressionBase<TResult> expr4, ExpressionBase<TResult> expr5, ExpressionBase<TResult> expr6, ExpressionBase<TResult> expr7, ExpressionBase<TResult> expr8, ExpressionBase<TResult> expr9, ExpressionBase<TResult> expr10, ExpressionBase<TResult> expr11, ExpressionBase<TResult> expr12, ExpressionBase<TResult> expr13, ExpressionBase<TResult> expr14, ExpressionBase<TResult> expr15, ExpressionBase<TResult> expr16)
        {
            return Create(expr1, expr2, expr3, expr4, expr5, expr6, expr7, expr8, expr9, expr10, expr11, expr12, expr13, expr14, expr15, expr16, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, Echo, null);
        }
    }

    internal class SelectInstancedClass<TResult, ParseResult> : InstanceBase<TResult, ParseResult>
    {
        int[] exprIndexes;
        Func<object, TResult>[] funcs;
        Func<ParsingException[], Exception> error;
        int N;

        public SelectInstancedClass(int[] exprIndexes, Func<object, TResult>[] funcs, Func<ParsingException[], Exception> error, Parser<ParseResult> parser, int thisIndex) : base(parser, thisIndex)
        {
            this.exprIndexes = exprIndexes;
            this.funcs = funcs;
            this.error = error;
            this.N = this.exprIndexes.Length;
        }

        protected override Expected<TResult,ParsingException> ParseImplementation(string str, ref int index, List<ParsingException> exceptions, MemoDictionary memo)
        {
            var start = index;
            var selectExceptions = new ParsingException[this.N];
            foreach(var i in Range(this.N))
            {
                index = start;
                var val = this.Parser[this.exprIndexes[i]].Parse(str, ref index, exceptions, memo);
                if(val.TryGet(out var obj))
                {
                    return Success(this.funcs[i](obj));
                }
                else
                {
                    selectExceptions[i] = val.GetException();
                }
            }
            if(this.error is null)
            {
                exceptions.AddRange(selectExceptions);
                return Failure<TResult>(new ParsingException(index, new ArgumentException("All Expression don't match this string")));
            }
            else
            {
                return Failure<TResult>(new ParsingException(index, this.error(selectExceptions)));
            }
        }
    }
}