namespace ParkingLotManagement
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.close_Click = new System.Windows.Forms.Button();
            this.maximize_Click = new System.Windows.Forms.Button();
            this.minimized_Click = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(15)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 720);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 48);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(1003, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "@UIT - 22520003 - 22520105";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "HỆ THỐNG QUẢN LÍ BÃI ĐỖ XE THÔNG MINH";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.guna2Button3);
            this.panel2.Controls.Add(this.guna2Button2);
            this.panel2.Controls.Add(this.guna2Button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1366, 46);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            // 
            // guna2Button3
            // 
            this.guna2Button3.Animated = true;
            this.guna2Button3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button3.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button3.CheckedState.CustomBorderColor = System.Drawing.Color.Red;
            this.guna2Button3.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2Button3.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button3.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2Button3.ForeColor = System.Drawing.Color.Black;
            this.guna2Button3.HoverState.CustomBorderColor = System.Drawing.Color.Red;
            this.guna2Button3.Location = new System.Drawing.Point(440, -1);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(214, 45);
            this.guna2Button3.TabIndex = 2;
            this.guna2Button3.Text = "BÁO CÁO";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.Animated = true;
            this.guna2Button2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button2.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button2.CheckedState.CustomBorderColor = System.Drawing.Color.Red;
            this.guna2Button2.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2Button2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button2.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2Button2.ForeColor = System.Drawing.Color.Black;
            this.guna2Button2.HoverState.CustomBorderColor = System.Drawing.Color.Red;
            this.guna2Button2.Location = new System.Drawing.Point(220, -1);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(214, 45);
            this.guna2Button2.TabIndex = 1;
            this.guna2Button2.Text = "CHỖ TRỐNG HIỆN TẠI";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button1.Checked = true;
            this.guna2Button1.CheckedState.CustomBorderColor = System.Drawing.Color.Red;
            this.guna2Button1.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2Button1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.CustomBorderColor = System.Drawing.Color.Red;
            this.guna2Button1.Location = new System.Drawing.Point(0, -1);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(214, 45);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "BẢNG ĐIỀU KHIỂN";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 46);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1366, 674);
            this.panelContainer.TabIndex = 2;
            this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContainer_Paint);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panel1;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::ParkingLotManagement.Properties.Resources.minimize;
            this.panel3.Controls.Add(this.close_Click);
            this.panel3.Controls.Add(this.maximize_Click);
            this.panel3.Controls.Add(this.minimized_Click);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1179, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(185, 44);
            this.panel3.TabIndex = 3;
            // 
            // close_Click
            // 
            this.close_Click.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.close_Click.BackgroundImage = global::ParkingLotManagement.Properties.Resources.close;
            this.close_Click.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.close_Click.FlatAppearance.BorderSize = 0;
            this.close_Click.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_Click.ForeColor = System.Drawing.Color.Transparent;
            this.close_Click.Location = new System.Drawing.Point(133, 4);
            this.close_Click.Name = "close_Click";
            this.close_Click.Size = new System.Drawing.Size(36, 36);
            this.close_Click.TabIndex = 2;
            this.close_Click.UseMnemonic = false;
            this.close_Click.UseVisualStyleBackColor = false;
            this.close_Click.Click += new System.EventHandler(this.close_Click_Click);
            // 
            // maximize_Click
            // 
            this.maximize_Click.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.maximize_Click.BackgroundImage = global::ParkingLotManagement.Properties.Resources.maximize;
            this.maximize_Click.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.maximize_Click.FlatAppearance.BorderSize = 0;
            this.maximize_Click.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximize_Click.ForeColor = System.Drawing.Color.Transparent;
            this.maximize_Click.Location = new System.Drawing.Point(77, 4);
            this.maximize_Click.Name = "maximize_Click";
            this.maximize_Click.Size = new System.Drawing.Size(36, 36);
            this.maximize_Click.TabIndex = 1;
            this.maximize_Click.UseMnemonic = false;
            this.maximize_Click.UseVisualStyleBackColor = false;
            this.maximize_Click.Click += new System.EventHandler(this.maximize_Click_Click);
            // 
            // minimized_Click
            // 
            this.minimized_Click.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.minimized_Click.BackgroundImage = global::ParkingLotManagement.Properties.Resources.minimize;
            this.minimized_Click.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.minimized_Click.FlatAppearance.BorderSize = 0;
            this.minimized_Click.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimized_Click.ForeColor = System.Drawing.Color.Transparent;
            this.minimized_Click.Location = new System.Drawing.Point(20, 4);
            this.minimized_Click.Name = "minimized_Click";
            this.minimized_Click.Size = new System.Drawing.Size(36, 36);
            this.minimized_Click.TabIndex = 0;
            this.minimized_Click.UseMnemonic = false;
            this.minimized_Click.UseVisualStyleBackColor = false;
            this.minimized_Click.Click += new System.EventHandler(this.minimized_Click_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelContainer;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button minimized_Click;
        private System.Windows.Forms.Button close_Click;
        private System.Windows.Forms.Button maximize_Click;
    }
}

