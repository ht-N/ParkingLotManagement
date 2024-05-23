namespace ParkingLotManagement.UserControls
{
    partial class BangDK_ra
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
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.loaiXe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loaiPhieu = new System.Windows.Forms.TextBox();
            this.bienSo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maPhieu = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.time_In = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.TextBox();
            this.money = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button2.Location = new System.Drawing.Point(908, 559);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(427, 41);
            this.button2.TabIndex = 35;
            this.button2.Text = "Xuất";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.label6.Location = new System.Drawing.Point(881, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 28);
            this.label6.TabIndex = 25;
            this.label6.Text = "Loại xe";
            // 
            // loaiXe
            // 
            this.loaiXe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loaiXe.Enabled = false;
            this.loaiXe.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.loaiXe.Location = new System.Drawing.Point(1033, 321);
            this.loaiXe.Name = "loaiXe";
            this.loaiXe.ReadOnly = true;
            this.loaiXe.Size = new System.Drawing.Size(302, 32);
            this.loaiXe.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.label5.Location = new System.Drawing.Point(881, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 28);
            this.label5.TabIndex = 25;
            this.label5.Text = "Loại phiếu";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // loaiPhieu
            // 
            this.loaiPhieu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loaiPhieu.Enabled = false;
            this.loaiPhieu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.loaiPhieu.Location = new System.Drawing.Point(1033, 235);
            this.loaiPhieu.Name = "loaiPhieu";
            this.loaiPhieu.ReadOnly = true;
            this.loaiPhieu.Size = new System.Drawing.Size(302, 32);
            this.loaiPhieu.TabIndex = 28;
            // 
            // bienSo
            // 
            this.bienSo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bienSo.Enabled = false;
            this.bienSo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.bienSo.Location = new System.Drawing.Point(1033, 155);
            this.bienSo.Name = "bienSo";
            this.bienSo.ReadOnly = true;
            this.bienSo.Size = new System.Drawing.Size(302, 32);
            this.bienSo.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.label3.Location = new System.Drawing.Point(881, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 28);
            this.label3.TabIndex = 25;
            this.label3.Text = "Mã phiếu";
            // 
            // maPhieu
            // 
            this.maPhieu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.maPhieu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.maPhieu.Location = new System.Drawing.Point(1033, 71);
            this.maPhieu.Name = "maPhieu";
            this.maPhieu.Size = new System.Drawing.Size(302, 32);
            this.maPhieu.TabIndex = 24;
            this.maPhieu.TextChanged += new System.EventHandler(this.maPhieu_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.label4.Location = new System.Drawing.Point(881, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 28);
            this.label4.TabIndex = 25;
            this.label4.Text = "Biển số";
            // 
            // imageBox
            // 
            this.imageBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox.Location = new System.Drawing.Point(29, 71);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(832, 497);
            this.imageBox.TabIndex = 21;
            this.imageBox.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Cascadia Code", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(547, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(304, 44);
            this.label9.TabIndex = 34;
            this.label9.Text = "BẢNG ĐIỀU KHIỂN";
            // 
            // time_In
            // 
            this.time_In.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.time_In.AutoSize = true;
            this.time_In.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.time_In.Location = new System.Drawing.Point(881, 402);
            this.time_In.Name = "time_In";
            this.time_In.Size = new System.Drawing.Size(135, 28);
            this.time_In.TabIndex = 25;
            this.time_In.Text = "Thời gian vào";
            // 
            // time
            // 
            this.time.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.time.Enabled = false;
            this.time.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.time.Location = new System.Drawing.Point(1033, 402);
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Size = new System.Drawing.Size(302, 32);
            this.time.TabIndex = 39;
            // 
            // money
            // 
            this.money.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.money.Enabled = false;
            this.money.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.money.Location = new System.Drawing.Point(1033, 494);
            this.money.Name = "money";
            this.money.ReadOnly = true;
            this.money.Size = new System.Drawing.Size(302, 32);
            this.money.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.label1.Location = new System.Drawing.Point(881, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 28);
            this.label1.TabIndex = 25;
            this.label1.Text = "Phí giữ xe";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.label2.Location = new System.Drawing.Point(298, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 28);
            this.label2.TabIndex = 42;
            this.label2.Text = "Biển số xe lúc vào bãi";
            // 
            // BangDK_ra
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.money);
            this.Controls.Add(this.time);
            this.Controls.Add(this.time_In);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loaiXe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.loaiPhieu);
            this.Controls.Add(this.bienSo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maPhieu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.Name = "BangDK_ra";
            this.Size = new System.Drawing.Size(1366, 649);
            this.Load += new System.EventHandler(this.BangDK_ra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox loaiXe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox loaiPhieu;
        private System.Windows.Forms.TextBox bienSo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox maPhieu;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label time_In;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.TextBox money;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}