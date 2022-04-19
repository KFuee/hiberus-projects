using System;

namespace AlgoritmosRecursivos
{
    class Utils
    {
        public static int pedirNumero()
        {
            // Pide un número por consola
            Console.Write("Introduce un número: ");
            string numero = Console.ReadLine();
             
            return int.Parse(numero);
        }
    }
}
