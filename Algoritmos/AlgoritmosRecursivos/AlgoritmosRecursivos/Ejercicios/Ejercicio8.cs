using System;

namespace AlgoritmosRecursivos.Ejercicios
{
    class Ejercicio8
    {
        public static void ejecutar()
        {
            // Pide los datos por consola
            int primerNumero = Utils.pedirNumero("Introduce el primer número: ");
            int segundoNumero = Utils.pedirNumero("Introduce el segundo número: ");

            // Calcula la suma de los elementos del vector introducido
            int resultadoMaximoComunDivisor = maximoComunDivisor(
                primerNumero, segundoNumero);
            Console.WriteLine("Resultado: " + resultadoMaximoComunDivisor);
        }

        private static int maximoComunDivisor(int n1, int n2)
        {
            if (n2 == 0)
            {
                return n1;
            }

            return maximoComunDivisor(n2, n1 % n2);
        }
    }
}
