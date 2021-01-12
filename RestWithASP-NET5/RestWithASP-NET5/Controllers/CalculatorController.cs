using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5.Controllers
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

        [HttpGet("somar/{firstNumber}/{secondNumber}")]
        public IActionResult GetSomar(string firstNumber,string secondNumber)
        {
            if (Isnumeric(firstNumber) && Isnumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Imput");
        }

        [HttpGet("subtrair/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtrair(string firstNumber, string secondNumber)
        {
            if (Isnumeric(firstNumber) && Isnumeric(secondNumber))
            {
                var subtrair = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtrair.ToString());
            }
            return BadRequest("Invalid Imput");
        }

        [HttpGet("multiplicar/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiplicar(string firstNumber, string secondNumber)
        {
            if (Isnumeric(firstNumber) && Isnumeric(secondNumber))
            {
                var multiplicar = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiplicar.ToString());
            }
            return BadRequest("Invalid Imput");
        }

        [HttpGet("dividir/{firstNumber}/{secondNumber}")]
        public IActionResult GetDividir(string firstNumber, string secondNumber)
        {
            if (Isnumeric(firstNumber) && Isnumeric(secondNumber))
            {
                var dividir = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(dividir.ToString());
            }
            return BadRequest("Invalid Imput");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult GetMedia(string firstNumber, string secondNumber)
        {
            if (Isnumeric(firstNumber) && Isnumeric(secondNumber))
            {
                var media = ((ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2);
                return Ok(media.ToString());
            }
            return BadRequest("Invalid Imput");
        }

        [HttpGet("raizquadrada/{firstNumber}")]
        public IActionResult GetRaizquadrada(string firstNumber)
        {
            if (Isnumeric(firstNumber))
            {
                var raizquadrada = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(raizquadrada.ToString());
            }
            return BadRequest("Invalid Imput");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal dcDecimalValue;
            if (Decimal.TryParse(strNumber, out dcDecimalValue))
            {
                return dcDecimalValue;
            }
            return 0;
        }

        private bool Isnumeric(string strNumber)
        {
            double number;
            bool isNumber = Double.TryParse(strNumber,System.Globalization.NumberStyles.Any,System.Globalization.NumberFormatInfo.InvariantInfo,out number);
            return isNumber;
        }
    }
}
