using System;

namespace AlgoritmosRecursivos.Ejercicios
{
    class Ejercicio1
    {
        public static void ejecutar()
        {
            // Pide los datos por consola
            int numeroUsuario = Utils.pedirNumero();

            // Calcula el factorial con los datos introducidos
            int resultadoFactorial = calcularFactorial(numeroUsuario);
            Console.WriteLine("Resultado: " + resultadoFactorial);
        }

        private static int calcularFactorial(int n)
        {
            if (n != 1)
            {
                return n * calcularFactorial(n - 1);
            }

            return 1;
        }
    }
}
