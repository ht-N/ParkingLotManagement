using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ParkingLotManagement.UserControls
{
    public partial class ChoTrong : UserControl
    {
        private Random random = new Random();
        private Dictionary<string, Panel> maphieuToPanelMap = new Dictionary<string, Panel>();
        public ChoTrong()
        {
            InitializeComponent();
            CheckDatabaseAndUpdatePanels();
        }
        private void CheckDatabaseAndUpdatePanels()
        {
            var maphieuLoaixeList = GetMaphieuLoaixeList();
            UpdatePanels(maphieuLoaixeList);
        }

        private List<(string Maphieu, string Loaixe)> GetMaphieuLoaixeList()
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = "C:\\Users\\hello\\source\\repos\\ParkingLotManagement\\backend\\parkinglot.py\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            List<(string Maphieu, string Loaixe)> maphieuLoaixeList = new List<(string Maphieu, string Loaixe)>();
            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd().Trim();
                if (!string.IsNullOrEmpty(output))
                {
                    foreach (var line in output.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            maphieuLoaixeList.Add((parts[0], parts[1]));
                        }
                    }
                }
            }
            return maphieuLoaixeList;
        }

        private void UpdatePanels(List<(string Maphieu, string Loaixe)> maphieuLoaixeList)
        {
            // Reset màu tất cả các panel
            foreach (var panel in this.Controls.OfType<Panel>())
            {
                panel.BackColor = SystemColors.Control; // Màu mặc định của Panel
            }

            maphieuToPanelMap.Clear();

            // Lấy danh sách các panel cho xe máy và xe đạp (panel0 đến panel150)
            var bikeAndMotorbikePanels = this.Controls.OfType<Panel>().Where(p => p.Name.StartsWith("panel") && int.Parse(p.Name.Replace("panel", "")) <= 150).ToList();

            // Lấy danh sách các panel cho ô tô (panel151 đến panel200)
            var carPanels = this.Controls.OfType<Panel>().Where(p => p.Name.StartsWith("panel") && int.Parse(p.Name.Replace("panel", "")) > 150).ToList();

            // Chọn các panel cho xe đạp và xe máy
            foreach (var (maphieu, loaixe) in maphieuLoaixeList.Where(x => x.Loaixe == "Xe máy"))
            {
                if (bikeAndMotorbikePanels.Count == 0) break;
                int index = random.Next(bikeAndMotorbikePanels.Count);
                var panel = bikeAndMotorbikePanels[index];
                panel.BackColor = loaixe == "Xe đạp" ? Color.Blue : Color.Green;
                maphieuToPanelMap[maphieu] = panel;
                bikeAndMotorbikePanels.RemoveAt(index); // Đảm bảo không tô màu lại panel đã chọn
            }

            // Chọn các panel cho ô tô
            foreach (var (maphieu, loaixe) in maphieuLoaixeList.Where(x => x.Loaixe == "Ô tô"))
            {
                if (carPanels.Count == 0) break;
                int index = random.Next(carPanels.Count);
                var panel = carPanels[index];
                panel.BackColor = Color.Green;
                maphieuToPanelMap[maphieu] = panel;
                carPanels.RemoveAt(index); // Đảm bảo không tô màu lại panel đã chọn
            }
        }
    }
}