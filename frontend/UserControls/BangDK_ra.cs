using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace ParkingLotManagement.UserControls
{
    public partial class BangDK_ra : UserControl
    {
        public BangDK_ra()
        {
            InitializeComponent();
            maPhieu.KeyDown += maPhieu_KeyDown;
        }

        private void BangDK_ra_Load(object sender, EventArgs e)
        {
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
                                time.Text = reader["THOIGIAN"].ToString();
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

        private void ClearTextBoxes()
        {
            DetachEventHandlers();

            bienSo.Clear();
            loaiPhieu.Clear();
            loaiXe.Clear();
            time.Clear();

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
    }
}