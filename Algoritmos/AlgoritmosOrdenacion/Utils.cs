using System;

namespace AlgoritmosOrdenacion
{
    class Utils
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
    }
}
