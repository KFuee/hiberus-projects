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

        public Calculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Comprueba si es un operador
        /// </summary>
        /// <param name="value">Valor de buttonText</param>
        /// <returns>bool indicando si es un operador</returns>
        private bool isOperator(string value)
        {
            string[] operators = new string[] { "*", "/", "+", "-" };

            return operators.Contains(value);
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

            return Convert.ToString(dt.Compute(operation, null));
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
                    this.operation.Text = "";
                    result.Text = "";
                    break;
                case "=":
                    result.Text = calculate(this.operation.Text);
                    this.operation.Text = "";
                    break;
                default:
                    break;
            }
        }

        public void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            if (isNumber(buttonText))
            {
                result.Text += buttonText;
                return;
            }

            if (isSpecialOperation(buttonText))
            {
                handleSpecialOperation(buttonText);
                return;
            }

            if (isOperator(buttonText))
            {
                var opResult = calculate(operation.Text + result.Text);
                operation.Text = (opResult + " " + buttonText + " ");
                result.Text = opResult;
            }
        }
    }
}
