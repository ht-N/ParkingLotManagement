using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

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
            // Get the base directory for the application
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Create the path for the AppData folder at the same level as the UserControls folder
            string dbFolderPath = Path.Combine(baseDirectory, "..\\..\\AppData");
            string db_path = Path.Combine(dbFolderPath, "BAIXE.db");

            if (!Directory.Exists(dbFolderPath))
            {
                Directory.CreateDirectory(dbFolderPath);
            }

            string absoluteDbPath = Path.GetFullPath(db_path);

            // Print the absolute path to a message box or console for debugging
            // MessageBox.Show($"Absolute path to the database: {absoluteDbPath}", "Database Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Console.WriteLine($"Absolute path to the database: {absoluteDbPath}");

            try
            {
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

                // Ensure the fields are not empty
                if (string.IsNullOrWhiteSpace(loaiPhieu.Text) ||
                    string.IsNullOrWhiteSpace(bienSo.Text) ||
                    string.IsNullOrWhiteSpace(loaiXe.Text) ||
                    string.IsNullOrWhiteSpace(Time.Text) ||
                    string.IsNullOrWhiteSpace(Date.Text))
                {
                    MessageBox.Show("Các trường dữ liệu có sai sót. Hãy kiểm tra lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo kết nối đến cơ sở dữ liệu SQLite
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={db_path};Version=3;Mode=ReadWrite;journal mode=Off;", true))
                {
                    // Mở kết nối
                    connection.Open();

                    string lp = loaiPhieu.Text;
                    string bs = bienSo.Text;
                    string lx = loaiXe.Text;
                    string time = Time.Text;
                    string date = Date.Text;

                    string insert_query = "INSERT INTO PHIEU (LOAIPHIEU, BIENSO, LOAIXE, THOIGIAN, NGAY) VALUES (@LoaiPhieu, @BienSo, @LoaiXe, @Time, @Date)";

                    using (SQLiteCommand command = new SQLiteCommand(insert_query, connection))
                    {
                        command.Parameters.AddWithValue("@LoaiPhieu", lp);
                        command.Parameters.AddWithValue("@BienSo", bs);
                        command.Parameters.AddWithValue("@LoaiXe", lx);
                        command.Parameters.AddWithValue("@Time", time);
                        command.Parameters.AddWithValue("@Date", date);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Xe đã vào bãi.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
