namespace Prog3_TP2__GESTION_ARTICULOS_
{
    partial class frmMarcas
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
            this.lbMarcas = new System.Windows.Forms.Label();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.btAgregar = new System.Windows.Forms.Button();
            this.cbMarcas = new System.Windows.Forms.ComboBox();
            this.btEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMarcas
            // 
            this.lbMarcas.AutoSize = true;
            this.lbMarcas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMarcas.Location = new System.Drawing.Point(26, 26);
            this.lbMarcas.Name = "lbMarcas";
            this.lbMarcas.Size = new System.Drawing.Size(76, 20);
            this.lbMarcas.TabIndex = 0;
            this.lbMarcas.Text = "Nombre:";
            // 
            // txbNombre
            // 
            this.txbNombre.Location = new System.Drawing.Point(30, 54);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(227, 20);
            this.txbNombre.TabIndex = 1;
            // 
            // btAgregar
            // 
            this.btAgregar.Location = new System.Drawing.Point(263, 52);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(75, 22);
            this.btAgregar.TabIndex = 2;
            this.btAgregar.Text = "Agregar";
            this.btAgregar.UseVisualStyleBackColor = true;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // cbMarcas
            // 
            this.cbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarcas.FormattingEnabled = true;
            this.cbMarcas.Location = new System.Drawing.Point(30, 94);
            this.cbMarcas.Name = "cbMarcas";
            this.cbMarcas.Size = new System.Drawing.Size(227, 21);
            this.cbMarcas.TabIndex = 3;
            // 
            // btEliminar
            // 
            this.btEliminar.Location = new System.Drawing.Point(263, 93);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(75, 21);
            this.btEliminar.TabIndex = 4;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // frmMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 150);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.cbMarcas);
            this.Controls.Add(this.btAgregar);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.lbMarcas);
            this.Name = "frmMarcas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marcas";
            this.Load += new System.EventHandler(this.frmMarcas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMarcas;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.ComboBox cbMarcas;
        private System.Windows.Forms.Button btEliminar;
    }
}