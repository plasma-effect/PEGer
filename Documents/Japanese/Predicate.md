# class AndPredicate\<TResult\> : ExpressionBase\<TResult\>
AndPredicateは肯定的先読みを表すExpressionである。このクラスのインスタンスは1つのExpressionのみを持つ。

このExpressionでは解析に成功しても文字列は消費されない。ただExpressionの解析の結果が返されるだけである。

AndPredicate\<TResult\>クラスのコンストラクタはinternal指定されている。実際に使う場合は以下のAndPredicateクラスを経由する。
# static class AndPredicate
AndPredicate Expressionを構成するためのstaticクラスである。以下のメソッドを持つ。
## static AndPredicate\<TResult\> Create\<TResult\>(ExpressionBase\<TResult\> expr)
ExpressionをAndPredicate Expressionにする。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var expr = AndPredicate.Create(number);
    var parser = Parser.Create(expr);
    var str = ReadLine();
    if (parser.Parse(str, out var ret, out var exceptions, out var end))
    {
        WriteLine(ret);
        WriteLine(end);
    }
    else
    {
        foreach (var exc in exceptions)
        {
            WriteLine($"{exc.Index}: {exc.Exception.Message}");
        }
    }
}
```
---
# 演算子オーバーロードについて
ExpressionBaseクラスではoperator \! がオーバーロードされている。返り値はAndPredicate.Create(expr)と同じである。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var expr = !number;
    var parser = Parser.Create(expr);
    var str = ReadLine();
    if (parser.Parse(str, out var ret, out var exceptions, out var end))
    {
        WriteLine(ret);
        WriteLine(end);
    }
    else
    {
        foreach (var exc in exceptions)
        {
            WriteLine($"{exc.Index}: {exc.Exception.Message}");
        }
    }
}
```
---
# class NotPredicate\<T, TResult\> : ExpressionBase\<TResult\>
NotPredicateは否定的先読みを表すExpressionである。このクラスのインスタンスは以下の3つの情報を持つ。
- 元となるExpression
- Expressionの解析に**失敗した場合に**使われるFunc\<int, TResult\>型の変数。解析の開始のindexを渡し、その返り値を解析の結果として返す。
- Expressionの解析に**成功した場合に**使われるFunc\<int, Exception\>型の変数。解析の開始のindexを渡し、その返り値を解析の結果として返す。

このExpressionでは元のExpressionの解析に**失敗した場合**解析に成功したことになる。またその仕様上文字列は消費されない。

NotPredicate\<T, TResult\>クラスのコンストラクタはinternal指定されている。実際に使う場合は以下のNotPredicateクラスを経由する。
# static class NotPredicate
NotPredicate Expressionを構成するためのstaticクラスである。以下のメソッドを持つ。
## static NotPredicate\<T, TResult\> Create\<T, TResult\>(ExpressionBase\<T\> expr, Func\<int, TResult\> failure)
Expressionの解析に失敗した場合に呼ばれる関数を設定してNotPredicate Expressionを構成するメソッド。Expressionの解析に成功した場合はデフォルトのエラー関数が呼ばれる。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var expr = NotPredicate.Create(number, i => $"Success: {i}");
    var parser = Parser.Create(expr);
    var str = ReadLine();
    if (parser.Parse(str, out var ret, out var exceptions, out var end))
    {
        WriteLine(ret);
        WriteLine(end);
    }
    else
    {
        foreach (var exc in exceptions)
        {
            WriteLine($"{exc.Index}: {exc.Exception.Message}");
        }
    }
}
```
---

## static NotPredicate\<T, TResult\> Create\<T, TResult\>(ExpressionBase\<T\> expr, Func\<int, TResult\> failure, Func\<int, Exception\> error)
全ての変数を設定してNotPredicate Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var expr = NotPredicate.Create(number, i => $"Success: {i}",
        k => new System.Exception($"Fails: {k}"));
    var parser = Parser.Create(expr);
    var str = ReadLine();
    if (parser.Parse(str, out var ret, out var exceptions, out var end))
    {
        WriteLine(ret);
        WriteLine(end);
    }
    else
    {
        foreach (var exc in exceptions)
        {
            WriteLine($"{exc.Index}: {exc.Exception.Message}");
        }
    }
}
```
---

## static NotPredicate\<T, TResult\> Create\<T, TResult\>(ExpressionBase\<T\> expr, TResult failure)
Expressionの解析に失敗した場合に返される値を設定してNotPredicate Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var expr = NotPredicate.Create(number, "Success");
    var parser = Parser.Create(expr);
    var str = ReadLine();
    if (parser.Parse(str, out var ret, out var exceptions, out var end))
    {
        WriteLine(ret);
        WriteLine(end);
    }
    else
    {
        foreach (var exc in exceptions)
        {
            WriteLine($"{exc.Index}: {exc.Exception.Message}");
        }
    }
}
```
---

## static NotPredicate\<T, TResult\> Create\<T, TResult\>(ExpressionBase\<T\> expr, TResult failure, Func\<int, Exception\> error)
Expressionの解析に失敗した場合に返される値とエラー関数を設定してNotPredicate Expressionを構成する。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var expr = NotPredicate.Create(number, "Success",
        i => new System.Exception($"Fails: {i}"));
    var parser = Parser.Create(expr);
    var str = ReadLine();
    if (parser.Parse(str, out var ret, out var exceptions, out var end))
    {
        WriteLine(ret);
        WriteLine(end);
    }
    else
    {
        foreach (var exc in exceptions)
        {
            WriteLine($"{exc.Index}: {exc.Exception.Message}");
        }
    }
}
```
---

# Not拡張メソッドについて
ExpressionBaseに対してNot拡張メソッドが定義されている。Not拡張メソッドの各オーバーロードは上記のCreateメソッドに対応している。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var expr = number.Not("Success");
    var parser = Parser.Create(expr);
    var str = ReadLine();
    if (parser.Parse(str, out var ret, out var exceptions, out var end))
    {
        WriteLine(ret);
        WriteLine(end);
    }
    else
    {
        foreach (var exc in exceptions)
        {
            WriteLine($"{exc.Index}: {exc.Exception.Message}");
        }
    }
}
```