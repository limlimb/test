using System;
using System.Collections.Generic;
using System.Text;
using Test1.DesignPattern.GoF.Observer;

// Observer パターン
// 観察するオブジェクト(Observer)が、対象オブジェクト(Subject)の状態変化の通知を受けそれに対する処理をする
// 対象オブジェクトには観察させるObserver(のリスト)を保持させる
// 
// Observerは観察する方、Observableは観察される方
// MVVMのviewがObserver、modelがObservable
// 
// C#:
// ObserverのDataSourceにObservableを指定することでデータバインドされる
// eventを使うと楽

namespace Test1.DesignPattern.GoF.Observer
{
    // 観察者クラス
    interface IObserver
    {
        void Update(Subject subject);
    }

    class KappaObserver : IObserver
    {
        public void Update(Subject subject)
        {
            Console.WriteLine(subject.Name + "の持ち物が更新されました。");
            subject.ShowAllItems();
        }
    }

    // 観察対象クラス
    abstract class Subject
    {
        List<IObserver> observers = new List<IObserver>();

        public string Name { get; private set; }

        protected Subject(string name)
        {
            this.Name = name;
        }

        public void AddObserver(IObserver observer) => observers.Add(observer);

        public void RemoveObserver(IObserver observer) => observers.Remove(observer);

        public void NotifyObserver()
        {
            foreach (var observer in observers)
                observer.Update(this);
        }

        public abstract void Done(string something);
        public abstract void ShowAllItems();
    }

    class Kappa : Subject
    {
        List<string> items = new List<string>();

        public Kappa(string name) : base(name) { }

        public override void Done(string something)
        {
            items.Add(something);
            NotifyObserver();
        }

        public override void ShowAllItems()
        {
            var str = String.Join(", ", items);
            Console.WriteLine(str);
        }
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Observer
    {
        public static void Test()
        {
            Console.WriteLine("### Observer");

            var observer = new KappaObserver();
            var kappaChan = new Kappa("かっぱちゃん");
            var kappaSan = new Kappa("かっぱさん");
            kappaChan.AddObserver(observer);
            kappaSan.AddObserver(observer);

            kappaChan.Done("スピンナーハンドル");
            kappaChan.Done("トルクレンチ");
            kappaSan.Done("設計ソフト");
            kappaSan.Done("プロジェクト管理ソフト");
            kappaChan.Done("塩漬けきゅうり");
            kappaSan.Done("もろきゅー");
        }
    }
}