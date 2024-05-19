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




using MySql.Data.MySqlClient;





namespace TiendaAnimals
{
    public partial class Modificar : Form
    {




        private MySqlConnection conexion;

        private MySqlCommand comando;
        private string seleccionActual;



        // Definir un evento que se activará cuando se realicen cambios
        public event EventHandler CambiosRealizados;




        public Modificar(MySqlConnection conexion,string id,  string nombre, string descripcion, string precio, string stock, string familia)
        {
            InitializeComponent();
            this.conexion = conexion;
           


            // Llenar los campos del formulario con la información del producto
            textId.Text = id;
            textnombre.Text = nombre;
            textDescripcion.Text = descripcion;
            textPrecio.Text = precio;
            textBStock.Text = stock;
            comboFamilia.Text = familia;




            // posicionar formulario a la derecha
            this.StartPosition = FormStartPosition.Manual;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int formWidth = this.Width;
            int positionX = screenWidth - formWidth;
            this.Location = new Point(positionX, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);


        }


        private void Modificar_Load(object sender, EventArgs e)
        {
            // Llamar a CargarFamilias para llenar el ComboBox al inicio
            CargarFamilias();
        }


        // Método para activar el evento CambiosRealizados
        protected virtual void OnCambiosRealizados()
        {
            CambiosRealizados?.Invoke(this, EventArgs.Empty);
        }


      

        private void comboFamilia_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Almacena la selección actual
            seleccionActual = comboFamilia.SelectedItem?.ToString();
        }

        
        //

        private void label9_Click(object sender, EventArgs e)
        {

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



        //---------------------------------



        private void textDescripcion_TextChanged(object sender, EventArgs e)
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



        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
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



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /////////////////////////
        }


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


        //



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

        //

        private void buttonguardar_Click(object sender, EventArgs e)
        {
            string id = textId.Text;
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


                // Obtener el ID de la familia seleccionada
                string consultaFamilia = "SELECT familia_id FROM Familias WHERE nombre = @nombre";
                MySqlCommand comandoFamilia = new MySqlCommand(consultaFamilia, conexion);
                comandoFamilia.Parameters.AddWithValue("@nombre", familia);
                int familiaId = Convert.ToInt32(comandoFamilia.ExecuteScalar());

                // Consulta SQL para actualizar los datos del producto
                string consultaActualizarProducto = "UPDATE Productos SET nombre = @nombre, descripcion = @descripcion, precio = @precio, stock = @stock, familia_id = @familia_id WHERE id = @id";
                MySqlCommand comandoActualizarProducto = new MySqlCommand(consultaActualizarProducto, conexion);
                comandoActualizarProducto.Parameters.AddWithValue("@nombre", nombre);
                comandoActualizarProducto.Parameters.AddWithValue("@descripcion", descripcion);
                comandoActualizarProducto.Parameters.AddWithValue("@precio", precioValue);
                comandoActualizarProducto.Parameters.AddWithValue("@stock", stockValue);
                comandoActualizarProducto.Parameters.AddWithValue("@familia_id", familiaId);
                comandoActualizarProducto.Parameters.AddWithValue("@id", id);

                // Ejecutar la consulta de actualización
                comandoActualizarProducto.ExecuteNonQuery();

                // Mostrar mensaje de éxito
                MessageBox.Show("Producto actualizado correctamente.");

                // Activar el evento CambiosRealizados si es necesario
                OnCambiosRealizados();

                // Cerrar el formulario después de guardar
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el producto: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }





        // -----------------------------------------





        private void label7_Click(object sender, EventArgs e)
        {

        }


        //


        private void textId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void errorDescripcion_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void errorStock_Click_1(object sender, EventArgs e)
        {

        }

        private void errorPrecio_Click_1(object sender, EventArgs e)
        {

        }

        private void errorNombres_Click_1(object sender, EventArgs e)
        {

        }


        private void comboFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }



    }
}
