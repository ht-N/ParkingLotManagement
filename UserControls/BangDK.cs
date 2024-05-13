using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

using Python.Runtime;

namespace ParkingLotManagement.UserControls
{
    public partial class BangDK : UserControl
    {
        public BangDK()
        {
            
            InitializeComponent();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BangDK_Load(object sender, EventArgs e)
        {
            timer1.Start();
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cboDevice.Items.Add(filterInfo.Name);
            }
            cboDevice.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            int xOffset = (pictureBox.Width - frame.Width) / 2;

            Bitmap adjustedFrame = new Bitmap(pictureBox.Width, pictureBox.Height);

            using (Graphics g = Graphics.FromImage(adjustedFrame))
            {
                g.Clear(Color.Transparent);
                g.DrawImage(frame, xOffset, 0, frame.Width, frame.Height);
            }
            pictureBox.Image = adjustedFrame;
        }

        private void BangDK_Closing(object sender, ControlEventArgs e)
        {
            if (captureDevice.IsRunning)
                captureDevice.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            Date.Text = DateTime.Now.ToLongDateString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string db_path = @"BAIXE.db";
        
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={db_path};Version=3;Mode=ReadWrite;journal mode=Off;", true))
            {
                connection.Open();
                string create_table = @"CREATE TABLE IF NOT EXISTS PHIEU (
                                     MAPHIEU INTEGER PRIMARY KEY, 
                                     LOAIPHIEU TEXT, 
                                     BIENSO TEXT, 
                                     LOAIXE TEXT,
                                     THOIGIAN TEXT,
                                     NGAY TEXT)";
                using (SQLiteCommand command = new SQLiteCommand(create_table, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            
            
            
            // Tạo kết nối đến cơ sở dữ liệu SQLite
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={db_path};Version=3;Mode=ReadWrite;journal mode=Off;", true))
            {
                // Mở kết nối
                connection.Open();
                
                string mp = maPhieu.Text;
                string lp = loaiPhieu.Text;
                string bs = bienSo.Text;
                string lx = loaiXe.Text;
                string time = Time.Text;
                string date = Date.Text;

                string insert_query = "INSERT INTO PHIEU (MAPHIEU, LOAIPHIEU, BIENSO, LOAIXE, THOIGIAN, NGAY) VALUES (@MaPhieu, @LoaiPhieu, @BienSo, @LoaiXe, @Time, @Date)";

                using (SQLiteCommand command = new SQLiteCommand(insert_query, connection))
                {
                    command.Parameters.AddWithValue("@MaPhieu", mp);
                    command.Parameters.AddWithValue("@LoaiPhieu", lp);
                    command.Parameters.AddWithValue("@BienSo", bs);
                    command.Parameters.AddWithValue("@LoaiXe", lx);
                    command.Parameters.AddWithValue("@Time", time);
                    command.Parameters.AddWithValue("@Date", date);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
