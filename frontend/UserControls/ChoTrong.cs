using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
namespace ParkingLotManagement.UserControls
{
    public partial class ChoTrong : UserControl
    {
        List<int> panelList = new List<int>();
        public ChoTrong()
        {
            InitializeComponent();
            UpdatePanels();
        }

        private void UpdatePanels()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dbFolderPath = Path.Combine(baseDirectory, "..\\..\\AppData");
            Console.WriteLine($"dbfolderpath: {dbFolderPath}");
            string db_path = Path.Combine(dbFolderPath, "BAIXE.db");
            string absoluteDbPath = Path.GetFullPath(db_path);

            //Select from CHOTRONG to get panel list
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={db_path};Version=3;Mode=ReadWrite;journal mode=Off;", true))
            {
                connection.Open();
                string query = "SELECT * FROM CHOTRONG;";
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
            foreach (var num in panelList)
            {
                string panelName = "panel" + num;
                Control[] foundControls = Controls.Find(panelName, true);

                if (foundControls.Length > 0)
                {
                    Panel panel = foundControls[0] as Panel;
                    if (panel != null)
                    {
                        panel.BackColor = Color.Green;
                    }
                }
            }
        }
    }
}