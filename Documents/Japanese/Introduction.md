# PEGerについて
PEGerは[Parsing Expression Grammar](https://ja.wikipedia.org/wiki/Parsing_Expression_Grammar)に基づいた構文解析器を構成するために各種クラスを提供するライブラリである。  
構文解析に使用するための各Expressionクラスは1つの型を持ち、構文解析に成功したときその型の値を返す。そのために1つ以上の関数を持つ。

最初の例は空白区切りの2つの数字をパースし、その2つの和を返すExpressionである。
```csharp
var number = Regex.Create(Number, (view, _) => int.Parse(view.ToString()));
var expr = Sequence.Create(number, number, (a, b) => a + b);
var parser = Parser.Create(expr);
if (parser.Parse("11 39", out var ret, out _, out _))
{
    WriteLine(ret);
}
```
Regexは[TrueRegex](https://github.com/plasma-effect/TrueRegex)で表現された正規言語にマッチするかをチェックするExpressionであり、StringViewとintを引数とした関数を必要とする。ここでStringViewは新しく文字列をインスタンス化することなく部分文字列を表現するクラスである。実際に部分文字列を抽出するにはToStringメソッドが必要になる(ただしUtilityLibraryパッケージの0.0.9以上ではstringへの暗黙変換が定義されている)。またデフォルトではIRegex.LastMatchメソッドを用いており(つまり最長マッチを返す)、Create関数のgreedy引数をfalseにすることでIRegex.FirstMatchを用いるようにすることができる。  
SequenceはExpressionの連結を表現するExpressionであり、それらのExpressionの返り値を引数とする関数を必要とする。  
そしてParser.Create関数で構文解析器を構成する。引数は最初に評価されるExpressionである。構成される構文解析器は空白をスキップするような初期設定がなされている。これを無効にするにはSpaceIgnoreプロパティをfalseに設定する。

Parse関数は文字列が完全にマッチするかをチェックしない。次のコードは上のコードと同様に"50"を出力する。
```csharp
var number = Regex.Create(Number, (view, _) => int.Parse(view.ToString()));
var expr = Sequence.Create(number, number, (a, b) => a + b);
var parser = Parser.Create(expr);
if (parser.Parse("11 39 99", out var ret, out _, out _))
{
    WriteLine(ret);
}
```
これを防ぐためにはParseFullMatch関数を使えばよい。例えば次のコードは何も出力されない。
```csharp
var number = Regex.Create(Number, (view, _) => int.Parse(view.ToString()));
var expr = Sequence.Create(number, number, (a, b) => a + b);
var parser = Parser.Create(expr);
if (parser.ParseFullMatch("11 39 99", out var ret, out _))
{
    WriteLine(ret);
}
```
逆にどこまで入力が消費されたかを確認したい場合は第4引数で受け取ることができる。
```csharp
var number = Regex.Create(Number, (view, _) => int.Parse(view.ToString()));
var expr = Sequence.Create(number, number, (a, b) => a + b);
var parser = Parser.Create(expr);
if (parser.Parse("11 39 99", out var ret, out _, out var end))
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
var asterisk = String.Create("*", _ => "*");
var plus = String.Create("+", _ => "+");
var atomic = new Value<int>();
var number = Regex.Create(TrueRegex.Predefined.Number, (view, _) => int.Parse(view.ToString()));
var mul = Sequence.Create(Repeat.Create(Sequence.Create(atomic, asterisk, First), Echo), atomic, Mul);
var sum = Sequence.Create(Repeat.Create(Sequence.Create(mul, plus, First), Echo), mul, Sum);
var bracket = Sequence.Create("(".ToExpr(), sum, ")".ToExpr(), Second);
atomic.Expr = Select.Create(number, bracket, Echo, Echo);
var parser = Parser.Create(sum);
if (parser.Parse("1 + 2 * 3 * (4 + 5)", out var ret, out _, out _))
{
    WriteLine(ret);
}
```
Stringは特定の文字列を表現するExpressionである。パース対象の文字列内での1文字目のindexを引数とする関数が必要になる。  
ValueはExpressionを1つ持つことができるが、その初期化を後回しにすることができるExpressionである。これを利用して再帰的な構文を実現している。  
RepeatはExpressionの繰り返しを表現するExpressionである。元のExpressionの返り値をListにしたものを引数とする関数が必要になる。  
SelectはExpressionの選択を表現するExpressionである。PEGの定義に基づき、パースに成功したらそれより後ろのExpressionについては無視される。それぞれのExpressionに対し、そのExpressionの返り値を引数とする関数が必要になる。また、それらの関数の返り値の型は同じでなければならない。

上の例ではStringクラスは自身が持つ文字列をそのまま返している。この場合stringに対する拡張メソッドを使うことができる。  
またRepeat ExpressionはListをそのまま返している。この場合演算子オーバーロードを使って定義を省略することができる。  
同様にSelect Expressionもそのまま値を返している。これにも演算子オーバーロードが用意されている。全て適用すると以下のように書くことができる。
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
var number = Regex.Create(TrueRegex.Predefined.Number, (view, _) => int.Parse(view.ToString()));
var mul = Sequence.Create(~Sequence.Create(atomic, "*".ToExpr(), First), atomic, Mul);
var sum = Sequence.Create(~Sequence.Create(mul, "+".ToExpr(), First), mul, Sum);
var bracket = Sequence.Create("(".ToExpr(), sum, ")".ToExpr(), Second);
atomic.Expr = number | bracket;
var parser = Parser.Create(sum);
if (parser.Parse("1 + 2 * 3 * (4 + 5)", out var ret, out _, out _))
{
    WriteLine(ret);
}
```
stringに対して拡張メソッドToExpr()を使うと、パースに成功した時その文字列を返すExpressionに変換することができる。  
Expressionに対し単項演算子\~を使うとRepeat Expressionに変換することができる。  
同じ型を持つExpressionに対し二項演算子 \| を使うとSelect Expressionに変換することができる。

Sequence ExpressionとSelect Expressionは16個までつなげることができる。これはSystem.Funcジェネリッククラスの制約の問題でそういう仕様になっている。

もう一つ例をあげよう。{a^n b^n c^n: n ≧ 1}は文脈自由でないがPEGでパースできる言語の例として有名である。これは次のコードで実現できる。
```csharp
bool Ignore2<T1, T2>(T1 v1, T2 v2)
{
    return true;
}
bool Ignore3<T1, T2, T3>(T1 v1, T2 v2, T3 v3)
{
    return true;
}
var S = new Value<bool>();
var A = new Value<bool>();
var B = new Value<bool>();
var a = "a".ToExpr(_ => true);
var b = "b".ToExpr(_ => true);
var c = "c".ToExpr(_ => true);
Func<ExpressionBase<bool>, ExpressionBase<bool>> And = AndPredicate.Create;
Func<ExpressionBase<bool>, ExpressionBase<bool>> Not = expr => NotPredicate.Create(expr, _ => true);
S.Expr = Sequence.Create(And(Sequence.Create(A, Not(b), Ignore2)), ~a, B, Ignore3);
A.Expr = Sequence.Create(a, A.ToOptional(true), b, Ignore3);
B.Expr = Sequence.Create(b, B.ToOptional(true), c, Ignore3);
var parser = Parser.Create(S);
parser.SpaceIgnore = false;
if (parser.ParseFullMatch("aaabbbccc", out _, out _))
{
    WriteLine("OK");
}
```
AndPredicateとNotPredicateは共に先読みを実現するためのExpressionであり、入力を消費しない。  
AndPredicateは肯定的な先読みである。Expressionを一つ持ち、そのExpressionのパースに成功したとき、その返り値をそのまま返し、パースの対象となるindexを元の位置に戻すExpressionである。  
NotPredicateは否定的な先読みである。Expressionを一つ持ち、そのExpressionのパースが失敗したとき、そのパースが開始された位置を引数とする関数の返り値を返すExpressionである。逆に元のExpressionのパースが成功したとき、NotPredicateのパースは失敗する。  
Optionalは省略可能なExpressionである。Expression一つと、引数を取らずそのExpressionの返り値を返す関数を持ち、パースに失敗したときその関数を評価した返り値を返す。任意のExpressionはToOptionalメソッドを持ち、パースに失敗したときその引数を返すOptional Expressionに変換することができる。