using System;
using System.IO;
using AlgoritmosOrdenacionLib;
using AlgoritmosOrdenacionLib.Metodos;

namespace AlgoritmosBusqueda
{
    class Program
    {
        private static int busquedaPalabra(string palabra, string[] texto)
        {
            int pos = 0;

            for (int i = 0; i < texto.Length - 1; i++)
            {
                if (texto[i].Equals(palabra))
                {
                    pos = i;
                }
            }

            return pos;
        }

        // Búsqueda binaria aplicando recursividad
        private static int busquedaBinaria(int numero, int[] numeros)
        {
            int izq = 0, dcha = numeros.Length - 1;

            while (izq <= dcha)
            {
                int posCentro = Convert.ToInt32(Math.Floor(Convert.ToDouble(izq + dcha) / 2));
                int valCentro = numeros[posCentro];

                // Comprobamos si se encuentra en el centro
                if (valCentro == numero)
                {
                    // Devuelve la posición central
                    return posCentro;
                }

                // Si no, seguimos buscando donde se encuentra
                if (numero < valCentro)
                {
                    dcha = posCentro - 1;
                } else
                {
                    izq = posCentro + 1;
                }
            }

            // Si no se ha devuelto nada quiere decir que no se encuentra
            return -1;
        }

        static void Main(string[] args)
        {
            // Búsqueda secuencial palabra
            string fichero = File.ReadAllText("search.txt");
            string[] texto = fichero.Split(' ', '\n');
            string palabraBuscar = "perro";

            int posicionPalabra = busquedaPalabra("perro", texto);
            Console.WriteLine(
                string.Format("Palabra '{0}' encontrada en la posición: {1}", palabraBuscar, posicionPalabra));

            // Búsqueda binaria número
            int[] numerosFichero = Utils.leerNumerosDeFichero("numbers2.txt", new char[] { '\t', '\n' });
            int[] ordenacion = new QuickSort().algoritmo(numerosFichero);
            int numeroBuscar = 81;

            int posicionNumero = busquedaBinaria(numeroBuscar, ordenacion);
            if (posicionNumero == -1)
            {
                Console.WriteLine("No se ha encontrado el número " + numeroBuscar);
                return;
            }

            Console.WriteLine(
                string.Format("Número {0} encontrado en la posición: {1}", numeroBuscar, posicionNumero));
        }
    }
}
