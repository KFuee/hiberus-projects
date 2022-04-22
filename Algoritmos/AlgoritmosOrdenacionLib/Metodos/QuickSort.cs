namespace AlgoritmosOrdenacionLib.Metodos
{
    public class QuickSort : Metodo
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

        private static int[] quickSort(int[] vector, int izq, int dcha)
        {
            int pivote = vector[izq];
            int i = izq;
            int j = dcha;

            int aux;

            while (i < j)
            {
                while (vector[i] <= pivote && i < j)
                {
                    i++;
                }

                while (vector[j] > pivote)
                {
                    j--;
                }

                if (i < j)
                {
                    aux = vector[i];
                    vector[i] = vector[j];
                    vector[j] = aux;
                }
            }

            vector[izq] = vector[j];
            vector[j] = pivote;

            if (izq < j - 1)
            {
                quickSort(vector, izq, j - 1);
            }

            if (j + 1 < dcha)
            {
                quickSort(vector, j + 1, dcha);
            }

            return vector;
        }

        public int[] algoritmo(int[] vector)
        {
            return quickSort(vector, 0, vector.Length - 1);
        }
    }
}
