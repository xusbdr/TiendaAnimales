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
    public partial class AñadirClientes : Form
    {



        private MySqlConnection conexion;
        private string seleccionActual;

        // Definir un evento que se activará cuando se realicen cambios
        public event EventHandler CambiosRealizados;

        // Variable para almacenar la última localidad seleccionada
        private string ultimaLocalidadSeleccionada;




        public AñadirClientes()
        {
            InitializeComponent();
            // Configura la conexión a tu base de datos MySQL para "seguros"
            string cadenaConexion = "server=127.0.0.1;user id=root;password=123456;database=tiendamascotas";
            conexion = new MySqlConnection(cadenaConexion);



            // posicionar formulario a la derecha
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




        private void AñadirClientes_Load(object sender, EventArgs e)
        {
            // Cargar ciudades y localidades
            CargarCiudades();
        }







        private void button2_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana actual de modificarNOTA
            this.Close();
        }




        private void button1_Click(object sender, EventArgs e)   // GUARDAR
        {

            string nombre = textBNombre.Text;
            string apellidos = textBApellidos.Text;
            string telefono = textTelefono.Text;
            string ciudadelas = comboCiudad.Text;
            string localidad = comboProvinvia.Text;

            try
            {
                conexion.Open();


                // Verificar si los campos obligatorios están llenos
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellidos) || string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(ciudadelas) || string.IsNullOrWhiteSpace(localidad))
                {
                    MessageBox.Show("Complete todos los campos,son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (string.IsNullOrWhiteSpace(telefono) || !int.TryParse(telefono, out int telefonoValue) || telefonoValue < 0)
                {
                    return;
                }

                // Validar que el campo Nombre y Apellidos contenga solo letras
                if (!string.IsNullOrWhiteSpace(nombre) && !Regex.IsMatch(nombre, @"^[a-zA-Z]+$"))
                {
                    return;
                }

                if (!string.IsNullOrWhiteSpace(apellidos) && !Regex.IsMatch(apellidos, @"^[a-zA-Z]+$"))
                {
                    return;
                }

                // Construir la consulta SQL para insertar un nuevo cliente
                string consulta = "INSERT INTO clientes (nombre, apellidos, telefono, ciudadelas, localidad) VALUES (@nombre, @apellidos, @telefono, @ciudadelas, @localidad)";

                MySqlCommand comandoCliente = new MySqlCommand(consulta, conexion);
                comandoCliente.Parameters.AddWithValue("@nombre", nombre);
                comandoCliente.Parameters.AddWithValue("@apellidos", apellidos);
                comandoCliente.Parameters.AddWithValue("@telefono", telefono);
                comandoCliente.Parameters.AddWithValue("@ciudadelas", ciudadelas);
                comandoCliente.Parameters.AddWithValue("@localidad", localidad);

                // Ejecutar la consulta de inserción
                int rowsAffected = comandoCliente.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Datos guardados correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnCambiosRealizados();
                    this.Close(); // Cerrar el formulario después de guardar
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción no esperada aquí
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }







        //


        private void CargarLocalidades(string ciudadelas)
        {
            try
            {
                conexion.Open();
                string consulta = "SELECT localidad, localidad1, localidad2 FROM ciudad WHERE ciudadelas = @ciudadelas"; // Ajusta esta consulta según tu base de datos
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@ciudadelas", ciudadelas);
                MySqlDataReader reader = comando.ExecuteReader();

                comboProvinvia.Items.Clear(); // Limpiar las localidades actuales
                if (reader.Read())
                {
                    comboProvinvia.Items.Add(reader.GetString("localidad"));
                    comboProvinvia.Items.Add(reader.GetString("localidad1"));
                    comboProvinvia.Items.Add(reader.GetString("localidad2"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las localidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }




        private void CargarCiudades()
        {
            try
            {
                conexion.Open();
                string consulta = "SELECT ciudadelas FROM ciudad"; // Asegúrate de que esta consulta sea correcta para tu base de datos
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    comboCiudad.Items.Add(reader.GetString("ciudadelas"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ciudades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }


       
        /// ///////////
       


        private void textBApellidos_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto contiene solo letras y tiene un máximo de 16 caracteres
            if (!string.IsNullOrWhiteSpace(textBApellidos.Text) &&
                textBApellidos.Text.Length <= 16 &&
                textBApellidos.Text.All(char.IsLetter))
            {
                errorApellidos.Text = "";
            }
            else
            {
                errorApellidos.Text = " (Solo letras, máximo 16 letras)";
                errorApellidos.ForeColor = Color.Red;
            }
        }



        private void textBNombre_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto contiene solo letras y tiene un máximo de 16 caracteres
            if (!string.IsNullOrWhiteSpace(textBNombre.Text) &&
                textBNombre.Text.Length <= 16 &&
                textBNombre.Text.All(char.IsLetter))
            {
                errorNombre.Text = "";
            }
            else
            {
                errorNombre.Text = " (Solo letras, máximo 16 letras)";
                errorNombre.ForeColor = Color.Red;
            }
        }




        private void textTelefono_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto contiene solo dígitos y tiene exactamente 9 caracteres
            if (!string.IsNullOrWhiteSpace(textTelefono.Text) && (textTelefono.Text.Length != 9 || !textTelefono.Text.All(char.IsDigit)))
            {
                errorTelefono.Text = "El teléfono debe tener 9 números.";
                errorTelefono.ForeColor = Color.Red;
            }
            else
            {
                errorTelefono.Text = "";
            }
        }

        private void comboProvinvia_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Actualizar la última localidad seleccionada cuando se cambie la selección
            if (comboProvinvia.SelectedItem != null)
            {
                ultimaLocalidadSeleccionada = comboProvinvia.SelectedItem.ToString();
            }
        }




        private void comboCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCiudad.SelectedItem != null)
            {
                string ciudadSeleccionada = comboCiudad.SelectedItem.ToString();
                CargarLocalidades(ciudadSeleccionada);

                // Seleccionar la primera localidad después de cargar las localidades
                if (comboProvinvia.Items.Count > 0)
                {
                    comboProvinvia.SelectedIndex = 0;
                }
            }
        }
    }
}
