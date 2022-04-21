namespace AlgoritmosOrdenacionLib.Metodos
{
    public class BubbleSort : Metodo
    {
        public string nombre {
            get => "Bubble Sort";
        }

        public void ejecutar(int[] vector)
        {
            int[] resultado = algoritmo(vector);

            // Imprime el resultado en consola
            Utils.imprimirResultado(nombre, resultado);
        }

        public int[] algoritmo(int[] vector)
        {
            int temporal;
            for (int escribir = 0; escribir < vector.Length; escribir++)
            {
                for (int ordenar = 0; ordenar < vector.Length - 1; ordenar++)
                {
                    if (vector[ordenar] > vector[ordenar + 1])
                    {
                        temporal = vector[ordenar + 1];
                        vector[ordenar + 1] = vector[ordenar];
                        vector[ordenar] = temporal;
                    }
                }
            }

            return vector;
        }
    }
}
