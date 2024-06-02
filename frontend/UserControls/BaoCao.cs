using System;
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

namespace ParkingLotManagement.UserControls
{
    public partial class BaoCao : UserControl
    {
        public BaoCao()
        {
            InitializeComponent();
            getCarSlot();
        }
        
        static int[] getNumber(string input)
        {
            string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[2];
            for (int i = 0; i < 2; i++)
                numbers[i] = int.Parse(lines[i].Trim());
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
                        int[] numbers = getNumber(result);
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
    }
}
