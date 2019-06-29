# class Value\<T\> : ExpressionBase\<T\>
Valueは非終端記号を表すExpressionである。このクラスは1つのExpressionを持つが、そのExpressionを後から設定できる。これを利用して再帰的な構文を構成することができる。

Valueはpublic指定された、引数を取らないコンストラクタを持つ。パーサを構成する前にExprプロパティを設定しなければならない。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var value = new Value<int>();
    value.Expr = number.Next(
        "+".ToExpr().Next(value).ToExpr((a, v) => v).ToOptional(0)
        ).ToExpr((x, y) => x + y);
    var parser = Parser.Create(value);
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