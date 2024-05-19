
namespace TiendaAnimals
{
    partial class INVENTARIOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INVENTARIOS));
            this.label3 = new System.Windows.Forms.Label();
            this.textBuscador = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridProductos = new System.Windows.Forms.DataGridView();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonInsertar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Buscador";
            // 
            // textBuscador
            // 
            this.textBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBuscador.Location = new System.Drawing.Point(168, 170);
            this.textBuscador.Name = "textBuscador";
            this.textBuscador.Size = new System.Drawing.Size(596, 24);
            this.textBuscador.TabIndex = 16;
            this.textBuscador.TextChanged += new System.EventHandler(this.textBuscador_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 39);
            this.label2.TabIndex = 11;
            this.label2.Text = "Disponible en la tienda";
            // 
            // dataGridProductos
            // 
            this.dataGridProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProductos.Location = new System.Drawing.Point(51, 208);
            this.dataGridProductos.Name = "dataGridProductos";
            this.dataGridProductos.ReadOnly = true;
            this.dataGridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProductos.Size = new System.Drawing.Size(713, 497);
            this.dataGridProductos.TabIndex = 10;
            this.dataGridProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridALUMNOS_CellContentClick);
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBorrar.BackgroundImage")));
            this.buttonBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBorrar.Location = new System.Drawing.Point(816, 481);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(167, 78);
            this.buttonBorrar.TabIndex = 14;
            this.buttonBorrar.Text = "Borrar";
            this.buttonBorrar.UseVisualStyleBackColor = true;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonModificar.BackgroundImage")));
            this.buttonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificar.Location = new System.Drawing.Point(816, 342);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(167, 78);
            this.buttonModificar.TabIndex = 13;
            this.buttonModificar.Text = "Modifficar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonInsertar
            // 
            this.buttonInsertar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonInsertar.BackgroundImage")));
            this.buttonInsertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsertar.Location = new System.Drawing.Point(816, 208);
            this.buttonInsertar.Name = "buttonInsertar";
            this.buttonInsertar.Size = new System.Drawing.Size(167, 80);
            this.buttonInsertar.TabIndex = 12;
            this.buttonInsertar.Text = "Insertar";
            this.buttonInsertar.UseVisualStyleBackColor = true;
            this.buttonInsertar.Click += new System.EventHandler(this.buttonInsertar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::TiendaAnimals.Properties.Resources.telon_de_fondo_con_siluetas_de_huella_de_perro_o_de_gato_vector_animal_ilustracion_purpura_paw_via_patron_huellas_sin_fisuras_t1dhpg;
            this.label1.Location = new System.Drawing.Point(-55, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1169, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "                                                             Inventario          " +
    "                                                         ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // INVENTARIOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1021, 758);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBuscador);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.buttonInsertar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridProductos);
            this.Controls.Add(this.label1);
            this.Name = "INVENTARIOS";
            this.Text = "INVENTARIOS";
            this.Load += new System.EventHandler(this.INVENTARIOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBuscador;
        private System.Windows.Forms.Button buttonBorrar;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonInsertar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridProductos;
    }
}