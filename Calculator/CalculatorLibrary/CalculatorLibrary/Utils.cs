using System;
using System.Data;
using System.Linq;

namespace CalculatorLibrary
{
    public class Utils
    {
        /// <summary>
        /// Comprueba si es una operación especial
        /// </summary>
        /// <param name="value">Valor de buttonText</param>
        /// <returns>bool indicando si es una operación especial</returns>
        public static bool isSpecialOperation(string value)
        {
            string[] specialOperations = new string[] { "MR", "M", "C", "±", ".", "=" };

            return specialOperations.Contains(value);
        }

        /// <summary>
        /// Comprueba si es un número parseandolo
        /// </summary>
        /// <param name="value">Valor de buttonText</param>
        /// <returns>Indica si la conversión se ha realizado correctamente</returns>
        public static bool isNumber(string value)
        {
            return double.TryParse(value, out _);
        }

        /// <summary>
        /// Realiza el cálculo del input con DataTable.Compute
        /// </summary>
        /// <param name="operation">String con la operación</param>
        /// <returns>Devuelve String con el resultado</returns>
        public static string calculate(string operation)
        {
            string opReplace = operation.Replace(",", ".");

            DataTable dt = new DataTable();

            string result = Convert.ToString(dt.Compute(opReplace, null));

            /* Al dividir entre 0 con Compute no suelta una excepción
             * y da como resultado "∞", ya que es el límite de los resultados.
             * Por eso lanzamos la excepción DivideByZero
             **/
            if (result == "∞") throw new DivideByZeroException();

            return result;
        }
    }
}
