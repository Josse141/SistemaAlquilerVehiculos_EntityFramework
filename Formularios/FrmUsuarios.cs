using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using SistemaAlquilerVehiculos.Datos;
using SistemaAlquilerVehiculos.Modelos;
using SistemaAlquilerVehiculos.Utilidades;

namespace SistemaAlquilerVehiculos.Formularios
{
    // Permite al administrador registrar, actualizar y desactivar usuarios.
    public partial class FrmUsuarios : Form
    {
        private readonly AlquilerDbContext _contexto;
        private int _idUsuarioSeleccionado;

        public FrmUsuarios()
        {
            InitializeComponent();
            _contexto = new AlquilerDbContext();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            if (!SesionUsuario.EsAdministrador())
            {
                MessageBox.Show("No tiene permisos para administrar usuarios.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            CargarRoles();
            CargarUsuarios();
            LimpiarFormulario();
        }

        private void CargarRoles()
        {
            cboRol.DataSource = _contexto.Roles
                .Where(r => r.Estado)
                .OrderBy(r => r.NombreRol)
                .ToList();
            cboRol.DisplayMember = "NombreRol";
            cboRol.ValueMember = "IdRol";
        }

        private void CargarUsuarios()
        {
            var usuarios = _contexto.Usuarios
                .Include(u => u.Rol)
                .OrderBy(u => u.NombreCompleto)
                .Select(u => new
                {
                    u.IdUsuario,
                    u.NombreCompleto,
                    u.Correo,
                    u.NombreUsuario,
                    Rol = u.Rol.NombreRol,
                    Estado = u.Estado ? "Activo" : "Inactivo",
                    u.FechaRegistro
                })
                .ToList();

            dgvUsuarios.DataSource = usuarios;
            dgvUsuarios.Columns["IdUsuario"].HeaderText = "ID";
            dgvUsuarios.Columns["NombreCompleto"].HeaderText = "Nombre completo";
            dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Usuario";
        }

        private void LimpiarFormulario()
        {
            _idUsuarioSeleccionado = 0;
            txtId.Clear();
            txtNombreCompleto.Clear();
            txtCorreo.Clear();
            txtNombreUsuario.Clear();
            txtContrasenia.Clear();
            txtConfirmarContrasenia.Clear();
            if (cboRol.Items.Count > 0) cboRol.SelectedIndex = 0;
            btnGuardar.Text = "Guardar usuario";
            txtNombreCompleto.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreCompleto = txtNombreCompleto.Text.Trim();
            string correo = txtCorreo.Text.Trim().ToLower();
            string nombreUsuario = txtNombreUsuario.Text.Trim();
            string contrasenia = txtContrasenia.Text;
            string confirmarContrasenia = txtConfirmarContrasenia.Text;

            if (string.IsNullOrWhiteSpace(nombreCompleto) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(nombreUsuario))
            {
                MessageBox.Show("Debe completar nombre, correo y nombre de usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!correo.Contains("@") || !correo.Contains("."))
            {
                MessageBox.Show("Debe ingresar un correo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_idUsuarioSeleccionado == 0 && string.IsNullOrWhiteSpace(contrasenia))
            {
                MessageBox.Show("Debe indicar una contraseña para el nuevo usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(contrasenia))
            {
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
            }

            int idRol = Convert.ToInt32(cboRol.SelectedValue);
            bool usuarioDuplicado = _contexto.Usuarios.Any(u => u.NombreUsuario == nombreUsuario && u.IdUsuario != _idUsuarioSeleccionado);
            bool correoDuplicado = _contexto.Usuarios.Any(u => u.Correo == correo && u.IdUsuario != _idUsuarioSeleccionado);

            if (usuarioDuplicado || correoDuplicado)
            {
                MessageBox.Show(usuarioDuplicado ? "El nombre de usuario ya está registrado." : "El correo ya está registrado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_idUsuarioSeleccionado == 0)
            {
                Usuario nuevoUsuario = new Usuario
                {
                    NombreCompleto = nombreCompleto,
                    Correo = correo,
                    NombreUsuario = nombreUsuario,
                    Contrasenia = Seguridad.Encriptar(contrasenia),
                    IdRol = idRol,
                    Estado = true
                };

                _contexto.Usuarios.Add(nuevoUsuario);
            }
            else
            {
                Usuario usuario = _contexto.Usuarios.Find(_idUsuarioSeleccionado);
                usuario.NombreCompleto = nombreCompleto;
                usuario.Correo = correo;
                usuario.NombreUsuario = nombreUsuario;
                usuario.IdRol = idRol;

                // Una contraseña vacía durante edición significa que se conserva la actual.
                if (!string.IsNullOrWhiteSpace(contrasenia))
                {
                    usuario.Contrasenia = Seguridad.Encriptar(contrasenia);
                }
            }

            try
            {
                _contexto.SaveChanges();
                MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible guardar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _idUsuarioSeleccionado = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["IdUsuario"].Value);
            Usuario usuario = _contexto.Usuarios.Find(_idUsuarioSeleccionado);

            if (usuario == null) return;

            txtId.Text = usuario.IdUsuario.ToString();
            txtNombreCompleto.Text = usuario.NombreCompleto;
            txtCorreo.Text = usuario.Correo;
            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtContrasenia.Clear();
            txtConfirmarContrasenia.Clear();
            cboRol.SelectedValue = usuario.IdRol;
            btnGuardar.Text = "Actualizar usuario";
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (_idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_idUsuarioSeleccionado == SesionUsuario.IdUsuario)
            {
                MessageBox.Show("No puede desactivar el usuario que mantiene la sesión actual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuario = _contexto.Usuarios.Find(_idUsuarioSeleccionado);
            usuario.Estado = !usuario.Estado;
            _contexto.SaveChanges();

            MessageBox.Show("Estado del usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarUsuarios();
            LimpiarFormulario();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _contexto.Dispose();
            base.OnFormClosed(e);
        }
    }
}
