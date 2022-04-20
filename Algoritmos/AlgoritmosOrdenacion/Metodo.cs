using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosOrdenacion
{
    public interface Metodo
    {
        string nombre {
            get;
        }

        void ejecutar(int[] vector);

        string[] algoritmo(int[] vector);
    }
}
