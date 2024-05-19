using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using MySql.Data.MySqlClient;


namespace TiendaAnimals
{
    public partial class Form1 : Form
    {

        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataAdapter adaptador;

      




        public Form1()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // posociobnar los form al medio 



            string host = "127.0.0.1";
            string usuario = "root";
            string contraseña = "123456";
            string nombreBD = "tiendamascotas";

            string cadenaConexion = $"server={host};user id={usuario};password={contraseña};database={nombreBD}";
            conexion = new MySqlConnection(cadenaConexion);

        }






        private void label1_Click(object sender, EventArgs e)
        {
            /////////////
        }

        private void entrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PRINCIPAL principal = new PRINCIPAL(conexion);
            principal.ShowDialog();

        }
    }
}
