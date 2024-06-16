using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ParkingLotManagement.UserControls
{
    public partial class BaoCao : UserControl
    {
        public BaoCao()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            await Task.WhenAll(getSlotAndDoanhThu(), updateChart(), getSoLuongPhieu());
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

        private async Task getSlotAndDoanhThu()
        {
            string pythonCommand = "python";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
            string scriptPath = Path.Combine(projectDirectory, @"backend\slot_and_doanhthu.py");
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
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = await reader.ReadToEndAsync();
                        await process.WaitForExitAsync();
                        List<int> numbers = getNumListFromString(result);
                        for (int i = 0; i < numbers.Count; i++)
                            Console.WriteLine(numbers[i]);
                
                        carSlot.Text = numbers[0].ToString();
                        motorSlot.Text = numbers[1].ToString();
                        doanhThuTuan.Text = numbers[2].ToString();
                        doanhThuThang.Text = numbers[3].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private async Task<List<int>> getVehicleRate()
        {
            string pythonCommand = "python";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
            string scriptPath = Path.Combine(projectDirectory, @"backend\vehicle_rate.py");
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
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = await reader.ReadToEndAsync();
                        await process.WaitForExitAsync();
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

        private async Task updateChart()
        {
            List<int> vehicle_rate = await getVehicleRate();
            for (int i = 0; i < vehicle_rate.Count; i++)
                Console.WriteLine(vehicle_rate[i]);

            float carRate = vehicle_rate[0] * 100 / (vehicle_rate[0] + vehicle_rate[1] + vehicle_rate[2]);
            float motorRate = vehicle_rate[1] * 100 / (vehicle_rate[0] + vehicle_rate[1] + vehicle_rate[2]);
            float bikeRate = vehicle_rate[2] * 100 / (vehicle_rate[0] + vehicle_rate[1] + vehicle_rate[2]);
            Console.WriteLine("car rate: " + carRate + "\nmotor rate: " + motorRate + "\nbike rate: " + bikeRate);
            vehicleRateChart.Series["s1"].Points.Clear();

            vehicleRateChart.Series["s1"].Points.AddXY("Ô tô", carRate);
            vehicleRateChart.Series["s1"].Points[0].Label = carRate.ToString() + "%";
            vehicleRateChart.Series["s1"].Points[0].LegendText = "Ô tô";

            vehicleRateChart.Series["s1"].Points.AddXY("Xe máy", motorRate);
            vehicleRateChart.Series["s1"].Points[1].Label = motorRate.ToString() + "%";
            vehicleRateChart.Series["s1"].Points[1].LegendText = "Xe máy";

            vehicleRateChart.Series["s1"].Points.AddXY("Xe đạp", bikeRate);
            vehicleRateChart.Series["s1"].Points[2].Label = bikeRate.ToString() + "%";
            vehicleRateChart.Series["s1"].Points[2].LegendText = "Xe đạp";

            vehicleRateChart.Series["s1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            vehicleRateChart.Series["s1"].Points[0].Color = Color.Blue;
            vehicleRateChart.Series["s1"].Points[1].Color = Color.Orange;
            vehicleRateChart.Series["s1"].Points[2].Color = Color.Red;

            vehicleRateChart.Legends[0].ForeColor = Color.White;
            vehicleRateChart.Legends[0].Font = new Font("Calibri", 13, FontStyle.Regular);
        }

        private async Task getSoLuongPhieu()
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
                    await connection.OpenAsync();
                    using (SQLiteDataReader reader = (SQLiteDataReader)await command.ExecuteReaderAsync())
                    {
                        int thangCount = 0;
                        int ngayCount = 0;
                        while (await reader.ReadAsync())
                        {
                            string loaiPhieu = reader["LOAIPHIEU"].ToString();
                            int count = Convert.ToInt32(reader["Count"]);

                            if (loaiPhieu == "Tháng")
                                thangCount = count;
                            else if (loaiPhieu == "Ngày")
                                ngayCount = count;
                        }

                        // Update labels
                        phieuNgay.Text = ngayCount.ToString();
                        phieuThang.Text = thangCount.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public static class ProcessExtensions
    {
        public static Task WaitForExitAsync(this Process process, CancellationToken cancellationToken = default)
        {
            if (process.HasExited) return Task.CompletedTask;

            var tcs = new TaskCompletionSource<object>();
            process.EnableRaisingEvents = true;
            process.Exited += (sender, args) => tcs.TrySetResult(null);
            if (cancellationToken != default)
            {
                cancellationToken.Register(() => tcs.SetCanceled());
            }

            return process.HasExited ? Task.CompletedTask : tcs.Task;
        }
    }
}
