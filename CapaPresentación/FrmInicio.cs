using System;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentación
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }
        private void cerrarTS_Click(object sender, EventArgs e)
        {
            //MEDIANTE ESTA FUNCION CERRAMOS EL FORMULARIO DE INICIO
            this.Close();
        }
        private void ventasTS_Click(object sender, EventArgs e)
        {
            FrmVentas ventas = new FrmVentas();

            //ABRIMOS EL FORMULARIO DE VENTAS
            ventas.Show();

            //Y OCULTAMOS EL DE INICIO
            this.Hide();
        }
        private void sobreNosotrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //INSTANCIAMOS EL FORMULARIO DE ALUMNOS DONDE SE MOSTRARÁN NUESTROS DATOS
            FrmAlumnos verAlumnos = new FrmAlumnos();

            //ABRIMOS EL FORMULARIO DE ALUMNOS
            verAlumnos.Show();

            //OCULTAMOS EL FORMULARIO DE INICIO
            this.Hide();
        }
    }
}
