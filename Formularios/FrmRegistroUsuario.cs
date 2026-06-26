using System;
using System.Linq;
using System.Windows.Forms;
using SistemaAlquilerVehiculos.Datos;
using SistemaAlquilerVehiculos.Modelos;
using SistemaAlquilerVehiculos.Utilidades;

namespace SistemaAlquilerVehiculos.Formularios
{
    // Permite registrar nuevos usuarios con el rol de Cliente.
    public partial class FrmRegistroUsuario : Form
    {
        public FrmRegistroUsuario()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombreCompleto = txtNombreCompleto.Text.Trim();
            string correo = txtCorreo.Text.Trim().ToLower();
            string nombreUsuario = txtNombreUsuario.Text.Trim();
            string contrasenia = txtContrasenia.Text;
            string confirmarContrasenia = txtConfirmarContrasenia.Text;

            if (string.IsNullOrWhiteSpace(nombreCompleto) || string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasenia))
            {
                MessageBox.Show("Debe completar todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!correo.Contains("@") || !correo.Contains("."))
            {
                MessageBox.Show("Debe ingresar un correo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contrasenia.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contrasenia != confirmarContrasenia)
            {
                MessageBox.Show("La confirmación de contraseña no coincide.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (AlquilerDbContext contexto = new AlquilerDbContext())
            {
                bool usuarioExiste = contexto.Usuarios.Any(u => u.NombreUsuario == nombreUsuario);
                bool correoExiste = contexto.Usuarios.Any(u => u.Correo == correo);

                if (usuarioExiste)
                {
                    MessageBox.Show("El nombre de usuario ya está registrado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (correoExiste)
                {
                    MessageBox.Show("El correo ya está registrado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Rol rolCliente = contexto.Roles.FirstOrDefault(r => r.NombreRol == "CLIENTE" && r.Estado);

                if (rolCliente == null)
                {
                    MessageBox.Show("No se encontró el rol CLIENTE. Verifique la configuración inicial de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Usuario nuevoUsuario = new Usuario
                {
                    NombreCompleto = nombreCompleto,
                    Correo = correo,
                    NombreUsuario = nombreUsuario,
                    Contrasenia = Seguridad.Encriptar(contrasenia),
                    IdRol = rolCliente.IdRol,
                    Estado = true
                };

                contexto.Usuarios.Add(nuevoUsuario);
                contexto.SaveChanges();
            }

            MessageBox.Show("Usuario registrado correctamente. Ya puede iniciar sesión.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
