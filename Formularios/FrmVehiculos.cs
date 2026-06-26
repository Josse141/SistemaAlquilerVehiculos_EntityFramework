using System;
using System.Linq;
using System.Windows.Forms;
using SistemaAlquilerVehiculos.Datos;
using SistemaAlquilerVehiculos.Modelos;
using SistemaAlquilerVehiculos.Utilidades;

namespace SistemaAlquilerVehiculos.Formularios
{
    // Permite al administrador registrar, actualizar y desactivar vehículos.
    public partial class FrmVehiculos : Form
    {
        private readonly AlquilerDbContext _contexto;
        private int _idVehiculoSeleccionado;

        public FrmVehiculos()
        {
            InitializeComponent();
            _contexto = new AlquilerDbContext();
        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            if (!SesionUsuario.EsAdministrador())
            {
                MessageBox.Show("No tiene permisos para administrar vehículos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            ConfigurarCombos();
            CargarVehiculos();
            LimpiarFormulario();
        }

        private void ConfigurarCombos()
        {
            cboTipoVehiculo.Items.Clear();
            cboTipoVehiculo.Items.AddRange(new object[] { "SEDÁN", "SUV", "CAMIONETA", "HATCHBACK", "PICK-UP", "VAN", "OTRO" });

            cboEstadoVehiculo.Items.Clear();
            cboEstadoVehiculo.Items.AddRange(new object[] { "DISPONIBLE", "ALQUILADO", "MANTENIMIENTO" });
        }

        private void CargarVehiculos()
        {
            var consulta = _contexto.Vehiculos.AsQueryable();

            if (!chkMostrarInactivos.Checked)
            {
                consulta = consulta.Where(v => v.Activo);
            }

            var vehiculos = consulta
                .OrderBy(v => v.Placa)
                .Select(v => new
                {
                    v.IdVehiculo,
                    v.Placa,
                    v.Marca,
                    v.Modelo,
                    Año = v.Anio,
                    Tipo = v.TipoVehiculo,
                    TarifaDiaria = v.TarifaDiaria,
                    Estado = v.EstadoVehiculo,
                    Activo = v.Activo ? "Sí" : "No"
                })
                .ToList();

            dgvVehiculos.DataSource = vehiculos;
            dgvVehiculos.Columns["IdVehiculo"].HeaderText = "ID";
            dgvVehiculos.Columns["TarifaDiaria"].DefaultCellStyle.Format = "N2";
        }

        private void LimpiarFormulario()
        {
            _idVehiculoSeleccionado = 0;
            txtId.Clear();
            txtPlaca.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtAnio.Clear();
            txtTarifaDiaria.Clear();
            cboTipoVehiculo.SelectedIndex = 0;
            cboEstadoVehiculo.SelectedItem = "DISPONIBLE";
            btnGuardar.Text = "Guardar vehículo";
            txtPlaca.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text.Trim().ToUpper();
            string marca = txtMarca.Text.Trim();
            string modelo = txtModelo.Text.Trim();
            int anio;
            decimal tarifaDiaria;

            if (string.IsNullOrWhiteSpace(placa) || string.IsNullOrWhiteSpace(marca) || string.IsNullOrWhiteSpace(modelo) ||
                cboTipoVehiculo.SelectedIndex < 0 || cboEstadoVehiculo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe completar todos los datos del vehículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAnio.Text, out anio) || anio < 1900 || anio > DateTime.Now.Year + 1)
            {
                MessageBox.Show("Debe ingresar un año válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtTarifaDiaria.Text, out tarifaDiaria) || tarifaDiaria <= 0)
            {
                MessageBox.Show("La tarifa diaria debe ser un número mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool placaDuplicada = _contexto.Vehiculos.Any(v => v.Placa == placa && v.IdVehiculo != _idVehiculoSeleccionado);
            if (placaDuplicada)
            {
                MessageBox.Show("Ya existe un vehículo registrado con esta placa.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_idVehiculoSeleccionado == 0)
            {
                Vehiculo nuevoVehiculo = new Vehiculo
                {
                    Placa = placa,
                    Marca = marca,
                    Modelo = modelo,
                    Anio = anio,
                    TipoVehiculo = cboTipoVehiculo.Text,
                    TarifaDiaria = tarifaDiaria,
                    EstadoVehiculo = cboEstadoVehiculo.Text,
                    Activo = true
                };

                _contexto.Vehiculos.Add(nuevoVehiculo);
            }
            else
            {
                Vehiculo vehiculo = _contexto.Vehiculos.Find(_idVehiculoSeleccionado);
                vehiculo.Placa = placa;
                vehiculo.Marca = marca;
                vehiculo.Modelo = modelo;
                vehiculo.Anio = anio;
                vehiculo.TipoVehiculo = cboTipoVehiculo.Text;
                vehiculo.TarifaDiaria = tarifaDiaria;
                vehiculo.EstadoVehiculo = cboEstadoVehiculo.Text;
            }

            try
            {
                _contexto.SaveChanges();
                MessageBox.Show("Vehículo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarVehiculos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible guardar el vehículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _idVehiculoSeleccionado = Convert.ToInt32(dgvVehiculos.Rows[e.RowIndex].Cells["IdVehiculo"].Value);
            Vehiculo vehiculo = _contexto.Vehiculos.Find(_idVehiculoSeleccionado);

            if (vehiculo == null) return;

            txtId.Text = vehiculo.IdVehiculo.ToString();
            txtPlaca.Text = vehiculo.Placa;
            txtMarca.Text = vehiculo.Marca;
            txtModelo.Text = vehiculo.Modelo;
            txtAnio.Text = vehiculo.Anio.ToString();
            txtTarifaDiaria.Text = vehiculo.TarifaDiaria.ToString("0.00");
            cboTipoVehiculo.SelectedItem = vehiculo.TipoVehiculo;
            cboEstadoVehiculo.SelectedItem = vehiculo.EstadoVehiculo;
            btnGuardar.Text = "Actualizar vehículo";
        }

        private void btnCambiarEstadoActivo_Click(object sender, EventArgs e)
        {
            if (_idVehiculoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un vehículo de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Vehiculo vehiculo = _contexto.Vehiculos.Find(_idVehiculoSeleccionado);
            vehiculo.Activo = !vehiculo.Activo;
            _contexto.SaveChanges();

            MessageBox.Show("Estado activo del vehículo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarVehiculos();
            LimpiarFormulario();
        }

        private void chkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarVehiculos();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _contexto.Dispose();
            base.OnFormClosed(e);
        }
    }
}
