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
            this.SuspendLayout();
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(61, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(314, 30);
            this.lblTitulo.Text = "Sistema de Alquiler Vehicular";
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(37, 81);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(0, 15);
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(37, 108);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(0, 15);
            this.btnUsuarios.Location = new System.Drawing.Point(40, 150);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(160, 58);
            this.btnUsuarios.Text = "Administrar usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            this.btnVehiculos.Location = new System.Drawing.Point(232, 150);
            this.btnVehiculos.Name = "btnVehiculos";
            this.btnVehiculos.Size = new System.Drawing.Size(160, 58);
            this.btnVehiculos.Text = "Administrar vehículos";
            this.btnVehiculos.UseVisualStyleBackColor = true;
            this.btnVehiculos.Click += new System.EventHandler(this.btnVehiculos_Click);
            this.lblAccesoCliente.AutoSize = true;
            this.lblAccesoCliente.Location = new System.Drawing.Point(40, 231);
            this.lblAccesoCliente.Name = "lblAccesoCliente";
            this.lblAccesoCliente.Size = new System.Drawing.Size(351, 15);
            this.lblAccesoCliente.Text = "Las opciones de alquiler estarán disponibles al integrar el módulo 2.";
            this.btnCerrarSesion.Location = new System.Drawing.Point(248, 275);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(144, 35);
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 338);
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
    }
}
