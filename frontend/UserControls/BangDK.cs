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
        
        public BangDK()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
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

            captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
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
            string modelPath = Path.Combine(projectDirectory, @"backend\my_api.py");

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = pythonCommand,
                Arguments = $" {modelPath} \"{imagePath}\"",
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
                Console.WriteLine("AppDataPath: " + appDataPath);
                if (!Directory.Exists(appDataPath))
                {
                    Directory.CreateDirectory(appDataPath);
                }
                int imageIndex = 0;
                string imagePath = Path.Combine(appDataPath, $"xe_{imageIndex}.png");

                try
                {
                    capturedImage.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Image captured and saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // string plate = await Program.ProcessImage(imagePath);
                    string plate = await getPlate(imagePath);
                    bienSo.Text = plate;
                    maPhieu.Text = getID().ToString();

                    string new_file_name = Path.Combine(appDataPath, $"{maPhieu.Text}.png");
                    Console.WriteLine("image path: " + new_file_name);
                    System.IO.File.Move(imagePath, new_file_name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No image to capture!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (!Directory.Exists(dbFolderPath))
            {
                Directory.CreateDirectory(dbFolderPath);
            }

            string absoluteDbPath = Path.GetFullPath(db_path);
            
            try
            {
                int mp = int.Parse(maPhieu.Text);
                string lp = loaiPhieu.Text;
                string bs = bienSo.Text;
                string lx = loaiXe.Text;
                string time = Time.Text;
                string date = Date.Text;
                string thoigian = $"{time},{date}";
                List<int> panelList = new List<int>();

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
                                            CHODAU INTEGER);";
                    using (SQLiteCommand command = new SQLiteCommand(create_table, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                if (string.IsNullOrWhiteSpace(loaiPhieu.Text) ||
                    string.IsNullOrWhiteSpace(bienSo.Text) ||
                    string.IsNullOrWhiteSpace(loaiXe.Text) ||
                    string.IsNullOrWhiteSpace(Time.Text) ||
                    string.IsNullOrWhiteSpace(Date.Text))
                {
                    MessageBox.Show("Các trường dữ liệu đã có sai sót.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
 
                if (!int.TryParse(maPhieu.Text, out int maPhieuValue))
                {
                    MessageBox.Show("Mã phiếu phải là số.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
                                panelList.Add(int.Parse(reader["CHODAU"].ToString()));
                            }
                        }
                    }
                }
                
                //Insert into PHIEU
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={db_path};Version=3;Mode=ReadWrite;journal mode=Off;", true))
                {
                    connection.Open();
                    int chodau = getRandomPanel(lx, panelList);
                    string insert_query = "INSERT INTO PHIEU (MAPHIEU, LOAIPHIEU, BIENSO, LOAIXE, THOIGIAN, CHODAU) VALUES (@MaPhieu, @LoaiPhieu, @BienSo, @LoaiXe, @Thoigian, @ChoDau)";
                    using (SQLiteCommand command = new SQLiteCommand(insert_query, connection))
                    {
                        command.Parameters.AddWithValue("@MaPhieu", mp);
                        command.Parameters.AddWithValue("@LoaiPhieu", lp);
                        command.Parameters.AddWithValue("@BienSo", bs);
                        command.Parameters.AddWithValue("@LoaiXe", lx);
                        command.Parameters.AddWithValue("@Thoigian", thoigian);
                        command.Parameters.AddWithValue("@ChoDau", chodau);
                        command.ExecuteNonQuery();
                    }
                }
                ClearTextBoxes();
                MessageBox.Show("Xe đã vào bãi.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Getting unique ID (not these one in the DB)
        private static ConcurrentDictionary<int, byte> generatedIDs = new ConcurrentDictionary<int, byte>();
        private static ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random());
        static int getID()
        {
            int newID;
            do
            {
                newID = random.Value.Next(100000, 1000000);
            } while (!generatedIDs.TryAdd(newID, 0));

            return newID;
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
