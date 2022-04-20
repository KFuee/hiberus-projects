using System;

namespace AlgoritmosRecursivos.Ejercicios
{
    class Ejercicio7
    {
        public static void ejecutar()
        {
            // Pide los datos por consola
            int numeroDeDatos = Utils.pedirNumero("Introduce el tamaño del vector: ");

            int[] vectorNumeros = new int[numeroDeDatos];

            for (int i = 0; i < numeroDeDatos; i++)
            {
                int nuevoNumero = Utils.pedirNumero(
                    string.Format("Introduce el número {0}: ", i + 1));
                vectorNumeros[i] = nuevoNumero;
            }

            // Calcula la multiplicación de los elementos del vector introducido
            int resultadoMultiplicacionVector = multiplicacionElementosVector(
                vectorNumeros, numeroDeDatos - 1);
            Console.WriteLine("Resultado: " + resultadoMultiplicacionVector);
        }

        private static int multiplicacionElementosVector(int[] vector, int n)
        {
            if (n < 0)
            {
                return 1;
            }

            return vector[n] * multiplicacionElementosVector(vector, n - 1);
        }
    }
}
