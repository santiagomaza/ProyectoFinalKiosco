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
            //INSTANCIAMOS LA CLASE DEL FORMULARIO DE INICIO
            FrmInicio volverInicio = new FrmInicio();

            //CON EL METODO SHOW VOLVEMOS AL FORMULARIO DE INICIO
            volverInicio.Show();

            //OCULTAMOS Y CERRAMOS ESTE FORMULARIO (EL DE ALUMNOS)
            this.Hide();

            this.Close();
        }  
    }
}
