using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UbiTec
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string descripcionTarea = txtTarea.Text;
            if (string.IsNullOrWhiteSpace(descripcionTarea))
            {
                MessageBox.Show("Por favor, ingresa una descripción para la tarea.");
                return; 
            }
            DateTime inicio = calendar.SelectionStart;
            DateTime fin = calendar.SelectionEnd;

            string estadoTarea = checkBox1.Checked ? "Tarea terminada" : "Pendiente";

            try
            {
                int idTarea = await Task.Run(() => GuardarTareaEnBaseDeDatos(descripcionTarea, inicio, fin, estadoTarea));
                if (idTarea > 0)
                {
                    dataGridView1.Rows.Add(idTarea, descripcionTarea, inicio, fin, estadoTarea);
                    MessageBox.Show("Tarea guardada en la base de datos");
                    txtTarea.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la tarea en la base de datos: " + ex.Message);
            }
        }

        private int GuardarTareaEnBaseDeDatos(string descripcionTarea, DateTime inicio, DateTime fin, string estadoTarea)
        {
            int idTarea = -1;
            string sql = "INSERT INTO tareas (tarea_descripcion, fecha_inicio, fecha_fin, estado) VALUES (@descripcion, @inicio, @fin, @estado)";
            using (MySqlConnection conexionBD = Conexion.getConexion())
            {
                conexionBD.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexionBD))
                {
                    comando.Parameters.AddWithValue("@descripcion", descripcionTarea);
                    comando.Parameters.AddWithValue("@inicio", inicio);
                    comando.Parameters.AddWithValue("@fin", fin);
                    comando.Parameters.AddWithValue("@estado", estadoTarea);
                    comando.ExecuteNonQuery();

                    // Obtener el ID de la tarea recién insertada
                    string sqlId = "SELECT LAST_INSERT_ID()";
                    comando.CommandText = sqlId;
                    idTarea = Convert.ToInt32(comando.ExecuteScalar());
                }
            }
            return idTarea;
        }

            private void button2_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                // Obtener el id de la tarea seleccionada
                int idTarea = Convert.ToInt32(filaSeleccionada.Cells["id_tarea"].Value);

                // Eliminar la fila seleccionada del DataGridView
                dataGridView1.Rows.Remove(filaSeleccionada);

                // Eliminar la tarea seleccionada de la base de datos
                MySqlConnection conexionBD = Conexion.getConexion();
                conexionBD.Open();

                try
                {
                    string sql = "DELETE FROM tareas WHERE id_tarea = @id";
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                    comando.Parameters.AddWithValue("@id", idTarea);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Tarea eliminada de la base de datos y del DataGridView");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la tarea de la base de datos: " + ex.Message);
                }
                finally
                {
                    conexionBD.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una tarea para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

 

        private void Form2_Load(object sender, EventArgs e)
        {
            
            
            // Cargar datos desde la base de datos al DataGridView
            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();

            try
            {
                string sql = "SELECT id_tarea, tarea_descripcion, fecha_inicio, fecha_fin, estado FROM tareas";
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    // Agregar una nueva fila al DataGridView con los datos cargados
                    dataGridView1.Rows.Add(
                        reader["id_tarea"].ToString(),
                        reader["tarea_descripcion"].ToString(),
                        reader["fecha_inicio"],
                        reader["fecha_fin"],
                        reader["estado"]
                    );
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la base de datos: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }
    }
}
