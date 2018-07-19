using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    class CalculateResult
    {
        double result;

        public double Result(double number1, double number2, string mathOperator) {

            switch (mathOperator) {
                case "÷":
                    result = number1 / number2;
                    break;
                case "×":
                    result = number1 * number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "+":
                    result = number1 + number2;
                    break;
            }
            return result;
        }
    }
}
