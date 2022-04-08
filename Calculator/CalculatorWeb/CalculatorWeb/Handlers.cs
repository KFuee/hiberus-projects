using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalculatorLibrary;

namespace CalculatorWeb
{
    public class Handlers
    {
        Calculator calculator;

        public Handlers(Calculator calculator)
        {
            this.calculator = calculator;
        }

        /// <summary>
        /// Controla que acción ejecutar si es una operación especial
        /// </summary>
        /// <param name="operation">Tipo de operación</param>
        public void handleSpecialOperation(string operation)
        {
            switch (operation)
            {
                case "MR":
                    calculator.PublicOperation.Text = Calculator.savedValue;
                    break;
                case "M":
                    Calculator.savedValue = calculator.PublicResult.Text;
                    break;
                case "C":
                    calculator.cleanForm(null);
                    break;
                case "±":
                    if (calculator.PublicResult.Text == "") return;

                    double parsedString = double.Parse(calculator.PublicResult.Text);
                    calculator.PublicResult.Text = parsedString > 0 ?
                        ("-" + calculator.PublicResult.Text) :
                        Math.Abs(parsedString).ToString();

                    break;
                case ".":
                    // Comprueba si ya hay un punto/número
                    if (calculator.PublicResult.Text.Contains(".") ||
                        calculator.PublicResult.Text.Length == 0) return;
                    calculator.PublicResult.Text += ".";
                    break;
                case "=":
                    calculator.PublicResult.Text = Utils.calculate
                        (calculator.PublicOperation.Text + calculator.PublicResult.Text);
                    calculator.PublicOperation.Text = "";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Realiza una acción en función del tipo de acción
        /// </summary>
        /// <param name="buttonText">Texto del botón</param>
        public void handleAction(string buttonText)
        {
            if (Utils.isNumber(buttonText))
            {
                // Comprueba si se debe resetear el valor de resultado
                if (Calculator.lastValue == calculator.PublicResult.Text)
                {
                    calculator.PublicResult.Text = buttonText;
                }
                else
                {
                    calculator.PublicResult.Text += buttonText;
                }

                return;
            }

            if (Utils.isSpecialOperation(buttonText))
            {
                handleSpecialOperation(buttonText);
                return;
            }

            // Se ejecuta si la acción es un operador
            if (Calculator.lastValue != calculator.PublicResult.Text)
            {
                var opResult = Utils.calculate
                    (calculator.PublicOperation.Text + calculator.PublicResult.Text);
                calculator.PublicOperation.Text = (opResult + " " + buttonText + " ");
                calculator.PublicResult.Text = opResult;
                Calculator.lastValue = calculator.PublicResult.Text;
            }
        }
    }
}