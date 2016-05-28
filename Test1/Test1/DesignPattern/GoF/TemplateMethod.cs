using System;
using Test1.DesignPattern.GoF.TemplateMethod;

// Template Method パターン
// アルゴリズムの骨組み(スケルトン)だけを定義し、その中のステップをサブクラスで再定義する
// 
// アルゴリズムの詳細を動的に切り替える点でStrategyと似ている
// サブクラスで定義した処理を、
//   単体で呼び出して意味がある(public) -> Strategy
//   単体では意味を成さず、複数のメソッドとの組み合わせで意味を成す(protected) -> Template Method
// と使い分ける

namespace Test1.DesignPattern.GoF.TemplateMethod
{
    public abstract class TemplateBase
    {
        // 作業1->休憩->作業2 という骨組みを定義
        // 
        // TODO: メソッドだけを継承禁止にするためにJavaならfinalが使えたが、
        // C#ではここではoverrideしたメソッドではないのでsealedが使えない
        public void TemplateMethod()
        {
            Work1();
            Console.WriteLine("--- ちょっと一息");
            Work2();
        }

        // TemplateMethod内でしか使わない(意味を成さない)メソッドなのでprotected指定
        protected abstract void Work1();
        protected abstract void Work2();
    }

    public class FarmTemplate : TemplateBase
    {
        protected override void Work1() => Console.WriteLine("きゅうり畑を耕します。");

        protected override void Work2() => Console.WriteLine("きゅうりの苗を植えましょう。");
    }

    public class SomethingTemplate : TemplateBase
    {
        protected override void Work1() => Console.WriteLine("なんかの作業の前準備をします。");

        protected override void Work2() => Console.WriteLine("いよいよ本格的な作業が始まります。");
    }
}

namespace Test1.DesignPattern.Tester
{
    static class TemplateMethod
    {
        public static void Test()
        {
            Console.WriteLine("### TemplateMethod");

            var temp = new FarmTemplate();
            temp.TemplateMethod();

            Console.WriteLine();

            var temp2 = new SomethingTemplate();
            temp2.TemplateMethod();
        }
    }
}