namespace 计算器工厂.Operations {
    /// <summary>
    /// Bracket, 最低优先运算级
    /// AddOrSub, 与加减相同的运算级使用这个，以下同理
    /// MulOrDiv, 乘除法
    /// Exponentiation,  幂运算
    /// Factorial   阶乘
    /// </summary>
    public enum EOperatorPrecedence {
        Bracket, 
        AddOrSub, 
        MulOrDiv, 
        Exponentiation, 
        Factorial  
    }

}