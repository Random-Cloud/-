using 计算器工厂.ContextPackages;

namespace 计算器工厂.FormulaHandlers {
    /// <summary>
    /// 判断是否是左括号
    /// </summary>
    public class BracketHandler : FormulaHandler {
        
        public override void Handle(char ch, int index) {
            ContextPackage.PushList();
            if (ch == '(') {
                ContextPackage.operatorsStack.Push(ch);
            }
            else {
                base.Handle(ch, index);
            }
        }
    }
}
