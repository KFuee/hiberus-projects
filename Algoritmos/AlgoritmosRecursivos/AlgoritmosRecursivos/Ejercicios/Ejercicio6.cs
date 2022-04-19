using System;

namespace AlgoritmosRecursivos.Ejercicios
{
    class Ejercicio6
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

            // Calcula la suma de los elementos del vector introducido
            int resultadoSumaVector = sumarElementosVector(
                vectorNumeros, vectorNumeros.Length - 1);
            Console.WriteLine("Resultado: " + resultadoSumaVector);
        }

        private static int sumarElementosVector(int[] vector, int n)
        {
            if (n < 0)
            {
                return 0;
            }

            return vector[n] + sumarElementosVector(vector, n - 1);
        }
    }
}
