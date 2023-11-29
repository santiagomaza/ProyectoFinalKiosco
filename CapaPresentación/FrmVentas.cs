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
        {   
            panel1.Enabled = false;

            btnActualizar.Enabled = false;
            btnActualizar.Hide();

            cboProductos.SelectedValue = 0;
            cboClientes.SelectedValue = 0;
        }
        private void btnConectarBD_Click(object sender, EventArgs e)
        {   
            try
            {
                ListarVentas();
                ListarClientes();
                MostrarProductos();
                
                panel1.Enabled = true;
                
                btnEliminar.Enabled = false;
                btnEditar.Enabled = false;
                
                cboProductos.SelectedValue = 0;
                cboClientes.SelectedValue = 0;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void ListarVentas()
        {    
            CN_Kiosco user = new CN_Kiosco();
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = user.ListarVentas();
        }
        public void ListarClientes()
        {   
            CN_Kiosco cliente = new CN_Kiosco();
            
            cboClientes.DataSource = cliente.ListarClientes();
            cboClientes.ValueMember = "Id_Cliente";
            cboClientes.DisplayMember = "NombreYAp_Cliente";
        }
        public void MostrarProductos()
        {
            CN_Kiosco productos = new CN_Kiosco();
           
            cboProductos.DataSource = productos.MostrarProductos();
            cboProductos.ValueMember = "Id_Producto";
            cboProductos.DisplayMember = "Nombre_Producto";
        }
        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {   
            CN_Kiosco venta = new CN_Kiosco();
            
            string fecha = dtpFechaVenta.Text.ToString();
            
            if (fecha == "" || cboClientes.SelectedIndex == -1 || cboProductos.SelectedIndex == -1)
            {
                MessageBox.Show("Ingresa todos los datos");
            }
            else
            {   
                string Id_Cliente = cboClientes.SelectedValue.ToString().Trim();
                string Id_Producto = cboProductos.SelectedValue.ToString().Trim();
                
                if(dtpFechaVenta.Value > DateTime.Now)
                {   
                    MessageBox.Show("No se puede establecer una fecha mayor a la actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {   
                    venta.Insertar(fecha, Id_Producto, Id_Cliente);
                    MessageBox.Show("Dato agregado correctamente");
                    ListarVentas();
                    LimpiarInputs();
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {            
            btnAgregarVenta.Enabled = false;

            btnEliminar.Enabled = false;

            btnActualizar.Show();
            
            btnActualizar.Enabled = true;
            
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
            
            if (dgvVentas.Rows.Count > 0)
            {
                
                string Id = dgvVentas.CurrentRow.Cells["Id_Venta"].Value.ToString();
               
                DialogResult resultado = MessageBox.Show("¿Deseas eliminar esta venta?", "Alerta", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    venta.Eliminar(Id);
                    MessageBox.Show("Venta eliminada correctamente");
                    ListarVentas();
                    
                    btnEliminar.Enabled = false;
                }
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {         
            string fecha = dtpFechaVenta.Text.ToString();
            string Id_Producto = cboProductos.SelectedValue.ToString().Trim();
            string Id_Cliente = cboClientes.SelectedValue.ToString().Trim();
                      
            if(fecha == "" || Id_Producto == "" || Id_Cliente == "")
            {  
                MessageBox.Show("Debes llenar los campos");
            }
            else  
            {    
                CN_Kiosco venta = new CN_Kiosco();
                
                string Id = dgvVentas.CurrentRow.Cells["Id_Venta"].Value.ToString();
                
                DialogResult resultado = MessageBox.Show("¿Estas seguro de que deseas actualizar este campo?", "Advertencia", MessageBoxButtons.YesNo);

                if(resultado == DialogResult.Yes)
                {   
                    if(dtpFechaVenta.Value > DateTime.Now)
                    {
                        MessageBox.Show("No se puede establecer una fecha mayor a la actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
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
            
            dtpFechaVenta.ResetText();
            cboClientes.SelectedValue = 0;
            cboProductos.SelectedValue = 0;
        }
        private void volverInicioTS_Click(object sender, EventArgs e)
        {
            
            FrmInicio inicio = new FrmInicio();

            inicio.Show();

            this.Hide();

            this.Close();
        }

        private void dgvVentas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
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
