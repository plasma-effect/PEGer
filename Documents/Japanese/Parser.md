# ExpressionBase\<TResult\>
ExpressionBase\<TResult\>はTResult型の値を返すExpressionを表す抽象クラスである。全てのExpressionはこのクラスを継承する。  
ExpressionBaseには複数のメソッド、及び演算子オーバーロードが定義されているが、それらについては必要になったときに記述する。
# class Parser\<TResult\>
構文解析器を表すクラスである。ただしコンストラクタはinternal指定されており、インスタンス化するにはstatic class ParserのCreateメソッドを利用する(これについては後述)。Parser\<TResult\>クラスには以下のメソッドとプロパティが定義されている。
## public bool SpaceIgnore { get; set; }
空白をスキップするかのフラグを表すプロパティであり、デフォルトではtrueである。このプロパティがtrueであるとき、各Expressionに対し構文解析をする前にchar.IsWhiteSpaceメソッドがfalseを返すか文字列の末端に到達するまで文字列を消費する。

---
## public bool Parse(string str, out TResult ret, out List\<ParsingException\> exceptions, out int endPoint)
strの先頭から構文解析を行い、構文解析に成功したかどうかを返す。PEGの定義に従った構文解析を行うため、文字列全体が消費されるとは限らない。そのため、例えばプログラミング言語の構文解析の用途に用いる場合、後述のParseFullMatchメソッドを使うことを推奨する。出力変数に渡される値はこのメソッドの返り値によって異なる。
### trueの場合
- retにはExpressionごとに設定された返り値が渡される。
- exceptionsにはサイズ0のListが渡される。
- endPointには構文解析で消費された文字数が渡される。
### falseの場合
- retにはdefault(TResult)が渡される。
- exceptionsにはパースエラーを表すParsingExceptionクラスのListが渡される。Select ExpressionやContinue Expressionによって2つ以上のパースエラーが発生する可能性がある。
- endPointには-1が渡される。
---
## public bool ParseFullMatch(string str, out TResult ret, out List\<ParsingException\> exceptions)
strの先頭から構文解析を行い、構文解析に成功したかを返す。Parseメソッドとの違いは全ての文字列が消費されたかのチェックを行うことである。実際の処理としてはまずParseメソッドを呼び出し、その後SpaceIgnoreプロパティがtrueならchar.IsWhiteSpaceメソッドがfalseを返すか文字列の末端に到達するまで文字列を消費する。その後文字列が全て消費されているならtrueを返す。そうでない場合、つまりParseメソッドがfalseを返したか、消費されていない文字列が残っている場合falseを返す。

---
### ParseメソッドとParseFullMatchメソッドについて
ExpressionBaseクラスはParserクラスの変数とこの2つのメソッドを持ち、ParserクラスをCreateせず構文解析をすることができる。ただしSpaceIgnoreプロパティを変更することができず、したがって強制的に空白をスキップする。SpaceIgnoreをfalseにして構文解析を行いたい場合はParserクラスの値をインスタンス化する必要がある。

---
# static class Parser
Parser\<TResult\>クラスのインスタンスを構成するためのstaticクラスである。以下のメソッドを持つ。
## static Parser\<TResult\> Create\<TResult\>(ExpressionBase\<TResult\> expr)
exprで構文解析を行う構文解析器を返す。ジェネリックの型推論により明示的にTResultを書く必要はない。

---
# class ParsingException : Exception
構文解析に失敗したとき、その情報を格納をするために使うクラスである。以下のプロパティを持つ。
## int Index { get; }
構文解析に失敗した位置の情報を持つ。stringクラスとしてのstrのindexを持つので、例えば改行を含む文字列の場合、失敗した位置がわかりにくいことがありえる。それらに対する解決策は現状このライブラリで提供する予定はない。
## Exception Exception { get; }
エラーに関する情報を持つ。