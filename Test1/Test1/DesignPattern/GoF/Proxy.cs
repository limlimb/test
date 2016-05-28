using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Test1.DesignPattern.GoF.Proxy;

// Proxy パターン
// あるオブジェクト(RealSubject)へのアクセス制御のため、そのオブジェクトの代理(Proxy)を提供する
// ProxyとRealSubjectは共通のインターフェースを実装し、ProxyはRealSubjectの参照を保持する
// 
// Proxyには様々な役割を持たせることができる
//   Virtual Proxy: あるコストの高い処理を必要になる時まで遅延させる(e.g. データのキャッシュ)
//   Protection Proxy: 利用者がその要求を実行するのに必要なアクセス権を持っているかをチェックする(e.g. アカウント認証)
//   Remote Proxy: 分散処理のように別のサーバにアクセスする際、必要になるネットワーク情報を隠蔽する
// 
// Decoratorは機能の追加、
// Proxyは代理が処理をすることでのオブジェクトの負荷の軽減 にそれぞれ重点を置く

namespace Test1.DesignPattern.GoF.Proxy
{
    // ここではVirtual Proxyを実装する

    interface ISubject
    {
        void ReleaseFish(string name);
    }

    // Proxy
    class Kappa : ISubject
    {
        Dam dam;

        public void ReleaseFish(string name)
        {
            Create();
            dam.ReleaseFish(name);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        void Create()
        {
            if (dam == null)
                dam = new Dam();
        }
    }

    // RealSubject
    class Dam : ISubject
    {
        List<string> fishes;

        public Dam()
        {
            fishes = new List<string>();
            Construct();
        }

        // コストの高い処理の例
        void Construct()
        {
            Console.WriteLine("ダムを建立します。");
            for(int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.WriteLine("完成しました。");
        }

        public void ReleaseFish(string name)
        {
            if (name != "ブラックバス")
            {
                fishes.Add(name);
                Console.WriteLine($"{name}が放流されました。", name);
                var fish = String.Join(", ", fishes);
                Console.WriteLine($"現在、ダムには{fish}が生息しています。", fish);
            }
            else
            {
                Console.WriteLine("かっぱ「ブラックバス？そいつはだめだよ」");
            }
        }
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Proxy
    {
        public static void Test()
        {
            Console.WriteLine("### Proxy");

            var kappa = new Kappa();
            kappa.ReleaseFish("ワカサギ");
            kappa.ReleaseFish("ブラックバス");
            kappa.ReleaseFish("ニジマス");
        }
    }
}
