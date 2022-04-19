using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosRecursivos
{
    class Program
    {
        private static int calcularFactorial(int n)
        {
            if (n != 1)
            {
                return n * calcularFactorial(n - 1);
            }

            return 1;
        }

        private static int calcularPotencia(int n, int potencia)
        {
            if (potencia != 0)
            {
                return n * calcularPotencia(n, potencia - 1);
            }

            return 1;
        }

        private static int calcularDivisionRestasSucesivas(int dividendo, int divisor) {
            if (divisor > dividendo)
            {
                return 0;
            }

            return 1 + calcularDivisionRestasSucesivas(dividendo - divisor, divisor);
        }

        private static int invertirNumero(int n) {
            return 1;
        }

        static void Main(string[] args)
        {
            //int resultadoFactorial = calcularFactorial(5);
            //Console.WriteLine("Resultado: " + resultadoFactorial);

            //int resultadoPotencia = calcularPotencia(2, 4);
            //Console.WriteLine("Resultado: " + resultadoPotencia);

            //int resultadoDivisionRestasSucesivas = calcularDivisionRestasSucesivas(35, 8);
            //Console.WriteLine("Resultado: " + resultadoDivisionRestasSucesivas);

            int resultadoInvertirNumero = invertirNumero(1356);
            Console.WriteLine("Resultado: " + resultadoInvertirNumero);

            Console.ReadLine();
        }
    }
}
