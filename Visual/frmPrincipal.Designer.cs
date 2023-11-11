namespace Visual
{
    partial class frmPrincipal
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
            this.lblElemento = new System.Windows.Forms.Label();
            this.cbElemento = new System.Windows.Forms.ComboBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.lblTituloFiltro = new System.Windows.Forms.Label();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.txtFiltroRapido = new System.Windows.Forms.TextBox();
            this.lblFiltroRapido = new System.Windows.Forms.Label();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModifcar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvArticle = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblElemento
            // 
            this.lblElemento.AutoSize = true;
            this.lblElemento.Location = new System.Drawing.Point(695, 103);
            this.lblElemento.Name = "lblElemento";
            this.lblElemento.Size = new System.Drawing.Size(65, 16);
            this.lblElemento.TabIndex = 1;
            this.lblElemento.Text = "Elemento";
            // 
            // cbElemento
            // 
            this.cbElemento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbElemento.FormattingEnabled = true;
            this.cbElemento.Location = new System.Drawing.Point(782, 99);
            this.cbElemento.Name = "cbElemento";
            this.cbElemento.Size = new System.Drawing.Size(114, 24);
            this.cbElemento.TabIndex = 2;
            this.cbElemento.SelectedIndexChanged += new System.EventHandler(this.cbElemento_SelectedIndexChanged);
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(782, 143);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(114, 24);
            this.cbTipo.TabIndex = 3;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(636, 146);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(119, 16);
            this.lblTipo.TabIndex = 3;
            this.lblTipo.Text = "Tipo de busqueda";
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(725, 189);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(40, 16);
            this.lblFiltro.TabIndex = 5;
            this.lblFiltro.Text = "Filtro";
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(782, 187);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(114, 27);
            this.txtFiltroAvanzado.TabIndex = 4;
            this.txtFiltroAvanzado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltroAvanzado_KeyPress);
            // 
            // lblTituloFiltro
            // 
            this.lblTituloFiltro.AutoSize = true;
            this.lblTituloFiltro.Location = new System.Drawing.Point(731, 46);
            this.lblTituloFiltro.Name = "lblTituloFiltro";
            this.lblTituloFiltro.Size = new System.Drawing.Size(105, 16);
            this.lblTituloFiltro.TabIndex = 7;
            this.lblTituloFiltro.Text = "Filtro Avanzado";
            // 
            // btnFiltro
            // 
            this.btnFiltro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltro.Location = new System.Drawing.Point(720, 233);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(122, 36);
            this.btnFiltro.TabIndex = 5;
            this.btnFiltro.Text = "Filtro Avanzado";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // txtFiltroRapido
            // 
            this.txtFiltroRapido.Location = new System.Drawing.Point(16, 43);
            this.txtFiltroRapido.Name = "txtFiltroRapido";
            this.txtFiltroRapido.Size = new System.Drawing.Size(166, 27);
            this.txtFiltroRapido.TabIndex = 1;
            this.txtFiltroRapido.TextChanged += new System.EventHandler(this.txtFiltroRapido_TextChanged);
            // 
            // lblFiltroRapido
            // 
            this.lblFiltroRapido.AutoSize = true;
            this.lblFiltroRapido.Location = new System.Drawing.Point(205, 46);
            this.lblFiltroRapido.Name = "lblFiltroRapido";
            this.lblFiltroRapido.Size = new System.Drawing.Size(87, 16);
            this.lblFiltroRapido.TabIndex = 10;
            this.lblFiltroRapido.Text = "Filtro Rapido";
            // 
            // btnDetalle
            // 
            this.btnDetalle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalle.Location = new System.Drawing.Point(16, 289);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(97, 32);
            this.btnDetalle.TabIndex = 6;
            this.btnDetalle.Text = "Ver detalle";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(119, 289);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(127, 32);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar articulo";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModifcar
            // 
            this.btnModifcar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnModifcar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifcar.Location = new System.Drawing.Point(252, 289);
            this.btnModifcar.Name = "btnModifcar";
            this.btnModifcar.Size = new System.Drawing.Size(130, 32);
            this.btnModifcar.TabIndex = 8;
            this.btnModifcar.Text = "Modificar articulo";
            this.btnModifcar.UseVisualStyleBackColor = true;
            this.btnModifcar.Click += new System.EventHandler(this.btnModifcar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(388, 289);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(103, 32);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar articulo";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvArticle
            // 
            this.dgvArticle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArticle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvArticle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArticle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticle.Location = new System.Drawing.Point(16, 81);
            this.dgvArticle.Name = "dgvArticle";
            this.dgvArticle.RowHeadersWidth = 51;
            this.dgvArticle.RowTemplate.Height = 24;
            this.dgvArticle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticle.Size = new System.Drawing.Size(606, 188);
            this.dgvArticle.TabIndex = 0;
            this.dgvArticle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticle_CellDoubleClick);
            this.dgvArticle.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvArticle_CellFormatting);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 354);
            this.Controls.Add(this.dgvArticle);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModifcar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.lblFiltroRapido);
            this.Controls.Add(this.txtFiltroRapido);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.lblTituloFiltro);
            this.Controls.Add(this.txtFiltroAvanzado);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cbElemento);
            this.Controls.Add(this.lblElemento);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catalogo";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblElemento;
        private System.Windows.Forms.ComboBox cbElemento;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox txtFiltroAvanzado;
        private System.Windows.Forms.Label lblTituloFiltro;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.TextBox txtFiltroRapido;
        private System.Windows.Forms.Label lblFiltroRapido;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModifcar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvArticle;
    }
}

