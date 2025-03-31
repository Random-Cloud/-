using 计算器工厂.Logic;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWeb.Controllers;

[ApiController]
[Route("api/calculate")]
public class CalculateController : ControllerBase {
    [HttpPost]
    public IActionResult Post([FromBody] CalculationRequest request) {
        try {
            double result = Calculator.GetResult(request.Expression);
            return Ok(new {
                result = Math.Round(result, 3)
            });
        }
        catch (Exception ex) {
            // 输出错误日志到控制台
            Console.WriteLine($"计算异常：{ex.Message}");
            return BadRequest(ex.Message);
        }
    }
}

public class CalculationRequest {
    private string? _expression;
    public string Expression {
        get => _expression ?? "1+1";
        set => _expression = value;
    }
}