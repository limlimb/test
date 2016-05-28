using System;
using Test1.DesignPattern.GoF.Bridge;

// Bridge パターン
// あるクラスにおける機能拡張と実装を分離し、それらを独立して管理する(橋)
// 
// 具体的にはクラスにインターフェースを持たせる
// 機能追加はクラスの継承、機能実装はフィールドのインターフェースの実装で行う

namespace Test1.DesignPattern.GoF.Bridge
{
    interface IFeeling
    {
        void JikoShoukai();
    }

    class Mild : IFeeling
    {
        public Mild()
        {
            Console.WriteLine("おとなしい河童がやってきました。");
        }

        public void JikoShoukai() => Console.WriteLine("「わたしはおとなしい河童です。」");
    }

    class Salty : IFeeling
    {
        public Salty()
        {
            Console.WriteLine("気性の荒い河童がやってきました。");
        }

        public void JikoShoukai() => Console.WriteLine("「喋りかけないでくれる？」");
    }

    class Kappa
    {
        IFeeling feeling;

        public Kappa(IFeeling feeling)
        {
            this.feeling = feeling;
        }

        public void Talk() => feeling.JikoShoukai();
    }

    class NewKappa : Kappa
    {
        public NewKappa(IFeeling feeling) : base(feeling) { }

        public void Work() => Console.WriteLine("お仕事中");
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Bridge
    {
        public static void Test()
        {
            Console.WriteLine("### Bridge");

            var saltyKappa = new Kappa(new Salty());
            saltyKappa.Talk();

            Console.WriteLine();

            var mildKappa = new NewKappa(new Mild());
            mildKappa.Talk();
            mildKappa.Work();
        }
    }
}