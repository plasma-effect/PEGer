# class Sequence\<T1, T2, TResult\> : ExpressionBase\<TResult\>
2つのExpressionの連結を表すExpressionである。このクラスのインスタンスは以下の4つの情報を持つ。
- 1つ目のExpression
- 2つ目のExpression
- 解析に成功した場合に使われるFunc\<T1, T2, TResult\>型の変数。2つのExpressionの返り値を引数に取り、その返り値を解析の結果として返す。
- 解析に失敗した場合に使われるFunc\<ParsingException, int, Exception\>型の変数。第1引数にはそのパースエラーが、第2引数は解析に失敗したExpressionの番号(0-indexedであることに注意)が渡され、その返り値をParsingExceptionクラスに包んで解析の結果として返す。

ジェネリックなSequenceクラスは他に14個ある(Sequenceの長さに対応している、最長で16個連結である)。このドキュメントでは長さ2のSequence Expressionのみに言及するが、他の14個も同様に実装されている。

Sequence\<T1, T2, TResult\>クラスのコンストラクタはinternal指定されている。実際に使う場合は以下のSequenceクラスを経由する。
# static class Sequence
Sequence Expressionを構成するためのstaticクラスである。以下のメソッドを持つ。
## static Sequence\<T1, T2, TResult\> Create\<T1, T2, TResult\>(ExpressionBase\<T1\> expr1, ExpressionBase\<T2\> expr2, Func\<T1, T2, TResult\> func, Func\<ParsingException, int, Exception\> error)
全ての変数を設定してSequence Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Sequence.Create(baseExpr, baseExpr, (a, b) => a + b,
        (error, i) => new System.Exception($"Fails: {i + 1}"));
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
同様のオーバーロードが14個(それぞれSequenceの長さに対応している)が、それらについては省略する。

---
## static Sequence\<T1, T2, TResult\> Create\<T1, T2, TResult\>(ExpressionBase\<T1\> expr1, ExpressionBase\<T2\> expr2, Func\<T1, T2, TResult\> func)
デフォルトのエラー関数を設定してSequence Expressionを構成するメソッド。解析に失敗した場合、そのエラーがそのまま返される。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = Sequence.Create(baseExpr, baseExpr, (a, b) => a + b);
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
同様のオーバーロードが14個(それぞれSequenceの長さに対応している)が、それらについては省略する。

---
# ExpressionBase.NextメソッドとMakeSequenceクラスについて
Sequenceクラスのための演算子オーバーロードは、C#の演算子オーバーロードの制約上用意されていない。その代わりにExpressionBaseクラスにはNextメソッドが定義されている。Nextメソッドの返り値はMakeSequenceクラスであり、これはSequenceクラスのインスタンスを構成する補助のためのクラスである。  
MakeSequenceクラス自体はExpressionでない。Sequence Expressionに変換するにはToExprメソッドを用いる。例えば長さ2のMakeSequenceクラスには以下の2つのToExprメソッドが定義されている。
## Sequence\<T1, T2, TResult\> ToExpr\<TResult\>(Func<T1, T2, TResult\> func)
エラー関数を設定せずSequence Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = baseExpr.Next(baseExpr).ToExpr((a, b) => a + b);
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
## Sequence\<T1, T2, TResult\> ToExpr\<TResult\>(Func\<T1, T2, TResult\> func, Func\<ParsingException, int, Exception\> error)
エラー関数も設定してSequence Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = baseExpr.Next(baseExpr).ToExpr((a, b) => a + b,
        (error, i) => new System.Exception($"Fails: {i + 1}"));
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
長さが15以下であるMakeSequenceクラスにはNextメソッドが存在する。例えば長さが2であるMakeSequenceのNextメソッドから長さが3であるMakeSequenceを構成することができる。
### 使用例
```csharp
static void Main(string[] args)
{
    var baseExpr = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var expr = baseExpr.Next(baseExpr).Next(baseExpr).ToExpr((a, b, c) => a + b + c);
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