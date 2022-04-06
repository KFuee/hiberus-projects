using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace CalculadoraWin
{
    public partial class Calculadora : Form
    {
        public string savedValue;
        public string lastValue;

        public Calculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Limpia los TextBox del formulario
        /// </summary>
        /// <param name="resultText">Solo utilizado cuando se divide entre 0</param>
        private void cleanForm(string resultText)
        {
            operation.Text = "";
            result.Text = resultText;
            lastValue = null;
        }

        /// <summary>
        /// Comprueba si es una operación especial
        /// </summary>
        /// <param name="operation">Valor de buttonText</param>
        /// <returns>bool indicando si es una operación especial</returns>
        private bool isSpecialOperation(string value)
        {
            string[] specialOperations = new string[] { "MR", "M", "C", "=" };

            return specialOperations.Contains(value);
        }

        /// <summary>
        /// Comprueba si es un número parseandolo
        /// </summary>
        /// <param name="value">Valor de buttonText</param>
        /// <returns>Indica si la conversión se ha realizado correctamente</returns>
        private bool isNumber(string value)
        {
            return double.TryParse(value, out _);
        }

        /// <summary>
        /// Realiza el cálculo del input con DataTable.Compute
        /// </summary>
        /// <param name="operation">String con la operación</param>
        /// <returns>Devuelve String con el resultado</returns>
        private string calculate(string operation)
        {
            DataTable dt = new DataTable();

            string result = Convert.ToString(dt.Compute(operation, null));

            /* Al dividir entre 0 con Compute no suelta una excepción
             * y da como resultado "∞", ya que es el límite de los resultados.
             * Por eso lanzamos la excepción DivideByZero
             **/
            if (result == "∞") throw new DivideByZeroException();

            return result;
        }

        /// <summary>
        /// Controla que acción ejecutar si es una operación especial
        /// </summary>
        /// <param name="operation">Tipo de operación</param>
        private void handleSpecialOperation(string operation)
        {
            switch (operation)
            {
                case "MR":
                    this.operation.Text = savedValue;
                    break;
                case "M":
                    savedValue = result.Text;
                    break;
                case "C":
                    cleanForm(null);
                    break;
                case "=":
                    result.Text = calculate(this.operation.Text + result.Text);
                    this.operation.Text = "";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Realiza una acción en función del tipo de acción
        /// </summary>
        /// <param name="buttonText">Texto del botón</param>
        private void handleAction(string buttonText)
        {
            if (isNumber(buttonText))
            {
                // Comprueba si se debe resetear el valor de resultado
                if (lastValue == result.Text)
                {
                    result.Text = buttonText;
                } else
                {
                    result.Text += buttonText;
                }

                return;
            }

            if (isSpecialOperation(buttonText))
            {
                handleSpecialOperation(buttonText);
                return;
            }

            // Se ejecuta si la acción es un operador
            if (lastValue != result.Text)
            {
                var opResult = calculate(operation.Text + result.Text);
                operation.Text = (opResult + " " + buttonText + " ");
                result.Text = opResult;
                lastValue = result.Text;
            }
        }

        public void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            try
            {
                handleAction(button.Text);
            }
            catch (DivideByZeroException)
            {
                cleanForm("No se puede dividir entre cero");
            }
        }
    }
}
