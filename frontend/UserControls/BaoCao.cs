using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagement.UserControls
{
    public partial class BaoCao : UserControl
    {

        bool moved_button = false;
        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            while(!moved_button) {
                guna2Button1.Location = new Point(guna2Button1.Location.X - 400, guna2Button1.Location.Y);
                moved_button = true;
                pictureBox1.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
