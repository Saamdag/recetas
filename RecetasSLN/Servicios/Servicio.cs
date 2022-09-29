using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RecetasSLN.datos;
using RecetasSLN.datos.Implementacion;
using System.Data;

namespace RecetasSLN.Servicios
{
     class Servicio : IServicio
    {
        IReceta DAO;

        public Servicio()
        {
            DAO = new RecetaDao();
        }

        public bool confirmarReceta(Receta oReceta)
        {
            return DAO.crearReceta(oReceta);
        }

        public List<Receta> listarRecetas()
        {
            return DAO.listarRecetas();

        }

        public List<Ingrediente> obtenerIngredientes()
        {
            return DAO.getIngredientes();
        }

        public List<Receta> listarRecetas(string nombre,int tipo)
        {
            return DAO.listarRecetas(nombre,tipo);

        }
    }
}
