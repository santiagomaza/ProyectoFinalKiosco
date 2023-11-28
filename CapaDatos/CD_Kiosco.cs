using System;
using System.Data; //ESTO NOS PERMITE ACCEDER AL DATATABLE
using System.Data.SqlClient; //ESTO NOS PERMITE USAR SQLCOMMAND Y SQLDATAREADER

namespace CapaDatos
{
    public class CD_Kiosco
    {
        //GENERO LAS INSTANCIAS CORRESPONDIENTES
        ConexionSql conexion = new ConexionSql();
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;
        DataTable tabla = new DataTable();

        //LISTAMOS LAS VENTAS POR MEDIO DEL DATABLE
        public DataTable ListarVentas()
        {
            //ESTE TRY CATCH FINALLY PERMITE TRABAJAR CON EL MANEJO DE EXCEPCIONES
            try 
            {
                //PARA PODER TRABAJR NECESITAMOS TENER LA CONEXION ABIERTA
                comando.Connection = conexion.OpenConnection();
                //POR MEDIO DEL PROCEDIMIENTO ALMACENADO PODEMOS VER TODAS LAS VENTAS REALIZADAS
                string consulta = "ListarVentas";
                //---ESTE COMANDO RECIBE UNA CADENA DE TEXTO
                comando.CommandText = consulta;
                //EL COMMAND TYPE RECIBE EL PROCEDIMIENTO ALMACENADO
                comando.CommandType = CommandType.StoredProcedure;
                //POR MEDIO DEL LECTOR LEO LOS DATOS DE MI BD
                lector = comando.ExecuteReader();
                //AGREGO LOS DATOS A UNA TABLA 
                tabla.Load(lector);
            }
            catch (Exception error)
            {
                //SI SE ENCONTRO UN ERROR ME LO MOSTRARA
                throw error;
            }
            finally
            {
                //FINALMENTE CERRARA LA CONEXION
                conexion.CloseConnection();
            }
            return tabla;
        }
        public DataTable MostrarClientes()
        {
            try
            {
                //MEDIANTE ESTE METODO SE MOSTRARÁN LOS CLIENTES. PRIMERO SE ABRE LA CONEXION
                comando.Connection = conexion.OpenConnection();

                //MEDIANTE UN STORED PROCEDURE SE MOSTRARÁN LOS CLIENTRS
                string consulta = "mostrarCliente";

                comando.CommandText = consulta;

                comando.CommandType = CommandType.StoredProcedure;

                //SE EJECUTA EL COMANDO EXECUTEREADER PARA HACER UNA LECTURA
                lector = comando.ExecuteReader();

                tabla.Load(lector);
            }
            catch (Exception ex)
            {
                //EN CASO DE ERROR SE MANDA UN MENSAJE
                throw ex;
            }
            finally
            {
                //FINALMENTE SE CIERRA LA CONEXIÓN
                conexion.CloseConnection();
            }
            return tabla; //Y SE RETORNA LA TABLA
        }
        public DataTable MostrarProductos()
        {
            try
            {
                //MEDIANTE ESTE METODO SE MOSTRARÁ EN UN DATATABLE LOS PRODUCTOS
                comando.Connection = conexion.OpenConnection();

                //SE HACE UNA CONSULTA NORMAL SELECCIONANDO LAS COLUMNAS A HACER LA CONSULTA
                string consulta = "select Id_Producto, Nombre_Producto from Producto";

                //MEDIANTE EL COMMAND TEXT SE LE PASA LA QUERY
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
            return tabla; //SE RETORNA EL VALOR DE LA TABLA
        }
        public void Insertar(string fechaVenta, int Id_Producto, int Id_Cliente)
        {
            try
            {
                //MEDIANTE ESTE METODO SE INSERTAN VALORES DE VENTA A LA BD PASANDOLE PARAMETROS DE FECHA DE VENTA, EL ID DEL PRODUCTO Y EL ID DEL CLIENTE

                comando.Connection = conexion.OpenConnection();

                //MEDIANTE EL COMMAND TEXT SE LE PASA LA QUERY QUE CONTIENE EL COMANDO PARA PODER INSERTAR LOS VALORES PASANDOLE ADEMÁS LOS PARAMETROS INICIALES EN EL MÉTODO
                comando.CommandText = "insert into Venta values ('" + fechaVenta + "', '" + Id_Producto + "', '" + Id_Cliente + "')";

                //Y SE UTULIZA EL MÉTODO EXECUTENONQUERY PORQUE EN ESTE CASO NO SE HACE UNA LECTURA DE DATOS
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
                //CON ESTE METODO SE ELIMINAN LOS DATOS DE LA TABLA DE VENTAS PASANDOLE COMO PARAMETRO UN ID

                comando.Connection = conexion.OpenConnection();

                //AL COMMAND TEXT SE LE PASA LA QUERY QUE CONTIENE EL COMANDO PARA PODER BORRAR UN DATO PASANDOLE EL PARAMETRO DEL ID
                comando.CommandText = "delete from Venta where Id_Venta = '" + Id + "'";

                //SE UTILIZA EL MÉTODO EXECUTE NON QUERY PORQUE EN ESTE CASO NO SE HACE LECTURA DE DATOS
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
                //MEDIATE EL METODO EDITAR SE EDITAN LOS DATOS DE LA TABLA VENTAS DE LA BD PASANDOLE LOS RESPECTIVOS PARAMETROS

                comando.Connection = conexion.OpenConnection();

                //AL COMMAND TEXT SE LE PASA LA QUERY QUE CONTIENE EL COMANDO PARA ACTUALIZAR LOS DATOS
                comando.CommandText = "update Venta set Fecha_Venta = '" + fechaVenta + "', Id_Producto = '" + Id_Producto + "', Id_Cliente = '" + Id_Cliente + "' where Id_Venta =  '" + Id + "'";
                
                //EN ESTE CASO SE UTILIZA EL MÉTODO EXECUTE NON QUERY PORQUE NO SE HACE LECTURA DE DATOS
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
