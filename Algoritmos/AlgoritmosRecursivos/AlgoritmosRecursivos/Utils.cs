using System;

namespace AlgoritmosRecursivos
{
    class Utils
    {
        public static int pedirNumero(string mensaje = "")
        {
            // Pide un número por consola
            Console.Write(mensaje.Length > 0 ? mensaje : "Introduce un número: ");
            string numero = Console.ReadLine();
             
            return int.Parse(numero);
        }
    }
}
