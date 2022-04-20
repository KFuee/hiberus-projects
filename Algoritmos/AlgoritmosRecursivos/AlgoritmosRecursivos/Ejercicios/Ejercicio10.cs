using System;

namespace AlgoritmosRecursivos.Ejercicios
{
    class Ejercicio10
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

            // Obtiene el número mayor de los elementos del vector introducido
            int resultadoNumeroMayor = numeroMayorVector(vectorNumeros, numeroDeDatos - 1);
            Console.WriteLine("Resultado: " + resultadoNumeroMayor);
        }

        private static int numeroMayorVector(int[] vector, int length)
        {
            if (length == 1)
            {
                return vector[0] > vector[1] ? vector[0] : vector[1];
            }

            return vector[length] > numeroMayorVector(vector, length - 1) ?
                vector[length] : numeroMayorVector(vector, length - 1);
        }
    }
}
