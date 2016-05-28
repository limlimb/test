using System;
using System.Collections.Generic;
using Test1.DesignPattern.GoF.Command;

// Command パターン
// 命令をクラスで表現し、オブジェクトを切り替えることで操作の切り替えを実現する
// データに対し更新手続き(命令)の集合をカプセル化するという点ではトランザクションに近い
//   =>つまりCommandと別のCommandを組み合わせることも可能である
// 
// UNDOの実装が可能
//   CommandにUndoメソッドを追加する(元に戻したい情報もCommandに保存しておく)
//   →Invokerに直前に選ばれたCommandを保存しておく
//   →Undoする: 直前に選ばれたCommandのUndoを呼ぶ
// 
// 利用者がすること
//   Receiver(Commandの対象になるクラス)とCommandを生成し、CommandにReceiverを渡す
//   →Invoker(Commandを起動するクラス)にCommandを登録する(ハッシュマップにより管理する)
//   →Invokerに文字列を渡すと、Invokerが該当Commandを起動する

namespace Test1.DesignPattern.GoF.Command
{
    abstract class CommandBase
    {
        protected IReceiver receiver;
        
        public CommandBase(IReceiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
        public abstract void Unexecute();
    }

    class Win : CommandBase
    {
        public Win(IReceiver receiver) : base(receiver) { }

        public override void Execute()
        {
            receiver.Add(Hoshi.Win);
        }

        public override void Unexecute()
        {
            receiver.Undo();
        }
    }

    class Lose : CommandBase
    {
        public Lose(IReceiver receiver) : base(receiver) { }

        public override void Execute()
        {
            receiver.Add(Hoshi.Lose);
        }

        public override void Unexecute()
        {
            receiver.Undo();
        }
    }

    interface IReceiver
    {
        void Add(Hoshi result);
        void Undo();
        void ShowAll();
    }

    class Hoshitori : IReceiver
    {
        List<string> results;
        int wins, losses;
        Hoshi prevResult;

        public Hoshitori()
        {
            results = new List<string>();
        }

        public void Add(Hoshi result)
        {
            prevResult = result;
            switch (result)
            {
                case Hoshi.Win:
                    results.Add("○");
                    wins++;
                    break;
                case Hoshi.Lose:
                    results.Add("●");
                    losses++;
                    break;
                default:
                    prevResult = Hoshi.Unknown;
                    break;
            }
        }

        public void Undo()
        {
            var lastIndex = wins + losses - 1;
            switch (prevResult)
            {
                case Hoshi.Win:
                    results.RemoveAt(lastIndex);
                    wins--;
                    break;
                case Hoshi.Lose:
                    results.RemoveAt(lastIndex);
                    losses--;
                    break;
                case Hoshi.Unknown:
                    break;
            }
            prevResult = Hoshi.Unknown;
        }

        public void ShowAll()
        {
            Console.Write($"今場所は{wins}勝{losses}敗です。星取表:");
            foreach (var result in results)
            {
                Console.Write(result);
            }
            Console.WriteLine();
        }
    }

    class Invoker
    {
        Dictionary<string, CommandBase> commands;   // 命令のマップ
        Stack<CommandBase> history;                 // 命令の履歴

        public Invoker()
        {
            commands = new Dictionary<string, CommandBase>();
            history = new Stack<CommandBase>();
        }
        
        public void AddCommand(string key, CommandBase command)
        {
            if (key != string.Empty && command != null)
                commands[key] = command;
        }

        public void Execute(string key)
        {
            CommandBase command;
            if(commands.TryGetValue(key, out command))
            {
                command.Execute();
                history.Push(command);
            }
        }

        public void Unexecute()
        {
            if (history.Count != 0)
            {
                var prevCommand = history.Pop();
                prevCommand.Unexecute();
            }
        }
    }

    enum Hoshi
    {
        Win,
        Lose,
        Unknown
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Command
    {
        public static void Test()
        {
            Console.WriteLine("### Command");

            var hoshitori = new Hoshitori();
            var winCommand = new Win(hoshitori);
            var loseCommand = new Lose(hoshitori);
            var invoker = new Invoker();
            invoker.AddCommand("w", winCommand);
            invoker.AddCommand("l", loseCommand);

            invoker.Execute("l");
            invoker.Execute("w");
            invoker.Execute("w");
            invoker.Execute("l");
            invoker.Execute("l");
            invoker.Unexecute();
            invoker.Execute("w");
            invoker.Unexecute();
            invoker.Execute("l");
            invoker.Execute("w");

            hoshitori.ShowAll();
        }
    }
}
