namespace AlgoritmosOrdenacion.Metodos
{
    class QuickSort : Metodo
    {
        public string nombre
        {
            get => "Quick Sort";
        }

        public void ejecutar(int[] vector)
        {
            int[] resultado = algoritmo(vector);

            // Imprime el resultado en consola
            Utils.imprimirResultado(nombre, resultado);
        }

        static private int partir(int[] vector, int izq, int dcha)
        {
            int pivote;
            pivote = vector[izq];

            while (true)
            {
                while (vector[izq] < pivote)
                {
                    izq++;
                }

                while (vector[dcha] > pivote)
                {
                    dcha--;
                }

                if (izq < dcha)
                {
                    int temp = vector[dcha];
                    vector[dcha] = vector[izq];
                    vector[izq] = temp;
                } else
                {
                    return dcha;
                }
            }
        }

        private int[] quickSort(int[] vector, int izq, int dcha)
        {
            int pivote;
            int[] vectorOrdenado = vector;

            if (izq < dcha)
            {
                pivote = partir(vectorOrdenado, izq, dcha);

                if (pivote > 1)
                {
                    quickSort(vectorOrdenado, izq, dcha - 1);
                }

                if (pivote + 1 < dcha)
                {
                    quickSort(vectorOrdenado, pivote + 1, dcha);
                }
            }

            return vectorOrdenado;
        }

        public int[] algoritmo(int[] vector)
        {
            return quickSort(vector, 0, vector.Length - 1);
        }
    }
}
