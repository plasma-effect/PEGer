# class Regex\<T\> : ExpressionBase\<T\>
RegexはTrueRegexパッケージで定義されている正規表現を表現するExpressionである。TrueRegexの詳細は[TrueRegexのドキュメント](https://github.com/plasma-effect/TrueRegex/blob/master/Documents/Japanese.md)を参照。このクラスは以下の4つの情報を持つ。
- 対象となる正規表現。
- 解析に成功した場合に使われるFunc\<StringView, int, T\>型の変数。StringViewは文字列の所有権を持たずに文字列を参照するクラスである。解析に成功した部分文字列のStringViewと解析の開始のindexを渡し、その返り値を解析の結果として返す。
- 貪欲に解析するかのフラグ。trueの場合IRegex.LastMatchが、falseの場合IRegex.FirstMatchが用いられる。
- 解析に失敗した場合に使われるFunc\<Exception\>型の変数。引数を取らずに呼び出され、その返り値をParsingExceptionに包んだものを解析の結果として返す。

Regex\<T\>クラスのコンストラクタはinternal指定されている。実際に使う場合は以下のRegexクラスを経由する。
# static class Regex
Regex Expressionを構成するためのstaticクラスである。以下のメソッドを持つ。
## static Regex\<TResult\> Create\<TResult\>(IRegex regex, Func<StringView, int, TResult> func, Func\<Exception\> error, bool greedy = true)
上記の4要素を全て受け取りRegex Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = Regex.Create(TrueRegex.Predefined.Number,
        (view, _) => int.Parse(view.ToString()),
        () => new System.Exception("Fails"));
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
## static Regex\<TResult\> Create\<TResult\>(IRegex regex, Func\<StringView, int, TResult\> func, bool greedy = true)
デフォルトのエラー関数を設定してRegex Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = Regex.Create(TrueRegex.Predefined.Number,
        (view, _) => int.Parse(view.ToString()));
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
## static Regex\<StringView\> Create(IRegex regex, bool greedy = true)
正規表現のみを受け取りRegex Expressionを構成するメソッド。解析に成功した場合、成功した部分のStringViewを返す。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = Regex.Create(TrueRegex.Predefined.Number);
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
## static Regex\<StringView\> Create(IRegex regex, Func\<Exception\> error, bool greedy = true)
正規表現と解析に失敗した場合に呼ばれる関数を設定してRegex Expressionを構成するメソッド。解析に成功した場合、成功した部分のStringViewを返す。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = Regex.Create(TrueRegex.Predefined.Number,
        () => new System.Exception("Fails"));
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
## static Regex\<StringView\> ToExpr(this IRegex regex, bool greedy = true)
IRegexに対する拡張メソッド。上記のCreate(regex, greedy)と同じ処理を行う。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = TrueRegex.Predefined.Number.ToExpr();
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
## static Regex\<T\> ToExpr\<T\>(this IRegex regex, Func\<StringView, int, T\> func, bool greedy = true)
IRegexに対する拡張メソッド。上記のCreate(regex, func, greedy)と同じ処理を行う。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = TrueRegex.Predefined.Number.ToExpr((view, _) => int.Parse(view.ToString()));
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
## static Regex\<T\> ToExpr\<T\>(this IRegex regex, Func\<StringView, int, T\> func, Func\<Exception\> error, bool greedy = true)
IRegexに対する拡張メソッド。上記のCreate(regex, func, error, greedy)と同じ処理を行う。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()),
        () => new System.Exception("Fails"));
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