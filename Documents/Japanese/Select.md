# class Select\<T1, T2, TResult\> : ExpressionBase\<TResult\>
SelectはExpressionの選択を表すExpressionである。PEGの定義に基づき先頭のExpressionから解析に成功するかをチェックし、解析に成功した場合そこでSelect Expressionの解析を打ち切る。したがって構文木に曖昧さは存在しない。このクラスのインスタンスは以下の5つの情報を持つ。
- 1つ目のExpression
- 2つ目のExpression
- 1つ目のExpressionの解析で成功した場合に使われるFunc\<T1, TResult\>型の変数。そのExpressionの返り値を渡し、その返り値を解析の結果として返す。
- 2つ目のExpressionの解析で成功した場合に使われるFunc\<T2, TResult\>型の変数。そのExpressionの返り値を渡し、その返り値を解析の結果として返す。
- 全てのExpressionで解析に失敗した場合に使われるFunc\<ParsingException, ParsingException, Exception\>型の変数。それらのエラーを全て渡し、その返り値をParsingExceptionクラスに包んで解析の結果として返す。

ジェネリックなSelectクラスは他に14個存在する(Expressionの数に対応している)。このドキュメントでは2個のSelectにのみ言及するが、他の14個も同様に実装されている。

5つ目の変数がFunc\<ParsingException[], Exception\>やFunc\<List\<ParsingException\>, Exception\>でないのは単なる設計ミスである(例えばSelect\<T1, T2, T3, TResult\>ではFunc\<ParsingException, ParsingException, ParsingException, Exception\>となる)。将来的に変更する可能性はあるが(その場合Func\<ParsingException[], Exception\>になるだろう)破壊的変更になるため当分の間は変更の予定はない。

Select\<T1, T2, TResult\>クラスのコンストラクタはinternal指定されている。実際に使う場合は以下のSelectクラスを経由する。
# static class Select
Select Expressionを構成するためのstaticクラスである。以下のメソッドを持つ。
## static Select\<T1, T2, TResult\> Create\<T1, T2, TResult\>(ExpressionBase\<T1\> expr1, ExpressionBase\<T2\> expr2, Func\<T1, TResult\> func1, Func\<T2, TResult\> func2, Func\<ParsingException, ParsingException, Exception\> error)
すべての変数を設定してSelect Expressionを構成するメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var name = TrueRegex.Predefined.Name.ToExpr(
        (view, _) => view.ToString());
    var expr = Select.Create(number, name,
        n => $"Number: {n}",
        s => $"Name: {s}",
        (e1, e2) => new System.Exception("Fails"));
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
同様のオーバーロードが14個(それぞれSelectの個数に対応している)が、それらについては省略する。

---
## static Select\<T1, T2, TResult\> Create\<T1, T2, TResult\>(ExpressionBase\<T1\> expr1, ExpressionBase\<T2\> expr2, Func\<T1, TResult\> func1, Func\<T2, TResult\> func2)
エラー関数を設定せずSelect Expressionを構成する。解析に失敗した場合、それぞれのExpressionのエラーが全てexceptionsに追加され、全てのExpressionで解析に失敗した旨のメッセージが設定されたExceptionを包んだParsingExceptionを解析の結果として返す。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => int.Parse(view.ToString()));
    var name = TrueRegex.Predefined.Name.ToExpr(
        (view, _) => view.ToString());
    var expr = Select.Create(number, name,
        n => $"Number: {n}",
        s => $"Name: {s}");
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
同様のオーバーロードが14個(それぞれSelectの個数に対応している)が、それらについては省略する。

---
# 演算子オーバーロードについて
対象となるExpressionが全て同じ型を返し、さらに「全てのExpressionについて、解析に成功した場合その返り値をそのままSelect Expressionの返り値にする」ことをしたい場合、ExpressionBaseに対しoperator \| を適用することができる。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var name = TrueRegex.Predefined.Name.ToExpr(
        (view, _) => view.ToString());
    var expr = number | name;
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
このoperator \| によって構成されるExpressionはSelectを継承した異なる型の値であり、以下の3つのメソッドを持つ(ここでは2個の場合のメソッドについて記述する)。
## Select\<T, T, TResult\> Change\<TResult\>(Func\<T, TResult\> func1, Func\<T, TResult\> func2, Func\<ParsingException, ParsingException, Exception\> error)
各Expressionに変換関数を与え、更にエラー関数を設定したSelect Expressionを返すメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var name = TrueRegex.Predefined.Name.ToExpr(
        (view, _) => view.ToString());
    var baseExpr = number | name;
    var expr = baseExpr.Change(
        n => $"Number: {n}",
        s => $"Name: {s}",
        (e0, e1) => new System.Exception("Fails"));
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
## Select\<T, T, TResult\> Change\<TResult\>(Func\<T, TResult\> func1, Func\<T, TResult\> func2)
各Expressionに変換関数を与えたSelect Expressionを返すメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var name = TrueRegex.Predefined.Name.ToExpr(
        (view, _) => view.ToString());
    var baseExpr = number | name;
    var expr = baseExpr.Change(
        n => $"Number: {n}",
        s => $"Name: {s}");
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
## Select\<T, T, T\> Change(Func\<ParsingException, ParsingException, Exception\> error)
エラー関数のみを設定したSelect Expressionを返すメソッド。
### 使用例
```csharp
static void Main(string[] args)
{
    var number = TrueRegex.Predefined.Number.ToExpr(
        (view, _) => view.ToString());
    var name = TrueRegex.Predefined.Name.ToExpr(
        (view, _) => view.ToString());
    var baseExpr = number | name;
    var expr = baseExpr.Change(
        (e0, e1) => new System.Exception("Fails"));
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