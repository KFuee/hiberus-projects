using System;

namespace AlgoritmosRecursivos.Ejercicios
{
    class Ejercicio9
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
            int resultadoNumeroMenor = numeroMenorVector(vectorNumeros, numeroDeDatos - 1);
            Console.WriteLine("Resultado: " + resultadoNumeroMenor);
        }

        private static int numeroMenorVector(int[] vector, int length)
        {
            if (length == 1)
            {
                return vector[0] > vector[1] ? vector[1] : vector[0];
            }

            return vector[length] < numeroMenorVector(vector, length - 1) ?
                vector[length] : numeroMenorVector(vector, length - 1);
        }
    }
}
