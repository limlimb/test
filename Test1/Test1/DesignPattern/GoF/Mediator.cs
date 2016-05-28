using System;
using System.Collections.Generic;
using Test1.DesignPattern.GoF.Mediator;

// Mediator パターン
// オブジェクト群の関わりをカプセル化し、お互いを明示的に参照し合わないようにする
// このオブジェクト群はMediator(仲裁者)を介して処理を行うようにする
// 
// オブジェクト群が多対多の複雑な絡み合い方をしている場合に有効
// 処理をMediatorに局所化し、変更したければこれを新しく継承すればいい
// 
// MediatorはColleagueを全て知っている(メンバに持っている)

namespace Test1.DesignPattern.GoF.Mediator
{
    interface IMeditor
    {
        void CreateColleague(ColleagueBase colleague);
        void ColleagueChanged(ColleagueBase colleague);
    }

    abstract class ColleagueBase
    {
        public string Name { get; private set; }

        public ColleagueBase(string name)
        {
            this.Name = name;
        }

        public abstract void SetMediator(IMeditor mediator);
        public abstract void ControlColleague();
    }

    class KappaMediator : IMeditor
    {
        Dictionary<string, ColleagueBase> dic;

        public KappaMediator()
        {
            dic = new Dictionary<string, ColleagueBase>();
        }

        public void CreateColleague(ColleagueBase colleague) => dic[colleague.Name] = colleague;

        public void ColleagueChanged(ColleagueBase colleague)
        {
            if (dic[colleague.Name] is ThinColleague)
            {
                // ThinColleagueクラスに対しいろいろ処理する部分
                colleague.ControlColleague();
            }
            else if (dic[colleague.Name] is FatColleague)
            {
                // FatColleagueクラスに対しいろいろ処理する部分
                colleague.ControlColleague();
            }
            else
                Console.WriteLine(colleague.Name + "は知らない子です。");
        }
    }

    class ThinColleague : ColleagueBase
    {
        IMeditor mediator;

        public ThinColleague(string name) : base(name) { }

        public override void SetMediator(IMeditor mediator)
        {
            this.mediator = mediator;
        }

        public override void ControlColleague() => Console.WriteLine(Name + ": 今日も激務だ…");
    }

    class FatColleague : ColleagueBase
    {
        IMeditor mediator;

        public FatColleague(string name) : base(name) { }

        public override void SetMediator(IMeditor mediator)
        {
            this.mediator = mediator;
        }

        public override void ControlColleague() => Console.WriteLine(Name + ": 天狗のパワハラでストレス太り止まらん");
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Mediator
    {
        public static void Test()
        {
            Console.WriteLine("### Mediator");

            var kappaMediator = new KappaMediator();
            var thinKappa = new ThinColleague("痩せかっぱ");
            var fatKappa = new FatColleague("太りかっぱ");

            thinKappa.SetMediator(kappaMediator);
            fatKappa.SetMediator(kappaMediator);
            kappaMediator.CreateColleague(thinKappa);
            kappaMediator.CreateColleague(fatKappa);

            // 相談
            kappaMediator.ColleagueChanged(thinKappa);
            kappaMediator.ColleagueChanged(fatKappa);
        }
    }
}