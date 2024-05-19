
namespace TiendaAnimals
{
    partial class Añadir
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
            this.errorNombre = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboFamilia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textPrecio = new System.Windows.Forms.TextBox();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.textnombre = new System.Windows.Forms.TextBox();
            this.textBStock = new System.Windows.Forms.TextBox();
            this.buttonguardar = new System.Windows.Forms.Button();
            this.errorNombres = new System.Windows.Forms.Label();
            this.errorPrecio = new System.Windows.Forms.Label();
            this.errorStock = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.errorDescripcion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorNombre
            // 
            this.errorNombre.Location = new System.Drawing.Point(38, 103);
            this.errorNombre.Name = "errorNombre";
            this.errorNombre.Size = new System.Drawing.Size(100, 23);
            this.errorNombre.TabIndex = 2;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.MistyRose;
            this.buttonCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancelar.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(348, 708);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(94, 33);
            this.buttonCancelar.TabIndex = 36;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 22);
            this.label7.TabIndex = 35;
            this.label7.Text = "Añadir Stock a tienda";
            // 
            // comboFamilia
            // 
            this.comboFamilia.FormattingEnabled = true;
            this.comboFamilia.Location = new System.Drawing.Point(234, 142);
            this.comboFamilia.Name = "comboFamilia";
            this.comboFamilia.Size = new System.Drawing.Size(181, 21);
            this.comboFamilia.TabIndex = 33;
            this.comboFamilia.SelectedIndexChanged += new System.EventHandler(this.comboFamilia_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Tipo de Familia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 410);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 40);
            this.label3.TabIndex = 29;
            this.label3.Text = "Precio \r\n                ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nombre ";
            // 
            // textPrecio
            // 
            this.textPrecio.Location = new System.Drawing.Point(234, 302);
            this.textPrecio.Name = "textPrecio";
            this.textPrecio.Size = new System.Drawing.Size(181, 20);
            this.textPrecio.TabIndex = 26;
            this.textPrecio.TextChanged += new System.EventHandler(this.textPrecio_TextChanged);
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(56, 511);
            this.textDescripcion.Multiline = true;
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(359, 80);
            this.textDescripcion.TabIndex = 25;
            this.textDescripcion.TextChanged += new System.EventHandler(this.textapellidos_TextChanged);
            // 
            // textnombre
            // 
            this.textnombre.Location = new System.Drawing.Point(234, 212);
            this.textnombre.Name = "textnombre";
            this.textnombre.Size = new System.Drawing.Size(181, 20);
            this.textnombre.TabIndex = 24;
            this.textnombre.TextChanged += new System.EventHandler(this.textnombre_TextChanged);
            // 
            // textBStock
            // 
            this.textBStock.Location = new System.Drawing.Point(234, 408);
            this.textBStock.Name = "textBStock";
            this.textBStock.Size = new System.Drawing.Size(181, 20);
            this.textBStock.TabIndex = 23;
            this.textBStock.TextChanged += new System.EventHandler(this.textBStock_TextChanged);
            // 
            // buttonguardar
            // 
            this.buttonguardar.BackColor = System.Drawing.Color.Honeydew;
            this.buttonguardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonguardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonguardar.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonguardar.Location = new System.Drawing.Point(240, 708);
            this.buttonguardar.Name = "buttonguardar";
            this.buttonguardar.Size = new System.Drawing.Size(94, 33);
            this.buttonguardar.TabIndex = 22;
            this.buttonguardar.Text = "Guardar";
            this.buttonguardar.UseVisualStyleBackColor = false;
            this.buttonguardar.Click += new System.EventHandler(this.buttonguardar_Click);
            // 
            // errorNombres
            // 
            this.errorNombres.AutoSize = true;
            this.errorNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorNombres.Location = new System.Drawing.Point(57, 232);
            this.errorNombres.Name = "errorNombres";
            this.errorNombres.Size = new System.Drawing.Size(11, 13);
            this.errorNombres.TabIndex = 37;
            this.errorNombres.Text = ".";
            // 
            // errorPrecio
            // 
            this.errorPrecio.AutoSize = true;
            this.errorPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorPrecio.Location = new System.Drawing.Point(57, 324);
            this.errorPrecio.Name = "errorPrecio";
            this.errorPrecio.Size = new System.Drawing.Size(11, 13);
            this.errorPrecio.TabIndex = 38;
            this.errorPrecio.Text = ".";
            // 
            // errorStock
            // 
            this.errorStock.AutoSize = true;
            this.errorStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorStock.Location = new System.Drawing.Point(57, 430);
            this.errorStock.Name = "errorStock";
            this.errorStock.Size = new System.Drawing.Size(11, 13);
            this.errorStock.TabIndex = 39;
            this.errorStock.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(121, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "(solo números)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(122, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "( solo letras )";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(121, 415);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "(solo números)";
            // 
            // errorDescripcion
            // 
            this.errorDescripcion.AutoSize = true;
            this.errorDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorDescripcion.Location = new System.Drawing.Point(57, 594);
            this.errorDescripcion.Name = "errorDescripcion";
            this.errorDescripcion.Size = new System.Drawing.Size(11, 13);
            this.errorDescripcion.TabIndex = 46;
            this.errorDescripcion.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(159, 493);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "(Máximo 35 Caracteres)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TiendaAnimals.Properties.Resources.ic;
            this.pictureBox1.Location = new System.Drawing.Point(382, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 106;
            this.pictureBox1.TabStop = false;
            // 
            // Añadir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(464, 756);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.errorDescripcion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.errorStock);
            this.Controls.Add(this.errorPrecio);
            this.Controls.Add(this.errorNombres);
            this.Controls.Add(this.errorNombre);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboFamilia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPrecio);
            this.Controls.Add(this.textDescripcion);
            this.Controls.Add(this.textnombre);
            this.Controls.Add(this.textBStock);
            this.Controls.Add(this.buttonguardar);
            this.Name = "Añadir";
            this.Text = "Añadir";
            this.Load += new System.EventHandler(this.Añadir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label errorNombre;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboFamilia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPrecio;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.TextBox textnombre;
        private System.Windows.Forms.TextBox textBStock;
        private System.Windows.Forms.Button buttonguardar;
        private System.Windows.Forms.Label errorNombres;
        private System.Windows.Forms.Label errorPrecio;
        private System.Windows.Forms.Label errorStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label errorDescripcion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}