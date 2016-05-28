using System;
using System.Collections.Generic;
using Test1.DesignPattern.GoF.Memento;

// Memento パターン
// カプセル化を保ったままオブジェクトの内部状態を保存しておき、後で戻せるようにする
// 
// Caretaker(世話係)がMementoの生成･使用･保持の責任を持つ
// CaretakerがOriginatorに生成やアンドゥの指示を出す。生成した場合はMementoを受け取る
// 利用者からはMementoが絶対に見られないようになっている
//
// いわゆるアンドゥ機能の実装がこのパターン

namespace Test1.DesignPattern.GoF.Memento
{
    class Originator
    {
        KappaState state;

        public KappaMemento CreateMemento() => new KappaMemento(state);

        public void SetMemento(KappaMemento memento) => state = memento.GetState();

        public void SetState(KappaState state) => this.state = state;

        public void ShowState() => Console.WriteLine("現在の状態: " + state.ToString());
    }

    class KappaMemento
    {
        KappaState state;

        internal KappaMemento(KappaState state)
        {
            this.state = state;
        }

        public KappaState GetState() => state;

        public void SetState(KappaState state) => this.state = state;
    }

    static class Caretaker
    {
        static List<KappaMemento> mementoList = new List<KappaMemento>();

        public static void SaveState(Originator orig) => mementoList.Add(orig.CreateMemento());
        
        // TODO: 直接インデックスを指定しているが、
        // 取り出すMementoを識別できるようにすると利便性が高まるかもしれない
        public static void RestoreState(Originator orig, int num) => orig.SetMemento(mementoList[num]);
    }

    enum KappaState
    {
        Thin,
        Normal,
        Fat,
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Memento
    {
        public static void Test()
        {
            Console.WriteLine("### Memento");

            var orig = new Originator();

            orig.SetState(KappaState.Normal);
            Caretaker.SaveState(orig);          // Originatorの現在の状態をCaretakerに保存
            orig.ShowState();

            orig.SetState(KappaState.Fat);
            Caretaker.SaveState(orig);
            orig.ShowState();

            orig.SetState(KappaState.Thin);
            Caretaker.SaveState(orig);
            orig.ShowState();

            // 状態を保存済みのMementoから戻す
            Caretaker.RestoreState(orig, 0);
            orig.ShowState();
        }
    }
}