using System;

namespace AlgoritmosRecursivos.Ejercicios
{
    class Ejercicio4
    {
        public static void ejecutar()
        {
            // Pide los datos por consola
            int numeroUsuario = Utils.pedirNumero();

            // Invierte el número introducido
            int resultadoInversion = invertirNumero(numeroUsuario, 0);
            Console.WriteLine("Resultado: " + resultadoInversion);
        }

        private static int invertirNumero(int n, int acumulador)
        {
            // Obtiene el último número y lo añade al acumulador hasta n = 0
            return n == 0 ? acumulador :
                invertirNumero(n / 10, acumulador * 10 + n % 10);
        }
    }
}
