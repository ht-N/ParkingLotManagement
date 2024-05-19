namespace ParkingLotManagement.UserControls
{
    partial class BangDK
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.videoBox = new System.Windows.Forms.PictureBox();
            this.cboDevice = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.maPhieu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bienSo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loaiPhieu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.loaiXe = new System.Windows.Forms.TextBox();
            this.Time = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Capture_picture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.videoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // videoBox
            // 
            this.videoBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.videoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.videoBox.Location = new System.Drawing.Point(19, 18);
            this.videoBox.Name = "videoBox";
            this.videoBox.Size = new System.Drawing.Size(832, 497);
            this.videoBox.TabIndex = 2;
            this.videoBox.TabStop = false;
            // 
            // cboDevice
            // 
            this.cboDevice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboDevice.FormattingEnabled = true;
            this.cboDevice.Location = new System.Drawing.Point(240, 537);
            this.cboDevice.Name = "cboDevice";
            this.cboDevice.Size = new System.Drawing.Size(620, 32);
            this.cboDevice.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(15, 540);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Camera đang được chọn:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // maPhieu
            // 
            this.maPhieu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.maPhieu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.maPhieu.Location = new System.Drawing.Point(987, 80);
            this.maPhieu.Name = "maPhieu";
            this.maPhieu.Size = new System.Drawing.Size(333, 32);
            this.maPhieu.TabIndex = 6;
            this.maPhieu.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(889, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mã phiếu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(889, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Biển số";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // bienSo
            // 
            this.bienSo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bienSo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.bienSo.Location = new System.Drawing.Point(987, 191);
            this.bienSo.Name = "bienSo";
            this.bienSo.Size = new System.Drawing.Size(333, 32);
            this.bienSo.TabIndex = 8;
            this.bienSo.TextChanged += new System.EventHandler(this.bienSo_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(882, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Loại phiếu";
            // 
            // loaiPhieu
            // 
            this.loaiPhieu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loaiPhieu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.loaiPhieu.Location = new System.Drawing.Point(987, 300);
            this.loaiPhieu.Name = "loaiPhieu";
            this.loaiPhieu.Size = new System.Drawing.Size(333, 32);
            this.loaiPhieu.TabIndex = 10;
            this.loaiPhieu.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(893, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "Loại xe";
            // 
            // loaiXe
            // 
            this.loaiXe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loaiXe.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.loaiXe.Location = new System.Drawing.Point(987, 402);
            this.loaiXe.Name = "loaiXe";
            this.loaiXe.Size = new System.Drawing.Size(333, 32);
            this.loaiXe.TabIndex = 12;
            // 
            // Time
            // 
            this.Time.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Time.Location = new System.Drawing.Point(1016, 476);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(51, 24);
            this.Time.TabIndex = 14;
            this.Time.Text = "Time";
            this.Time.Click += new System.EventHandler(this.label7_Click);
            // 
            // Date
            // 
            this.Date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Date.Location = new System.Drawing.Point(1016, 518);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(49, 24);
            this.Date.TabIndex = 15;
            this.Date.Text = "Date";
            this.Date.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Cascadia Code", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(531, 307);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(304, 44);
            this.label9.TabIndex = 16;
            this.label9.Text = "BẢNG ĐIỀU KHIỂN";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button2.Location = new System.Drawing.Point(893, 576);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(427, 41);
            this.button2.TabIndex = 18;
            this.button2.Text = "Lưu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Capture_picture
            // 
            this.Capture_picture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Capture_picture.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Capture_picture.Location = new System.Drawing.Point(19, 582);
            this.Capture_picture.Name = "Capture_picture";
            this.Capture_picture.Size = new System.Drawing.Size(841, 35);
            this.Capture_picture.TabIndex = 20;
            this.Capture_picture.Text = "Chụp";
            this.Capture_picture.UseVisualStyleBackColor = true;
            this.Capture_picture.Click += new System.EventHandler(this.Capture_Click);
            // 
            // BangDK
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.Capture_picture);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loaiXe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.loaiPhieu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bienSo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maPhieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboDevice);
            this.Controls.Add(this.videoBox);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "BangDK";
            this.Size = new System.Drawing.Size(1366, 649);
            this.Load += new System.EventHandler(this.BangDK_Load);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.BangDK_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.videoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox videoBox;
        private System.Windows.Forms.ComboBox cboDevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox maPhieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bienSo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox loaiPhieu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox loaiXe;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Capture_picture;
    }
}
