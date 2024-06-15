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
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
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
                getID_info();
            }
        }
        
        private void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void updateDoanhThu()
        {

        }

        private void getID_info()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectRoot = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            string appDataPath = Path.Combine(projectRoot, "frontend", "AppData");
            string db_path = Path.Combine(appDataPath, "BAIXE.db");
            string absoluteDbPath = Path.GetFullPath(db_path);
            Console.WriteLine("dbpath: " + absoluteDbPath);
            string connectionString = $"Data Source={absoluteDbPath};Version=3;";
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
                        
                                bienSo.Text = reader["BIENSO"].ToString();
                                loaiPhieu.Text = reader["LOAIPHIEU"].ToString();
                                loaiXe.Text = reader["LOAIXE"].ToString();
                                thoiGianVao.Text = reader["THOIGIAN"].ToString();
                                string format = "dd-MM-yyyy,HH:mm:ss";
                                DateTime tmp = DateTime.ParseExact(thoiGianVao.Text, format, CultureInfo.InvariantCulture);
                                if(loaiPhieu.Text == "Tháng")
                                {
                                    if(IsMoreThanOneMonthApart(tmp, DateTime.Now))
                                        money.Text = get_Phiguixe();
                                    else
                                        money.Text = "0VND";
                                }   
                                else
                                {
                                    money.Text = get_Phiguixe();
                                }
                            }
                            else
                            {
                                this.Alert("Mã phiếu không tồn tại trong hệ thống", Form_Alert.enmType.Warning);
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
                    Console.WriteLine("An error occured: " + ex.Message);
                }
            }
        }

        private bool IsMoreThanOneMonthApart(DateTime datetime1, DateTime datetime2)
        {
            int monthsDifference = ((datetime2.Year - datetime1.Year) * 12) + datetime2.Month - datetime1.Month;

            // Adjust for the day of the month
            if (datetime2.Day < datetime1.Day)
                monthsDifference--;
            return monthsDifference > 1;
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
            string scriptPath= Path.Combine(projectDirectory, @"backend\money.py");
            Console.WriteLine("money path: " + scriptPath);
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = pythonCommand,
                Arguments = $" {scriptPath} \"{maphieu}\" \"{thoi_gian_ra}\"",
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
            bienSo.Clear();
            loaiPhieu.Clear();
            loaiXe.Clear();
            thoiGianVao.Clear();
            money.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeBox.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dateBox.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void xuatButton_Click(object sender, EventArgs e)
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

            if (imageBox.Image != null)
            {
                imageBox.Image.Dispose();
                imageBox.Image = null;
            }
            
            if(money.Text != "0VND")
            {
                // Delete from PHIEU table
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM PHIEU WHERE MAPHIEU = @maPhieu;";
                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@maPhieu", id);
                            command.ExecuteNonQuery();
                        }

                        string vehicle_pic_path = Path.Combine(appDataPath, "Vehicle_pictures", $"{id}.png");
                        if (System.IO.File.Exists(vehicle_pic_path))
                        {
                            System.IO.File.Delete(vehicle_pic_path);
                        }
                        this.Alert("Xe ra khỏi bãi.", Form_Alert.enmType.Success);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occured: " + ex.Message);
                    }
                }
            }
            else
            {
                // Update PHIEU table
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string trongbai = "Không";
                        int chodau = 0;
                        string query = "UPDATE PHIEU SET TRONGBAI = @trongBai, CHODAU = @choDau WHERE MAPHIEU = @maPhieu";
                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@maPhieu", id);
                            command.Parameters.AddWithValue("@trongBai", trongbai);
                            command.Parameters.AddWithValue("@choDau", chodau);
                            command.ExecuteNonQuery();
                        }

                        string vehicle_pic_path = Path.Combine(appDataPath, "Vehicle_pictures", $"{id}.png");
                        if (System.IO.File.Exists(vehicle_pic_path))
                        {
                            System.IO.File.Delete(vehicle_pic_path);
                        }
                        this.Alert("Xe ra khỏi bãi.", Form_Alert.enmType.Success);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occured: " + ex.Message);
                    }
                }
            }
            ClearTextBoxes();
            maPhieu.Clear();
        }
    }
}
