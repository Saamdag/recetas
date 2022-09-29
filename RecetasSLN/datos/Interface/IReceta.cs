using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSLN.dominio;
namespace RecetasSLN.datos
{
     interface IReceta
    {
        int obtenerProxNum();
        List<Ingrediente> getIngredientes();

        bool crearReceta(Receta oReceta);

        List<Receta> listarRecetas();
        List<Receta> listarRecetas(string nombre,int tipoReceta);
    }
}
