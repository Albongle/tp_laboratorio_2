namespace TP_N4
{
    partial class frmEstacionamiento
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstacionamiento));
            this.listBoxVehiculos = new System.Windows.Forms.ListBox();
            this.pnlLateral = new System.Windows.Forms.Panel();
            this.lblHabilitar = new System.Windows.Forms.Label();
            this.btnEncendido = new System.Windows.Forms.Button();
            this.imgListPower = new System.Windows.Forms.ImageList(this.components);
            this.grpValorHora = new System.Windows.Forms.GroupBox();
            this.txtImporteAuto = new System.Windows.Forms.TextBox();
            this.txtImporteCamioneta = new System.Windows.Forms.TextBox();
            this.txtImporteMoto = new System.Windows.Forms.TextBox();
            this.btnEstablecerImporte = new System.Windows.Forms.Button();
            this.imgListCandado = new System.Windows.Forms.ImageList(this.components);
            this.lblMoto = new System.Windows.Forms.Label();
            this.lblCamioneta = new System.Windows.Forms.Label();
            this.lblAuto = new System.Windows.Forms.Label();
            this.lblHoraActual = new System.Windows.Forms.Label();
            this.btnNuevoIngreso = new System.Windows.Forms.Button();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.timerHora = new System.Windows.Forms.Timer(this.components);
            this.lblListadoDeVehiculos = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.txtToolBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressToolBar = new System.Windows.Forms.ToolStripProgressBar();
            this.grpManual = new System.Windows.Forms.GroupBox();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblPatente = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.pnlLateral.SuspendLayout();
            this.grpValorHora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            this.statusBar.SuspendLayout();
            this.grpManual.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxVehiculos
            // 
            this.listBoxVehiculos.BackColor = System.Drawing.SystemColors.Menu;
            this.listBoxVehiculos.FormattingEnabled = true;
            this.listBoxVehiculos.HorizontalScrollbar = true;
            this.listBoxVehiculos.Location = new System.Drawing.Point(133, 25);
            this.listBoxVehiculos.Name = "listBoxVehiculos";
            this.listBoxVehiculos.Size = new System.Drawing.Size(354, 368);
            this.listBoxVehiculos.TabIndex = 2;
            this.listBoxVehiculos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstbVehiculos_MouseDoubleClick);
            // 
            // pnlLateral
            // 
            this.pnlLateral.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlLateral.Controls.Add(this.lblHabilitar);
            this.pnlLateral.Controls.Add(this.btnEncendido);
            this.pnlLateral.Controls.Add(this.grpValorHora);
            this.pnlLateral.Controls.Add(this.lblHoraActual);
            this.pnlLateral.Controls.Add(this.btnNuevoIngreso);
            this.pnlLateral.Controls.Add(this.pcbLogo);
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size = new System.Drawing.Size(124, 637);
            this.pnlLateral.TabIndex = 3;
            // 
            // lblHabilitar
            // 
            this.lblHabilitar.AutoSize = true;
            this.lblHabilitar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblHabilitar.Location = new System.Drawing.Point(19, 112);
            this.lblHabilitar.Name = "lblHabilitar";
            this.lblHabilitar.Size = new System.Drawing.Size(94, 15);
            this.lblHabilitar.TabIndex = 10;
            this.lblHabilitar.Text = "Habilitar Ingreso";
            // 
            // btnEncendido
            // 
            this.btnEncendido.FlatAppearance.BorderSize = 0;
            this.btnEncendido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncendido.ImageIndex = 0;
            this.btnEncendido.ImageList = this.imgListPower;
            this.btnEncendido.Location = new System.Drawing.Point(31, 130);
            this.btnEncendido.Name = "btnEncendido";
            this.btnEncendido.Size = new System.Drawing.Size(55, 37);
            this.btnEncendido.TabIndex = 6;
            this.btnEncendido.UseVisualStyleBackColor = true;
            this.btnEncendido.Click += new System.EventHandler(this.btnEncendido_Click);
            // 
            // imgListPower
            // 
            this.imgListPower.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListPower.ImageStream")));
            this.imgListPower.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListPower.Images.SetKeyName(0, "switch-off.png");
            this.imgListPower.Images.SetKeyName(1, "switch-on.png");
            // 
            // grpValorHora
            // 
            this.grpValorHora.Controls.Add(this.txtImporteAuto);
            this.grpValorHora.Controls.Add(this.txtImporteCamioneta);
            this.grpValorHora.Controls.Add(this.txtImporteMoto);
            this.grpValorHora.Controls.Add(this.btnEstablecerImporte);
            this.grpValorHora.Controls.Add(this.lblMoto);
            this.grpValorHora.Controls.Add(this.lblCamioneta);
            this.grpValorHora.Controls.Add(this.lblAuto);
            this.grpValorHora.Location = new System.Drawing.Point(6, 396);
            this.grpValorHora.Name = "grpValorHora";
            this.grpValorHora.Size = new System.Drawing.Size(112, 181);
            this.grpValorHora.TabIndex = 9;
            this.grpValorHora.TabStop = false;
            this.grpValorHora.Text = "Importe de la Hora";
            // 
            // txtImporteAuto
            // 
            this.txtImporteAuto.Location = new System.Drawing.Point(6, 32);
            this.txtImporteAuto.Name = "txtImporteAuto";
            this.txtImporteAuto.Size = new System.Drawing.Size(100, 20);
            this.txtImporteAuto.TabIndex = 10;
            this.txtImporteAuto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteAuto_KeyPress);
            // 
            // txtImporteCamioneta
            // 
            this.txtImporteCamioneta.Location = new System.Drawing.Point(6, 68);
            this.txtImporteCamioneta.Name = "txtImporteCamioneta";
            this.txtImporteCamioneta.Size = new System.Drawing.Size(100, 20);
            this.txtImporteCamioneta.TabIndex = 11;
            this.txtImporteCamioneta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteCamioneta_KeyPress);
            // 
            // txtImporteMoto
            // 
            this.txtImporteMoto.Location = new System.Drawing.Point(6, 109);
            this.txtImporteMoto.Name = "txtImporteMoto";
            this.txtImporteMoto.Size = new System.Drawing.Size(100, 20);
            this.txtImporteMoto.TabIndex = 12;
            this.txtImporteMoto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteMoto_KeyPress);
            // 
            // btnEstablecerImporte
            // 
            this.btnEstablecerImporte.FlatAppearance.BorderSize = 0;
            this.btnEstablecerImporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstablecerImporte.ImageIndex = 1;
            this.btnEstablecerImporte.ImageList = this.imgListCandado;
            this.btnEstablecerImporte.Location = new System.Drawing.Point(31, 135);
            this.btnEstablecerImporte.Name = "btnEstablecerImporte";
            this.btnEstablecerImporte.Size = new System.Drawing.Size(49, 40);
            this.btnEstablecerImporte.TabIndex = 12;
            this.btnEstablecerImporte.UseVisualStyleBackColor = true;
            this.btnEstablecerImporte.Click += new System.EventHandler(this.btnEstablecerImporte_Click);
            // 
            // imgListCandado
            // 
            this.imgListCandado.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListCandado.ImageStream")));
            this.imgListCandado.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListCandado.Images.SetKeyName(0, "CandadoLock.png");
            this.imgListCandado.Images.SetKeyName(1, "CandadoUnLock.png");
            // 
            // lblMoto
            // 
            this.lblMoto.AutoSize = true;
            this.lblMoto.Location = new System.Drawing.Point(6, 91);
            this.lblMoto.Name = "lblMoto";
            this.lblMoto.Size = new System.Drawing.Size(34, 13);
            this.lblMoto.TabIndex = 11;
            this.lblMoto.Text = "Moto:";
            // 
            // lblCamioneta
            // 
            this.lblCamioneta.AutoSize = true;
            this.lblCamioneta.Location = new System.Drawing.Point(6, 53);
            this.lblCamioneta.Name = "lblCamioneta";
            this.lblCamioneta.Size = new System.Drawing.Size(60, 13);
            this.lblCamioneta.TabIndex = 10;
            this.lblCamioneta.Text = "Camioneta:";
            // 
            // lblAuto
            // 
            this.lblAuto.AutoSize = true;
            this.lblAuto.Location = new System.Drawing.Point(6, 16);
            this.lblAuto.Name = "lblAuto";
            this.lblAuto.Size = new System.Drawing.Size(32, 13);
            this.lblAuto.TabIndex = 9;
            this.lblAuto.Text = "Auto:";
            // 
            // lblHoraActual
            // 
            this.lblHoraActual.AutoSize = true;
            this.lblHoraActual.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblHoraActual.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraActual.Location = new System.Drawing.Point(12, 606);
            this.lblHoraActual.Name = "lblHoraActual";
            this.lblHoraActual.Size = new System.Drawing.Size(59, 22);
            this.lblHoraActual.TabIndex = 5;
            this.lblHoraActual.Text = "Hora:";
            // 
            // btnNuevoIngreso
            // 
            this.btnNuevoIngreso.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnNuevoIngreso.FlatAppearance.BorderSize = 0;
            this.btnNuevoIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoIngreso.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoIngreso.Location = new System.Drawing.Point(3, 173);
            this.btnNuevoIngreso.Name = "btnNuevoIngreso";
            this.btnNuevoIngreso.Size = new System.Drawing.Size(115, 45);
            this.btnNuevoIngreso.TabIndex = 2;
            this.btnNuevoIngreso.Text = "Nuevo Ingreso";
            this.btnNuevoIngreso.UseVisualStyleBackColor = false;
            this.btnNuevoIngreso.Visible = false;
            this.btnNuevoIngreso.Click += new System.EventHandler(this.btnNuevoIngreso_Click);
            // 
            // pcbLogo
            // 
            this.pcbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcbLogo.Image")));
            this.pcbLogo.Location = new System.Drawing.Point(3, 3);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(115, 88);
            this.pcbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLogo.TabIndex = 0;
            this.pcbLogo.TabStop = false;
            // 
            // timerHora
            // 
            this.timerHora.Enabled = true;
            this.timerHora.Tick += new System.EventHandler(this.timerHora_Tick);
            // 
            // lblListadoDeVehiculos
            // 
            this.lblListadoDeVehiculos.AutoSize = true;
            this.lblListadoDeVehiculos.Location = new System.Drawing.Point(130, 9);
            this.lblListadoDeVehiculos.Name = "lblListadoDeVehiculos";
            this.lblListadoDeVehiculos.Size = new System.Drawing.Size(108, 13);
            this.lblListadoDeVehiculos.TabIndex = 4;
            this.lblListadoDeVehiculos.Text = "Listado de Vehiculos:";
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtToolBar,
            this.progressToolBar});
            this.statusBar.Location = new System.Drawing.Point(124, 615);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(425, 22);
            this.statusBar.TabIndex = 7;
            // 
            // txtToolBar
            // 
            this.txtToolBar.Name = "txtToolBar";
            this.txtToolBar.Size = new System.Drawing.Size(122, 17);
            this.txtToolBar.Text = "Capacidad/Ocupados";
            // 
            // progressToolBar
            // 
            this.progressToolBar.Name = "progressToolBar";
            this.progressToolBar.Size = new System.Drawing.Size(100, 16);
            // 
            // grpManual
            // 
            this.grpManual.Controls.Add(this.cmbTipoVehiculo);
            this.grpManual.Controls.Add(this.lblTipo);
            this.grpManual.Controls.Add(this.lblHora);
            this.grpManual.Controls.Add(this.lblPatente);
            this.grpManual.Controls.Add(this.btnAceptar);
            this.grpManual.Controls.Add(this.txtHora);
            this.grpManual.Controls.Add(this.txtPatente);
            this.grpManual.Location = new System.Drawing.Point(133, 412);
            this.grpManual.Name = "grpManual";
            this.grpManual.Size = new System.Drawing.Size(193, 148);
            this.grpManual.TabIndex = 8;
            this.grpManual.TabStop = false;
            this.grpManual.Text = "Salida";
            this.grpManual.Visible = false;
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(59, 92);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(100, 21);
            this.cmbTipoVehiculo.TabIndex = 6;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(8, 100);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 5;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(6, 59);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(33, 13);
            this.lblHora.TabIndex = 4;
            this.lblHora.Text = "Hora:";
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(6, 23);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(47, 13);
            this.lblPatente.TabIndex = 3;
            this.lblPatente.Text = "Patente:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(9, 119);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(178, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtHora
            // 
            this.txtHora.Location = new System.Drawing.Point(59, 52);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(100, 20);
            this.txtHora.TabIndex = 1;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(59, 16);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(100, 20);
            this.txtPatente.TabIndex = 0;
            // 
            // frmEstacionamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(549, 637);
            this.Controls.Add(this.grpManual);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.lblListadoDeVehiculos);
            this.Controls.Add(this.pnlLateral);
            this.Controls.Add(this.listBoxVehiculos);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEstacionamiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estacionamiento 24 Hs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEstacionamiento_FormClosing);
            this.Load += new System.EventHandler(this.frmEstacionamiento_Load);
            this.pnlLateral.ResumeLayout(false);
            this.pnlLateral.PerformLayout();
            this.grpValorHora.ResumeLayout(false);
            this.grpValorHora.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.grpManual.ResumeLayout(false);
            this.grpManual.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxVehiculos;
        private System.Windows.Forms.Panel pnlLateral;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.Button btnNuevoIngreso;
        private System.Windows.Forms.Label lblHoraActual;
        private System.Windows.Forms.Timer timerHora;
        private System.Windows.Forms.GroupBox grpValorHora;
        private System.Windows.Forms.Label lblMoto;
        private System.Windows.Forms.Label lblCamioneta;
        private System.Windows.Forms.Label lblAuto;
        private System.Windows.Forms.Button btnEstablecerImporte;
        private System.Windows.Forms.ImageList imgListCandado;
        private System.Windows.Forms.TextBox txtImporteAuto;
        private System.Windows.Forms.TextBox txtImporteCamioneta;
        private System.Windows.Forms.TextBox txtImporteMoto;
        private System.Windows.Forms.Button btnEncendido;
        private System.Windows.Forms.ImageList imgListPower;
        private System.Windows.Forms.Label lblHabilitar;
        private System.Windows.Forms.Label lblListadoDeVehiculos;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel txtToolBar;
        private System.Windows.Forms.ToolStripProgressBar progressToolBar;
        private System.Windows.Forms.GroupBox grpManual;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
        private System.Windows.Forms.Label lblTipo;
    }
}

