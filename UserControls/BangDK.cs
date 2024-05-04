using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Python.Runtime;

namespace ParkingLotManagement.UserControls
{
    public partial class BangDK : UserControl
    {
        public BangDK()
        {
            
            InitializeComponent();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
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
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Clone the frame
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            // Flip the image horizontally
            // frame.RotateFlip(RotateFlipType.RotateNoneFlipX);

            // Calculate the position to center the image horizontally
            int xOffset = (pictureBox.Width - frame.Width) / 2;

            // Create a new bitmap to draw the adjusted frame
            Bitmap adjustedFrame = new Bitmap(pictureBox.Width, pictureBox.Height);

            using (Graphics g = Graphics.FromImage(adjustedFrame))
            {
                // Clear the graphics surface with a transparent color
                g.Clear(Color.Transparent);

                // Draw the adjusted frame onto the graphics surface
                g.DrawImage(frame, xOffset, 0, frame.Width, frame.Height);
            }

            // Display the adjusted frame in the pictureBox
            pictureBox.Image = adjustedFrame;
        }

        private void BangDK_Closing(object sender, ControlEventArgs e)
        {
            if (captureDevice.IsRunning)
                captureDevice.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToLongTimeString();
            label8.Text = DateTime.Now.ToLongDateString();
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
    }
}
