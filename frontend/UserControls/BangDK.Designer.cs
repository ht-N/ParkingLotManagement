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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.cboDevice = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Capture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(39, 31);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(475, 497);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // cboDevice
            // 
            this.cboDevice.FormattingEnabled = true;
            this.cboDevice.Location = new System.Drawing.Point(321, 550);
            this.cboDevice.Name = "cboDevice";
            this.cboDevice.Size = new System.Drawing.Size(192, 24);
            this.cboDevice.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(35, 548);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chọn camera muốn hoạt động:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(321, 592);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Mở cam";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // maPhieu
            // 
            this.maPhieu.Font = new System.Drawing.Font("Cascadia Code", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.maPhieu.Location = new System.Drawing.Point(761, 82);
            this.maPhieu.Name = "maPhieu";
            this.maPhieu.Size = new System.Drawing.Size(559, 46);
            this.maPhieu.TabIndex = 6;
            this.maPhieu.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(628, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mã phiếu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(628, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 27);
            this.label4.TabIndex = 9;
            this.label4.Text = "Biển số";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // bienSo
            // 
            this.bienSo.Font = new System.Drawing.Font("Cascadia Code", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.bienSo.Location = new System.Drawing.Point(761, 191);
            this.bienSo.Name = "bienSo";
            this.bienSo.Size = new System.Drawing.Size(559, 46);
            this.bienSo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(604, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 27);
            this.label5.TabIndex = 11;
            this.label5.Text = "Loại phiếu";
            // 
            // loaiPhieu
            // 
            this.loaiPhieu.Font = new System.Drawing.Font("Cascadia Code", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.loaiPhieu.Location = new System.Drawing.Point(761, 300);
            this.loaiPhieu.Name = "loaiPhieu";
            this.loaiPhieu.Size = new System.Drawing.Size(559, 46);
            this.loaiPhieu.TabIndex = 10;
            this.loaiPhieu.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(628, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 27);
            this.label6.TabIndex = 13;
            this.label6.Text = "Loại xe";
            // 
            // loaiXe
            // 
            this.loaiXe.Font = new System.Drawing.Font("Cascadia Code", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.loaiXe.Location = new System.Drawing.Point(761, 402);
            this.loaiXe.Name = "loaiXe";
            this.loaiXe.Size = new System.Drawing.Size(559, 46);
            this.loaiXe.TabIndex = 12;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Time.Location = new System.Drawing.Point(756, 517);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(60, 27);
            this.Time.TabIndex = 14;
            this.Time.Text = "Time";
            this.Time.Click += new System.EventHandler(this.label7_Click);
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Date.Location = new System.Drawing.Point(756, 562);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(60, 27);
            this.Date.TabIndex = 15;
            this.Date.Text = "Date";
            this.Date.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
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
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button2.Location = new System.Drawing.Point(987, 503);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(333, 41);
            this.button2.TabIndex = 18;
            this.button2.Text = "Lưu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(272, 337);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 191);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // Capture
            // 
            this.Capture.Location = new System.Drawing.Point(438, 592);
            this.Capture.Name = "Capture";
            this.Capture.Size = new System.Drawing.Size(75, 23);
            this.Capture.TabIndex = 20;
            this.Capture.Text = "Chụp";
            this.Capture.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(346, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 27);
            this.label1.TabIndex = 21;
            this.label1.Text = "Biển số";
            // 
            // BangDK
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Capture);
            this.Controls.Add(this.pictureBox1);
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
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboDevice);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label9);
            this.Name = "BangDK";
            this.Size = new System.Drawing.Size(1366, 649);
            this.Load += new System.EventHandler(this.BangDK_Load);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.BangDK_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox cboDevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Capture;
        private System.Windows.Forms.Label label1;
    }
}
