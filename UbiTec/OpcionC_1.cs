using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UbiTec
{
    public partial class OpcionC_1 : Form
    {
        public OpcionC_1()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void OpcionC_1_Load(object sender, EventArgs e)
        {

        }


        private void BotonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
