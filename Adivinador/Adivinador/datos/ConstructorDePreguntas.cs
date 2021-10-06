using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adivinador.datos
{
    class ConstructorDePreguntas
    {
        public int id { get; set; }
        public String pregunta { get; set; }
        public int nodoPadre { get; set; }
        public int nodoIzquierdo { get; set; }
        public int nodoDerecho { get; set; }

        public ConstructorDePreguntas()
        {

        }
    }
}
