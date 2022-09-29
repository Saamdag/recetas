using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
     class Receta
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string cheff { get; set; }
        public int tipoReceta { get; set; }

        public List<DetalleReceta> listDetalle { get; set; }

        public Receta()
        {
            listDetalle = new List<DetalleReceta>();

        }

        public void agregarDetalle(DetalleReceta detalle)
        {
            listDetalle.Add(detalle);
        }

        public void quitarDetalle(int indice)
        {
            listDetalle.RemoveAt(indice);
        }
    }
}
