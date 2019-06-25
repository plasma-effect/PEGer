# PEGerについて
PEGerは[Parsing Expression Grammar](https://ja.wikipedia.org/wiki/Parsing_Expression_Grammar)に基づいた構文解析器を構成するために各種クラスを提供するライブラリである。  
構文解析に使用するための各Expressionクラスは1つの型を持ち、構文解析に成功したときその型の値を返す。そのために1つ以上の関数を持つ。

最初の例は空白区切りの2つの数字をパースし、その2つの和を返すExpressionである。
```csharp
var number = Regex<int>.Create(Number, (view, _) => int.Parse(view.ToString()));
var expr = Sequence<int>.Create(number, number, (a, b) => a + b);
var parser = Parser.Create(expr);
if (parser.Parse("11 39", out var ret, out _, out _))
{
    WriteLine(ret);
}
```
Regexは[TrueRegex](https://github.com/plasma-effect/TrueRegex)で表現された正規言語にマッチするかをチェックするExpressionであり、StringViewとintを引数とした関数を必要とする。ここでStringViewは新しく文字列をインスタンス化することなく部分文字列を表現するクラスである。実際に部分文字列を抽出するにはToStringメソッドが必要になる。  
SequenceはExpressionの連結を表現するExpressionであり、それらのExpressionの返り値を引数とする関数を必要とする。  
そしてParser.Create関数で構文解析器を構成する。引数は最初に評価されるExpressionである。構成される構文解析器は空白をスキップするような初期設定がなされている。これを無効にするには

Parse関数は文字列が完全にマッチするかをチェックしない。次のコードは上のコードと同様に"50"を出力する。
```csharp
var number = Regex<int>.Create(Number, (view, _) => int.Parse(view.ToString()));
var expr = Sequence<int>.Create(number, number, (a, b) => a + b);
var parser = Parser.Create(expr);
if (parser.Parse("11 39 90", out var ret, out _, out _))
{
    WriteLine(ret);
}
```
これを防ぐためにはParseFullMatch関数を使えばよい。例えば次のコードは何も出力されない。
```csharp
var number = Regex<int>.Create(Number, (view, _) => int.Parse(view.ToString()));
var expr = Sequence<int>.Create(number, number, (a, b) => a + b);
var parser = Parser.Create(expr);
if (parser.ParseFullMatch("11 39 90", out var ret, out _))
{
    WriteLine(ret);
}
```
逆にどこまで入力が消費されたかを確認したい場合は第4引数で受け取ることができる。
```csharp
var number = Regex<int>.Create(Number, (view, _) => int.Parse(view.ToString()));
var expr = Sequence<int>.Create(number, number, (a, b) => a + b);
var parser = Parser.Create(expr);
if (parser.Parse("11 39 90", out var ret, out _, out var end))
{
    WriteLine(ret);
    WriteLine(end);
}
```
より複雑な例を考えよう。次の例は\+と\*と括弧で構成された数式をパースし、計算の結果を返すExpressionである。
```csharp
int Mul(List<int> list, int v)
{
    foreach (var u in list)
    {
        v *= u;
    }
    return v;
}
int Sum(List<int> list, int v)
{
    foreach (var u in list)
    {
        v += u;
    }
    return v;
}
T Echo<T>(T v)
{
    return v;
}
T1 First<T1, T2>(T1 v1, T2 v2)
{
    return v1;
}
T2 Second<T1, T2, T3>(T1 v1, T2 v2, T3 v3)
{
    return v2;
}
var asterisk = String<string>.Create("*", _ => "*");
var plus = String<string>.Create("+", _ => "+");
var atomic = new Value<int>();
var number = Regex<int>.Create(Predefined.Number, (view, _) => int.Parse(view.ToString()));
var mul = Sequence<int>.Create(Repeat<List<int>>.Create(Sequence<int>.Create(atomic, asterisk, First), Echo), atomic, Mul);
var sum = Sequence<int>.Create(Repeat<List<int>>.Create(Sequence<int>.Create(mul, plus, First), Echo), mul, Sum);
var bracket = Sequence<int>.Create("(".ToExpr(), sum, ")".ToExpr(), Second);
atomic.Expr = Select<int>.Create(number, bracket, Echo, Echo);
var parser = Parser.Create(sum);
if (parser.Parse("1 + 2 * 3 * (4 + 5)", out var ret, out _, out _))
{
    WriteLine(ret);
}
```
Stringクラスは特定の文字列を表現するExpressionである。パースに成功した時、その最初のindexを引数とする関数が必要になる。  
ValueクラスはExpressionを1つ持つことができるが、その初期化を後回しにすることができるクラスである。これを利用して再帰的な構文を実現している。  
RepeatクラスはExpressionの繰り返しを表現するExpressionである。元のExpressionの返り値をListにしたものを引数とする関数が必要になる。  
SelectクラスはExpressionの選択を表現するExpressionである。PEGの定義に基づき、パースに成功したらそれより後ろのExpressionについては無視される。それぞれのExpressionに対し、そのExpressionの返り値を引数とする関数が必要になる。また、それらの関数の返り値の型は同じでなければならない。

ところで上の例ではRepeat ExpressionのListをそのまま返している。その場合Repeat Expressionには省略記法が用意されている。  
同様にSelect Expressionでもそのまま値を返している。これにも省略記法が用意されている。両方適用すると以下のように書くことができる。
```csharp
int Mul(List<int> list, int v)
{
    foreach (var u in list)
    {
        v *= u;
    }
    return v;
}
int Sum(List<int> list, int v)
{
    foreach (var u in list)
    {
        v += u;
    }
    return v;
}
T1 First<T1, T2>(T1 v1, T2 v2)
{
    return v1;
}
T2 Second<T1, T2, T3>(T1 v1, T2 v2, T3 v3)
{
    return v2;
}
var atomic = new Value<int>();
var number = Regex<int>.Create(Number, (view, _) => int.Parse(view.ToString()));
var mul = Sequence<int>.Create(Repeat.Create(Sequence<int>.Create(atomic, "*".ToExpr(), First)), atomic, Mul);
var sum = Sequence<int>.Create(Repeat.Create(Sequence<int>.Create(mul, "+".ToExpr(), First)), mul, Sum);
var bracket = Sequence<int>.Create("(".ToExpr(), sum, ")".ToExpr(), Second);
atomic.Expr = Select<int>.Create(number, bracket);
var parser = Parser.Create(sum);
if (parser.Parse("1 + 2 * 3 * (4 + 5)", out var ret, out _, out _))
{
    WriteLine(ret);
}
```
更にこの場合演算子オーバーロードを使って更に省略することができる。
```csharp
int Mul(List<int> list, int v)
{
    foreach (var u in list)
    {
        v *= u;
    }
    return v;
}
int Sum(List<int> list, int v)
{
    foreach (var u in list)
    {
        v += u;
    }
    return v;
}
T1 First<T1, T2>(T1 v1, T2 v2)
{
    return v1;
}
T2 Second<T1, T2, T3>(T1 v1, T2 v2, T3 v3)
{
    return v2;
}
var atomic = new Value<int>();
var number = Regex<int>.Create(Number, (view, _) => int.Parse(view.ToString()));
var mul = Sequence<int>.Create(~Sequence<int>.Create(atomic, "*".ToExpr(), First), atomic, Mul);
var sum = Sequence<int>.Create(~Sequence<int>.Create(mul, "+".ToExpr(), First), mul, Sum);
var bracket = Sequence<int>.Create("(".ToExpr(), sum, ")".ToExpr(), Second);
atomic.Expr = number | bracket;
var parser = Parser.Create(sum);
if (parser.Parse("1 + 2 * 3 * (4 + 5)", out var ret, out _, out _))
{
    WriteLine(ret);
}
```