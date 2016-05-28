using System;
using Test1.DesignPattern.GoF.Singleton;

// Singleton パターン
// インスタンスが1つだけ生成されるようにするパターン
// 
// 様々な問題を孕むパターンである
// ・テストがしにくい
// ・保守性に欠ける
// ・staticでインスタンスを保持する手前、解放順序が定まらない
// 
// C#:
// ユーティリティクラスを目的とするときはSingletonではなく静的クラスの方が最適解

namespace Test1.DesignPattern.GoF.Singleton
{
    public class KingOfKappa
    {
        static KingOfKappa instance = new KingOfKappa();

        // コンストラクタをprivateにする
        KingOfKappa() { }

        // 唯一のインスタンスを取得するためのプロパティ
        public static KingOfKappa Instance => instance;

        public void Do() => Console.WriteLine("河童の王であるぞ");
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Singleton
    {
        public static void Test()
        {
            Console.WriteLine("### Singleton");

            // エラー: CS0712, CS0723
            // var ousama = new Singleton();

            KingOfKappa.Instance.Do();
        }
    }
}