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
    public partial class ModificarClientes : Form
    {


        private MySqlConnection conexion;

        private MySqlCommand comando;
        private string seleccionActual;
        private int rowsAffected;

        // Variable para almacenar la última localidad seleccionada
        private string ultimaLocalidadSeleccionada;


        // Definir un evento que se activará cuando se realicen cambios
        public event EventHandler CambiosRealizados;





        public ModificarClientes(MySqlConnection conexion, string id, string nombre, string apellidos, string telefono, string ciudad, string localidad)
        {
            InitializeComponent();
            this.conexion = conexion;



            // Llenar los campos del formulario con la información 
            textID.Text = id;
            textBNombre.Text = nombre;
            textBApellidos.Text = apellidos;
            textTelefono.Text = telefono;
            comboCiudad.Text = ciudad;
            comboProvinvia.Text = localidad;

            // Cargar ciudades y localidades
            CargarCiudades();




            // posicionar formulario a la derecha
            this.StartPosition = FormStartPosition.Manual;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int formWidth = this.Width;
            int positionX = screenWidth - formWidth;
            this.Location = new Point(positionX, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

        }


        //



        // Método para activar el evento CambiosRealizados
        protected virtual void OnCambiosRealizados()
        {
            CambiosRealizados?.Invoke(this, EventArgs.Empty);
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



        private void ModificarClientes_Load(object sender, EventArgs e)
        {
            // Seleccionar la ciudad y cargar las localidades correspondientes
            if (comboCiudad.Items.Count > 0)
            {
                comboCiudad.SelectedItem = comboCiudad.Text;
                CargarLocalidades(comboCiudad.Text);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana actual de modificarNOTA
            this.Close();
        }






        private void button1_Click(object sender, EventArgs e) // GUARDAR
        {
            string id = textID.Text;
            string nombre = textBNombre.Text;
            string apellidos = textBApellidos.Text;
            string telefono = textTelefono.Text;

            string ciudadelas = comboCiudad.Text;
            string localidad = comboProvinvia.Text;


            try
            {
                conexion.Open();





                // Verificar si la localidad ha sido seleccionada después de cambiar la ciudad
                if (string.IsNullOrWhiteSpace(localidad))
                {
                    errorProvincia.Text = "Debe seleccionar una localidad.";
                    errorProvincia.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    errorProvincia.Text = ""; // Limpiar el mensaje de error si se selecciona una localidad
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

                // Actualizar los datos del cliente en la base de datos
                string consulta = "UPDATE clientes SET nombre = @nombre, apellidos = @apellidos, telefono = @telefono,  ciudadelas = @ciudadelas, localidad = @localidad  WHERE id = @id";

                MySqlCommand comandoCliente = new MySqlCommand(consulta, conexion);
                comandoCliente.Parameters.AddWithValue("@nombre", nombre);
                comandoCliente.Parameters.AddWithValue("@apellidos", apellidos);
                comandoCliente.Parameters.AddWithValue("@telefono", telefono);
                comandoCliente.Parameters.AddWithValue("@ciudadelas", ciudadelas);
                comandoCliente.Parameters.AddWithValue("@localidad",localidad);

                comandoCliente.Parameters.AddWithValue("@id", id);

                // Ejecutar la consulta de actualización
                int rowsAffected = comandoCliente.ExecuteNonQuery();


                if (rowsAffected > 0)
                {
                    MessageBox.Show("Datos actualizados correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnCambiosRealizados();
                    this.Close(); // Cerrar el formulario después de guardar
                }
                else
                {
                    MessageBox.Show("No se encontró el cliente para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción no esperada aquí
                MessageBox.Show("Error al actualizar los datos: " + ex.Message);
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
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





      
        /// //////////////////
       




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





        private void errorApellidos_Click(object sender, EventArgs e)
        {

        }

        private void errorNombre_Click(object sender, EventArgs e)
        {

        }

        private void errorTelefono_Click(object sender, EventArgs e)
        {

        }

        private void errorProvincia_Click(object sender, EventArgs e)
        {

        }

        /// ///////










        ////
    }
}
