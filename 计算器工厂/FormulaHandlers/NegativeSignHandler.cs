using 计算器工厂.ContextPackages;
using 计算器工厂.Factorys;

namespace 计算器工厂.FormulaHandlers {
    /// <summary>
    /// 判断是否是负数
    /// </summary>
    public class NegativeSignHandler : FormulaHandler {
        public override void Handle(char ch, int index) {

            if (ch == '-' && IsNegativeSign(ContextPackage.formula, index)) {
                ContextPackage.numCharsList.Add('-');
            }
            else {
                base.Handle(ch, index);
            }
        }
        /// <summary>
        /// 负号合法性校验
        /// </summary>
        /// <param name="formula">算式数组</param>
        /// <param name="index">数组索引</param>
        /// <returns></returns>
        private bool IsNegativeSign(char[] formula, int index) {
            return index == 0 ||
                   formula[index - 1] != ')' &&
                    OperationFactory.IsOperator(formula[index - 1]);
        }
    }
}
