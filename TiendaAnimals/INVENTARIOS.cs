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
    public partial class INVENTARIOS : Form
    {


        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataAdapter adaptador;
        private DataTable datos;


        private DataTable info;





        public INVENTARIOS(MySqlConnection conexion)
        {

            InitializeComponent();
            this.conexion = conexion;
            this.StartPosition = FormStartPosition.CenterScreen; // posociobnar los form al medio 

        }



        //




        private void INVENTARIOS_Load(object sender, EventArgs e)
        {

            dataGridProductos.RowHeadersVisible = false;

            dataGridProductos.AllowUserToResizeColumns = false;
            dataGridProductos.AllowUserToResizeRows = false;
            // Configura las propiedades del DataGridView
            dataGridProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProductos.AutoGenerateColumns = true;



            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }



                // Ajustar la consulta para obtener el nombre de la familia en lugar del ID
                string consulta = @"
        SELECT 
            id AS 'ID',
            p.nombre AS 'Nombre',
            p.descripcion AS 'Descripcion',
            p.precio AS 'Precio',
            p.stock AS 'Stock',
            f.nombre AS 'Familia'
        FROM 
            Productos p
        JOIN 
            Familias f ON p.familia_id = f.familia_id";



                // Crea un adaptador MySQL y un DataTable
                adaptador = new MySqlDataAdapter(consulta, conexion);
                info = new DataTable();

                // Llena el DataTable con los resultados de la consulta
                adaptador.Fill(info);

                // Inicializa el DataTable datos
                datos = info.Copy();

                // Vincula el DataTable al DataGridView
               dataGridProductos.DataSource = datos;
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




        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            Añadir añadir = new Añadir();
            añadir.CambiosRealizados += Añadir_CambiosRealizados;
            añadir.ShowDialog();
        }




        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridProductos.SelectedRows.Count > 0)
            {
                string id = dataGridProductos.SelectedRows[0].Cells["id"].Value.ToString();
                string nombre = dataGridProductos.SelectedRows[0].Cells["nombre"].Value.ToString();
                string descripcion = dataGridProductos.SelectedRows[0].Cells["descripcion"].Value.ToString();
                string precio = dataGridProductos.SelectedRows[0].Cells["precio"].Value.ToString();
                string stock = dataGridProductos.SelectedRows[0].Cells["stock"].Value.ToString();
                string familia = dataGridProductos.SelectedRows[0].Cells["familia"].Value.ToString();

                Modificar modificarForm = new Modificar(conexion,id, nombre, descripcion, precio, stock,   familia);
                modificarForm.CambiosRealizados += Añadir_CambiosRealizados;
                modificarForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de modificar");
            }
        }




        private void buttonVer_Click(object sender, EventArgs e)
        {
            ///////////
        }



        //


        private void buttonBorrar_Click(object sender, EventArgs e)
        {

            if (dataGridProductos.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas borrar este registro?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    object idObject = dataGridProductos.SelectedRows[0].Cells["ID"].Value;

                    if (idObject != null && int.TryParse(idObject.ToString(), out int id))
                    {
                        try
                        {
                            if (conexion.State == ConnectionState.Closed)
                            {
                                conexion.Open();
                            }

                            string consultaBorrar = "DELETE FROM productos WHERE ID = @id";
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






        private void dINFORMACION_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /////////////////
        }




        private void dataGridALUMNOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ////////////////////
        }





        private void label1_Click(object sender, EventArgs e)
        {
            //////////////////
        }






        // ///////////////////



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
            dataGridProductos.DataSource = datos;
        }




        // //////////////////////////////////




        // Método invocado cuando se hace clic en una celda del DataGridView para mostrar más información
        private void dataGridVisualizar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        /// /////////



        private void textBuscador_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = textBuscador.Text.Trim();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                // Si el cuadro de búsqueda está vacío, restaura todos los datos originales
                datos.Clear();
                datos.Merge(info);
            }
            else
            {
                if (int.TryParse(textoBusqueda, out int id))
                {
                    // Si el texto es un número, busca por ID
                    BuscarPorID(id);
                }
                else
                {
                    // Si no es un número, busca por descripción
                    BuscarPorDescripcion(textoBusqueda);
                }
            }
        }




        //





        private void BuscarPorDescripcion(string descripcion)
        {

            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                string consulta = @"
            SELECT 
                id AS 'ID',
                p.nombre AS 'Nombre',
                p.descripcion AS 'Descripcion',
                p.precio AS 'Precio',
                p.stock AS 'Stock',
                f.nombre AS 'Familia'
            FROM 
                Productos p
            JOIN 
                Familias f ON p.familia_id = f.familia_id
            WHERE 
                p.nombre LIKE @nombre OR f.nombre LIKE @nombre"; // Buscar por nombre del producto o nombre de la familia

                comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@nombre", "%" + descripcion + "%");

                // Limpiar los datos existentes en el DataTable 'datos'
                datos.Clear();

                // Crear un nuevo DataTable para almacenar los resultados de la búsqueda
                DataTable tabla = new DataTable();

                // Llenar el nuevo DataTable con los resultados de la consulta
                adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(tabla);

                // Filtrar las filas que coinciden con el nombre del producto o nombre de la familia
                DataRow[] filasFiltradas = tabla.Select("Nombre LIKE '%" + descripcion + "%' OR Familia LIKE '%" + descripcion + "%'");

                // Copiar los datos filtrados al DataTable 'datos'
                foreach (DataRow row in filasFiltradas)
                {
                    datos.ImportRow(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }





        //






        private void BuscarPorID(int id)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                string consulta = @"
            SELECT 
                p.id AS 'ID',
                p.nombre AS 'Nombre',
                p.descripcion AS 'Descripcion',
                p.precio AS 'Precio',
                p.stock AS 'Stock',
                f.nombre AS 'Familia'
            FROM 
                productos p
            JOIN 
                familias f ON p.familia_id = f.familia_id
            WHERE 
                p.id = @id";

                comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id", id);

                DataTable tabla = new DataTable();
                adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(tabla);

                datos.Clear();
                datos.Merge(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar por ID: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }




    }
    }


