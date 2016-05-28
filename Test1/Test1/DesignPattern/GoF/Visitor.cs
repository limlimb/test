using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Test1.DesignPattern.GoF.Visitor;

// Visitor パターン
// 構造を表現するクラスと、それに対する処理を行うクラスを分離する
// この際、構造の方を変更することなく処理を追加できる
// (逆に言えば、構造を定義するクラスをほとんど変更しない場合が望ましい)
// 
// 複雑な構造をする複合オブジェクトに対する処理をするのに都合がいいため、Compositeパターンと相性がいい
// 
// 構造を把握していなければ処理がそもそも書けないので、依存関係にあると言える
// カプセル化の概念にも反する

namespace Test1.DesignPattern.GoF.Visitor
{
    interface IElement
    {
        void Accept(IVisitor visitor);
    }

    // Compositeパターン
    interface IKappa : IElement
    {
        void Add(IKappa kappa);
        int GetAmount();
    }

    class Kappas : IKappa
    {
        List<IKappa> list = new List<IKappa>();

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);

            foreach (var item in list)
                item.Accept(visitor);
        }

        public void Add(IKappa kappa) => list.Add(kappa);

        public int GetAmount()
        {
            var result = 0;
            foreach(var item in list)
            {
                result += item.GetAmount();
            }
            return result;
        }
    }

    class Kappa : IKappa
    {
        int efficiency;

        public Kappa()
        {
            // 仕事の効率性を乱数で決定
            efficiency = GetRandomInteger(1, 10);
        }

        // System.Security.Cryptographyクラスを利用した乱数生成機
        // [min, max]の範囲の整数が決定される
        int GetRandomInteger(int min, int max)
        {
            if (min == max) return min;
            var buffer = new byte[4];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
            }
            var divide = (double)BitConverter.ToUInt32(buffer, 0) / (UInt32.MaxValue + 1.0);
            var range = max - min + 1;
            var floor = (int)((long)Math.Floor(divide * range) + min);
            return floor;
        }

        public void Accept(IVisitor visitor) => visitor.Visit(this);

        public void Add(IKappa kappa)
        {
            throw new NotImplementedException();
        }

        public int GetAmount()
        {
            var amount = efficiency * 3;
            Console.WriteLine(amount + "本のきゅうりを収穫しました。");
            return amount;
        }
    }

    interface IVisitor
    {
        void Visit(Kappa kappa);
        void Visit(Kappas kappas);
    }

    class KappaVisitor : IVisitor
    {
        public int amount { get; private set; }

        public KappaVisitor()
        {
            amount = 0;
        }

        public void Visit(Kappas kappas)
        {
            // 実装しない
        }

        public void Visit(Kappa kappa) => amount += kappa.GetAmount();
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Visitor
    {
        const int KAPPA = 10;

        public static void Test()
        {
            Console.WriteLine("### Visitor");


            Console.WriteLine("かっぱを" + KAPPA + "人使役してきゅうりを収穫します。");
            var visitor = new KappaVisitor();
            var leader = new Kappas();
            for (int i = 0; i < KAPPA; ++i)
            {
                leader.Add(new Kappa());
            }

            leader.Accept(visitor);
            Console.WriteLine("きゅうりは全部で" + visitor.amount + "本収穫できました。");
        }
    }
}