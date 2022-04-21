namespace AlgoritmosOrdenacionLib.Metodos
{
    public class InsertionSort : Metodo
    {
        public string nombre
        {
            get => "Insertion Sort";
        }

        public void ejecutar(int[] vector)
        {
            int[] resultado = algoritmo(vector);

            // Imprime el resultado en consola
            Utils.imprimirResultado(nombre, resultado);
        }

        public int[] algoritmo(int[] vector)
        {
            for (int i = 0; i < vector.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (vector[j - 1] > vector[j])
                    {
                        int temp = vector[j - 1];
                        vector[j - 1] = vector[j];
                        vector[j] = temp;
                    }
                }
            }

            return vector;
        }
    }
}
