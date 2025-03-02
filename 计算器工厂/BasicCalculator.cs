using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计算器工厂 {
    internal class BasicCalculator {
        // 四则运算计算器
        public double GetResult(double num1, double num2, char op) {
            switch (op) {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/': {
                        if (num2 == 0) {
                            Console.WriteLine("除数不能为0");
                            return 0;
                        }
                        else {
                            return num2 / num1;
                        }
                    }
                default:
                    Console.WriteLine("非法输入，请检查算式！");
                    break;
            }
            return 0;
        }
    }
}
