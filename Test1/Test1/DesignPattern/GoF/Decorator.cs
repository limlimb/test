using System;
using Test1.DesignPattern.GoF.Decorator;

// Decorator パターン
// ある核となるオブジェクトに対し、動的に機能を追加する
// 
// 初期段階でクラスに機能を付けすぎず、後から必要な時に追加するということが可能になる
// 
// Decoratorは機能の追加、
// Proxyは代理で処理をすることでの負荷の軽減 にそれぞれ重点を置く

namespace Test1.DesignPattern.GoF.Decorator
{
    interface IKappa
    {
        void Work();
    }

    class OriginalKappa : IKappa
    {
        public OriginalKappa()
        {
            Console.WriteLine("古い河童がやってきました。");
        }

        public void Work() => Console.WriteLine("ダム建設疲れました…");
    }

    abstract class DecoratorKappa : IKappa
    {
        protected IKappa kappa;

        public DecoratorKappa(IKappa kappa)
        {
            this.kappa = kappa;
        }

        public abstract void Work();
    }

    class NewKappa : DecoratorKappa
    {
        public NewKappa(IKappa kappa) : base(kappa)
        {
            Console.WriteLine("若い河童がやってきました");
        }

        public override void Work()
        {
            kappa.Work();
            Console.WriteLine("尻子玉でも食べて休憩しよ");
        }
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Decorator
    {
        public static void Test()
        {
            Console.WriteLine("### Decorator");

            var oldKappa = new OriginalKappa();
            oldKappa.Work();

            Console.WriteLine();

            var newKappa = new NewKappa(oldKappa);
            newKappa.Work();
        }
    }
}