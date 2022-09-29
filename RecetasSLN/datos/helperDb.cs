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
    class helperDb
    {
        private  SqlConnection cnn;
        private  helperDb instancia;
        

        public helperDb()
        {
            cnn = new SqlConnection(Properties.Resources.cnnString);
        }

        public  helperDb obInstancia()
        {
            if(instancia== null)
                instancia = new helperDb();
            return instancia;
        }

        private SqlConnection abrirCnn()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }

            return cnn;
        }
        private SqlConnection cerrarCnn()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            return cnn;
        }


        public bool ejecutarInsert(Receta oReceta)
        {
            bool ok = true;
            SqlTransaction t = null;
            //SqlCommand cmd = new SqlCommand();

            try
            {
                abrirCnn();
                //t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("dbo.SP_INSERTAR_RECETA", cnn, t);
                //cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
               // cmd.CommandText = "dbo.SP_INSERTAR_RECETA";
                cmd.Parameters.AddWithValue("@nombre", oReceta.nombre);
                cmd.Parameters.AddWithValue("@cheff", oReceta.cheff);
                cmd.Parameters.AddWithValue("@tipo_receta", oReceta.tipoReceta);

                //parámetro de salida:
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@id";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);
                cmd.ExecuteNonQuery();

                int recetaNro = (int)pOut.Value;

                SqlCommand cmdDetalle;
                //int detalleNro = 1;

                foreach (DetalleReceta item in oReceta.listDetalle)
                {
                    cmdDetalle = new SqlCommand("dbo.SP_INSERTAR_DETALLES", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.CommandType = CommandType.Text;
                    cmdDetalle.Parameters.AddWithValue("@id_receta", recetaNro);
                    cmdDetalle.Parameters.AddWithValue("@id_ingrediente", item.ingrediente.idIngrediente);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.cantidad);
                    //cmdDetalle.Parameters.AddWithValue("@nroDetalle", detalleNro);
                    cmdDetalle.ExecuteNonQuery();
                    //detalleNro++;
                }
                t.Commit();

            }
            catch (Exception ex)
            {
                if (t != null)
                    t.Rollback();
                ok = false;

            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cerrarCnn();
            }
            return ok;
        }

        public DataTable Consultar(string NombreSP)
        {
            DataTable tabla = new DataTable();

            cnn.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = NombreSP;

            tabla.Load(comando.ExecuteReader());

            cnn.Close();
            return tabla;
        }

        public DataTable Consultar(string NombreSP,List<SqlParameter> parametros)
        {
            DataTable tabla = new DataTable();

            cnn.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = NombreSP;

            foreach (SqlParameter p in parametros)
            {
                comando.Parameters.AddWithValue(p.ParameterName, p.Value);
            }

            tabla.Load(comando.ExecuteReader());

            cnn.Close();
            comando.Parameters.Clear();
            return tabla;
        }


        public DataTable listarIngredientes()
        {
            DataTable resultado = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirCnn();
            cmd.CommandText = "[dbo].[SP_CONSULTAR_INGREDIENTES]";
            cmd.CommandType = CommandType.StoredProcedure;

            resultado.Load(cmd.ExecuteReader());

            cerrarCnn();

            return resultado;
        }



    }
}
