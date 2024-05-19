
namespace TiendaAnimals
{
    partial class Modificar
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
            this.textId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.errorDescripcion = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorStock = new System.Windows.Forms.Label();
            this.errorPrecio = new System.Windows.Forms.Label();
            this.errorNombres = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.comboFamilia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textPrecio = new System.Windows.Forms.TextBox();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.textnombre = new System.Windows.Forms.TextBox();
            this.textBStock = new System.Windows.Forms.TextBox();
            this.buttonguardar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textId
            // 
            this.textId.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textId.Location = new System.Drawing.Point(19, 50);
            this.textId.Name = "textId";
            this.textId.ReadOnly = true;
            this.textId.Size = new System.Drawing.Size(100, 22);
            this.textId.TabIndex = 104;
            this.textId.TextChanged += new System.EventHandler(this.textId_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(177, 527);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 13);
            this.label9.TabIndex = 103;
            this.label9.Text = "(Máximo 25 Caracteres))";
            this.label9.Click += new System.EventHandler(this.label9_Click_1);
            // 
            // errorDescripcion
            // 
            this.errorDescripcion.AutoSize = true;
            this.errorDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorDescripcion.Location = new System.Drawing.Point(71, 624);
            this.errorDescripcion.Name = "errorDescripcion";
            this.errorDescripcion.Size = new System.Drawing.Size(11, 13);
            this.errorDescripcion.TabIndex = 102;
            this.errorDescripcion.Text = ".";
            this.errorDescripcion.Click += new System.EventHandler(this.errorDescripcion_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(135, 428);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 101;
            this.label10.Text = "(solo números)";
            this.label10.Click += new System.EventHandler(this.label10_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(136, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 100;
            this.label8.Text = "( solo letras )";
            this.label8.Click += new System.EventHandler(this.label8_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(135, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "(solo números)";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // errorStock
            // 
            this.errorStock.AutoSize = true;
            this.errorStock.BackColor = System.Drawing.Color.WhiteSmoke;
            this.errorStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorStock.Location = new System.Drawing.Point(71, 443);
            this.errorStock.Name = "errorStock";
            this.errorStock.Size = new System.Drawing.Size(11, 13);
            this.errorStock.TabIndex = 98;
            this.errorStock.Text = ".";
            this.errorStock.Click += new System.EventHandler(this.errorStock_Click_1);
            // 
            // errorPrecio
            // 
            this.errorPrecio.AutoSize = true;
            this.errorPrecio.BackColor = System.Drawing.Color.Transparent;
            this.errorPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorPrecio.Location = new System.Drawing.Point(71, 337);
            this.errorPrecio.Name = "errorPrecio";
            this.errorPrecio.Size = new System.Drawing.Size(11, 13);
            this.errorPrecio.TabIndex = 97;
            this.errorPrecio.Text = ".";
            this.errorPrecio.Click += new System.EventHandler(this.errorPrecio_Click_1);
            // 
            // errorNombres
            // 
            this.errorNombres.AutoSize = true;
            this.errorNombres.BackColor = System.Drawing.Color.Transparent;
            this.errorNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorNombres.Location = new System.Drawing.Point(71, 245);
            this.errorNombres.Name = "errorNombres";
            this.errorNombres.Size = new System.Drawing.Size(11, 13);
            this.errorNombres.TabIndex = 96;
            this.errorNombres.Text = ".";
            this.errorNombres.Click += new System.EventHandler(this.errorNombres_Click_1);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.MistyRose;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancelar.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(374, 708);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(94, 33);
            this.buttonCancelar.TabIndex = 95;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // comboFamilia
            // 
            this.comboFamilia.FormattingEnabled = true;
            this.comboFamilia.Location = new System.Drawing.Point(248, 155);
            this.comboFamilia.Name = "comboFamilia";
            this.comboFamilia.Size = new System.Drawing.Size(181, 21);
            this.comboFamilia.TabIndex = 94;
            this.comboFamilia.SelectedIndexChanged += new System.EventHandler(this.comboFamilia_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 93;
            this.label5.Text = "Tipo de Familia";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 92;
            this.label4.Text = "Stock";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 40);
            this.label3.TabIndex = 91;
            this.label3.Text = "Precio \r\n                ";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 522);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 90;
            this.label2.Text = "Descripción";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(66, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 20);
            this.label11.TabIndex = 89;
            this.label11.Text = "Nombre ";
            this.label11.Click += new System.EventHandler(this.label11_Click_1);
            // 
            // textPrecio
            // 
            this.textPrecio.Location = new System.Drawing.Point(248, 315);
            this.textPrecio.Name = "textPrecio";
            this.textPrecio.Size = new System.Drawing.Size(181, 20);
            this.textPrecio.TabIndex = 88;
            this.textPrecio.TextChanged += new System.EventHandler(this.textPrecio_TextChanged);
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(74, 547);
            this.textDescripcion.Multiline = true;
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(355, 74);
            this.textDescripcion.TabIndex = 87;
            this.textDescripcion.TextChanged += new System.EventHandler(this.textDescripcion_TextChanged);
            // 
            // textnombre
            // 
            this.textnombre.Location = new System.Drawing.Point(248, 225);
            this.textnombre.Name = "textnombre";
            this.textnombre.Size = new System.Drawing.Size(181, 20);
            this.textnombre.TabIndex = 86;
            this.textnombre.TextChanged += new System.EventHandler(this.textnombre_TextChanged);
            // 
            // textBStock
            // 
            this.textBStock.Location = new System.Drawing.Point(248, 421);
            this.textBStock.Name = "textBStock";
            this.textBStock.Size = new System.Drawing.Size(181, 20);
            this.textBStock.TabIndex = 85;
            this.textBStock.TextChanged += new System.EventHandler(this.textBStock_TextChanged);
            // 
            // buttonguardar
            // 
            this.buttonguardar.BackColor = System.Drawing.Color.Honeydew;
            this.buttonguardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonguardar.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonguardar.Location = new System.Drawing.Point(272, 708);
            this.buttonguardar.Name = "buttonguardar";
            this.buttonguardar.Size = new System.Drawing.Size(94, 33);
            this.buttonguardar.TabIndex = 84;
            this.buttonguardar.Text = "Guardar";
            this.buttonguardar.UseVisualStyleBackColor = false;
            this.buttonguardar.Click += new System.EventHandler(this.buttonguardar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(210, 24);
            this.label7.TabIndex = 79;
            this.label7.Text = "Modificar Información";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TiendaAnimals.Properties.Resources.ic;
            this.pictureBox1.Location = new System.Drawing.Point(398, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 105;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(480, 757);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.errorDescripcion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.errorStock);
            this.Controls.Add(this.errorPrecio);
            this.Controls.Add(this.errorNombres);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.comboFamilia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textPrecio);
            this.Controls.Add(this.textDescripcion);
            this.Controls.Add(this.textnombre);
            this.Controls.Add(this.textBStock);
            this.Controls.Add(this.buttonguardar);
            this.Controls.Add(this.label7);
            this.Name = "Modificar";
            this.Text = "Modificar";
            this.Load += new System.EventHandler(this.Modificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label errorDescripcion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label errorStock;
        private System.Windows.Forms.Label errorPrecio;
        private System.Windows.Forms.Label errorNombres;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.ComboBox comboFamilia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textPrecio;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.TextBox textnombre;
        private System.Windows.Forms.TextBox textBStock;
        private System.Windows.Forms.Button buttonguardar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}