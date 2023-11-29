using System;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentación
{
    public partial class FrmAlumnos : Form
    {
        public FrmAlumnos()
        {
            InitializeComponent();
        }

        private void volverAInicioTS_Click(object sender, EventArgs e)
        {            
            FrmInicio volverInicio = new FrmInicio();
          
            volverInicio.Show();
         
            this.Hide();

            this.Close();
        }  
    }
}
