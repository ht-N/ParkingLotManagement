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
using System.Threading;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace ParkingLotManagement.UserControls
{
    public partial class BangDK : UserControl
    {
        public BangDK()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        public async Task SomeMethod()
        {
            string imagePath = "path/to/your/image.png";
            string plate = await Program.ProcessImage(imagePath);
            Console.WriteLine(plate);
        }


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

            captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
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

        private void bienSo_TextChanged(object sender, EventArgs e)
        {

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
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={db_path};Version=3;Mode=ReadWrite;journal mode=Off;", true))
                {
                    connection.Open();
                    string create_table = @"CREATE TABLE IF NOT EXISTS PHIEU (
                                            MAPHIEU INTEGER PRIMARY KEY, 
                                            LOAIPHIEU TEXT, 
                                            BIENSO TEXT, 
                                            LOAIXE TEXT,
                                            THOIGIAN TEXT)";
                    using (SQLiteCommand command = new SQLiteCommand(create_table, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                if (string.IsNullOrWhiteSpace(maPhieu.Text) ||
                    string.IsNullOrWhiteSpace(loaiPhieu.Text) ||
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

                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={db_path};Version=3;Mode=ReadWrite;journal mode=Off;", true))
                {
                    connection.Open();
                    int mp = int.Parse(maPhieu.Text);
                    string lp = loaiPhieu.Text;
                    string bs = bienSo.Text;
                    string lx = loaiXe.Text;
                    string time = Time.Text;
                    string date = Date.Text;
                    string thoigian = $"{time},{date}";
                    string insert_query = "INSERT INTO PHIEU (MAPHIEU, LOAIPHIEU, BIENSO, LOAIXE, THOIGIAN) VALUES (@MaPhieu, @LoaiPhieu, @BienSo, @LoaiXe, @Thoigian)";

                    using (SQLiteCommand command = new SQLiteCommand(insert_query, connection))
                    {
                        command.Parameters.AddWithValue("@MaPhieu", mp);
                        command.Parameters.AddWithValue("@LoaiPhieu", lp);
                        command.Parameters.AddWithValue("@BienSo", bs);
                        command.Parameters.AddWithValue("@LoaiXe", lx);
                        command.Parameters.AddWithValue("@Thoigian", thoigian);
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
                string imagePath;
                do
                {
                    imagePath = Path.Combine(appDataPath, $"xe_{imageIndex}.png");
                    imageIndex++;
                } while (File.Exists(imagePath));

                try
                {
                    capturedImage.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Image captured and saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    string plate = await Program.ProcessImage(imagePath);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cboDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void loaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void videoBox_Click(object sender, EventArgs e)
        {

        }
    }

    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task<int> Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: Program <imagePath>");
                return 1;
            }

            string imagePath = args[0];
            string response = await ProcessImage(imagePath);
            Console.WriteLine(response);
            return 0;
        }

        public static async Task<string> ProcessImage(string imagePath)
        {
            string url = " http://127.0.0.1:5000/detect";

            using (var content = new MultipartFormDataContent())
            {
                byte[] imageData = File.ReadAllBytes(imagePath);
                var imageContent = new ByteArrayContent(imageData);
                content.Add(imageContent, "image", Path.GetFileName(imagePath));

                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }
    }
}