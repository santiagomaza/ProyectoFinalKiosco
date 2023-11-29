using System;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class ConexionSql
    {
        SqlConnection conexion = new SqlConnection("Data Source=NOTEBOOK-SANTI;Initial Catalog=Kiosco0;Integrated Security=True;");
 
        public SqlConnection OpenConnection()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }
        public SqlConnection CloseConnection()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }
    }
}
