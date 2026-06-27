namespace SistemaAlquilerVehiculos.Formularios
{
    partial class FrmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnVehiculos;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblAccesoCliente;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnVehiculos = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblAccesoCliente = new System.Windows.Forms.Label();
            this.btnAlquileres = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(61, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(315, 30);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Sistema de Alquiler Vehicular";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(37, 81);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(0, 15);
            this.lblBienvenida.TabIndex = 5;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(37, 108);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(0, 15);
            this.lblRol.TabIndex = 4;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(40, 150);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(160, 58);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "Administrar usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnVehiculos
            // 
            this.btnVehiculos.Location = new System.Drawing.Point(232, 150);
            this.btnVehiculos.Name = "btnVehiculos";
            this.btnVehiculos.Size = new System.Drawing.Size(160, 58);
            this.btnVehiculos.TabIndex = 2;
            this.btnVehiculos.Text = "Administrar vehículos";
            this.btnVehiculos.UseVisualStyleBackColor = true;
            this.btnVehiculos.Click += new System.EventHandler(this.btnVehiculos_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(248, 337);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(144, 35);
            this.btnCerrarSesion.TabIndex = 1;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblAccesoCliente
            // 
            this.lblAccesoCliente.AutoSize = true;
            this.lblAccesoCliente.Location = new System.Drawing.Point(37, 299);
            this.lblAccesoCliente.Name = "lblAccesoCliente";
            this.lblAccesoCliente.Size = new System.Drawing.Size(362, 15);
            this.lblAccesoCliente.TabIndex = 0;
            this.lblAccesoCliente.Text = "Las opciones de alquiler estarán disponibles al integrar el módulo 2.";
            // 
            // btnAlquileres
            // 
            this.btnAlquileres.Location = new System.Drawing.Point(40, 225);
            this.btnAlquileres.Name = "btnAlquileres";
            this.btnAlquileres.Size = new System.Drawing.Size(170, 58);
            this.btnAlquileres.TabIndex = 7;
            this.btnAlquileres.Text = "Alquileres";
            this.btnAlquileres.UseVisualStyleBackColor = true;
            this.btnAlquileres.Click += new System.EventHandler(this.btnAlquileres_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 417);
            this.Controls.Add(this.btnAlquileres);
            this.Controls.Add(this.lblAccesoCliente);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnVehiculos);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú principal";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnAlquileres;
    }
}
