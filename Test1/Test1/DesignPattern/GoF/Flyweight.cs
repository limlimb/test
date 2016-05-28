using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Test1.DesignPattern.GoF.Flyweight;

// Flyweight パターン
// 多くの同じ型のオブジェクトを保有しているとき、それらを出来る限り再利用(共有)する
// 特にメモリ空間を節約する目的で使われる
// 
// FlyWeightを生成･管理するFactoryを間に挟む
// 
// Intrinsic state = 不変であり、共有される
//   e.g. 'a', 'b'などの文字情報
// Extrinsic state = 可変であり、利用者のオブジェクトで保有される。共有不可の情報
//   e.g. フォントスタイル, フォントカラー

namespace Test1.DesignPattern.GoF.Flyweight
{
    interface IKappa
    {
        void Use();
    }

    // Intrinsic state: 工具
    // リソースを比較的多く使うクラス
    class Tool : IKappa
    {
        public string Name { get; private set; }

        public Tool(string name)
        {
            this.Name = name;
        }

        public void Use()
        {
            // 何か処理
        }
    }

    // Extrinsic state: 河童
    class Kappa : IKappa
    {
        Dictionary<string, Tool> tools = new Dictionary<string, Tool>();

        public string Name { get; private set; }

        public Kappa(string name)
        {
            this.Name = name;
        }

        public void Add(Tool card) => tools[card.Name] = card;

        public void Use()
        {
            foreach (var tool in tools)
            {
                Console.WriteLine("{0}は{1}を取り出した。", Name, tool.Key);
                tool.Value.Use();
            }
        }
    }

    // 複数のファクトリが生成されないようにSingleton(C#:静的クラス)にしておく
    static class KappaFactory
    {
        static Dictionary<string, Tool> flyweightList = new Dictionary<string, Tool>();
        static object o = new object();

        // 排他制御して同じFlyweightの生成を防ぐ
        public static Tool GetFlyweight(string name)
        {
            lock (o)
            {
                // Intrinsic stateがプールにあるかどうか確認して、ないなら生成
                if (!(flyweightList.ContainsKey(name)))
                    flyweightList[name] = new Tool(name);
                var fw = flyweightList[name];

                // ここでExtrinsic stateを生成し、Intrinsic stateを保持させることもある

                return fw;
            }
        }
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Flyweight
    {
        public static void Test()
        {
            Console.WriteLine("### Flyweight");

            var kappa = new Kappa("かっぱちゃん");
            var tool1 = KappaFactory.GetFlyweight("クランクハンドル");
            kappa.Add(tool1);
            var tool2 = KappaFactory.GetFlyweight("ラチェット");
            kappa.Add(tool2);

            kappa.Use();
        }
    }
}