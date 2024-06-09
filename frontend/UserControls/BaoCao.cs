﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SQLite;

namespace ParkingLotManagement.UserControls
{
    public partial class BaoCao : UserControl
    {
        public BaoCao()
        {
            InitializeComponent();
            getCarSlot();
            List<int> vehicle_rate = getVehicleRate();
            for (int i = 0; i < vehicle_rate.Count; i++) 
            {
                Console.WriteLine(vehicle_rate[i]);
            }

            // int carRate = vehicle_rate[0]/(vehicle_rate[0] + vehicle_rate[1] + vehicle_rate[2]);
            // int motorRate = vehicle_rate[1]/(vehicle_rate[0] + vehicle_rate[1] + vehicle_rate[2]);
            // int bikeRate = vehicle_rate[2]/(vehicle_rate[0] + vehicle_rate[1] + vehicle_rate[2]);

            int carRate = vehicle_rate[0];
            int motorRate = vehicle_rate[1];
            int bikeRate = vehicle_rate[2];

            vehicleRateChart.Series["s1"].Points.Clear();

            vehicleRateChart.Series["s1"].Points.AddXY("Ô tô", carRate);
            vehicleRateChart.Series["s1"].Points[0].Label = carRate.ToString();
            vehicleRateChart.Series["s1"].Points[0].LegendText = "Ô tô";

            vehicleRateChart.Series["s1"].Points.AddXY("Xe máy", motorRate);
            vehicleRateChart.Series["s1"].Points[1].Label = motorRate.ToString();
            vehicleRateChart.Series["s1"].Points[1].LegendText = "Xe máy";

            vehicleRateChart.Series["s1"].Points.AddXY("Xe đạp", bikeRate);
            vehicleRateChart.Series["s1"].Points[2].Label = bikeRate.ToString();
            vehicleRateChart.Series["s1"].Points[2].LegendText = "Xe đạp";

            vehicleRateChart.Series["s1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            vehicleRateChart.Series["s1"].Points[0].Color = Color.Blue;
            vehicleRateChart.Series["s1"].Points[1].Color = Color.Orange;
            vehicleRateChart.Series["s1"].Points[2].Color = Color.Red;
        }
        
        static List<int> getNumListFromString(string input)
        {
            string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> numbers = new List<int>();
            foreach (var line in lines)
            {
                numbers.Add(int.Parse(line.Trim()));
            }
            return numbers;
        }

        private void getCarSlot()
        {
            string pythonCommand = "python";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
            string scriptPath= Path.Combine(projectDirectory, @"backend\slot.py");
            Console.WriteLine("script path: " + scriptPath);
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = pythonCommand,
                Arguments = $"{scriptPath}",
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
                        List<int> numbers = getNumListFromString(result);
                        for(int i=0;i<numbers.Count;i++)
                        {
                            Console.WriteLine(numbers[i]);
                        }
                        carSlot.Text = numbers[0].ToString();
                        motorSlot.Text = numbers[1].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private List<int> getVehicleRate()
        {
            string pythonCommand = "python";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
            string scriptPath= Path.Combine(projectDirectory, @"backend\vehicle_rate.py");
            Console.WriteLine("script path: " + scriptPath);
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = pythonCommand,
                Arguments = $"{scriptPath}",
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
                        List<int> numbers = getNumListFromString(result);
                        Console.WriteLine("List vehicle rate: " + numbers);
                        return numbers;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            List<int> tmp = new List<int> { 0, 0, 0 };
            return tmp;
        }


        private void FetchData()
        {
            string appDataPath = "..\\..\\AppData";
            string dbPath = Path.Combine(appDataPath, "BAIXE.db");
            string connectionString = $"Data Source={dbPath};Version=3;";
            string query = @"SELECT LOAIPHIEU, COUNT(*) as Count
                            FROM PHIEU
                            GROUP BY LOAIPHIEU";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);

                try
                {
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();

                    int thangCount = 0;
                    int ngayCount = 0;

                    while (reader.Read())
                    {
                        string loaiPhieu = reader["LOAIPHIEU"].ToString();
                        int count = Convert.ToInt32(reader["Count"]);

                        if (loaiPhieu == "Tháng")
                        {
                            thangCount = count;
                        }
                        else if (loaiPhieu == "Ngày")
                        {
                            ngayCount = count;
                        }
                    }

                    reader.Close();

                    // Update labels
                    phieuNgay.Text = ngayCount.ToString();
                    phieuThang.Text = thangCount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            FetchData();
        }

        private void phieuNgay_Click(object sender, EventArgs e)
        {

        }
    }
}
