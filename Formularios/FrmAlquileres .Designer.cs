namespace SistemaAlquilerVehiculos.Formularios
{
    partial class FrmAlquileres
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cboVehiculo = new System.Windows.Forms.ComboBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDevolucion = new System.Windows.Forms.DateTimePicker();
            this.btnSolicitar = new System.Windows.Forms.Button();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.btnRegistrarDevolucion = new System.Windows.Forms.Button();
            this.dgvAlquileres = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquileres)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(279, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solicitud de Alquiler";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cboVehiculo
            // 
            this.cboVehiculo.FormattingEnabled = true;
            this.cboVehiculo.Location = new System.Drawing.Point(12, 78);
            this.cboVehiculo.Name = "cboVehiculo";
            this.cboVehiculo.Size = new System.Drawing.Size(225, 21);
            this.cboVehiculo.TabIndex = 1;
            this.cboVehiculo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(12, 147);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(225, 20);
            this.dtpFechaInicio.TabIndex = 2;
            // 
            // dtpFechaDevolucion
            // 
            this.dtpFechaDevolucion.Location = new System.Drawing.Point(12, 209);
            this.dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            this.dtpFechaDevolucion.Size = new System.Drawing.Size(225, 20);
            this.dtpFechaDevolucion.TabIndex = 3;
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolicitar.Location = new System.Drawing.Point(63, 235);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(104, 33);
            this.btnSolicitar.TabIndex = 4;
            this.btnSolicitar.Text = "Solicitar";
            this.btnSolicitar.UseVisualStyleBackColor = true;
            this.btnSolicitar.Click += new System.EventHandler(this.btnSolicitar_Click);
            // 
            // btnAprobar
            // 
            this.btnAprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAprobar.Location = new System.Drawing.Point(182, 720);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(92, 36);
            this.btnAprobar.TabIndex = 5;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechazar.Location = new System.Drawing.Point(310, 720);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(96, 36);
            this.btnRechazar.TabIndex = 6;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // btnRegistrarDevolucion
            // 
            this.btnRegistrarDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarDevolucion.Location = new System.Drawing.Point(445, 720);
            this.btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            this.btnRegistrarDevolucion.Size = new System.Drawing.Size(168, 36);
            this.btnRegistrarDevolucion.TabIndex = 7;
            this.btnRegistrarDevolucion.Text = "Registrar devolución";
            this.btnRegistrarDevolucion.UseVisualStyleBackColor = true;
            this.btnRegistrarDevolucion.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvAlquileres
            // 
            this.dgvAlquileres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlquileres.Location = new System.Drawing.Point(12, 326);
            this.dgvAlquileres.Name = "dgvAlquileres";
            this.dgvAlquileres.Size = new System.Drawing.Size(776, 388);
            this.dgvAlquileres.TabIndex = 8;
            this.dgvAlquileres.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlquileres_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(285, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Solicitudes / Historial";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Fecha de inicio";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Fecha de devolucion";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Vehiculo";
            // 
            // FrmAlquileres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 786);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAlquileres);
            this.Controls.Add(this.btnRegistrarDevolucion);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.btnSolicitar);
            this.Controls.Add(this.dtpFechaDevolucion);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.cboVehiculo);
            this.Controls.Add(this.label1);
            this.Name = "FrmAlquileres";
            this.Text = "FrmAlquileres";
            this.Load += new System.EventHandler(this.FrmAlquileres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquileres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboVehiculo;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaDevolucion;
        private System.Windows.Forms.Button btnSolicitar;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnRegistrarDevolucion;
        private System.Windows.Forms.DataGridView dgvAlquileres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}