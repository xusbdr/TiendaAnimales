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
    public partial class CLIENTES : Form
    {



        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataAdapter adaptador;
        private DataTable datos;


        private DataTable info;




        public CLIENTES(MySqlConnection conexion)
        {

            InitializeComponent();
            this.conexion = conexion;
            this.StartPosition = FormStartPosition.CenterScreen; // posociobnar los form al medio 
        }



        //



        private void CLIENTES_Load(object sender, EventArgs e)
        {

           dataClientes.RowHeadersVisible = false;

           dataClientes.AllowUserToResizeColumns = false;
            dataClientes.AllowUserToResizeRows = false;
            // Configura las propiedades del DataGridView
            dataClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataClientes.AutoGenerateColumns = true;



            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }



                // Define la consulta SQL para "articulos"
                string consulta = "SELECT * FROM clientes";



                // Crea un adaptador MySQL y un DataTable
                adaptador = new MySqlDataAdapter(consulta, conexion);
                info = new DataTable();

                // Llena el DataTable con los resultados de la consulta
                adaptador.Fill(info);

                // Inicializa el DataTable datos
                datos = info.Copy();

                // Vincula el DataTable al DataGridView
                dataClientes.DataSource = datos;
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






        private void button3_Click(object sender, EventArgs e)
        {
            if (dataClientes.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas borrar este registro?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    object idObject = dataClientes.SelectedRows[0].Cells["ID"].Value;

                    if (idObject != null && int.TryParse(idObject.ToString(), out int id))
                    {
                        try
                        {
                            if (conexion.State == ConnectionState.Closed)
                            {
                                conexion.Open();
                            }

                            string consultaBorrar = "DELETE FROM clientes WHERE ID = @id";
                            comando = new MySqlCommand(consultaBorrar, conexion);
                            comando.Parameters.AddWithValue("@id", id);
                            comando.ExecuteNonQuery();

                            MessageBox.Show("Registro eliminado correctamente");

                            RefreshDataGridView();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al borrar el registro: " + ex.Message);
                        }
                        finally
                        {
                            if (conexion.State == ConnectionState.Open)
                            {
                                conexion.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor en la columna 'ID' no es un número válido.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de borrar");
            }
        }


        //






        private void buttonModificar_Click(object sender, EventArgs e)
        {

            if (dataClientes.SelectedRows.Count > 0)
            {
                string id = dataClientes.SelectedRows[0].Cells["id"].Value.ToString();
                string nombre = dataClientes.SelectedRows[0].Cells["nombre"].Value.ToString();
                string apellidos = dataClientes.SelectedRows[0].Cells["apellidos"].Value.ToString();
                string telefono = dataClientes.SelectedRows[0].Cells["telefono"].Value.ToString();

                string ciudad = dataClientes.SelectedRows[0].Cells["ciudadelas"].Value.ToString();
                string localidad = dataClientes.SelectedRows[0].Cells["localidad"].Value.ToString();

             //   string compra = dataClientes.SelectedRows[0].Cells["compras"].Value.ToString();
               

                ModificarClientes modificarForm = new ModificarClientes(conexion, id, nombre, apellidos,telefono,ciudad, localidad);
                modificarForm.CambiosRealizados += Añadir_CambiosRealizados;
                modificarForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de modificar");
            }
        }



        //




        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            AñadirClientes añadir = new AñadirClientes();
            añadir.CambiosRealizados += Añadir_CambiosRealizados;
            añadir.ShowDialog();
        }




        //






        private void dataClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ///
        }











        private void Añadir_CambiosRealizados(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            // Limpia los datos actuales en el DataTable
            datos.Clear();

            // Vuelve a llenar el DataTable con los resultados de la consulta
            adaptador.Fill(datos);

            // Vincula de nuevo el DataTable al DataGridView
            dataClientes.DataSource = datos;
        }








    }
}
