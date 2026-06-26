using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using SistemaAlquilerVehiculos.Datos;
using SistemaAlquilerVehiculos.Utilidades;

namespace SistemaAlquilerVehiculos.Formularios
{
    // Formulario encargado de validar el acceso de usuarios al sistema.
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text.Trim();
            string contrasenia = txtContrasenia.Text;

            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasenia))
            {
                MessageBox.Show("Debe ingresar el nombre de usuario y la contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string contraseniaEncriptada = Seguridad.Encriptar(contrasenia);

            using (AlquilerDbContext contexto = new AlquilerDbContext())
            {
                var usuario = contexto.Usuarios
                    .Include(u => u.Rol)
                    .FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasenia == contraseniaEncriptada && u.Estado && u.Rol.Estado);

                if (usuario == null)
                {
                    MessageBox.Show("Usuario, contraseña incorrecta o usuario inactivo.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SesionUsuario.IdUsuario = usuario.IdUsuario;
                SesionUsuario.NombreCompleto = usuario.NombreCompleto;
                SesionUsuario.NombreUsuario = usuario.NombreUsuario;
                SesionUsuario.Rol = usuario.Rol.NombreRol;
            }

            FrmMenuPrincipal menu = new FrmMenuPrincipal();
            menu.FormClosed += delegate { Close(); };
            Hide();
            menu.Show();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            using (FrmRegistroUsuario formularioRegistro = new FrmRegistroUsuario())
            {
                formularioRegistro.ShowDialog();
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            SesionUsuario.CerrarSesion();
        }
    }
}
