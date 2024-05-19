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
    public partial class VENTAS : Form
    {



        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataAdapter adaptador;
        private DataTable datos;
        private DataTable info;




        public event EventHandler CarritoActualizado;

        private DataTable articulosVarios;

        private List<ItemCarrito> datosCarrito;
      

        public double TotalCarrito { get; private set; }
        public int idCliente { get; private set; }

        public event EventHandler CambiosRealizados;








        public VENTAS(MySqlConnection conexion)
        {

            InitializeComponent();
            this.conexion = conexion;
            this.StartPosition = FormStartPosition.CenterScreen; // posociobnar los form al medio 

            
        }




        // ---------------

        //

        public class ItemCarrito
        {
            public int ID { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public string Descripcion { get; set; }
            public double precio { get; set; }
            public int Stock { get; set; }
            public int FamiliaId { get; set; }
            public int Cantidad { get; set; }

            //
           
            public double Precio { get; set; }
            public double Total { get; set; }
            public double Pagado { get; set; }
           
        }



        //  -----------





        // ----------------------

        // Método para activar el evento CambiosRealizados
        protected virtual void OnCambiosRealizados()
        {
            CambiosRealizados?.Invoke(this, EventArgs.Empty);
        }




        // --------


        // ----------


        private void RefreshDataG()
        {
            // Limpia los datos actuales en el DataTable
            datos.Clear();

            // Vuelve a llenar el DataTable con los resultados de la consulta
            adaptador.Fill(datos);

            // Vincula de nuevo el DataTable al DataGridView
            dataGridProductos.DataSource = datos;


            // Notificar cambios al exterior
            OnCarritoActualizado();
        }

        //

        protected virtual void OnCarritoActualizado()
        {
            CarritoActualizado?.Invoke(this, EventArgs.Empty);
        }



        //  -----------


        // Método que devuelve los datos del carrito
        public List<ItemCarrito> ObtenerDatosCarrito()
        {

            datosCarrito = new List<ItemCarrito>();

            if (dataCarrito != null && dataCarrito.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataCarrito.Rows)
                {
                    if (row != null && 
                        row.Cells["ID"].Value != null && 
                        row.Cells["Nombre"].Value != null &&
                      
                        row.Cells["Cantidad"].Value != null &&
                         row.Cells["Total"].Value != null &&
                        row.Cells["Precio"].Value != null)
                    {

                        ItemCarrito item = new ItemCarrito
                        {
                            ID = Convert.ToInt32(row.Cells["ID"].Value),
                            nombre = row.Cells["Nombre"].Value.ToString(),

                            Cantidad= Convert.ToInt32(row.Cells["Cantidad"].Value),
                            Precio = Convert.ToDouble(row.Cells["Precio"].Value),
                           Total = Convert.ToDouble(row.Cells["Total"].Value)

                        };

                        datosCarrito.Add(item);
                    }
                }
            }

            return datosCarrito;
        }



        // ------------




        private void ActualizarTotal()
        {
            double total = 0.0;

            // Verifica si dataGridComprados.DataSource es un DataTable
            if (dataCarrito.DataSource is DataTable)
            {
                // Obtén el DataTable de los artículos comprados
                DataTable dataTableComprados = (DataTable)dataCarrito.DataSource;

                // Verifica si hay alguna fila en el DataTable
                if (dataTableComprados.Rows.Count > 0)
                {
                    // Recorre las filas del DataTable
                    foreach (DataRow row in dataTableComprados.Rows)
                    {
                        // Asegúrate de ajustar las propiedades según tu modelo de datos
                        total += Convert.ToDouble(row["Total"]);
                    }
                }
            }
            // Actualiza tu interfaz o haz lo que necesites con el nuevo total
            // Por ejemplo, puedes mostrar el nuevo total en un TextBox u otro control
            textBoxSubtotal.Text = total.ToString("C");

            // Almacena el total en la propiedad TotalCarrito
            TotalCarrito = total;

            // Notifica cambios realizados
            OnCambiosRealizados();
        }


        //
        //----------------------




        private void VENTAS_Load(object sender, EventArgs e)
        {
            // Configura las propiedades del DataGridView
            dataGridProductos.RowHeadersVisible = false;
            dataGridProductos.AllowUserToResizeColumns = false;
            dataGridProductos.AllowUserToResizeRows = false;            
            dataGridProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProductos.AutoGenerateColumns = true;
            ///////////////////////////////////////////////////
            dataCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataCarrito.AutoGenerateColumns = true;
            dataCarrito.RowHeadersVisible = false;
            dataCarrito.AllowUserToResizeColumns = false;
            dataCarrito.AllowUserToResizeRows = false;



            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }



                // Define la consulta SQL para "articulos"
                string consulta = "SELECT * FROM productos";



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





        //




        private void dataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Verifica si el clic no se realizó en las columnas de nombre y descripción RESTRINGIR LAS COLUMNAS PAR QUE SE AGRGUEN MANUELAMNTE
            if (e.ColumnIndex != dataGridProductos.Columns["nombre"].Index && e.ColumnIndex != dataGridProductos.Columns["descripcion"].Index && e.ColumnIndex != dataGridProductos.Columns["id"].Index && e.ColumnIndex != dataGridProductos.Columns["precio"].Index
                 && e.ColumnIndex != dataGridProductos.Columns["stock"].Index && e.ColumnIndex != dataGridProductos.Columns["familia_id"].Index)
            {
                // Verifica si hay alguna fila seleccionada en el DataGridView de los artículos
                if (dataGridProductos.SelectedRows.Count > 0)
                {
                    // Obtén la fila seleccionada
                    DataGridViewRow selectedRow = dataGridProductos.SelectedRows[0];

                    // Obtén el índice de la fila seleccionada
                    int rowIndex = selectedRow.Index;

                    // Obtén el DataTable del origen de datos del DataGridView de los artículos
                    DataTable dataTableArticulos = (DataTable)dataGridProductos.DataSource;

                    // Verifica si el DataTable de los artículos comprados se ha inicializado
                    if (dataCarrito.DataSource == null)
                    {
                        // Inicializa el DataTable de los artículos comprados
                        DataTable dataTableComprados = new DataTable();

                        // Agrega las columnas necesarias (ajusta según tus necesidades)
                        dataTableComprados.Columns.Add("ID", typeof(int));
                        dataTableComprados.Columns.Add("nombre", typeof(string));
                        dataTableComprados.Columns.Add("descripcion", typeof(string));
                        dataTableComprados.Columns.Add("precio", typeof(int));
                        dataTableComprados.Columns.Add("stock", typeof(int));
                        dataTableComprados.Columns.Add("familia_id", typeof(int));

                        // Asigna el DataTable de los artículos comprados al DataSource del DataGridView
                        dataCarrito.DataSource = dataTableComprados;
                    }

                    // Crea una nueva fila para el DataTable de los artículos comprados
                    DataRow newRow = ((DataTable)dataCarrito.DataSource).NewRow();

                    // Copia manualmente los valores de la fila seleccionada a la nueva fila
                    for (int i = 0; i < dataTableArticulos.Columns.Count; i++)
                    {
                        string columnName = dataTableArticulos.Columns[i].ColumnName;
                        newRow[columnName] = dataTableArticulos.Rows[rowIndex][columnName];
                    }

                    // Agrega la nueva fila al DataTable de los artículos comprados
                    ((DataTable)dataCarrito.DataSource).Rows.Add(newRow);

                    MessageBox.Show("Artículo añadido al carrito de compras.");


                    OnCambiosRealizados();

                }
                else
                {
                    MessageBox.Show("Selecciona una fila antes de añadir al carrito de compras.");
                }
            }
        }







        private void dataCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ///////////////
        }




        //




        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            if (dataCarrito.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas borrar este artículo del carrito?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataCarrito.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dataCarrito.Rows.Remove(row);
                        }
                    }
                    ActualizarTotal();
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de borrar");
            }
        }









        //






        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            // Verifica si hay alguna fila seleccionada en el DataGridView de los artículos
            if (dataGridProductos.SelectedRows.Count > 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow selectedRow = dataGridProductos.SelectedRows[0];

                // Obtén el índice de la fila seleccionada
                int rowIndex = selectedRow.Index;

                // Obtén el DataTable del origen de datos del DataGridView de los artículos
                DataTable dataTableArticulos = (DataTable)dataGridProductos.DataSource;

                // Verifica si el DataTable de los artículos comprados se ha inicializado
                if (dataCarrito.DataSource == null || !(dataCarrito.DataSource is DataTable))
                {
                    // Inicializa el DataTable de los artículos comprados
                    DataTable dataTableComprados = new DataTable();

                    // Agrega las columnas necesarias (ajusta según tus necesidades)
                    dataTableComprados.Columns.Add("ID", typeof(int));
                    dataTableComprados.Columns.Add("Nombre", typeof(string));
                    dataTableComprados.Columns.Add("Cantidad", typeof(int));
                    dataTableComprados.Columns.Add("Precio", typeof(double));
                    dataTableComprados.Columns.Add("Total", typeof(double));

                    // Asigna el DataTable de los artículos comprados al DataSource del DataGridView
                    dataCarrito.DataSource = dataTableComprados;
                }

                // Verifica que el DataSource del dataGridComprados sea un DataTable
                if (dataCarrito.DataSource is DataTable)
                {
                    // Crea una nueva fila para el DataTable de los artículos comprados
                    DataRow newRow = ((DataTable)dataCarrito.DataSource).NewRow();

                    // Obtén el precio unitario del artículo seleccionado
                    double precioUnitario = Convert.ToDouble(dataTableArticulos.Rows[rowIndex]["Precio"]);

                    // Ajusta la cantidad según tus necesidades
                    int cantidad = 1;

                    // Calcula el total basado en el precio unitario y la cantidad
                    double total = precioUnitario * cantidad;

                    // Copia manualmente los valores de la fila seleccionada a la nueva fila
                    foreach (DataColumn column in dataTableArticulos.Columns)
                    {
                        // Verifica si la columna existe en el DataTable de los artículos comprados
                        if (((DataTable)dataCarrito.DataSource).Columns.Contains(column.ColumnName))
                        {
                            newRow[column.ColumnName] = dataTableArticulos.Rows[rowIndex][column.ColumnName];
                        }
                    }

                    // Asigna el precio unitario, la cantidad y el total a las columnas correspondientes
                    newRow["Precio"] = precioUnitario;
                    newRow["Cantidad"] = cantidad;
                    newRow["Total"] = total;

                    // Agrega la nueva fila al DataTable de los artículos comprados
                    ((DataTable)dataCarrito.DataSource).Rows.Add(newRow);

                    // Actualiza el total en el TextBox correspondiente
                    ActualizarTotal();
                }
                else
                {
                    MessageBox.Show("Error: El DataSource del dataGridComprados no es un DataTable válido.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de añadir al carrito de compras.");
            }
        }


        //




        private void buttonComprar_Click(object sender, EventArgs e)
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
                MessageBox.Show("ID de cliente No válido.");
                return; // Sale del método si el ID de cliente no es un número válido
            }

            // Verifica si el cliente existe
            if (!VerificarClienteExistente(idCliente))
            {
                MessageBox.Show("El cliente no existe, ingrese un ID válido");
                return; // Sale del método si el cliente no existe
            }



            // Verifica si hay elementos en el carrito
            if (dataCarrito.Rows.Count > 0)
            {
                // Pregunta si está seguro de realizar la compra
                DialogResult confirmResult = MessageBox.Show("¿Estás seguro de que deseas realizar la compra?", "Confirmar Compra", MessageBoxButtons.YesNo);
                if (confirmResult != DialogResult.Yes)
                {
                    return; // Sale del método si el usuario no confirma la compra
                }

                List<ItemCarrito> itemsComprados = ObtenerDatosCarrito(); // Obtén los datos del carrito
                decimal totalPagado = CalcularTotalPagado(itemsComprados); // Calcula el total pagado por todos los artículos
                int totalArticulos = CalcularTotalArticulos(itemsComprados); // Calcula el total de artículos comprados

                try
                {
                    // Abre la conexión a la base de datos si no está abierta
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }

                    // Inserta los detalles de la venta en la tabla de ventas como una única transacción
                    string insertVentaQuery = "INSERT INTO ventas (nombre, cantidad, pagado, idCliente) " +
                                              "VALUES (@Nombre, @Cantidad, @Pagado, @IdCliente);";
                    using (MySqlCommand comando = new MySqlCommand(insertVentaQuery, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", "Compra Exitosa");
                        comando.Parameters.AddWithValue("@Cantidad", totalArticulos); // Se registra el total de artículos comprados
                        comando.Parameters.AddWithValue("@Pagado", totalPagado); // Total pagado por todos los artículos
                        comando.Parameters.AddWithValue("@IdCliente", Convert.ToInt32(textIdCliente.Text));
                        comando.ExecuteNonQuery();
                    }

                    // Limpia el carrito después de la compra
                    ((DataTable)dataCarrito.DataSource).Clear();
                    ActualizarTotal();

                    MessageBox.Show("Compra realizada con éxito.");

                    // Actualiza el stock de los productos
                    ActualizarStock(itemsComprados, conexion);


                    RefreshDataG();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar la compra: " + ex.Message);
                }
                finally
                {
                    // Cierra la conexión a la base de datos
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay elementos en el carrito para comprar.");
            }
        }



        //


        // Método para calcular el total pagado por todos los artículos en el carrito
        private decimal CalcularTotalPagado(List<ItemCarrito> items)
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += Convert.ToDecimal(item.Total); // Suma el precio total de cada artículo al total general
            }
            return total;
        }



        //


        // Método para calcular el total de artículos comprados
        private int CalcularTotalArticulos(List<ItemCarrito> items)
        {
            int total = 0;
            foreach (var item in items)
            {
                total += item.Cantidad; // Suma la cantidad de cada artículo al total de artículos
            }
            return total;
        }





        // ----------



        private void ActualizarStock(List<ItemCarrito> itemsComprados, MySqlConnection conexion)
        {
            try
            {
                // Verifica si la conexión está abierta
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                // Itera sobre los elementos comprados
                foreach (var item in itemsComprados)
                {
                    // Crea un comando SQL para actualizar el stock del producto
                    string updateStockQuery = "UPDATE productos SET stock = stock - @CantidadComprada WHERE id = @IDProducto;";
                    using (MySqlCommand comando = new MySqlCommand(updateStockQuery, conexion))
                    {
                        comando.Parameters.AddWithValue("@CantidadComprada", item.Cantidad);
                        comando.Parameters.AddWithValue("@IDProducto", item.ID);
                        comando.ExecuteNonQuery();
                    }
                }

                // Notifica que el stock ha sido actualizado
                MessageBox.Show("Stock actualizado después de la compra.");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el stock: " + ex.Message);
            }
        }




        //

        private bool VerificarClienteExistente(int idCliente)
        {
            try
            {
                if (idCliente <= 0)
                {
                    MessageBox.Show("ID de cliente no existe" + idCliente);
                    return false;
                }

                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }

                conexion.Open();

                // Define la consulta SQL con un WHERE para filtrar por el ID del cliente
                string consulta = "SELECT 1 FROM clientes WHERE id = @Id";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", idCliente);

                    

                    // Ejecuta la consulta y comprueba si hay al menos una fila
                    object result = comando.ExecuteScalar();

                    return result != null;
                }
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show("Error de MySQL al verificar el cliente: " + sqlEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general al verificar el cliente: " + ex.Message);
                return false;
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



        private void textIdCliente_TextChanged(object sender, EventArgs e)
        {

        }



      
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
        



        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            CONSULTARcompras consulta = new CONSULTARcompras(conexion);
            consulta.ShowDialog();
        }




       



    }
}
