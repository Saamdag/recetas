using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSLN.dominio;

namespace RecetasSLN.Servicios
{
     interface IServicio
    {
        List<Ingrediente> obtenerIngredientes();
        bool confirmarReceta(Receta oReceta);

        List<Receta> listarRecetas();

        List<Receta> listarRecetas(string nombre,int tipo);
    }
}
