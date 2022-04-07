using System;
using System.Windows.Forms;

namespace CalculatorWin
{
    public partial class Calculator : Form
    {
        public string savedValue;
        public string lastValue;

        private Handlers handlers;

        public Calculator()
        {
            InitializeComponent();
            handlers = new Handlers(this);
        }

        /// <summary>
        /// Limpia los TextBox del formulario
        /// </summary>
        /// <param name="resultText">Solo utilizado cuando se divide entre 0</param>
        public void cleanForm(string resultText)
        {
            operation.Text = "";
            result.Text = resultText;
            lastValue = null;
        }

        public void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            try
            {
                handlers.handleAction(button.Text);
            }
            catch (DivideByZeroException)
            {
                cleanForm("No se puede dividir entre cero");
            }
        }
    }
}
