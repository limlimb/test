using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Test1.DesignPattern.GoF.Iterator;

// Iterator パターン
// ある集合体(配列など)の要素1つ1つに順次アクセスする方法を提供する
// 利用者はIteratorを介して集合体にアクセスする
// 
// イテレータによる走査処理の詳細をカプセル化する
// 
// C#:
// 文法レベルでIteratorをカバーしている(foreach文)

namespace Test1.DesignPattern.GoF.Iterator
{
    interface IIterator
    {
        string FirstItem { get; }
        string NextItem { get; }
        string CurrentItem { get; }
        bool IsDone { get; }
    }

    interface IAggregate
    {
        IIterator GetIterator();
        string this[int itemIdx] { set; get; }
        int Count { get; }
    }

    // 実際のコレクションとイテレータを得るメソッドを実装する
    class ConcreteAggregate : IAggregate
    {
        List<string> list;

        public ConcreteAggregate() { list = new List<string>(); }

        public IIterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        public string this[int itemIndex]
        {
            get
            {
                return (itemIndex < list.Count) ? list[itemIndex] : string.Empty;
            }
            set
            {
                list.Add(value);
            }
        }

        public int Count => list.Count;
    }

    class ConcreteIterator : IIterator
    {
        IAggregate aggregate;
        int currentIndex = 0;

        public ConcreteIterator(IAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public string CurrentItem
        {
            get
            {
                return aggregate[currentIndex];
            }
        }

        public string FirstItem
        {
            get
            {
                currentIndex = 0;
                return aggregate[0];
            }
        }

        public bool IsDone => (currentIndex < aggregate.Count) ? false : true;

        public string NextItem
        {
            get
            {
                currentIndex++;
                return (!IsDone) ? aggregate[currentIndex] : string.Empty;
            }
        }
    }

    // C#: IEnumerable実装
    public class SharpAggregate : IEnumerable
    {
        List<string> list;

        public SharpAggregate()
        {
            list = new List<string>();
        }

        public string this[int itemIndex]
        {
            get
            {
                return (itemIndex < list.Count) ? list[itemIndex] : string.Empty;
            }
            set
            {
                list.Add(value);
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Count; ++i)
                yield return list[i];
        }
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Iterator
    {
        public static void Test()
        {
            Console.WriteLine("### Iterator");

            var aggregate = new ConcreteAggregate();
            // 1から10を格納するだけ
            Enumerable.Range(1, 10).ToList().ForEach(x => aggregate[x] = x.ToString());
            var iterator = aggregate.GetIterator();
            for(var str = iterator.FirstItem; !(iterator.IsDone); str = iterator.NextItem)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("\n--- IEnumerable実装");
            var sharp = new SharpAggregate();
            Enumerable.Range(1, 10).ToList().ForEach(x => sharp[x] = x.ToString());
            foreach (var item in sharp)
                Console.WriteLine(item);
        }
    }
}