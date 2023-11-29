using System;
using System.Data; 
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Kiosco
    {
        
        ConexionSql conexion = new ConexionSql();
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;
        DataTable tabla = new DataTable();
        public DataTable ListarVentas()
        {
            try 
            {            
                comando.Connection = conexion.OpenConnection();
                
                string consulta = "ListarVentas";
                
                comando.CommandText = consulta;
                
                comando.CommandType = CommandType.StoredProcedure;
                
                lector = comando.ExecuteReader();
                
                tabla.Load(lector);
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                conexion.CloseConnection();
            }
            return tabla;
        }
        public DataTable MostrarClientes()
        {
            try
            {
                comando.Connection = conexion.OpenConnection();

                
                string consulta = "mostrarCliente";

                comando.CommandText = consulta;

                comando.CommandType = CommandType.StoredProcedure;

                lector = comando.ExecuteReader();

                tabla.Load(lector);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            finally
            {
                conexion.CloseConnection();
            }
            return tabla;
        }
        public DataTable MostrarProductos()
        {
            try
            {                
                comando.Connection = conexion.OpenConnection();
             
                string consulta = "select Id_Producto, Nombre_Producto from Producto";
              
                comando.CommandText = consulta;

                lector = comando.ExecuteReader();

                tabla.Load(lector);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.CloseConnection();
            }
            return tabla;
        }
        public void Insertar(string fechaVenta, int Id_Producto, int Id_Cliente)
        {
            try
            {      
                comando.Connection = conexion.OpenConnection();
              
                comando.CommandText = "insert into Venta values ('" + fechaVenta + "', '" + Id_Producto + "', '" + Id_Cliente + "')";

                comando.ExecuteNonQuery();
                
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                conexion.CloseConnection();
            }
        }
        public void EliminarFisicoVenta(int Id)
        {
            try
            {
                comando.Connection = conexion.OpenConnection();

                comando.CommandText = "delete from Venta where Id_Venta = '" + Id + "'";

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.CloseConnection();
            }

        }
        public void EditarVenta(string fechaVenta, int Id_Producto, int Id_Cliente, int Id)
        {
            try
            {
                comando.Connection = conexion.OpenConnection();

                comando.CommandText = "update Venta set Fecha_Venta = '" + fechaVenta + "', Id_Producto = '" + Id_Producto + "', Id_Cliente = '" + Id_Cliente + "' where Id_Venta =  '" + Id + "'";
                
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.CloseConnection();
            }
        }
    }
}
