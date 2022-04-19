using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
