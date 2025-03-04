using 计算器工厂.ContextPackages;
namespace 计算器工厂.FormulaHandlers {
    /// <summary>
    /// 判断是否为数字
    /// </summary>
    public class DigitHandler : FormulaHandler {
        public override void Handle(char ch, int index) {
            if (char.IsDigit(ch) || ch == '.') {
                ContextPackage.numCharsList.Add(ch);
            }
            else {
                base.Handle(ch, index);
            }
        }
    }
}
