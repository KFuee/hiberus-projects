namespace AlgoritmosOrdenacion.Metodos
{
    class SelectionSort : Metodo
    {
        public string nombre
        {
            get => "Selection Sort";
        }

        public void ejecutar(int[] vector)
        {
            int[] resultado = algoritmo(vector);

            // Imprime el resultado en consola
            Utils.imprimirResultado(nombre, resultado);
        }

        public int[] algoritmo(int[] vector)
        {
            int[] vectorOrdenado = vector;

            int temp, menor;
            for (int i = 0; i < vectorOrdenado.Length - 1; i++)
            {
                menor = i;
                for (int j = i + 1; j < vectorOrdenado.Length; j++)
                {
                    if (vectorOrdenado[j] < vectorOrdenado[menor])
                    {
                        menor = j;
                    }
                }

                temp = vectorOrdenado[menor];
                vectorOrdenado[menor] = vectorOrdenado[i];
                vectorOrdenado[i] = temp;
            }

            return vectorOrdenado;
        }
    }
}
