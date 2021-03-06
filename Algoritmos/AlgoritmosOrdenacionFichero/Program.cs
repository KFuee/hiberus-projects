using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

// using métodos de ordenación
using AlgoritmosOrdenacionLib;
using AlgoritmosOrdenacionLib.Metodos;

namespace AlgoritmosOrdenacionFichero
{
    class Program
    {
        static Stopwatch timer = new Stopwatch();

        static Dictionary<Metodo, long> mediasEjecucion = new Dictionary<Metodo, long> ();

        static void imprimirResultado(int pos, Metodo tipo, long[] tiempos)
        {
            Console.Write(string.Format("Números ordenados con {0} en: ", tipo.nombre));
            foreach (var ms in tiempos)
            {
                Console.Write(ms + "ms ");
            }

            // Espacio en blanco
            Console.WriteLine();

            long media = tiempos.Sum() / 10;
            mediasEjecucion.Add(tipo, media);
            Console.WriteLine("Media de las 10 iteraciones con {0}: {1}ms", tipo.nombre, media);

            // Espacio en blanco
            Console.WriteLine();
        }

        private static long[] obtenerTiemposDeEjecucion(Metodo Metodo, int[] numeros)
        {
            long[] tiemposEjecucion = new long[10];
            for (int i = 0; i < 10; i++)
            {
                // Empieza a contar el tiempo de ejecución
                timer.Start();

                // Ordena el vector de números
                Metodo.algoritmo(numeros);

                // Para de contar el tiempo de ejecución
                timer.Stop();

                // Añade el tiempo de ejecución de la iteración al vector
                tiemposEjecucion[i] = timer.ElapsedMilliseconds;
                // Resetea el contador
                timer.Reset();
            }

            return tiemposEjecucion;
        }

        private static void guardarEnArchivo(int[] numeros)
        {
            // Obtiene el método que ha tardado menos en ordenar
            long numeroMenor = mediasEjecucion.Values.Min();
            KeyValuePair<Metodo, long> menor = mediasEjecucion.First(metodo => metodo.Value == numeroMenor);

            // Realiza la ordenación
            int[] ordenacion = menor.Key.algoritmo(numeros);

            // Escribe en el fichero
            string txtSalida = "numbersOutput.txt";
            StreamWriter escribir = new StreamWriter(txtSalida);

            foreach (int numero in ordenacion)
            {
                escribir.Write(numero + " ");
            }

            // Cierra el StreamWriter
            escribir.Close();
       
            Console.WriteLine(
                string.Format("Escrito el resultado con el método {0} en numbersOutput.txt", menor.Key.nombre));
        }

        // TODO: Al finalizar las iteracione obtener el que ha tardado menos y utilizarlo para escribir en el txt
        static void Main(string[] args)
        {
            // Empieza a contar el tiempo de ejecución de leerNumerosDeFichero
            timer.Start();

            // Lee los números del fichero numbers.txt
            int[] numerosFichero = Utils.leerNumerosDeFichero("numbers.txt", new char[] { ' ', '\n' });

            // Para de contar el tiempo de ejecución de leerNumerosDeFichero
            timer.Stop();

            // Imprime el tiempo de ejecución de leerNumerosDeFichero
            Console.WriteLine(
                string.Format("Números del fichero leídos en {0}ms", timer.ElapsedMilliseconds));
            // Resetea el contador
            timer.Reset();

            // Instanciar métodos de ordenación
            BubbleSort bSort = new BubbleSort();
            QuickSort qSort = new QuickSort();
            SelectionSort sSort = new SelectionSort();
            InsertionSort iSort = new InsertionSort();

            // Ejecuta los métodos de ordenación
            long[] tiemposEjecucionBubbleSort = obtenerTiemposDeEjecucion(bSort, numerosFichero);
            long[] tiemposEjecucionQuickSort = obtenerTiemposDeEjecucion(qSort, numerosFichero);
            long[] tiemposEjecucionSelectionSort = obtenerTiemposDeEjecucion(sSort, numerosFichero);
            long[] tiemposEjecucionInsertionSort = obtenerTiemposDeEjecucion(iSort, numerosFichero);

            // Espacio en blanco
            Console.WriteLine();
            // Imprime los tiempos de ejecución
            imprimirResultado(0, bSort, tiemposEjecucionBubbleSort);
            imprimirResultado(1, qSort, tiemposEjecucionQuickSort);
            imprimirResultado(2, sSort, tiemposEjecucionSelectionSort);
            imprimirResultado(3, iSort, tiemposEjecucionInsertionSort);

            guardarEnArchivo(numerosFichero);
        }
    }
}
