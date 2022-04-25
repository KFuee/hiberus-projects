using System;
using System.IO;

namespace AlgoritmosOrdenacionLib
{
    public class Utils
    {
        public static int pedirNumero(string mensaje = "")
        {
            Console.Write(mensaje.Length > 0 ? mensaje : "Introduce un número: ");

            return int.Parse(Console.ReadLine());
        }

        public static void imprimirResultado(string metodo, int[] resultado)
        {
            Console.WriteLine(string.Format("El resultado del {0} es:", metodo));

            foreach (var item in resultado)
            {
                Console.Write(item + " ");
            }

            // Deja espacio en blanco al final
            Console.WriteLine();
        }

        public static int[] leerNumerosDeFichero(string file, char[] splitBy)
        {
            string fichero = File.ReadAllText(file);
            string[] numeros = fichero.Split(splitBy);

            int[] numerosParsed = new int[numeros.Length];
            for (int i = 0; i < numeros.Length - 1; i++)
            {
                numerosParsed[i] = int.Parse(numeros[i]);
            }

            return numerosParsed;
        }
    }
}
