using System;
using Test1.DesignPattern.GoF.Adapter;

// Adapter パターン
// あるインターフェースを別のインターフェースに変換し、本来関連のないクラスとして使用する
// 継承するか委譲するかの2種類の実装方法がある

namespace Test1.DesignPattern.GoF.Adapter
{
    // 既存クラス
    class Kappa
    {
        public void Cry() => Console.WriteLine("昔ながらのかっぱっぱ");
    }

    #region 継承を使うパターン

    interface INewKappa
    {
        void NewCry();
    }

    class DeriveClass : Kappa, INewKappa
    {
        public void NewCry() => Cry();
    }

    #endregion

    #region 委譲を使うパターン

    abstract class DelegateBase
    {
        public abstract void NewCry();
    }

    class DelegateClass : DelegateBase
    {
        Kappa kappa;

        public DelegateClass()
        {
            kappa = new Kappa();
        }

        public override void NewCry() => kappa.Cry();
    }

    #endregion
}

namespace Test1.DesignPattern.Tester
{
    static class Adapter
    {
        public static void Test()
        {
            Console.WriteLine("### Adapter");

            Console.WriteLine("--- 既存のクラスをそのまま使う");
            var kappa = new Kappa();
            kappa.Cry();

            Console.WriteLine("--- 継承して新しいインターフェースから呼び出す");
            var kappa2 = new DeriveClass();
            kappa2.NewCry();

            Console.WriteLine("--- 委譲して新しいインターフェースから呼び出す");
            var kappa3 = new DelegateClass();
            kappa3.NewCry();
        }
    }
}