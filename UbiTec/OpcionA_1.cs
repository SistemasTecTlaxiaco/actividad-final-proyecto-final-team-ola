using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace UbiTec
{
    public partial class OpcionA_1 : Form
    {
        public OpcionA_1()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void OpcionA_1_Load(object sender, EventArgs e)
        {
            
        }
        private void BotonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
