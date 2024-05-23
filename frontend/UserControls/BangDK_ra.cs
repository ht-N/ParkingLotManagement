using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ParkingLotManagement.UserControls
{
    public partial class BangDK_ra : UserControl
    {
        public BangDK_ra()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            maPhieu.KeyDown += maPhieu_KeyDown;
        }

        private void BangDK_ra_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void maPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                FetchData();
            }
        }

        private void maPhieu_TextChanged(object sender, EventArgs e)
        {
        }

        private void money_TextChanged(object sender, EventArgs e)
        {
        }

        private void FetchData()
        {
            string appDataPath = "..\\..\\AppData";
            string dbPath = Path.Combine(appDataPath, "BAIXE.db");
            string connectionString = $"Data Source={dbPath};Version=3;";
            string id = maPhieu.Text;

            if (string.IsNullOrEmpty(id))
            {
                ClearTextBoxes();
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT BIENSO, LOAIPHIEU, LOAIXE, THOIGIAN FROM PHIEU WHERE MAPHIEU = @maPhieu";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@maPhieu", maPhieu.Text);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DetachEventHandlers();
                                bienSo.Text = reader["BIENSO"].ToString();
                                loaiPhieu.Text = reader["LOAIPHIEU"].ToString();
                                loaiXe.Text = reader["LOAIXE"].ToString();
                                thoiGianVao.Text = reader["THOIGIAN"].ToString();
                                money.Text = get_Phiguixe();
                                AttachEventHandlers();
                            }
                            else
                            {
                                ClearTextBoxes();
                            }
                        }
                    }
                    string vehicle_pic_path = Path.Combine(appDataPath, "Vehicle_pictures", $"{id}.png");
                    if (File.Exists(vehicle_pic_path))
                    {
                        imageBox.Image = Image.FromFile(vehicle_pic_path);
                    }
                    else
                    {
                        imageBox.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private string get_Phiguixe()
        {
            string maphieu = maPhieu.Text; 
            string time = timeBox.Text;
            string date = dateBox.Text;
            string thoi_gian_ra = $"{time},{date}";

            string pythonCommand = "python";

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
            string modelPath= Path.Combine(projectDirectory, @"backend\money.py");
            Console.WriteLine("money path: " + modelPath);
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = pythonCommand,
                Arguments = $" {modelPath} \"{maphieu}\" \"{thoi_gian_ra}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (Process process = Process.Start(psi))
                {
                    using (System.IO.StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        process.WaitForExit();
                        Console.WriteLine("result:" + result);
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                return string.Empty;
            }
        }

        private void ClearTextBoxes()
        {
            DetachEventHandlers();

            bienSo.Clear();
            loaiPhieu.Clear();
            loaiXe.Clear();
            thoiGianVao.Clear();
            AttachEventHandlers();
        }

        private void DetachEventHandlers()
        {
            // Detach event handlers if necessary
        }

        private void AttachEventHandlers()
        {
            // Attach event handlers if necessary
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Handle button2 click event
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Handle label5 click event
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Handle button1 click event
        }

        // private void timer1_Tick(object sender, EventArgs e)
        // {
        //     timeBox.Text = DateTime.Now.ToString("T", CultureInfo.CurrentCulture);
        //     dateBox.Text = DateTime.Now.ToString("D", CultureInfo.CurrentCulture);
        // }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeBox.Text = DateTime.Now.ToString("HH:mm:ss.fff", CultureInfo.CurrentCulture);
            dateBox.Text = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture);
        }
    }
}