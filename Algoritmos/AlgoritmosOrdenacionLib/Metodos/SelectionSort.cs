namespace AlgoritmosOrdenacionLib.Metodos
{
    public class SelectionSort : Metodo
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
            int temp, menor;
            for (int i = 0; i < vector.Length - 1; i++)
            {
                menor = i;
                for (int j = i + 1; j < vector.Length; j++)
                {
                    if (vector[j] < vector[menor])
                    {
                        menor = j;
                    }
                }

                temp = vector[menor];
                vector[menor] = vector[i];
                vector[i] = temp;
            }

            return vector;
        }
    }
}
