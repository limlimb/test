using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Test1.DesignPattern.GoF.Prototype;

// Prototype パターン
// Clone()によりオブジェクトを複製して得る
// 
// 勝手を考えたらディープコピーの方が望ましい？
// 
// C#:
// ICloneableインタフェースを実装する
// また、MemberwiseCopy()はシャローコピーであることに注意する

namespace Test1.DesignPattern.GoF.Prototype
{
    interface IKappa : ICloneable
    {
        void Work();
    }

    class Kappa : IKappa
    {
        string name;
        Text nanika;

        public Kappa(string name, string text)
        {
            this.name = name;
            nanika = new Text(text);
        }

        public void SetText(string text) => nanika = new Text(text);

        public object Clone()
        {
            var newKappa = this.MemberwiseClone();
            return newKappa;
        }

        public Kappa DeepCopy()
        {
            var newKappa = (Kappa)this.MemberwiseClone();
            newKappa.SetText(this.nanika.text);
            return newKappa;
        }

        public void Work() => Console.WriteLine(name + "(" + nanika.text + "): どちらかといえば泳ぎたい");
    }

    class Text
    {
        public string text { get; private set; }

        public Text(string text) { this.text = text; }
    }

    static class Util
    {
        // シリアライズを利用したディープコピーを一応残しておく
        // [Serializable]属性を付与したクラスに対して有効になる
        public static object DeepCopy(this object target)
        {
            object result;
            var bf = new BinaryFormatter();
            var mem = new MemoryStream();

            try
            {
                bf.Serialize(mem, target);
                mem.Position = 0;
                result = bf.Deserialize(mem);
            }
            finally
            {
                mem.Close();
            }

            return result;
        }
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Prototype
    {
        public static void Test()
        {
            Console.WriteLine("### Prototype");

            var kappa = new Kappa("にとり", "かっぱ");
            var kappa2 = (Kappa)kappa.Clone();
            kappa.Work();
            kappa2.Work();

            Console.WriteLine("kappaのtextを変更します。");
            kappa.SetText("河童");
            kappa.Work();
            kappa2.Work();  // シャローコピーなのでこちらのtextも変更されている

            var kappa3 = kappa.DeepCopy();
            Console.WriteLine("kappaのtextを戻します。");
            kappa.SetText("かっぱ");
            kappa.Work();
            kappa3.Work();  // ディープコピーなのでこちらのtextは河童のまま変更されない
        }
    }
}