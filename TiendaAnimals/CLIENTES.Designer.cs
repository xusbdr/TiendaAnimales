
namespace TiendaAnimals
{
    partial class CLIENTES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CLIENTES));
            this.label1 = new System.Windows.Forms.Label();
            this.dataClientes = new System.Windows.Forms.DataGridView();
            this.buttonAñadir = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::TiendaAnimals.Properties.Resources.telon_de_fondo_con_siluetas_de_huella_de_perro_o_de_gato_vector_animal_ilustracion_purpura_paw_via_patron_huellas_sin_fisuras_t1dhpg;
            this.label1.Location = new System.Drawing.Point(-250, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1387, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "                                               Clientes                          " +
    "           ";
            // 
            // dataClientes
            // 
            this.dataClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataClientes.Location = new System.Drawing.Point(66, 176);
            this.dataClientes.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dataClientes.Name = "dataClientes";
            this.dataClientes.ReadOnly = true;
            this.dataClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataClientes.Size = new System.Drawing.Size(745, 616);
            this.dataClientes.TabIndex = 2;
            this.dataClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataClientes_CellContentClick);
            // 
            // buttonAñadir
            // 
            this.buttonAñadir.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAñadir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAñadir.BackgroundImage")));
            this.buttonAñadir.Font = new System.Drawing.Font("Mongolian Baiti", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAñadir.Location = new System.Drawing.Point(871, 176);
            this.buttonAñadir.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonAñadir.Name = "buttonAñadir";
            this.buttonAñadir.Size = new System.Drawing.Size(173, 96);
            this.buttonAñadir.TabIndex = 3;
            this.buttonAñadir.Text = "Añadir ";
            this.buttonAñadir.UseVisualStyleBackColor = false;
            this.buttonAñadir.Click += new System.EventHandler(this.buttonAñadir_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonModificar.BackgroundImage")));
            this.buttonModificar.Font = new System.Drawing.Font("Mongolian Baiti", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificar.Location = new System.Drawing.Point(871, 346);
            this.buttonModificar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(173, 96);
            this.buttonModificar.TabIndex = 4;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBorrar.BackgroundImage")));
            this.buttonBorrar.Font = new System.Drawing.Font("Mongolian Baiti", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBorrar.Location = new System.Drawing.Point(871, 512);
            this.buttonBorrar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(173, 96);
            this.buttonBorrar.TabIndex = 5;
            this.buttonBorrar.Text = "Borrar";
            this.buttonBorrar.UseVisualStyleBackColor = true;
            this.buttonBorrar.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Reem Kufi", 24F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(32, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 61);
            this.label2.TabIndex = 12;
            this.label2.Text = "Clientes Registrados";
            // 
            // CLIENTES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1082, 832);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.buttonAñadir);
            this.Controls.Add(this.dataClientes);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.Name = "CLIENTES";
            this.Text = "CLIENTES";
            this.Load += new System.EventHandler(this.CLIENTES_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataClientes;
        private System.Windows.Forms.Button buttonAñadir;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonBorrar;
        private System.Windows.Forms.Label label2;
    }
}