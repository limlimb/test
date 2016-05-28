using System;
using System.Collections.Generic;
using Test1.DesignPattern.GoF.Composite;

// Composite パターン
// ツリー構造のような再帰的なデータ構造を表現するために使われるパターン
// 枝と葉のように異なるものを同一のインターフェースを継承させることにより統一的に扱える
// (≒個々のオブジェクトとオブジェクトを合成したものを一様に扱える)

namespace Test1.DesignPattern.GoF.Composite
{
    public abstract class KappaBase
    {
        protected string name;

        public virtual void Add(KappaBase kb)
        {
            throw new Exception();
        }

        public virtual void Work()
        {
            throw new Exception();
        }
    }

    public class ParentKappa : KappaBase
    {
        List<KappaBase> list;

        public ParentKappa(string name)
        {
            base.name = name;
            list = new List<KappaBase>();
        }

        public override void Add(KappaBase kb) => list.Add(kb);

        public override void Work()
        {
            Console.WriteLine(name + ": 作業しなさい！");
            list.ForEach(x => x.Work());
            Console.WriteLine(name + ": 終わり！");
        }
    }

    public class ChildKappa: KappaBase
    {
        public ChildKappa(string name)
        {
            this.name = name;
        }

        public override void Work() => Console.WriteLine(name + "が働いている……");
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Composite
    {
        public static void Test()
        {
            Console.WriteLine("### Composite");

            var bigParent = new ParentKappa("大親方かっぱ");
            bigParent.Add(new ChildKappa("下っ端かっぱA"));
            bigParent.Add(new ChildKappa("下っ端かっぱB"));
            var parent1 = new ParentKappa("親方かっぱA");
            parent1.Add(new ChildKappa("下っ端かっぱC"));
            parent1.Add(new ChildKappa("下っ端かっぱD"));
            var parent2 = new ParentKappa("親方かっぱB");
            parent2.Add(new ChildKappa("下っ端かっぱE"));
            parent2.Add(new ChildKappa("下っ端かっぱF"));
            bigParent.Add(parent1);
            bigParent.Add(parent2);

            bigParent.Work();
        }
    }
}