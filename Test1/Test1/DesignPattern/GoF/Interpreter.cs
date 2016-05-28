using System;
using System.Collections.Generic;
using Test1.DesignPattern.GoF.Interpreter;

// Interpreter パターン
// 文法規則をクラスで表現し、構文解析して得た結果に基づき処理をしていく(インタプリタ)
// 小さなオリジナル言語(ドメインに"特化"した言語)の実装など
// 
// 文法が複雑になると、クラス構造が肥大化してしまうのでそういうものには向いてない
// また、しばしば非効率である
// 
// TODO: 河童コンセプトで思いつかなかったので暫定的に逆ポーランド記法の計算と代替

namespace Test1.DesignPattern.GoF.Interpreter
{
    // AbstractExpression
    interface IExpression
    {
        void Interpret(Stack<int> stack);
    }
    
    class PlusTerminalExpression : IExpression
    {
        public void Interpret(Stack<int> stack)
        {
            stack.Push(stack.Pop() + stack.Pop());
        }
    }

    class MinusTerminalExpression : IExpression
    {
        public void Interpret(Stack<int> stack)
        {
            stack.Push(-stack.Pop() + stack.Pop());
        }
    }

    class MultiplyTerminalExpression : IExpression
    {
        public void Interpret(Stack<int> stack)
        {
            stack.Push(stack.Pop() * stack.Pop());
        }
    }

    class DivideTerminalExpression : IExpression
    {
        public void Interpret(Stack<int> stack)
        {
            var denominator = stack.Pop();
            var numerator = stack.Pop();
            stack.Push(numerator / denominator);
        }
    }

    class NumberTerminalExpression : IExpression
    {
        int num;

        public void Interpret(Stack<int> stack)
        {
            stack.Push(num);
        }

        public NumberTerminalExpression(int num)
        {
            this.num = num;
        }
    }

    class Context
    {
        List<IExpression> tokens;

        public Context(string source)
        {
            tokens = new List<IExpression>();

            var list = source.Split(' ');
            foreach(var node in list)
            {
                switch (node)
                {
                    case "+":
                        tokens.Add(new PlusTerminalExpression());
                        break;
                    case "-":
                        tokens.Add(new MinusTerminalExpression());
                        break;
                    case "*":
                        tokens.Add(new MultiplyTerminalExpression());
                        break;
                    case "/":
                        tokens.Add(new DivideTerminalExpression());
                        break;
                    default:
                        tokens.Add(new NumberTerminalExpression(int.Parse(node)));
                        break;
                }
            }
        }

        public int Calculate()
        {
            var stack = new Stack<int>();
            foreach (var token in tokens) token.Interpret(stack);
            return stack.Pop();
        }
    }
}

namespace Test1.DesignPattern.Tester
{
    static class Interpreter
    {
        public static void Test()
        {
            Console.WriteLine("### Interpreter");

            var source = "5 1 2 + 4 * + 3 -";   
            var context = new Context(source);
            var result = context.Calculate();
            Console.WriteLine($"{source} => {result}");
            
            source = "1 3 + 5 4 2 / - *";
            context = new Context(source);
            result = context.Calculate();
            Console.WriteLine($"{source} => {result}");
        }
    }
}
