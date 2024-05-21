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
            maPhieu.TextChanged += maPhieu_TextChanged;
        }

        private void BangDK_ra_Load(object sender, EventArgs e)
        {
        }

        private void maPhieu_TextChanged(object sender, EventArgs e)
        {
            FetchData();
        }

        private void FetchData()
        {
            string appDataPath = "..\\..\\AppData";
            string dbPath = Path.Combine(appDataPath, "BAIXE.db");
            string connectionString = $"Data Source={dbPath};Version=3;";
            string id = maPhieu.Text;

            // If maPhieu is empty
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
                    imageBox.Image = Image.FromFile(vehicle_pic_path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        // Clear text boxes if changed
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
            maPhieu.TextChanged -= maPhieu_TextChanged;
            // Add other textboxes if necessary
        }

        private void AttachEventHandlers()
        {
            maPhieu.TextChanged += maPhieu_TextChanged;
            // Add other textboxes if necessary
        }
    }
}