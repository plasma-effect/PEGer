# class Optional\<T, TResult\> : ExpressionBase\<TResult\>
Optionalは省略可能であることを表すExpressionである。このクラスのインスタンスは以下の3つの情報を持つ。
- ベースとなるExpression(返り値はT)
- Expressionの解析に成功した場合に使われるFunc\<T, TResult\>型の変数。Expressionの返り値を渡し、その返り値を解析の結果として返す。
- Expressionの解析に失敗した場合に使われるFunc\<TResult\>型の変数。その返り値を解析の結果として返す。

Optional\<T, TResult\>クラスのコンストラクタはinternal指定されている。実際に使う場合は以下のOptionalクラスを経由する。

# static class Optional
Optional Expressionを構成するためのstaticクラスである。以下のメソッドを持つ。

## static Optional\<T, TResult\> Create\<T, TResult\>(ExpressionBase\<T\> expr, Func\<T, TResult\> success, Func\<TResult\> failure)
3つの変数を全て指定してOptional Expressionを構成する。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var expr = Optional.Create(number, s => int.Parse(s), () => -1);
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
## static Optional\<T, T\> Create\<T\>(ExpressionBase\<T\> expr, Func\<T\> failure)
失敗した場合に呼ばれる関数を設定してOptional Expressionを構成するメソッド。成功した場合はExpressionの返り値がそのまま返される。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var expr = Optional.Create(number, () => "Not Number");
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
## static Optional\<T, T\> Create\<T\>(ExpressionBase\<T\> expr, T failure)
失敗した場合に返される値を設定してOptional Expressionを構成するメソッド。成功した場合はExpressionの返り値がそのまま返され、失敗した場合はfailureが返される。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var expr = Optional.Create(number, "Not Number");
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
# ToOptional拡張メソッドについて
ExpressionBaseに対してToOptional拡張メソッドが定義されている。ToOptional拡張メソッドの各オーバーロードは上記のCreateメソッドに対応している。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var expr = number.ToOptional("Not Number");
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