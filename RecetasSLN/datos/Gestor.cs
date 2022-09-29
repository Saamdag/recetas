using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecetasSLN.dominio;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Gestor
{
	public Gestor()
	{

     private static SqlConnection cnn;

    public DAO()
    {
        cnn = new SqlConnection(Properties.Resources.cnnString);
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
}
}
