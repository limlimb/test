using System;
using Test1.DesignPattern.GoF.ChainOfResponsibility;

// Chain of Responsibility パターン
// 複数のオブジェクトを鎖状に繋ぎ、その中のあるオブジェクトがある要求を処理するまで、
// 鎖に沿って順次要求を受け流していく(責任のたらいまわし)
// 
// 処理を行うオブジェクトが特定できないので、処理速度の低下や保守性の低下を招く

namespace Test1.DesignPattern.GoF.ChainOfResponsibility
{
    abstract class HandlerBase
    {
        protected int Num { get; private set; }
        protected HandlerBase next;

        public HandlerBase(int num)
        {
            this.Num = num;
        }

        public HandlerBase Next(HandlerBase handler)
        {
            this.next = handler;
            return handler;
        }

        public abstract void Request(int req);
    }

    class KappaHandler : HandlerBase
    {
        string name;

        public KappaHandler(string name, int num) : base(num)
        {
            this.name = name;
        }

        public override void Request(int req)
        {
            if (req <= Num)
                Console.WriteLine(name + ": ヒット！わたしは" + Num + "歳です。");
            else if (next != null)
            {
                Console.WriteLine(name + ": はずれ！他の子に聞いてね");
                next.Request(req);
            }
            else
                Console.WriteLine("該当者が誰もいなかったようです…");
        }
    }
}

namespace Test1.DesignPattern.Tester
{
    static class ChainOfResponsibility
    {
        public static void Test()
        {
            Console.WriteLine("### Chain of Responsibility");

            var kappa1 = new KappaHandler("かっぱちゃん", 15);
            var kappa2 = new KappaHandler("かっぱさん", 22);
            var kappa3 = new KappaHandler("かっぱさま", 31);
            kappa1.Next(kappa2).Next(kappa3);   // メソッドチェーンにする

            var reqNum = 20;
            Console.WriteLine("作業のため、"+ reqNum + "歳以上の河童の手を借ります。");
            kappa1.Request(reqNum);
        }
    }
}

