using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using MySql.Data.MySqlClient; //





namespace TiendaAnimals
{
    public partial class PRINCIPAL : Form
    {

        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataAdapter adaptador;



        public PRINCIPAL(MySqlConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;


            // posicionar a la iozquierda
            this.StartPosition = FormStartPosition.Manual; // Usar posición manual
            this.Location = new Point(0, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            /////
        }

        private void buttonInventarios_Click(object sender, EventArgs e)
        {
            INVENTARIOS inventarios = new INVENTARIOS(conexion);
            inventarios.ShowDialog();
        }

        private void buttonClientes_Click(object sender, EventArgs e)
        {
            CLIENTES clientes = new CLIENTES(conexion);
            clientes.ShowDialog();
        }

        private void buttonVerntas_Click(object sender, EventArgs e)
        {
            VENTAS ventas = new VENTAS(conexion);
            ventas.ShowDialog();
        }
    }
}
