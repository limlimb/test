using System;
using System.Collections.Generic;

// http://stackoverflow.com/questions/6705583/indexers-in-list-vs-array/
// var arr = new MyStruct[10];
// arr[0]	// 参照を返す
// var lists = new List<MyStruct>();
// lists[0]	// コピーを返す

namespace Test1.classes.ArrayAndList
{
    struct MyStruct
    {
        public int num;
    }

    class MyClass
    {
        public int num;
    }

    public static class Test
    {
        public static void Do()
        {
            Console.WriteLine("### 配列とList<T>のテスト");

            Console.WriteLine("--- 構造体でテスト");
            Console.WriteLine("--- 配列");
            var arr = new MyStruct[] { new MyStruct { num = 2 } };
            Console.WriteLine("arr[0].num -> {0}", arr[0].num);
            arr[0].num = 3;
            Console.WriteLine("arr[0].num = 3 -> {0}", arr[0].num);
            
            Console.WriteLine("--- List<T>");
            var lists = new List<MyStruct>() { new MyStruct { num = 2 } };
            Console.WriteLine("lists[0].num -> {0}", lists[0].num);
            // lists[0].num = 3;
            // エラー CS1612  変数ではないため、'List<MyStruct>.this[int]' の戻り値を変更できません
            // ＞このエラーは、ジェネリック コレクション内の構造体を直接変更しようとしたときに発生する可能性があります。
            var temp = lists[0];    // 1回ローカル変数に割り当てる必要がある
            temp.num = 3;
            lists[0] = temp;
            Console.WriteLine("lists[0].num = 3 -> {0}\n", lists[0].num);

            Console.WriteLine("--- クラスでテスト");
            Console.WriteLine("--- 配列");
            var arr2 = new MyClass[] { new MyClass { num = 2 } };
            Console.WriteLine("arr2[0].num -> {0}", arr2[0].num);
            arr2[0].num = 3;
            Console.WriteLine("arr2[0].num = 3 -> {0}", arr2[0].num);

            Console.WriteLine("--- List<T>");
            var lists2 = new List<MyClass>() { new MyClass { num = 2 } };
            Console.WriteLine("lists2[0].num -> {0}", lists2[0].num);
            lists2[0].num = 3;  // クラスなら直接書き換え可能
            Console.WriteLine("lists2[0].num = 3 -> {0}\n", lists2[0].num);
        }
    }
}
