# class Repeat\<T, TResult\> : ExpressionBase\<TResult\>
RepeatはExpressionの繰り返しを表すExpressionである。このクラスのインスタンスは以下の5つの情報を持つ。
- 繰り返しの対象となる返り値がTのExpression。
- 解析に成功した場合に使われるFunc\<List\<T\>, TResult\>型の変数。上のExpressionの返り値がListに格納されたものが渡され、その返り値を解析の結果として返す。
- 繰り返しの下限。繰り返しの回数がこの数値を下回った場合解析は失敗となる。
- 繰り返しの上限。繰り返しの回数がこの数値に到達した場合そこで解析を打ち切って成功したものと扱う。
- 繰り返しの回数が下限を下回った場合に呼ばれるFunc\<int, Exception\>型の変数。繰り返しの回数が渡され、その返り値をParsingExceptionで包んだものを解析の結果として返す。

Repeat\<T, TResult\>クラスのコンストラクタはinternal指定されている。実際に使う場合は以下のRepeatクラスを経由する。

# static class Repeat
Repeat Expressionを構成するためのstaticクラスである。以下のメソッドを持つ。
## static Repeat\<T, List\<T\>\> Create\<T\>(ExpressionBase\<T\> expr)
下限を0、上限をint.MaxValue、エラー関数をデフォルトのものとし、返り値はExpressionの返り値をListにしたものをそのまま返すRepeat Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Repeat.Create(baseExpr);
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
## static Repeat\<T, List\<T\>\> Create\<T\>(ExpressionBase\<T\> expr, int minCount)
下限を設定し、それ以外は上記のCreateメソッドと同じRepeat Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Repeat.Create(baseExpr, 3);
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
## static Repeat\<T, List\<T\>\> Create\<T\>(ExpressionBase\<T\> expr, int minCount, int maxCount)
下限と上限を設定し、それ以外は一番上のCreateメソッドと同じRepeat Expressionを構成する
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Repeat.Create(baseExpr, 3, 5);
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
## static Repeat\<T, List\<T\>\> Create\<T\>(ExpressionBase\<T\> expr, int minCount, Func\<int, Exception\> error)
下限と解析に失敗した場合(つまり繰り返しの回数が設定した下限を下回った場合)に呼ばれる関数を設定してRepeat Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Repeat.Create(baseExpr, 2, i => new System.Exception($"Fails: {i}"));
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
## static Repeat\<T, List\<T\>\> Create\<T\>(ExpressionBase\<T\> expr, int minCount, int maxCount, Func\<int, Exception\> error)
下限、上限、解析に失敗した場合に呼ばれる関数を設定してRepeat Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Repeat.Create(baseExpr, 2, 5, i => new System.Exception($"Fails: {i}"));
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
## static Repeat\<T, TResult\> Create\<T, TResult\>(ExpressionBase\<T\> expr, Func\<List\<T\>, TResult\> func, int minCount, int maxCount, Func\<int, Exception\> error)
全ての変数を設定してRepeat Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Repeat.Create(baseExpr, list => list.Sum(),
        2, 5, i => new System.Exception($"Fails: {i}"));
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
## static Repeat\<T, TResult\> Create\<T, TResult\>(ExpressionBase\<T\> expr, Func\<List\<T\>, TResult> func, int minCount, Func\<int, Exception\> error)
上限以外の変数を設定してRepeat Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Repeat.Create(baseExpr, list => list.Sum(),
        2, i => new System.Exception($"Fails: {i}"));
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
## static Repeat\<T, TResult\> Create\<T, TResult\>(ExpressionBase\<T\> expr, Func\<List\<T\>, TResult\> func, Func\<int, Exception\> error)
解析に成功した場合に呼ばれる関数と解析に失敗した場合に呼ばれる関数を設定してRepeat Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Repeat.Create(baseExpr, list => list.Sum(),
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
## static Repeat\<T, TResult\> Create\<T, TResult\>(ExpressionBase\<T\> expr, Func\<List\<T\>, TResult\> func, int minCount, int maxCount)
下限、上限、解析に成功した場合に呼ばれる関数を設定してRepeat Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Repeat.Create(baseExpr, list => list.Sum(), 2, 5);
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
## static Repeat\<T, TResult\> Create\<T, TResult\>(ExpressionBase\<T\> expr, Func\<List\<T\>, TResult\> func, int minCount)
下限と解析に成功した場合に呼ばれる関数を設定してRepeat Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Repeat.Create(baseExpr, list => list.Sum(), 2);
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
## static Repeat\<T, TResult\> Create\<T, TResult\>(ExpressionBase\<T\> expr, Func\<List\<T\>, TResult\> func)
解析に成功した場合に呼ばれる関数のみを設定してRepeat Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Repeat.Create(baseExpr, list => list.Sum());
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
## ToRepeat拡張メソッドについて
ExpressionBaseクラスに対してToRepeat拡張メソッドが定義されている。ToRepeat拡張メソッドの各オーバーロードは上記のCreateメソッドに対応している。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = baseExpr.ToRepeat(list => list.Sum());
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
## 演算子オーバーロードについて
ExpressionBaseクラスにはoperator\~がオーバーロードされている。返り値はRepeat.Create(expr)と同じである。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = ~baseExpr;
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