using System;
using Test1.DesignPattern.GoF.State;

// State パターン
// 状態を持つクラスを機能ごとに定義し、コンテキストに保持させる
// 利用者側はその状態を意識せず、コンテキストの同じメソッドを呼ぶ
// 
// 状態を表すクラスは状態を表すだけ(複数のインスタンスはいらない)なのでシングルトンで実装する
// 
// 利用者が直接利用するContextクラス内のif文を減らせるのが特徴

namespace Test1.DesignPattern.GoF.State
{
    public interface IState
    {
        void DoSomething(IContext context);
        void ShowStatus();
    }

    public class ThinState : IState
    {
        // シングルトン
        static IState state = new ThinState();
        ThinState() { }
        public static IState State => state;

        public void DoSomething(IContext context)
        {
            Console.WriteLine("きゅうりをいっぱい食べます。");
            context.ChangeState(FatState.State);
        }

        public void ShowStatus() => Console.WriteLine("状態: 痩せています。");
    }

    public class FatState : IState
    {
        // シングルトン
        static IState state = new FatState();
        FatState() { }
        public static IState State => state;

        public void DoSomething(IContext context)
        {
            Console.WriteLine("いっぱい泳ぎます。");
            context.ChangeState(ThinState.State);
        }

        public void ShowStatus() => Console.WriteLine("状態: 太っています。");
    }

    public interface IContext
    {
        void ChangeState(IState state);
        void DoSomething();
        void ShowStatus();
    }

    class Kappa : IContext
    {
        IState state;

        public Kappa(int weight)
        {
            // TODO: 便宜的に初期ステータスを設定するが、本来ここで具体的な数字により設定させたくない
            if (weight < 30 || weight > 70) throw new NotImplementedException();
            else if (weight <= 50) state = ThinState.State;
            else state = FatState.State;
        }

        public void ChangeState(IState state) => this.state = state;

        // 目標体重より現在の体重が軽ければ食事を、重ければ水泳をさせる
        public void DoSomething() => state.DoSomething(this);

        public void ShowStatus() => state.ShowStatus();
    }
}

namespace Test1.DesignPattern.Tester
{
    static class State
    {
        public static void Test()
        {
            Console.WriteLine("### State");

            var context = new Kappa(45);
            context.ShowStatus();
            context.DoSomething();
            context.ShowStatus();
            context.DoSomething();
            context.ShowStatus();
        }
    }
}