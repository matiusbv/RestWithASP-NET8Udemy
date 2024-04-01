using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace RestWithASPNETErudio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
       

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{operation}/{firstNumber}/{secondNumber}")]
      
        public IActionResult Get(string operation, string firstNumber, string secondNumber)
        {
   
            if(operation == "sum") {

                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                    return Ok(sum.ToString());
                }

            }
            else if (operation == "sub")
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                    return Ok(sum.ToString());
                }
            }
            else if (operation == "mult")
            {
                if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sum = (ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber));
                    return Ok(sum.ToString());
                }
            }
            else if (operation == "div")
            {
                if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sum = (ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber));
                    return Ok(sum.ToString());
                }
            }

                return BadRequest("Invalid Input");
            
        }
                    
         


    
        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;

                
        }

        private decimal ConvertToDecimal(string strNumber) 
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }
    }
}
