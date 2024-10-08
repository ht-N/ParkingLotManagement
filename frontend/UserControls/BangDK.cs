using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;

namespace ParkingLotManagement.UserControls
{
    public partial class BangDK : UserControl
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        List<int> panelList = new List<int>();
        
        public BangDK()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }



        private void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        

        private void BangDK_Load(object sender, EventArgs e)
        {
            timer1.Start();
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cboDevice.Items.Add(filterInfo.Name);
            }
            try
            {
                cboDevice.SelectedIndex = 0;
                captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                timer1.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No camera found");
                cboDevice.SelectedIndex = -1;
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                if (captureDevice != null && !captureDevice.IsRunning)
                {
                    captureDevice.Start();
                }
            }
            else
            {
                if (captureDevice != null && captureDevice.IsRunning)
                {
                    captureDevice.SignalToStop();
                }
            }
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            int xOffset = (videoBox.Width - frame.Width) / 2;

            Bitmap adjustedFrame = new Bitmap(videoBox.Width, videoBox.Height);

            using (Graphics g = Graphics.FromImage(adjustedFrame))
            {
                g.Clear(Color.Transparent);
                g.DrawImage(frame, xOffset, 0, frame.Width, frame.Height);
            }
            videoBox.Image = adjustedFrame;
        }

        private void BangDK_Closing(object sender, ControlEventArgs e)
        {
            if (captureDevice.IsRunning)
                captureDevice.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString("dd-MM-yyyy");
            Date.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        public static async Task<string> getPlate(string imagePath)
        {
            string pythonCommand = "python";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
            string scriptPath = Path.Combine(projectDirectory, @"backend\my_api.py");

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = pythonCommand,
                Arguments = $" {scriptPath} \"{imagePath}\"",
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
                        Console.WriteLine("plate:" + result);
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

        private async void Capture_Click(object sender, EventArgs e)
        {
            
            if (videoBox.Image != null)
            {
                Bitmap capturedImage = new Bitmap(videoBox.Image);

                string currentDirectory = Directory.GetCurrentDirectory();
                string projectRoot = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
                string appDataPath = Path.Combine(projectRoot, "frontend", "AppData", "Vehicle_pictures");

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string dbFolderPath = Path.Combine(baseDirectory, "..\\..\\AppData");
                string db_path = Path.Combine(dbFolderPath, "BAIXE.db");
                Console.WriteLine("AppDataPath: " + appDataPath);
                if (!Directory.Exists(appDataPath))
                {
                    Directory.CreateDirectory(appDataPath);
                }
                int imageIndex = 0;
                string imagePath = Path.Combine(appDataPath, $"xe_{imageIndex}.png");
                Console.WriteLine(getID().ToString());
                try
                {
                    capturedImage.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
                    Console.WriteLine("Image captured and saved successfully!");
                    
                    // string plate = await Program.ProcessImage(imagePath);
                    string plate = await getPlate(imagePath);
                    bienSo.Text = plate;
                    maPhieu.Text = getID().ToString();

                    string new_file_name = Path.Combine(appDataPath, $"{maPhieu.Text}.png");
                    Console.WriteLine("image path: " + new_file_name);
                    System.IO.File.Move(imagePath, new_file_name);
                    if(is_PhieuThang(bienSo.Text)!=0)
                    {
                        using (SQLiteConnection connection = new SQLiteConnection($"Data Source={db_path};Version=3;Mode=ReadWrite;journal mode=Off;", true))
                        {
                            connection.Open();
                            string query = "SELECT * FROM PHIEU WHERE MAPHIEU = @maPhieu";
                            using (SQLiteCommand command = new SQLiteCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@maPhieu", maPhieu.Text);
                                using (SQLiteDataReader reader = command.ExecuteReader())
                                {
                                    if(reader.Read())
                                    {
                                        bienSo.Text = reader["BIENSO"].ToString();
                                        Console.WriteLine(reader["LOAIPHIEU"] + " " + reader["LOAIXE"]);
                                        loaiPhieu.Text = reader["LOAIPHIEU"].ToString();
                                        loaiXe.Text = reader["LOAIXE"].ToString();
                                    }
                                }
                            }
                            string trongbai = "Có";
                            int chodau = getRandomPanel(loaiXe.Text, panelList);
                            query = "UPDATE PHIEU SET TRONGBAI = @trongBai, CHODAU = @choDau WHERE MAPHIEU = @maPhieu";
                            using (SQLiteCommand command = new SQLiteCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@maPhieu", maPhieu.Text);
                                command.Parameters.AddWithValue("@trongBai", trongbai);
                                command.Parameters.AddWithValue("@choDau", chodau);
                                command.ExecuteNonQuery();
                            }
                        } 
                    }
                    //Check Phieu Thang
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while saving the image: {ex.Message}");
                }
            }
            else
            {
               Console.WriteLine("No image to capture!");
            }
        }

        private void ClearTextBoxes()
        {
            maPhieu.Clear();
            bienSo.Clear();
            loaiPhieu.SelectedIndex = -1;
            loaiXe.SelectedIndex = -1;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string dbFolderPath = Path.Combine(baseDirectory, "..\\..\\AppData");
            Console.WriteLine($"dbfolderpath: {dbFolderPath}");
            string db_path = Path.Combine(dbFolderPath, "BAIXE.db");

            // if (!Directory.Exists(dbFolderPath))
            // {
            //     Directory.CreateDirectory(dbFolderPath);
            // }

            string absoluteDbPath = Path.GetFullPath(db_path);

            if (string.IsNullOrWhiteSpace(loaiPhieu.Text) ||
                string.IsNullOrWhiteSpace(bienSo.Text) ||
                string.IsNullOrWhiteSpace(loaiXe.Text))
            {
                this.Alert("Các trường dữ liệu đã có sai sót.", Form_Alert.enmType.Error);
                //MessageBox.Show("Các trường dữ liệu đã có sai sót.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(maPhieu.Text, out int maPhieuValue))
            {
                this.Alert("Mã phiếu phải là số.", Form_Alert.enmType.Error);
                //MessageBox.Show("Mã phiếu phải là số.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                int mp = int.Parse(maPhieu.Text);
                string lp = loaiPhieu.Text;
                string bs = bienSo.Text;
                string lx = loaiXe.Text;
                string time = Time.Text;
                string date = Date.Text;
                string thoigian = $"{time},{date}";
                string trongbai;
                int chodau;
                if(lp=="Tháng")
                    trongbai = "Có";
                else
                    trongbai = "None";

                //Create PHIEU table
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={db_path};Version=3;Mode=ReadWrite;journal mode=Off;", true))
                {
                    connection.Open();
                    string create_table = @"CREATE TABLE IF NOT EXISTS PHIEU (
                                            MAPHIEU INTEGER PRIMARY KEY, 
                                            LOAIPHIEU TEXT, 
                                            BIENSO TEXT, 
                                            LOAIXE TEXT,
                                            THOIGIAN TEXT,
                                            CHODAU INTEGER,
                                            TRONGBAI TEXT);";
                    using (SQLiteCommand command = new SQLiteCommand(create_table, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                //Select from CHOTRONG to get panel list
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={db_path};Version=3;Mode=ReadWrite;journal mode=Off;", true))
                {
                    connection.Open();
                    string query = "SELECT CHODAU FROM PHIEU;";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int tmp = int.Parse(reader["CHODAU"].ToString());
                                if(tmp == 0)
                                    continue;
                                else
                                    panelList.Add(tmp);
                            }
                        }
                    }
                }
                
                if(is_PhieuThang(bienSo.Text)==0)
                {
                    //Insert into PHIEU
                    using (SQLiteConnection connection = new SQLiteConnection($"Data Source={db_path};Version=3;Mode=ReadWrite;journal mode=Off;", true))
                    {
                        connection.Open();
                        chodau = getRandomPanel(lx, panelList);
                        string insert_query = "INSERT INTO PHIEU (MAPHIEU, LOAIPHIEU, BIENSO, LOAIXE, THOIGIAN, CHODAU, TRONGBAI) VALUES (@MaPhieu, @LoaiPhieu, @BienSo, @LoaiXe, @Thoigian, @ChoDau, @TrongBai)";
                        trongbai = "Có";
                        using (SQLiteCommand command = new SQLiteCommand(insert_query, connection))
                        {
                            command.Parameters.AddWithValue("@MaPhieu", mp);
                            command.Parameters.AddWithValue("@LoaiPhieu", lp);
                            command.Parameters.AddWithValue("@BienSo", bs);
                            command.Parameters.AddWithValue("@LoaiXe", lx);
                            command.Parameters.AddWithValue("@Thoigian", thoigian);
                            command.Parameters.AddWithValue("@ChoDau", chodau);
                            command.Parameters.AddWithValue("@TrongBai", trongbai);
                            command.ExecuteNonQuery();
                        }
                    }
                }

                ClearTextBoxes();
                this.Alert("Xe đã vào bãi.", Form_Alert.enmType.Success);
                // MessageBox.Show("Xe đã vào bãi.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private int is_PhieuThang(string bienSo)
        {
            // string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // string dbFolderPath = Path.Combine(baseDirectory, "..\\..\\AppData");
            // Console.WriteLine($"dbfolderpath: {dbFolderPath}");
            // string db_path = Path.Combine(dbFolderPath, "BAIXE.db");

            string currentDirectory = Directory.GetCurrentDirectory();
            string projectRoot = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            string db_path = Path.Combine(projectRoot, "frontend", "AppData", "BAIXE.db");
            string absoluteDbPath = Path.GetFullPath(db_path);
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={absoluteDbPath};Version=3;Mode=ReadWrite;journal mode=Off;", true))
            {
                connection.Open();
                string query = "SELECT * FROM PHIEU WHERE BIENSO = @BienSo";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BienSo", bienSo);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            Console.WriteLine(reader["MAPHIEU"].ToString());
                            return int.Parse(reader["MAPHIEU"].ToString());
                        }
                        
                    }   
                }
            }
            return 0;
        }

        // Getting unique ID (not these one in the DB)
        private static ConcurrentDictionary<int, byte> generatedIDs = new ConcurrentDictionary<int, byte>();
        private static ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random());

        private int getID()
        {
            if(is_PhieuThang(bienSo.Text) == 0)
            {
                int newID;
                do
                {
                    newID = random.Value.Next(100000, 1000000);
                } while (!generatedIDs.TryAdd(newID, 0));

                return newID;
            }
            int ID = is_PhieuThang(bienSo.Text);
            return ID;
        }

        static int getRandomPanel(string loaiXe, List<int> panelList)
        {
            int panel;
            if(loaiXe == "Xe máy")
            {
                do
                {
                    panel = random.Value.Next(1, 151);  
                }
                while(panelList.Contains(panel));
            }
            else
            {
                do 
                {
                    panel = random.Value.Next(151, 201);
                }
                while(panelList.Contains(panel));
            }
            return panel;
        }
    }
}
