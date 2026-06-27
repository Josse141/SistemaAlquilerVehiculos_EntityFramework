using System;
using System.Linq;
using System.Windows.Forms;
using SistemaAlquilerVehiculos.Datos;
using SistemaAlquilerVehiculos.Modelos;
using SistemaAlquilerVehiculos.Utilidades;

namespace SistemaAlquilerVehiculos.Formularios
{
    public partial class FrmAlquileres : Form
    {
        private readonly AlquilerDbContext _contexto;
        private int _idAlquilerSeleccionado;

        public FrmAlquileres()
        {
            InitializeComponent();
            _contexto = new AlquilerDbContext();
        }

        private void ConfigurarFormulario()
        {
            bool esAdministrador = SesionUsuario.EsAdministrador();

            btnAprobar.Visible = esAdministrador;
            btnRechazar.Visible = esAdministrador;
            btnRegistrarDevolucion.Visible = esAdministrador;
        }

        private void CargarVehiculos()
        {
            cboVehiculo.DataSource = _contexto.Vehiculos
                .Where(v => v.Activo && v.EstadoVehiculo == "DISPONIBLE")
                .OrderBy(v => v.Placa)
                .ToList();

            cboVehiculo.DisplayMember = "Placa";
            cboVehiculo.ValueMember = "IdVehiculo";
        }

        private void CargarAlquileres()
        {
            var consulta = _contexto.Alquileres.AsQueryable();

            // Si es cliente, solo ve sus alquileres.
            if (!SesionUsuario.EsAdministrador())
            {
                consulta = consulta.Where(a => a.IdUsuario == SesionUsuario.IdUsuario);
            }

            var alquileres = consulta
                .Select(a => new
                {
                    a.IdAlquiler,
                    Usuario = a.Usuario.NombreCompleto,
                    Vehiculo = a.Vehiculo.Placa,
                    a.FechaInicio,
                    a.FechaDevolucionEsperada,
                    a.FechaDevolucionReal,
                    a.Estado
                })
                .ToList();

            dgvAlquileres.DataSource = alquileres;

            if (dgvAlquileres.Columns.Count > 0)
            {
                dgvAlquileres.Columns["IdAlquiler"].HeaderText = "ID";
                dgvAlquileres.Columns["FechaInicio"].HeaderText = "Inicio";
                dgvAlquileres.Columns["FechaDevolucionEsperada"].HeaderText = "Devolución esperada";
                dgvAlquileres.Columns["FechaDevolucionReal"].HeaderText = "Devolución real";
            }
        }

        private void LimpiarFormulario()
        {
            _idAlquilerSeleccionado = 0;

            if (cboVehiculo.Items.Count > 0)
                cboVehiculo.SelectedIndex = 0;

            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaDevolucion.Value = DateTime.Now.AddDays(1);
        }

        private void FrmAlquileres_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
            CargarVehiculos();
            CargarAlquileres();
            LimpiarFormulario();

            dgvAlquileres.ReadOnly = true;
            dgvAlquileres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlquileres.MultiSelect = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_idAlquilerSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un alquiler.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Alquiler alquiler = _contexto.Alquileres.Find(_idAlquilerSeleccionado);

            if (alquiler == null)
                return;

            if (alquiler.Estado != "APROBADO")
            {
                MessageBox.Show("Solo los alquileres aprobados pueden devolverse.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Vehiculo vehiculo = _contexto.Vehiculos.Find(alquiler.IdVehiculo);

            alquiler.Estado = "DEVUELTO";
            alquiler.FechaDevolucionReal = DateTime.Now;

            vehiculo.EstadoVehiculo = "DISPONIBLE";

            try
            {
                _contexto.SaveChanges();

                MessageBox.Show("Devolución registrada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarVehiculos();
                CargarAlquileres();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible registrar la devolución: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            if (cboVehiculo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un vehículo.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dtpFechaDevolucion.Value <= dtpFechaInicio.Value)
            {
                MessageBox.Show("La fecha de devolución debe ser mayor que la fecha de inicio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Alquiler nuevoAlquiler = new Alquiler
            {
                IdUsuario = SesionUsuario.IdUsuario,
                IdVehiculo = Convert.ToInt32(cboVehiculo.SelectedValue),
                FechaInicio = dtpFechaInicio.Value,
                FechaDevolucionEsperada = dtpFechaDevolucion.Value,
                Estado = "PENDIENTE"
            };

            try
            {
                _contexto.Alquileres.Add(nuevoAlquiler);
                _contexto.SaveChanges();

                MessageBox.Show("Solicitud enviada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarAlquileres();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible registrar la solicitud: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (_idAlquilerSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un alquiler.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Alquiler alquiler = _contexto.Alquileres.Find(_idAlquilerSeleccionado);

            if (alquiler == null)
                return;

            if (alquiler.Estado != "PENDIENTE")
            {
                MessageBox.Show("Solo se pueden aprobar solicitudes pendientes.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Vehiculo vehiculo = _contexto.Vehiculos.Find(alquiler.IdVehiculo);

            alquiler.Estado = "APROBADO";
            vehiculo.EstadoVehiculo = "ALQUILADO";

            try
            {
                _contexto.SaveChanges();

                MessageBox.Show("Solicitud aprobada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarVehiculos();
                CargarAlquileres();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible aprobar la solicitud: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void dgvAlquileres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _idAlquilerSeleccionado = Convert.ToInt32(
                dgvAlquileres.Rows[e.RowIndex].Cells["IdAlquiler"].Value);

            Alquiler alquiler = _contexto.Alquileres.Find(_idAlquilerSeleccionado);

            if (alquiler == null)
                return;

            cboVehiculo.SelectedValue = alquiler.IdVehiculo;
            dtpFechaInicio.Value = alquiler.FechaInicio;
            dtpFechaDevolucion.Value = alquiler.FechaDevolucionEsperada;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (_idAlquilerSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un alquiler.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Alquiler alquiler = _contexto.Alquileres.Find(_idAlquilerSeleccionado);

            if (alquiler == null)
                return;

            if (alquiler.Estado != "PENDIENTE")
            {
                MessageBox.Show("Solo se pueden rechazar solicitudes pendientes.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            alquiler.Estado = "RECHAZADO";

            try
            {
                _contexto.SaveChanges();

                MessageBox.Show("Solicitud rechazada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarAlquileres();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible rechazar la solicitud: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

