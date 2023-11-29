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
            this.Close();
        }
        private void ventasTS_Click(object sender, EventArgs e)
        {
            FrmVentas ventas = new FrmVentas();

            ventas.Show();

            this.Hide();
        }
        private void sobreNosotrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAlumnos verAlumnos = new FrmAlumnos();

            verAlumnos.Show();

            this.Hide();
        }
    }
}
