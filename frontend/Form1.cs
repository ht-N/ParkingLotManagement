using ParkingLotManagement.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Runtime.InteropServices;



namespace ParkingLotManagement
{
    public partial class Form1 : Form
    {
        private FormWindowState previousWindowState;
        public Form1()
        {
            InitializeComponent();
            BangDK uc = new BangDK();
            AddUserControl(uc);
            previousWindowState = this.WindowState;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            
        }

        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ChoTrong uc = new ChoTrong();
            AddUserControl(uc);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BangDK uc = new BangDK();
            AddUserControl(uc);
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            BaoCao uc = new BaoCao();
            AddUserControl(uc);
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        
        

        private void nightControlBox1_Click(object sender, EventArgs e)
        {

        }

        // Doubleclick to make the app maximized
        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = previousWindowState;
            }
            else
            {
                previousWindowState = this.WindowState;
                this.WindowState = FormWindowState.Maximized;
            }
        }


        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            BangDK_ra uc = new BangDK_ra();
            AddUserControl(uc);
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
        Control control = (Control)sender;
                
        // Ensure the Form remains square (Height = Width).
        if(control.Size.Height != control.Size.Width)
        {
            control.Size = new Size(control.Size.Width, control.Size.Width);
        }
        }
    }
}