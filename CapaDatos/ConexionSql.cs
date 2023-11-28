using System;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class ConexionSql
    {
        //ESTABLECEMOS LA CONEXION A LA DB LOCAL
        SqlConnection conexion = new SqlConnection("Data Source=NOTEBOOK-SANTI;Initial Catalog=Kiosco0;Integrated Security=True;");

        //POR MEDIO DE ESTOS METODOS ABRIMOS O CERRAMOS LA CONEXION DEPENDIENDO EL USO QUE NECESITEMOS 
        //POR MEDIO DE LA CLASE SQLCONNECTION
        public SqlConnection OpenConnection()
        {
            //SI LA CONEXION SE ENCUENTRA CERRADA LA ABRE Y LA RETORNA
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }
        public SqlConnection CloseConnection()
        {
            //VERIFICA SI LA CONEXION SE ENCUENTRA ABIERTA SE LA CIERRA Y LA RETORNA
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }
    }
}
