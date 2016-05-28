using System;
using Test1.DesignPattern.GoF.Strategy;

// Strategy パターン
// アルゴリズム(戦略)自体を、使用する側のインターフェースを変えることなく、代替可能にする
// (≒アルゴリズムをごっそり入れ替える)
// 
// 振る舞いのカプセル化を行えるほか、実行時に動的に差し替えられる
// 
// コンテキストに使いたいストラテジを設定して、コンテキストのメソッドから実行する。
// どのストラテジを設定するかをFactoryに任せるやり方もある(Factoryに引数を投げる)
// 
// アルゴリズムの詳細を動的に切り替える点でTemplate Methodと似ている
// サブクラスで定義した処理を、
//   単体で呼び出して意味がある(public) -> Strategy
//   単体では意味を成さず、複数のメソッドとの組み合わせで意味を成す(protected) -> Template Method
// と使い分ける

namespace Test1.DesignPattern.GoF.Strategy
{
    interface IStrategy
    {
        void SomethingAction();
    }

    class StrategyA : IStrategy
    {
        public void SomethingAction() => Console.WriteLine("相撲する。");
    }

    class StrategyB : IStrategy
    {
        public void SomethingAction() => Console.WriteLine("泳ぐ。");
    }

    class Context
    {
        IStrategy strategy;

        public Context(IStrategy strategy)
        {
            SetStrategy(strategy);
        }

        public void SetStrategy(IStrategy strategy) => this.strategy = strategy;

        public void DoAction() => strategy.SomethingAction();
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Strategy
    {
        public static void Test()
        {
            Console.WriteLine("### Strategy");

            var context = new Context(new StrategyA());
            context.DoAction();
            context.SetStrategy(new StrategyB());
            context.DoAction();
        }
    }
}