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
    public partial class CONSULTARcompras : Form
    {


        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataAdapter adaptador;
        private DataTable datos;


        private DataTable info;



        public CONSULTARcompras(MySqlConnection conexion)
        {

            InitializeComponent();
            this.conexion = conexion;


            // posicionar a la iozquierda
            this.StartPosition = FormStartPosition.Manual; // Usar posición manual
            this.Location = new Point(13, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }



        private void CONSULTARcompras_Load(object sender, EventArgs e)
        {
            // Configura las propiedades del DataGridView
            dataGridCompras.RowHeadersVisible = false;
            dataGridCompras.AllowUserToResizeColumns = false;
            dataGridCompras.AllowUserToResizeRows = false;
            dataGridCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridCompras.AutoGenerateColumns = true;

        }








        private void dataGridCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





        private void textIdCliente_TextChanged(object sender, EventArgs e)
        {
            // Verifica si el contenido del TextBox no es numérico
            if (!EsNumero(textIdCliente.Text))
            {
                // Si el contenido no es numérico, muestra un mensaje de advertencia y limpia el TextBox
                MessageBox.Show("El ID del cliente debe ser un número.");
                textIdCliente.Text = string.Empty;
            }
        }


        // Método para verificar si una cadena contiene solo números
        private bool EsNumero(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!char.IsDigit(caracter))
                {
                    return false;
                }
            }
            return true;
        }




        
        /// ////////////////////
      





        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si se ha ingresado un ID de cliente
                if (string.IsNullOrWhiteSpace(textIdCliente.Text))
                {
                    MessageBox.Show("Por favor, introduce un ID de cliente.");
                    return; // Sale del método si no se ha ingresado un ID de cliente
                }

                // Intenta convertir el ID del cliente a un entero
                if (!int.TryParse(textIdCliente.Text, out int idCliente))
                {
                    MessageBox.Show("ID de cliente no válido.");
                    return; // Sale del método si el ID de cliente no es un número válido
                }

                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }


                string consulta = "SELECT v.id AS IdCompra, c.nombre AS NombreCliente, c.apellidos AS ApellidoCliente, c.telefono AS TelefonoCliente, v.pagado AS Pagado " +
                  "FROM ventas v " +
                  "JOIN clientes c ON v.idCliente = c.id " +
                  "WHERE v.idCliente = @IdCliente";



                // Crea un adaptador MySQL y un DataTable
                adaptador = new MySqlDataAdapter(consulta, conexion);
                adaptador.SelectCommand.Parameters.AddWithValue("@IdCliente", idCliente); // Agrega el parámetro del ID del cliente
                info = new DataTable();

                // Llena el DataTable con los resultados de la consulta
                adaptador.Fill(info);

                // Asigna el DataTable al DataSource del DataGridView
                dataGridCompras.DataSource = info;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión si está abierta al finalizar
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }






//
    }
}
