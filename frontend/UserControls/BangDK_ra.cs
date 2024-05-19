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

namespace ParkingLotManagement.UserControls
{
    public partial class BangDK_ra : UserControl
    {
        public BangDK_ra()
        {
            InitializeComponent();
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

        private void BangDK_ra_Load(object sender, EventArgs e)
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

        }

        }


}
