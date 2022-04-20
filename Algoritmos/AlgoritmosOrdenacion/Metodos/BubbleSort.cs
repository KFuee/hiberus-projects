using System;

namespace AlgoritmosOrdenacion.Metodos
{
    class BubbleSort : Metodo
    {
        public string nombre {
            get => "Bubble Sort";
        }

        public void ejecutar(int[] vector)
        {
            string[] resultado = algoritmo(vector);

            Console.WriteLine("El resultado del Bubble Sort es:");
            Console.WriteLine(resultado);
        }

        public string[] algoritmo(int[] vector)
        {
            string[] prueba = new string[0];
            return prueba;
        }
    }
}
