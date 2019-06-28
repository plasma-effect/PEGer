# class String\<TResult\> : ExpressionBase\<TResult\>
Stringは特定の文字列を表すExpressionである。このクラスのインスタンスは以下の3つの情報を持つ。
- 対象となる文字列。
- 解析に成功したときに使われるFunc\<int, TResult\>型の変数。文字列の先頭にあたるindexを渡し、その返り値を解析の結果として返す。
- 解析に失敗したときに使われるFunc\<int, Exception\>型の変数。このクラスの文字列でのindexを渡し、その返り値をParsingExceptionクラスに包んで解析の結果として返す。

String\<TResult\>クラスのコンストラクタはinternal指定されている。実際に使う場合は以下のStringクラスを経由する。

# static class String
String Expressionを構成するためのstaticクラスである。以下のメソッドを持つ。
## static String\<TResult\> Create\<TResult\>(string str, Func\<int, TResult\> func)
デフォルトのエラー関数を設定してString Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = String.Create("Hello", index => $"OK: {index}");
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
## static String\<TResult\> Create\<TResult\>(string str, Func\<int, TResult\> func, Func\<int, Exception\> error)
全ての変数を設定してString Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = String.Create("Hello", index => $"OK: {index}", i => new System.Exception($"NG: {i}"));
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
## static String\<string\> Create(string str)
文字列のみを設定してString Expressionを構成するメソッド。解析に成功した場合strが返される。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = String.Create("Hello");
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
## static String\<string\> Create(string str, Func\<int, Exception\> error)
文字列と解析に失敗した場合に呼ばれる関数を設定してString Expressionを構成するメソッド。解析に成功した場合strが返される。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = String.Create("Hello", i => new System.Exception($"NG: {i}"));
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
## static String\<string\> ToExpr(this string str)
stringに対する拡張メソッド。上記のCreate(string str)と同じ処理を行う。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = "Hello".ToExpr();
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
## static String\<T\> ToExpr\<T\>(this string str, Func\<int, T\> func)
stringに対する拡張メソッド。上記のCreate(string, Func\<int, TResult\>)と同じ処理を行う。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = "Hello".ToExpr(i => $"OK: {i}");
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
## static String\<T\> ToExpr\<T\>(this string str, Func\<int, T\> func, Func\<int, Exception\> error)
stringに対する拡張メソッド。上記のCreate(string, Func\<int, TResult\>, Func\<int, Exception\>)と同じ処理を行う。
### 使用例
```csharp
static void Main(string[] args)
{
    var expr = "Hello".ToExpr(i => $"OK: {i}", n => new System.Exception($"NG: {n}"));
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