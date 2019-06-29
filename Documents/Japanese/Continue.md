# class Continue\<T\> : ExpressionBase\<T\>
ContinueはSequence、Repeat内で「失敗しても解析を続行すること」を表明するExpressionである。このExpressionはパースエラーの解析に役立つ。

Continue\<T\>クラスのコンストラクタはinternal指定されている。実際に使う場合は以下のContinueクラスを経由する。
# static class Continue
Continue Expressionを構成するためのstaticクラスである。以下のメソッドを持つ。
## static Continue\<T\> Create\<T\>(ExpressionBase\<T\> expr)
exprをContinue Expressionにするメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var name = TrueRegex.Predefined.Name.ToExpr();
    var expr = Repeat.Create(
        (!name).Next(Continue.Create(!number)).Next(name).ToExpr((a, b, c) => b),
        list => list.Sum());
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