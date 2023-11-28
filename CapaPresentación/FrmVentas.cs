using System;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentación
{
    public partial class FrmVentas : Form
    {   
        public FrmVentas()
        {
            InitializeComponent();
        }
        private void FrmVentas_Load(object sender, EventArgs e)
        {   //CUANDO EL FORMULARIO SE CARGA NO SE PERMITIRA AL USUARIO INGRESAR DATOS
            //DESABILITANDO EL PANEL
            panel1.Enabled = false;

            btnActualizar.Enabled = false;
            btnActualizar.Hide();

            cboProductos.SelectedValue = 0;
            cboClientes.SelectedValue = 0;
        }
        private void btnConectarBD_Click(object sender, EventArgs e)
        {   
            try //AL APRETAR ESTE BOTON SE MOSTRARA EN PANTALLA LOS DATOS PROVENIENTES DE LA DB CON SUS RESPECTIVOS ComboBox
            {
                ListarVentas();
                ListarClientes();
                MostrarProductos();
                //AHORA SE ACTIVARA EL PANEL PARA QUE EL USUARIO PUEDA AGREGAR DATOS DE UNA VENTA
                panel1.Enabled = true;
                //SE DESABILITARA LOS BOTONES DE EDITAR Y ELIMINAR
                btnEliminar.Enabled = false;
                btnEditar.Enabled = false;
                //LOS ELEMENTOS POR DEFECTO DE LOS COMBOBOX EMPEZARAN EN CERO, MOSTRANDO UN CAMPO VACIO
                cboProductos.SelectedValue = 0;
                cboClientes.SelectedValue = 0;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void ListarVentas()
        {   //SE MUESTRAN LOS DATOS DE LA DB EN EL DATAGRIDVIEW 
            CN_Kiosco user = new CN_Kiosco();
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = user.ListarVentas();//POR MEDIO DEL OBJETO USER ACCEDO AL METODO LISTAR
        }
        public void ListarClientes()
        {   
            CN_Kiosco cliente = new CN_Kiosco();
            //POR MEDIO DEL VALUEMEMBER TOMAMOS EL VALOR DEL ID, Y MEDIANTE EL DISPLAYMEMBER MOSTRAMOS LA LISTA DE CLIENTE
            cboClientes.DataSource = cliente.ListarClientes();
            cboClientes.ValueMember = "Id_Cliente";
            cboClientes.DisplayMember = "NombreYAp_Cliente";
        }
        public void MostrarProductos()
        {
            CN_Kiosco productos = new CN_Kiosco();
            //POR MEDIO DEL VALUEMEMBER TOMAMOS EL VALOR DEL ID, Y MEDIANTE EL DISPLAYMEMBER MOSTRAMOS LA LISTA DE PRODUCTOS
            cboProductos.DataSource = productos.MostrarProductos();
            cboProductos.ValueMember = "Id_Producto";
            cboProductos.DisplayMember = "Nombre_Producto";
        }
        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {   
            CN_Kiosco venta = new CN_Kiosco();
            //SE GUARDA EN UNA VARIABLE DE TIPO STRING EL DATO FECHA
            string fecha = dtpFechaVenta.Text.ToString();
            //REALIZAMOS UNA VERIFICACION DE QUE TODOS LOS CAMPOS ESTEN LLENOS
            if (fecha == "" || cboClientes.SelectedIndex == -1 || cboProductos.SelectedIndex == -1)
            {
                MessageBox.Show("Ingresa todos los datos");
            }
            else
            {   //EN EL CASO DE QUE TENGAN VALORES LOS COMBOBOX SE GUARDAN EN VARIABLES
                string Id_Cliente = cboClientes.SelectedValue.ToString().Trim();
                string Id_Producto = cboProductos.SelectedValue.ToString().Trim();
                //SE VALIDA SI LA FECHA INGRESEDA ES MAYOR A LA ACTUAL 
                if(dtpFechaVenta.Value > DateTime.Now)
                {   //SE MUESTRA UN MENSAJE DE ERROR QUE SE DEBE INGRESAR UNA FECHA VALIDA HASTA EL DIA ACTUAL
                    MessageBox.Show("No se puede establecer una fecha mayor a la actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {   //SI ESTA TODO VALIDADO SE LO GUARDA EN EL METODO
                    venta.Insertar(fecha, Id_Producto, Id_Cliente);
                    MessageBox.Show("Dato agregado correctamente");
                    ListarVentas();
                    LimpiarInputs();
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {   //SE DESABILITA EL BOTON DE AGREGAR VENTA Y EL BOTON ELIMINAR 
            
            btnAgregarVenta.Enabled = false;

            btnEliminar.Enabled = false;

            btnActualizar.Show();
            //AQUI SE MUESTRA EL BOTON ACTUALIZAR
            btnActualizar.Enabled = true;
            //EN ESTAS VARIABLES SE GUARDAN LOS DATOS QUE SE TOMAN EN EL DATAGRIEDVIEW 
            dtpFechaVenta.Text = (string)dgvVentas.CurrentRow.Cells["Fecha de Venta"].Value.ToString();

            cboProductos.Text = dgvVentas.CurrentRow.Cells["Nombre del Producto"].Value.ToString();

            cboClientes.Text = dgvVentas.CurrentRow.Cells["Nombre del Cliente"].Value.ToString();

            dtpFechaVenta.Enabled = true;
            cboProductos.Enabled = true;
            cboClientes.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CN_Kiosco venta = new CN_Kiosco();
            //SE PREGUNTA SI SE SELECCIONA FILA COMPLETA 
            if (dgvVentas.Rows.Count > 0)
            {
                //SE GUARDA EN LA VARIABLE ID EL VALOR DE LA VENTA 
                string Id = dgvVentas.CurrentRow.Cells["Id_Venta"].Value.ToString();
                //SE GUARDA EN UNA VARIABLE DE TIPO DIALOGRESULT EL MENSAJE DE MESSAGEBOX
                DialogResult resultado = MessageBox.Show("¿Deseas eliminar esta venta?", "Alerta", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    //SI SE OPRIME EL BOTON "SI" SE CONFIRMA LA ELIMINACION
                    venta.Eliminar(Id);
                    MessageBox.Show("Venta eliminada correctamente");
                    ListarVentas();
                    //SE VUELVE A DESABILITAR EL BOTON HASTA SELECCIONAR UNA SIGUIENTE FILA 
                    btnEliminar.Enabled = false;
                }
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {   
            // RECIBO LOS DATOS DE LOS COMBOBOX Y DEL DATETIMEPICKER
            string fecha = dtpFechaVenta.Text.ToString();
            string Id_Producto = cboProductos.SelectedValue.ToString().Trim();
            string Id_Cliente = cboClientes.SelectedValue.ToString().Trim();
                      
            if(fecha == "" || Id_Producto == "" || Id_Cliente == "")
            {   //SE VERIFICA QUE LOS CAMPOS NO ESTEN VACIOS 
                MessageBox.Show("Debes llenar los campos");
            }
            else  
            {   //SI ESTAN LOS DATOS INGRESADOS CORRECTAMENTE SE EJECUTA LA SENTENCIA 
                CN_Kiosco venta = new CN_Kiosco();
                //SE PREGUNTA SI SE SELECCIONA FILA COMPLETA 
                string Id = dgvVentas.CurrentRow.Cells["Id_Venta"].Value.ToString();
                //SE GUARDA EN UNA VARIABLE DE TIPO DIALOGRESULT EL MENSAJE DE MESSAGEBOX
                DialogResult resultado = MessageBox.Show("¿Estas seguro de que deseas actualizar este campo?", "Advertencia", MessageBoxButtons.YesNo);

                if(resultado == DialogResult.Yes)
                {   
                    if(dtpFechaVenta.Value > DateTime.Now)
                    {
                        MessageBox.Show("No se puede establecer una fecha mayor a la actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else //MANDA LOS DATOS EDITADOS A LA DB
                    {
                        venta.EditarVenta(fecha, Id_Producto, Id_Cliente, Id);
                        MessageBox.Show("Campo de venta editado correctamente");
                        ListarVentas();
                        LimpiarInputs();
                    }
                }

                btnActualizar.Enabled = false;
                btnActualizar.Hide();
                btnEditar.Enabled = false;
                btnAgregarVenta.Enabled = true;
            }
        }

        public void LimpiarInputs()
        {
            //SE RESETEA LOS VALORES DEL DATATEPICKER Y DE LOS COMBOBOX
            dtpFechaVenta.ResetText();
            cboClientes.SelectedValue = 0;
            cboProductos.SelectedValue = 0;
        }
        private void volverInicioTS_Click(object sender, EventArgs e)
        {
            //VUELVO AL FORMULARIO INICIAL 
            FrmInicio inicio = new FrmInicio();

            inicio.Show();

            this.Hide();

            this.Close();
        }

        private void dgvVentas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //CUANDO SE SELECCIONA UNA FILA COMPLETA SE HABILITTAN LOS BOTONES DE ELIMINAR Y EDITAR Y SE DESHABILITA EL DE AGREGAR VENTAS. TAMBIEN SE DESHABILITAN TODO LO QUE ESTÁ EN EL PANEL
            btnEliminar.Enabled = true;

            btnAgregarVenta.Enabled = false;

            btnEditar.Enabled = true;

            dtpFechaVenta.Enabled = false;
            cboProductos.Enabled = false;
            cboClientes.Enabled = false;
        }
        private void dgvVentas_Leave(object sender, EventArgs e)
        {
            btnAgregarVenta.Enabled = true;                
        }
    }
}
