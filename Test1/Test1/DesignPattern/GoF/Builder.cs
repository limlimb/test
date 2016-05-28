using System;
using System.Text;
using Test1.DesignPattern.GoF.Builder;

// Builder パターン
// 複合オブジェクトについてその生成過程を隠蔽し、同じ過程で異なる内部表現のオブジェクトを生成できる
// 
// ・Strategyとの類似性
//   →あくまでもBuilderはオブジェクトの生成に重きを置いたパターン
// ・TemplateMethodとの類似性
//   →Builderで言うDirectorクラスを基底クラスとするのがTemplateMethod

namespace Test1.DesignPattern.GoF.Builder
{
    interface IBuilder
    {
        void Work1(string name);
        void Work2(string cucumber);
        Object GetResult();
    }

    class Director
    {
        IBuilder builder;

        public Director(IBuilder builder)
        {
            this.builder = builder;
        }

        public Object Construct()
        {
            builder.Work1("かっぱ");
            builder.Work2("塩漬けきゅうり");
            return builder.GetResult();
        }
    }

    class GourmetKappa : IBuilder
    {
        StringBuilder builder = new StringBuilder();

        public void Work1(string name) => builder.Append(name + "です。食にはほどほどにうるさいです。\n");

        public void Work2(string cucumber) => builder.Append(cucumber + "よりも味噌付けて食べたい\n");

        public object GetResult() => builder.ToString();
    }

    class NormalKappa : IBuilder
    {
        StringBuilder builder = new StringBuilder();

        public void Work1(string name) => builder.Append("普通のかっぱです。名前は" + name + "です。\n");

        public void Work2(string cucumber) => builder.Append(cucumber + "はとても好きです。\n");

        public object GetResult() => builder.ToString();
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Builder
    {
        public static void Test()
        {
            Console.WriteLine("### Builder");

            var director1 = new Director(new NormalKappa());
            var message = (string)director1.Construct();
            Console.WriteLine(message);

            var director2 = new Director(new GourmetKappa());
            message = (string)director2.Construct();
            Console.WriteLine(message);
        }
    }
}