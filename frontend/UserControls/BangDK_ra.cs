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
using System.Xml.Linq;

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
            //FetchData();
        }

        //private void FetchData()
        //{

        //    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        //    string dbFolderPath = Path.Combine(baseDirectory, "..\\..\\AppData");
        //    Console.WriteLine($"dbfolderpath: {dbFolderPath}");
        //    string connectionString = Path.Combine(dbFolderPath, "BAIXE.db");
        //    string id = maPhieu.Text;


        //    // If maPhieu is empty
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        ClearTextBoxes();
        //        return;
        //    }

        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            string 
        //            string query = "SELECT BIENSO, LOAIPHIEU, LOAIXE, FROM YourTable WHERE ID = @ID";
        //            using (SQLiteCommand command = new SQLiteCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@ID", id);

        //                using (SQLiteDataReader reader = command.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        txtName.Text = reader["Name"].ToString();
        //                        txtAddress.Text = reader["Address"].ToString();
        //                    }
        //                    else
        //                    {
        //                        ClearTextBoxes();
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("An error occurred: " + ex.Message);
        //        }
        //    }
        //}

        //// Clear text boxes if changed
        //private void ClearTextBoxes()
        //{
        //    txtName.Clear();
        //    txtAddress.Clear();
        //}
    }
}
