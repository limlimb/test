using Test1.DesignPattern.Tester;

// ### 河童を粗いコンセプトとしたデザインパターンの実装(の勉強)
// 各CSファイルだけ見れば十分な理解ができるよう、必要なクラスは各パターンごとに実装することにする

namespace Test1
{
    public static class DesignPatternTester
    {
        // 各パターンのTesterメソッドを実行する
        public static void Do()
        {
            Interpreter.Test();
        }
    }
}
