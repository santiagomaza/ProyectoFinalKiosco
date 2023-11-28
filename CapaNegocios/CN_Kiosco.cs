using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class CN_Kiosco
    {
        //INSTANCIAMOS LA CLASE CD_KIOSCO UBICADA EN LA CAPA DE DATOS
        CD_Kiosco kiosquito = new CD_Kiosco();
        public DataTable ListarVentas()
        {
            //MEDIANTE ESTE METODO PUBLICA SE MOSTRARÁN EN UN DATATABLE LAS VENTAS INGRESADAS EN LA DB
            DataTable tabla = new DataTable();
            tabla = kiosquito.ListarVentas();
            return tabla;
        }
        public DataTable ListarClientes()
        {
            //MEDIANTE ESTE METODO PUBLICA SE MOSTRARÁN EN UN DATATABLE LOS CLIENTES INGRESADOS EN LA DB
            DataTable tablaCliente = new DataTable();
            return tablaCliente = kiosquito.MostrarClientes();
        }
        public DataTable MostrarProductos()
        {
            //MEDIANTE ESTE METODO PUBLICA SE MOSTRARÁN EN UN DATATABLE LOS PRODUCTOS INGRESADOS EN LA DB
            DataTable tablaProducto = new DataTable();
            return tablaProducto = kiosquito.MostrarProductos();
        }
        public void Insertar(string fechaVenta, string Id_Producto, string Id_Cliente)
        {
            //MEDIANTE ESTE METODO INSERTAR SE TOMARÁN LOS VALORES PROVENIENTES DE LA CAPA DE DATOS Y SI ES NECESARIO SE HARAN CONVERSIONES DE TIPO DE DATOS. CON ESTE MÉTODO SE AGREGAN VENTAS A LA DB
            kiosquito.Insertar(fechaVenta, int.Parse(Id_Producto), int.Parse(Id_Cliente));
        }
        public void Eliminar(string Id)
        {
            //MEDIANTE EL MÉTODO ELIMINAR ELIMINAMOS UNA VENTA DE LA DB PASANDOLE UN ID COMO PARAMETRO
            kiosquito.EliminarFisicoVenta(int.Parse(Id));
        }
        public void EditarVenta(string fechaVenta, string Id_Producto, string Id_Cliente, string Id)
        {
            //CON EL MÉTODO EDITAR EDITAMOS LOS DATOS EN LA BASE DE DATOS PASANDOLE LOS PARAMETROS CORRESPONDIENTES SUMADO AL ID
            kiosquito.EditarVenta(fechaVenta, int.Parse(Id_Producto), int.Parse(Id_Cliente), int.Parse(Id));
        }
    }
}
