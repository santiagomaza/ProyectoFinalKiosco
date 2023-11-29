using System;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class CN_Kiosco
    {
        CD_Kiosco kiosquito = new CD_Kiosco();
        public DataTable ListarVentas()
        {        
            DataTable tabla = new DataTable();
            tabla = kiosquito.ListarVentas();
            return tabla;
        }
        public DataTable ListarClientes()
        {          
            DataTable tablaCliente = new DataTable();
            return tablaCliente = kiosquito.MostrarClientes();
        }
        public DataTable MostrarProductos()
        {       
            DataTable tablaProducto = new DataTable();
            return tablaProducto = kiosquito.MostrarProductos();
        }
        public void Insertar(string fechaVenta, string Id_Producto, string Id_Cliente)
        {          
            kiosquito.Insertar(fechaVenta, int.Parse(Id_Producto), int.Parse(Id_Cliente));
        }
        public void Eliminar(string Id)
        {          
            kiosquito.EliminarFisicoVenta(int.Parse(Id));
        }
        public void EditarVenta(string fechaVenta, string Id_Producto, string Id_Cliente, string Id)
        {         
            kiosquito.EditarVenta(fechaVenta, int.Parse(Id_Producto), int.Parse(Id_Cliente), int.Parse(Id));
        }
    }
}
