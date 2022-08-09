namespace QuanLyChoThueXe
{
    partial class fKhachHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddKhach = new System.Windows.Forms.Button();
            this.btnDeleteKhach = new System.Windows.Forms.Button();
            this.btnEditKhach = new System.Windows.Forms.Button();
            this.btnShowKhach = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbSearchKhachName = new System.Windows.Forms.TextBox();
            this.btnSearchKhach = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgvKhach = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nmKhachID = new System.Windows.Forms.NumericUpDown();
            this.nmTienThue = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nmSdt = new System.Windows.Forms.NumericUpDown();
            this.nmCmnd = new System.Windows.Forms.NumericUpDown();
            this.cbxGioiTinh = new System.Windows.Forms.ComboBox();
            this.txbDiachi = new System.Windows.Forms.TextBox();
            this.txbKhachName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKhach)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmKhachID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTienThue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSdt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmCmnd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(461, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khách Hàng";
            // 
            // btnAddKhach
            // 
            this.btnAddKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddKhach.Location = new System.Drawing.Point(17, 11);
            this.btnAddKhach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddKhach.Name = "btnAddKhach";
            this.btnAddKhach.Size = new System.Drawing.Size(75, 49);
            this.btnAddKhach.TabIndex = 1;
            this.btnAddKhach.Text = "Thêm";
            this.btnAddKhach.UseVisualStyleBackColor = true;
            this.btnAddKhach.Click += new System.EventHandler(this.btnAddKhach_Click);
            // 
            // btnDeleteKhach
            // 
            this.btnDeleteKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteKhach.Location = new System.Drawing.Point(165, 11);
            this.btnDeleteKhach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteKhach.Name = "btnDeleteKhach";
            this.btnDeleteKhach.Size = new System.Drawing.Size(75, 49);
            this.btnDeleteKhach.TabIndex = 2;
            this.btnDeleteKhach.Text = "Xóa";
            this.btnDeleteKhach.UseVisualStyleBackColor = true;
            this.btnDeleteKhach.Click += new System.EventHandler(this.btnDeleteKhach_Click);
            // 
            // btnEditKhach
            // 
            this.btnEditKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditKhach.Location = new System.Drawing.Point(317, 11);
            this.btnEditKhach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditKhach.Name = "btnEditKhach";
            this.btnEditKhach.Size = new System.Drawing.Size(75, 49);
            this.btnEditKhach.TabIndex = 3;
            this.btnEditKhach.Text = "Sửa";
            this.btnEditKhach.UseVisualStyleBackColor = true;
            this.btnEditKhach.Click += new System.EventHandler(this.btnEditKhach_Click);
            // 
            // btnShowKhach
            // 
            this.btnShowKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowKhach.Location = new System.Drawing.Point(445, 11);
            this.btnShowKhach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowKhach.Name = "btnShowKhach";
            this.btnShowKhach.Size = new System.Drawing.Size(99, 49);
            this.btnShowKhach.TabIndex = 4;
            this.btnShowKhach.Text = "Tải Lại";
            this.btnShowKhach.UseVisualStyleBackColor = true;
            this.btnShowKhach.Click += new System.EventHandler(this.btnShowKhach_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddKhach);
            this.panel1.Controls.Add(this.btnShowKhach);
            this.panel1.Controls.Add(this.btnDeleteKhach);
            this.panel1.Controls.Add(this.btnEditKhach);
            this.panel1.Location = new System.Drawing.Point(3, 458);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 66);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbSearchKhachName);
            this.panel2.Controls.Add(this.btnSearchKhach);
            this.panel2.Location = new System.Drawing.Point(567, 59);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 73);
            this.panel2.TabIndex = 6;
            // 
            // txbSearchKhachName
            // 
            this.txbSearchKhachName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearchKhachName.Location = new System.Drawing.Point(3, 23);
            this.txbSearchKhachName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbSearchKhachName.Name = "txbSearchKhachName";
            this.txbSearchKhachName.Size = new System.Drawing.Size(415, 27);
            this.txbSearchKhachName.TabIndex = 1;
            // 
            // btnSearchKhach
            // 
            this.btnSearchKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchKhach.Location = new System.Drawing.Point(428, 11);
            this.btnSearchKhach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchKhach.Name = "btnSearchKhach";
            this.btnSearchKhach.Size = new System.Drawing.Size(119, 52);
            this.btnSearchKhach.TabIndex = 0;
            this.btnSearchKhach.Text = "Tìm";
            this.btnSearchKhach.UseVisualStyleBackColor = true;
            this.btnSearchKhach.Click += new System.EventHandler(this.btnSearchKhach_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgvKhach);
            this.panel3.Location = new System.Drawing.Point(12, 59);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 609);
            this.panel3.TabIndex = 7;
            // 
            // dtgvKhach
            // 
            this.dtgvKhach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvKhach.Location = new System.Drawing.Point(3, 2);
            this.dtgvKhach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgvKhach.Name = "dtgvKhach";
            this.dtgvKhach.RowHeadersWidth = 51;
            this.dtgvKhach.RowTemplate.Height = 24;
            this.dtgvKhach.Size = new System.Drawing.Size(544, 604);
            this.dtgvKhach.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nmKhachID);
            this.panel4.Controls.Add(this.nmTienThue);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.nmSdt);
            this.panel4.Controls.Add(this.nmCmnd);
            this.panel4.Controls.Add(this.cbxGioiTinh);
            this.panel4.Controls.Add(this.txbDiachi);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.txbKhachName);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(567, 150);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(549, 527);
            this.panel4.TabIndex = 8;
            // 
            // nmKhachID
            // 
            this.nmKhachID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmKhachID.Location = new System.Drawing.Point(227, 20);
            this.nmKhachID.Name = "nmKhachID";
            this.nmKhachID.ReadOnly = true;
            this.nmKhachID.Size = new System.Drawing.Size(299, 28);
            this.nmKhachID.TabIndex = 16;
            this.nmKhachID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nmTienThue
            // 
            this.nmTienThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmTienThue.Location = new System.Drawing.Point(227, 404);
            this.nmTienThue.Margin = new System.Windows.Forms.Padding(4);
            this.nmTienThue.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmTienThue.Name = "nmTienThue";
            this.nmTienThue.ReadOnly = true;
            this.nmTienThue.Size = new System.Drawing.Size(299, 26);
            this.nmTienThue.TabIndex = 15;
            this.nmTienThue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmTienThue.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmTienThue.ValueChanged += new System.EventHandler(this.nmTienThue_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 412);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tiền Thuê Xe Mặc Định:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "ID:";
            // 
            // nmSdt
            // 
            this.nmSdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmSdt.Location = new System.Drawing.Point(227, 212);
            this.nmSdt.Margin = new System.Windows.Forms.Padding(4);
            this.nmSdt.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nmSdt.Name = "nmSdt";
            this.nmSdt.Size = new System.Drawing.Size(299, 29);
            this.nmSdt.TabIndex = 11;
            this.nmSdt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nmCmnd
            // 
            this.nmCmnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmCmnd.Location = new System.Drawing.Point(227, 143);
            this.nmCmnd.Margin = new System.Windows.Forms.Padding(4);
            this.nmCmnd.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nmCmnd.Name = "nmCmnd";
            this.nmCmnd.Size = new System.Drawing.Size(300, 29);
            this.nmCmnd.TabIndex = 10;
            this.nmCmnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxGioiTinh
            // 
            this.cbxGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGioiTinh.FormattingEnabled = true;
            this.cbxGioiTinh.Location = new System.Drawing.Point(227, 267);
            this.cbxGioiTinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxGioiTinh.Name = "cbxGioiTinh";
            this.cbxGioiTinh.Size = new System.Drawing.Size(107, 28);
            this.cbxGioiTinh.TabIndex = 9;
            this.cbxGioiTinh.Text = "Nam";
            // 
            // txbDiachi
            // 
            this.txbDiachi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDiachi.Location = new System.Drawing.Point(227, 334);
            this.txbDiachi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbDiachi.Name = "txbDiachi";
            this.txbDiachi.Size = new System.Drawing.Size(299, 27);
            this.txbDiachi.TabIndex = 8;
            // 
            // txbKhachName
            // 
            this.txbKhachName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbKhachName.Location = new System.Drawing.Point(227, 75);
            this.txbKhachName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbKhachName.Name = "txbKhachName";
            this.txbKhachName.Size = new System.Drawing.Size(299, 27);
            this.txbKhachName.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Địa Chỉ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Giới Tính:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số Điện Thoại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "CMND:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Khách Hàng:";
            // 
            // fKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(1131, 690);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fKhachHang";
            this.Text = "Phần mềm quản lý cho thuê xe";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKhach)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmKhachID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTienThue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSdt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmCmnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddKhach;
        private System.Windows.Forms.Button btnDeleteKhach;
        private System.Windows.Forms.Button btnEditKhach;
        private System.Windows.Forms.Button btnShowKhach;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbSearchKhachName;
        private System.Windows.Forms.Button btnSearchKhach;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvKhach;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbxGioiTinh;
        private System.Windows.Forms.TextBox txbDiachi;
        private System.Windows.Forms.TextBox txbKhachName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nmSdt;
        private System.Windows.Forms.NumericUpDown nmCmnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nmTienThue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nmKhachID;
    }
}