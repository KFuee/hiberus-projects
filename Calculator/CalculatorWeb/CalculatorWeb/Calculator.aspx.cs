using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculatorWeb
{
    public partial class Calculator : Page
    {
        public static string savedValue;
        public static string lastValue;

        private Handlers handlers;

        public TextBox PublicOperation
        {
            get { return this.operation; }
        }

        public TextBox PublicResult
        {
            get { return this.result; }
        }

        public Calculator()
        {
            handlers = new Handlers(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Método Page_Load
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