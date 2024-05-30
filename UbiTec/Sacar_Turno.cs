using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaCola;
using MySql.Data.MySqlClient;
using QRCoder;


namespace UbiTec
{
    public partial class Sacar_Turno : Form
    {

        public Sacar_Turno()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nombre = txtNombre.Text;
            String num_control = No_Control.Text;
            String carrera = combo_Carrera.Text;

            // Verificar que todos los cuadros de texto estén llenos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(num_control) || string.IsNullOrWhiteSpace(carrera))
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar que el número de control solo contenga números
            if (!int.TryParse(num_control, out _))
            {
                MessageBox.Show("El número de control solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar que el número de control no se repita
            if (Cola.ExisteNumeroDeControl(num_control))
            {
                MessageBox.Show("El número de control ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generar el código QR con los datos válidos
            String contenido = num_control + " " + nombre + " " + carrera;
            QRCodeGenerator qrGenerador = new QRCodeGenerator();
            QRCodeData qrDatos = qrGenerador.CreateQrCode(contenido, QRCodeGenerator.ECCLevel.H);
            QRCode qrCodigo = new QRCode(qrDatos);
            Bitmap qrImagen = qrCodigo.GetGraphic(8, Color.Black, Color.White, true);

            // Mostrar el código QR en el PictureBox
            pictureBox.Image = qrImagen;

            // Encolar el nombre y el número de control y mostrar mensaje
            string mensaje = Cola.Encolar(nombre, num_control);
            MessageBox.Show(mensaje);
        }



        private void BotonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

           }
}
