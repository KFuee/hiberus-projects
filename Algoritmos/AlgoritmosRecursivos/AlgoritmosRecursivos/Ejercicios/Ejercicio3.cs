using System;

namespace AlgoritmosRecursivos.Ejercicios
{
    class Ejercicio3
    {
        public static void ejecutar()
        {
            // Pide los datos por consola
            int dividendoUsuario = Utils.pedirNumero();
            int divisorUsuario = Utils.pedirNumero();

            // Calcula la división con los datos introducidos
            int resultadoDivision = calcularDivision(dividendoUsuario, divisorUsuario);
            Console.WriteLine("Resultado: " + resultadoDivision);
        }

        private static int calcularDivision(int dividendo, int divisor)
        {
            if (divisor > dividendo)
            {
                return 0;
            }

            return 1 + calcularDivision(dividendo - divisor, divisor);
        }
    }
}
