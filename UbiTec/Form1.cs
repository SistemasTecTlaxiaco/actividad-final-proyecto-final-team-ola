using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UbiTec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            btonMaximizar.Visible = false;
            btonRestaurar.Visible = true;
            diseñoInvisible();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }
        private void diseñoInvisible()
        {
            //panel1.Visible = false;
            subMenuUbicaciones.Visible = false;
            SubMenuTurnos.Visible = false;  
        }

        private void hideSubMenu()
        {
            if (subMenuUbicaciones.Visible == true)
            {
                subMenuUbicaciones.Visible = false;
            }
            if (SubMenuTurnos.Visible == true)
            {
                SubMenuTurnos.Visible = false;
            }
        }

        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else { subMenu.Visible = false; }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void BotonCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btonMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btonMaximizar.Visible = false;
            btonRestaurar.Visible = true;
        }

        private void btonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btonRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btonRestaurar.Visible = false;
            btonMaximizar.Visible = true;
        }

        private Form activeForm = null;
        private void AbrirFormHijo(Form formHijo)
        {
            if (activeForm!=null)
                activeForm.Close(); 
            activeForm = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;    
            formHijo.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(formHijo);
            this.panelContenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void btonUbicaciones_Click(object sender, EventArgs e)
        {

            showSubmenu(subMenuUbicaciones);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionA_1());
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionB_1());
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionC_1()); 
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionD_1()); 
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionE_1()); 
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionF_1()); 
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionG1());  
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionH1());
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionI_1());
            hideSubMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionJ_1());
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionK_1()); 
            hideSubMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionL_1());
            hideSubMenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionM_1()); 
            hideSubMenu();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionN_1()); 
            hideSubMenu();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionO_1()); 
            hideSubMenu();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionP_1());
            hideSubMenu();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionQ_1()); 
            hideSubMenu();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionR_1()); 
            hideSubMenu();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new OpcionS_1()); 
            hideSubMenu();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            showSubmenu(SubMenuTurnos);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Sacar_Turno());
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void button23_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Sacar_Turno());
        }

        private void button24_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Sacar_Turno());
        }

        private void button25_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Form2());
        }
    }
}
