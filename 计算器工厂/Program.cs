﻿
using 计算器工厂.Logic;

namespace 计算机工厂 {
    internal class Program {
        // 客户端代码
        static void Main(string[] args) {
            bool run = true;
            while (run) {
                Console.WriteLine("请输入算式（输入e结束）：");
                // 读取算式,并转化为字符数组
                string? str = Console.ReadLine();
                if (string.IsNullOrEmpty(str)) {
                    throw new ArgumentNullException("输入为空！");
                }
                if (str.Equals("e") || str.Equals("E")) {
                    run = false;
                    Console.WriteLine("程序结束");
                    break;
                }
                try {
                    double result = Calculator.GetResult(str);
                    result = Math.Round(result, 3);
                    Console.WriteLine($"{str}={result}");
                    Console.WriteLine();
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    Calculator.clearAll();
                }
            }            
        }
    }
}