using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSLN.datos;
using RecetasSLN.dominio;
using System.Data;
using System.Data.SqlClient;

namespace RecetasSLN.datos.Implementacion
{
     class RecetaDao : IReceta
    {
        helperDb db;

        public RecetaDao()
        {
            db = new helperDb();
        }
        
      

        public int obtenerProxNum()
        {
            throw new NotImplementedException();
        }

        public bool crearReceta(Receta oReceta)
        {
             return db.obInstancia().ejecutarInsert(oReceta);
           
        }

        public List<Ingrediente> getIngredientes()
        {
            List<Ingrediente> lst = new List<Ingrediente>();
            DataTable dt = db.obInstancia().listarIngredientes();
            //mapeo
            foreach(DataRow fila in dt.Rows)
            {
                Ingrediente i = new Ingrediente((int)fila["id_ingrediente"], fila["n_ingrediente"].ToString(), fila["unidad_medida"].ToString());
               lst.Add(i);
            }

            return lst;
        }

        public List<Receta> listarRecetas()
        {
            List<Receta> lst = new List<Receta>();
            DataTable dt =  db.obInstancia().Consultar("[dbo].[SP_CONSULTAR_RECETAS]");

            foreach (DataRow fila in dt.Rows)
            {
                Receta r = new Receta();
                r.id = (int)fila["id_receta"];
                r.tipoReceta = (int)fila["tipo_receta"];
                r.nombre = (string)fila["nombre"];
                r.cheff = (string)fila["cheff"];

                lst.Add(r);
            }

            return lst;
        }

        public List<Receta> listarRecetas(string nombre,int tipoReceta)
        {
            List<Receta> lst = new List<Receta>();

            List<SqlParameter> pList = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@nombre", nombre);
            SqlParameter p1 = new SqlParameter("@tipoReceta", tipoReceta);
            pList.Add(p);
            pList.Add(p1);

            DataTable dt = db.obInstancia().Consultar("[dbo].[SP_CONSULTAR_RECETASFILTRO]",pList);

            foreach (DataRow fila in dt.Rows)
            {
                Receta r = new Receta();
                r.id = (int)fila["id_receta"];
                r.tipoReceta = (int)fila["tipo_receta"];
                r.nombre = (string)fila["nombre"];
                r.cheff = (string)fila["cheff"];

                lst.Add(r);
            }

            return lst;
        }
    }
}
