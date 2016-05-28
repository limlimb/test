using System;
using Test1.DesignPattern.GoF.AbstractFactory;

// AbstractFactory パターン
// 関連のある、または整合性を要する複数のオブジェクトを安定して生成する
// 
// FactoryMethodは「オブジェクトの生成」の抽象化、
// AbstractFactoryは「関連するオブジェクトをまとめて生成するための手順」の抽象化

namespace Test1.DesignPattern.GoF.AbstractFactory
{
    interface IFactory
    {
        ICucumber cucumberFactory();
        IKappa kappaFactory();
    }

    class FatFactory : IFactory
    {
        public ICucumber cucumberFactory()=> new Morokyu();

        public IKappa kappaFactory() => new FatKappa();
    }

    class ThinFactory : IFactory
    {
        public ICucumber cucumberFactory() => new Shioduke();

        public IKappa kappaFactory() => new ThinKappa();
    }

    interface ICucumber
    {
        void Taste();
    }

    class Morokyu : ICucumber
    {
        public void Taste() => Console.WriteLine("今日はこの味噌に決まり");
    }

    class Shioduke : ICucumber
    {
        public void Taste() => Console.WriteLine("しょっぱいのがいいんだよ");
    }

    interface IKappa
    {
        void JikoShoukai();
    }

    class FatKappa : IKappa
    {
        public void JikoShoukai() => Console.WriteLine("もろきゅーが食べたい");
    }

    class ThinKappa : IKappa
    {
        public void JikoShoukai() => Console.WriteLine("塩漬けきゅうりが食べたいわ");
    }
}

namespace Test1.DesignPattern.Tester
{
    static class AbstractFactory
    {
        public static void Test()
        {
            Console.WriteLine("### AbstractFactory");

            IFactory factory;
            IKappa kappa;
            ICucumber cucumber;

            factory = new ThinFactory();
            kappa = factory.kappaFactory();
            cucumber = factory.cucumberFactory();
            kappa.JikoShoukai();
            cucumber.Taste();

            Console.WriteLine("--- Factoryの入れ替え");

            factory = new FatFactory();
            kappa = factory.kappaFactory();
            cucumber = factory.cucumberFactory();
            kappa.JikoShoukai();
            cucumber.Taste();
        }
    }
}