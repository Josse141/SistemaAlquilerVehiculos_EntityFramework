using System;
using System.Windows.Forms;
using SistemaAlquilerVehiculos.Utilidades;

namespace SistemaAlquilerVehiculos.Formularios
{
    // Presenta las opciones disponibles de acuerdo con el rol autenticado.
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = "Bienvenido(a): " + SesionUsuario.NombreCompleto;
            lblRol.Text = "Rol: " + SesionUsuario.Rol;

            bool esAdministrador = SesionUsuario.EsAdministrador();
            btnUsuarios.Enabled = esAdministrador;
            btnVehiculos.Enabled = esAdministrador;
            lblAccesoCliente.Visible = !esAdministrador;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            using (FrmUsuarios formularioUsuarios = new FrmUsuarios())
            {
                formularioUsuarios.ShowDialog();
            }
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            using (FrmVehiculos formularioVehiculos = new FrmVehiculos())
            {
                formularioVehiculos.ShowDialog();
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            SesionUsuario.CerrarSesion();
            Close();
        }
    }
}
