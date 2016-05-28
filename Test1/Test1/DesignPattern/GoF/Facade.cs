using System;
using Test1.DesignPattern.GoF.Facade;

// Facade パターン
// ライブラリの機能などをラップするときに使えるパターン
// ある一連の操作に関してその操作の順番が不可逆であるときなど、特殊または複雑な操作を包み隠す

namespace Test1.DesignPattern.GoF.Facade
{
    class CucumberLibrary
    {
        Cucumber cucumber = Cucumber.none;

        public void Plant()
        {
            if (cucumber == Cucumber.none)
            {
                Console.WriteLine("まずきゅうりの苗を植えます。");
                cucumber = Cucumber.plant;
            }
            else
                Console.WriteLine("既にポットに苗が埋まっています。");
        }

        public void Water()
        {
            if (cucumber == Cucumber.plant)
            {
                Console.WriteLine("水をあげるとすくすく育ちます。");
                cucumber = Cucumber.growed;
            }
            else
                Console.WriteLine("苗が存在しないか、育ちきっています。");
        }

        public void Harvest()
        {
            if (cucumber == Cucumber.growed)
            {
                Console.WriteLine("育っていたので収穫します。");
                cucumber = Cucumber.none;
            }
            else
                Console.WriteLine("苗が存在しないか、まだ育ちきっていません。");
        }
    }

    enum Cucumber
    {
        none,
        plant,
        growed,
    }

    public static class GetCucumber
    {
        public static void Facade()
        {
            var library = new CucumberLibrary();
            library.Plant();
            library.Water();
            library.Harvest();
        }
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Facade
    {
        public static void Test()
        {
            Console.WriteLine("### Facade");

            Console.WriteLine("--- まずFacadeパターンで呼び出す");
            GetCucumber.Facade();   // 複雑な操作を利用者側からは簡易に、そして正確に済ませる

            Console.WriteLine("\n--- 次に自分で呼び出してみる");
            var lib = new CucumberLibrary();
            lib.Plant();
            lib.Harvest();  // まだ水を与えていないのに収穫しようとしてしまうヒューマンエラー
            lib.Water();
        }
    }
}