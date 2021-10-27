using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Adivinador.prueba
{
    class ArbolBinario
    {
        public String dato;
        public ArbolBinario izquierdo, derecho, Padre;
       

        public Prueba arbol { get; set; }

        public ArbolBinario(String info, ArbolBinario izq, ArbolBinario der, ArbolBinario padre)
        {
            dato = info;
            izquierdo = izq;
            derecho = der;
            Padre = padre;
            
        }
       

    }
}
