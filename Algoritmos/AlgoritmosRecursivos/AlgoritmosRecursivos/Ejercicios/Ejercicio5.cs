using System;

namespace AlgoritmosRecursivos.Ejercicios
{
    class Ejercicio5
    {
        public static void ejecutar()
        {
            // Pide los datos por consola
            int numeroUsuario = Utils.pedirNumero();

            // Calcula la suma con los datos introducidos
            int resultadoSumaDigitos = calcularSumaDigitos(numeroUsuario, 0);
            Console.WriteLine("Resultado: " + resultadoSumaDigitos);
        }

        private static int calcularSumaDigitos(int n, int acumulador)
        {
            return n == 0 ? acumulador :
                calcularSumaDigitos(n / 10, (n % 10) + acumulador);
        }
    }
}
