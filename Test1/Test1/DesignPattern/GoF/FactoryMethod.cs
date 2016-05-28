using System;
using Test1.DesignPattern.GoF.FactoryMethod;

// FacroryMethod パターン
// インスタンスの生成をnew演算子ではなくFactoryで行うようにする

namespace Test1.DesignPattern.GoF.FactoryMethod
{
    interface IFactory
    {
        IKappa Create();
    }

    class ThinFactory : IFactory
    {
        public IKappa Create() { return new ThinKappa(); }
    }

    class FatFactory : IFactory
    {
        public IKappa Create() { return new FatKappa(); }
    }

    interface IKappa
    {
        void Eat();
    }

    class FatKappa : IKappa
    {
        public void Eat() => Console.WriteLine("太った河童がきゅうりをむしゃむしゃ食べ始めました。");
    }

    class ThinKappa : IKappa
    {
        public void Eat() => Console.WriteLine("痩せた河童がきゅうりをぽりぽり食べ始めました。");
    }
}

namespace Test1.DesignPattern.Tester
{
    static class FactoryMethod
    {
        public static void Test()
        {
            Console.WriteLine("### FactoryMethod");

            IFactory factory;

            factory = new ThinFactory();
            var kappaChan = factory.Create();
            kappaChan.Eat();

            Console.WriteLine("--- Factoryの入れ替え");

            factory = new FatFactory();
            var kappaSan = factory.Create();
            kappaSan.Eat();
        }
    }
}