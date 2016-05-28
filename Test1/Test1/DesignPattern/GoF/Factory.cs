using System;
using Test1.DesignPattern.GoF.Factory;

// Factory パターン
// インスタンスの生成をnew演算子ではなく、Factoryに委譲する
// 
// ある1つのFactoryに対して生成の要請をし、内部の実装はif-elseまたはswitchで構成される
// 
// メモ: FactoryMethodともAbstractFactoryとも違うパターン
// GoF外で言及されてるパターンかもしれない

namespace Test1.DesignPattern.GoF.Factory
{
    static class KappaFactory
    {
        public static IKappa Create(int weight)
        {
            if (weight <= 40)
            {
                throw new ArgumentException();
            }
            else if (weight <= 50)
            {
                return new ThinKappa();
            }
            else
            {
                return new FatKappa();
            }
        }
    }

    interface IKappa
    {
        void Jikoshoukai();
    }

    class ThinKappa : IKappa
    {
        public void Jikoshoukai() => Console.WriteLine("痩せてる河童です。");
    }

    class FatKappa : IKappa
    {
        public void Jikoshoukai() => Console.WriteLine("太ってる河童です。");
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Factory
    {
        public static void Test()
        {
            Console.WriteLine("### Factory");

            var kappa = KappaFactory.Create(45);
            kappa.Jikoshoukai();

            kappa = KappaFactory.Create(55);
            kappa.Jikoshoukai();
        }
    }
}