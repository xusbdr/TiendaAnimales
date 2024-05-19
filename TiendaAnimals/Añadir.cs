using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



using MySql.Data.MySqlClient; //




namespace TiendaAnimals
{



    public partial class Añadir : Form
    {



        private MySqlConnection conexion;
        private string seleccionActual;

        // Definir un evento que se activará cuando se realicen cambios
        public event EventHandler CambiosRealizados;




        public Añadir()
        {
            InitializeComponent();
            // Configura la conexión a tu base de datos MySQL para "seguros"
            string cadenaConexion = "server=127.0.0.1;user id=root;password=123456;database=tiendamascotas";
            conexion = new MySqlConnection(cadenaConexion);



            // posicionar a la derecha
            this.StartPosition = FormStartPosition.Manual;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int formWidth = this.Width;
            int positionX = screenWidth - formWidth;
            this.Location = new Point(positionX, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

        }






        // Método para activar el evento CambiosRealizados
        protected virtual void OnCambiosRealizados()
        {
            CambiosRealizados?.Invoke(this, EventArgs.Empty);
        }





        private void Añadir_Load(object sender, EventArgs e)
        {

            // Llamar a CargarFamilias para llenar el ComboBox al inicio
            CargarFamilias();

        }





        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana actual de modificarNOTA
            this.Close();
        }








        private void buttonguardar_Click(object sender, EventArgs e)
        {
            string stock = textBStock.Text;
            string nombre = textnombre.Text;
            string descripcion = textDescripcion.Text;
            string precio = textPrecio.Text;
            string familia = comboFamilia.Text;

            try
            {
                conexion.Open();

                if (string.IsNullOrWhiteSpace(stock) || !int.TryParse(stock, out int stockValue) || stockValue < 0)
                    return;


                if (comboFamilia.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una Familia.");
                    return;
                }


                if (string.IsNullOrWhiteSpace(precio) || !decimal.TryParse(precio.Replace(".", ","), out decimal precioValue) || precioValue < 0)
                    return;



                // Validar que el campo Nombre contenga solo letras
                if (!string.IsNullOrWhiteSpace(nombre) && !Regex.IsMatch(nombre, @"^[a-zA-Z]+$"))
                    return;

                if (!string.IsNullOrWhiteSpace(descripcion) && descripcion.Length > 35)
                    return;

                string consultaFamilia = "SELECT familia_id FROM Familias WHERE nombre = @nombre";
                MySqlCommand comandoFamilia = new MySqlCommand(consultaFamilia, conexion);
                comandoFamilia.Parameters.AddWithValue("@nombre", familia);
                int familiaId = Convert.ToInt32(comandoFamilia.ExecuteScalar());

                MySqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    string consultaProducto = "INSERT INTO Productos (nombre, descripcion, precio, stock, familia_id) VALUES (@nombre, @descripcion, @precio, @stock, @familia_id); SELECT LAST_INSERT_ID();";
                    MySqlCommand comandoProducto = new MySqlCommand(consultaProducto, conexion);
                    comandoProducto.Parameters.AddWithValue("@nombre", nombre);
                    comandoProducto.Parameters.AddWithValue("@descripcion", descripcion);
                    comandoProducto.Parameters.AddWithValue("@precio", precioValue);
                    comandoProducto.Parameters.AddWithValue("@stock", stockValue);
                    comandoProducto.Parameters.AddWithValue("@familia_id", familiaId);
                    int nuevoId = Convert.ToInt32(comandoProducto.ExecuteScalar());
                    transaccion.Commit();
                    OnCambiosRealizados();



                    // Cerrar el formulario después de guardar
                    this.Close();

                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción no esperada aquí
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }








        private void comboFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Almacena la selección actual
            seleccionActual = comboFamilia.SelectedItem?.ToString();
        }







        private void CargarFamilias()
        {
            try
            {
                // Abre la conexión
                conexion.Open();

                // Define la consulta SQL para obtener las familias
                string consultaFamilias = "SELECT nombre FROM Familias";

                // Crea un comando con la consulta
                MySqlCommand comandoFamilias = new MySqlCommand(consultaFamilias, conexion);

                // Ejecuta el comando para obtener las familias
                using (MySqlDataReader reader = comandoFamilias.ExecuteReader())
                {
                    // Limpiar el ComboBox de familias
                    comboFamilia.Items.Clear();

                    // Agregar los nombres de las familias al ComboBox
                    while (reader.Read())
                    {
                        comboFamilia.Items.Add(reader["nombre"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las familias: " + ex.Message);
            }
            finally
            {
                // Asegúrate de cerrar la conexión en el bloque finally
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }









        //


        private void textapellidos_TextChanged(object sender, EventArgs e)
        {

            // Verificar si el texto contiene solo letras, números y espacios, y tiene un máximo de 20 caracteres
            if (!string.IsNullOrWhiteSpace(textDescripcion.Text) &&
                textDescripcion.Text.Length <= 25 &&
                textDescripcion.Text.All(c => char.IsLetterOrDigit(c) || c == ' '))
            {
                errorDescripcion.Text = "";
            }
            else
            {
                errorDescripcion.Text = " (máximo 35 caracteres)";
                errorDescripcion.ForeColor = Color.Red;
            }
        }


        //
        //
       

        private void textPrecio_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto es un número decimal válido y mayor o igual a 0
            if (!string.IsNullOrWhiteSpace(textPrecio.Text) &&
                decimal.TryParse(textPrecio.Text.Replace(".", ","), out decimal precio) &&
                precio >= 0)
            {
                errorPrecio.Text = "";
            }
            else
            {
                errorPrecio.Text = "Tiene que ser un número mayor o igual a 0";
                errorPrecio.ForeColor = Color.Red;
            }
        }


        //


        
        private void textnombre_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto contiene solo letras y tiene un máximo de 16 caracteres
            if (!string.IsNullOrWhiteSpace(textnombre.Text) &&
                textnombre.Text.Length <= 16 &&
                textnombre.Text.All(char.IsLetter))
            {
                errorNombres.Text = "";
            }
            else
            {
                errorNombres.Text = " (máximo 16 letras)";
                errorNombres.ForeColor = Color.Red;
            }
        }



        private void textBStock_TextChanged(object sender, EventArgs e)
        {

            // Verificar si el texto contiene solo dígitos
            if (!string.IsNullOrWhiteSpace(textBStock.Text) && !textBStock.Text.All(char.IsDigit))
            {
                errorStock.Text = "El Stock debe contener solo números.";
                errorStock.ForeColor = Color.Red;
            }
            else
            {
                errorStock.Text = "";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ///////////////
        }
    }
}
