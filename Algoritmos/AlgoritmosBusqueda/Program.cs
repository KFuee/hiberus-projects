using System.IO;

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

        static void Main(string[] args)
        {
            string fichero = File.ReadAllText("search.txt");
            string[] texto = fichero.Split(' ', '\n');

            int posicionPalabra = busquedaPalabra("perro", texto);
            System.Console.WriteLine(
                string.Format("Palabra encontrada en la posición: {0}", posicionPalabra));
        }
    }
}
