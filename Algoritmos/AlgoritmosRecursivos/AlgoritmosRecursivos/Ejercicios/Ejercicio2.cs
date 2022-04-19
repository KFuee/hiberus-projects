using System;

namespace AlgoritmosRecursivos.Ejercicios
{
    class Ejercicio2
    {
        public static void ejecutar()
        {
            // Pide los datos por consola
            int numeroUsuario = Utils.pedirNumero();
            int potenciaUsuario = Utils.pedirNumero();

            // Calcula la potencia con los datos introducidos
            int resultadoPotencia = calcularPotencia(numeroUsuario, potenciaUsuario);
            Console.WriteLine("Resultado: " + resultadoPotencia);
        }

        private static int calcularPotencia(int n, int potencia)
        {
            if (potencia != 0)
            {
                return n * calcularPotencia(n, potencia - 1);
            }

            return 1;
        }
    }
}
