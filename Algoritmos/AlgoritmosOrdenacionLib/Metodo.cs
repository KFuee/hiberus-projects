namespace AlgoritmosOrdenacionLib
{
    public interface Metodo
    {
        string nombre {
            get;
        }

        void ejecutar(int[] vector);

        int[] algoritmo(int[] vector);
    }
}
