using System;
using CalculatorLibrary;

namespace CalculatorWin
{
    class Handlers
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
                    calculator.operation.Text = calculator.savedValue;
                    break;
                case "M":
                    calculator.savedValue = calculator.result.Text;
                    break;
                case "C":
                    calculator.cleanForm(null);
                    break;
                case "±":
                    if (calculator.result.Text == "") return;

                    double parsedString = double.Parse(calculator.result.Text);
                    calculator.result.Text = parsedString > 0 ? 
                        ("-" + calculator.result.Text) :
                        Math.Abs(parsedString).ToString();

                    break;
                case ".":
                    // Comprueba si ya hay un punto/número
                    if (calculator.result.Text.Contains(".") ||
                        calculator.result.Text.Length == 0) return;
                    calculator.result.Text += ".";
                    break;
                case "=":
                    calculator.result.Text = Utils.calculate
                        (calculator.operation.Text + calculator.result.Text);
                    calculator.operation.Text = "";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Realiza una acción en función del botón pulsado
        /// </summary>
        /// <param name="buttonText">Texto del botón</param>
        public void handleAction(string buttonText)
        {
            if (Utils.isNumber(buttonText))
            {
                // Comprueba si se debe resetear el valor de resultado
                if (calculator.lastValue == calculator.result.Text)
                {
                    calculator.result.Text = buttonText;
                }
                else
                {
                    calculator.result.Text += buttonText;
                }

                return;
            }

            if (Utils.isSpecialOperation(buttonText))
            {
                handleSpecialOperation(buttonText);
                return;
            }

            // Se ejecuta si la acción es un operador
            if (calculator.lastValue != calculator.result.Text)
            {
                var opResult = Utils.calculate
                    (calculator.operation.Text + calculator.result.Text);
                calculator.operation.Text = (opResult + " " + buttonText + " ");
                calculator.result.Text = opResult;
                calculator.lastValue = calculator.result.Text;
            }
        }
    }
}
