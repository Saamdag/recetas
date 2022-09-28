using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RecetasSLN.datos
{
    internal class helperDb
    {
        private static helperDb instancia;
        private DAO DAO = new DAO();

        private helperDb()
        {
            
        }

        public static helperDb obtenerInstancia()
        {
            if(instancia== null)
                instancia = new helperDb();
            return instancia;
        }

        public DataTable listarProductos()
        {
            return DAO.listarIngredientes();

        }

        public bool confirmarReceta(Receta oReceta)
        {
            return DAO.ejecutarInsert(oReceta);

        }

        public void consultarProximo(string nombreSp,string nombreParamOut)
        {

        }




    }
}
