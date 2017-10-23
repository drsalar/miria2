namespace app1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.logTB = new System.Windows.Forms.TextBox();
            this.startBt = new System.Windows.Forms.Button();
            this.timeL = new System.Windows.Forms.Label();
            this.timeTB = new System.Windows.Forms.TextBox();
            this.stopBt = new System.Windows.Forms.Button();
            this.c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.u1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.u2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.u3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.u4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.u5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.u6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.account,
            this.name,
            this.status});
            this.dataGridView1.Location = new System.Drawing.Point(26, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(879, 77);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // account
            // 
            this.account.HeaderText = "账号";
            this.account.Name = "account";
            this.account.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "昵称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c1,
            this.c2,
            this.c3,
            this.c4,
            this.c5,
            this.c6});
            this.dataGridView2.Location = new System.Drawing.Point(26, 136);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(879, 120);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.u1,
            this.u2,
            this.u3,
            this.u4,
            this.u5,
            this.u6});
            this.dataGridView3.Location = new System.Drawing.Point(26, 279);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(879, 130);
            this.dataGridView3.TabIndex = 2;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView4.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ch1,
            this.ch2,
            this.ch3,
            this.ch4,
            this.ch5,
            this.ch6,
            this.ch7,
            this.ch8,
            this.ch9,
            this.ch10});
            this.dataGridView4.Location = new System.Drawing.Point(26, 432);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.RowTemplate.Height = 23;
            this.dataGridView4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(879, 130);
            this.dataGridView4.TabIndex = 3;
            this.dataGridView4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellContentClick);
            // 
            // logTB
            // 
            this.logTB.Location = new System.Drawing.Point(26, 580);
            this.logTB.Multiline = true;
            this.logTB.Name = "logTB";
            this.logTB.ReadOnly = true;
            this.logTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTB.Size = new System.Drawing.Size(879, 81);
            this.logTB.TabIndex = 4;
            this.logTB.TextChanged += new System.EventHandler(this.logTB_TextChanged);
            // 
            // startBt
            // 
            this.startBt.Location = new System.Drawing.Point(616, 688);
            this.startBt.Name = "startBt";
            this.startBt.Size = new System.Drawing.Size(75, 23);
            this.startBt.TabIndex = 5;
            this.startBt.Text = "开始答题";
            this.startBt.UseVisualStyleBackColor = true;
            this.startBt.Click += new System.EventHandler(this.startBt_Click);
            // 
            // timeL
            // 
            this.timeL.AutoSize = true;
            this.timeL.Location = new System.Drawing.Point(68, 693);
            this.timeL.Name = "timeL";
            this.timeL.Size = new System.Drawing.Size(185, 12);
            this.timeL.TabIndex = 6;
            this.timeL.Text = "设置单元挂学时时长(单位，分钟)";
            // 
            // timeTB
            // 
            this.timeTB.Location = new System.Drawing.Point(268, 690);
            this.timeTB.Name = "timeTB";
            this.timeTB.Size = new System.Drawing.Size(68, 21);
            this.timeTB.TabIndex = 7;
            this.timeTB.Text = "4";
            this.timeTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // stopBt
            // 
            this.stopBt.Location = new System.Drawing.Point(446, 688);
            this.stopBt.Name = "stopBt";
            this.stopBt.Size = new System.Drawing.Size(75, 23);
            this.stopBt.TabIndex = 8;
            this.stopBt.Text = "开始挂学时";
            this.stopBt.UseVisualStyleBackColor = true;
            this.stopBt.Click += new System.EventHandler(this.stopBt_Click);
            // 
            // c1
            // 
            this.c1.HeaderText = "课程";
            this.c1.Name = "c1";
            this.c1.ReadOnly = true;
            // 
            // c2
            // 
            this.c2.HeaderText = "学习进度";
            this.c2.Name = "c2";
            this.c2.ReadOnly = true;
            // 
            // c3
            // 
            this.c3.HeaderText = "学习时长";
            this.c3.Name = "c3";
            this.c3.ReadOnly = true;
            this.c3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // c4
            // 
            this.c4.HeaderText = "课程剩余时间";
            this.c4.Name = "c4";
            this.c4.ReadOnly = true;
            // 
            // c5
            // 
            this.c5.HeaderText = "状态";
            this.c5.Name = "c5";
            this.c5.ReadOnly = true;
            this.c5.Visible = false;
            // 
            // c6
            // 
            this.c6.HeaderText = "课程链接";
            this.c6.Name = "c6";
            this.c6.ReadOnly = true;
            this.c6.Visible = false;
            // 
            // u1
            // 
            this.u1.HeaderText = "单元";
            this.u1.Name = "u1";
            this.u1.ReadOnly = true;
            // 
            // u2
            // 
            this.u2.HeaderText = "学习进度";
            this.u2.Name = "u2";
            this.u2.ReadOnly = true;
            // 
            // u3
            // 
            this.u3.HeaderText = "学习时长";
            this.u3.Name = "u3";
            this.u3.ReadOnly = true;
            this.u3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // u4
            // 
            this.u4.HeaderText = "成绩";
            this.u4.Name = "u4";
            this.u4.ReadOnly = true;
            // 
            // u5
            // 
            this.u5.HeaderText = "状态";
            this.u5.Name = "u5";
            this.u5.ReadOnly = true;
            this.u5.Visible = false;
            // 
            // u6
            // 
            this.u6.HeaderText = "链接";
            this.u6.Name = "u6";
            this.u6.ReadOnly = true;
            this.u6.Visible = false;
            // 
            // ch1
            // 
            this.ch1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ch1.Frozen = true;
            this.ch1.HeaderText = "小节";
            this.ch1.Name = "ch1";
            this.ch1.ReadOnly = true;
            this.ch1.Width = 175;
            // 
            // ch2
            // 
            this.ch2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ch2.FillWeight = 30F;
            this.ch2.Frozen = true;
            this.ch2.HeaderText = "总页数";
            this.ch2.Name = "ch2";
            this.ch2.ReadOnly = true;
            this.ch2.Width = 80;
            // 
            // ch3
            // 
            this.ch3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ch3.FillWeight = 30F;
            this.ch3.Frozen = true;
            this.ch3.HeaderText = "练习页数";
            this.ch3.Name = "ch3";
            this.ch3.ReadOnly = true;
            this.ch3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ch3.Width = 80;
            // 
            // ch4
            // 
            this.ch4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ch4.Frozen = true;
            this.ch4.HeaderText = "累计学习时长";
            this.ch4.Name = "ch4";
            this.ch4.ReadOnly = true;
            this.ch4.Width = 120;
            // 
            // ch5
            // 
            this.ch5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ch5.HeaderText = "成绩";
            this.ch5.Name = "ch5";
            this.ch5.ReadOnly = true;
            this.ch5.Width = 80;
            // 
            // ch6
            // 
            this.ch6.HeaderText = "是否完成";
            this.ch6.Name = "ch6";
            this.ch6.ReadOnly = true;
            // 
            // ch7
            // 
            this.ch7.HeaderText = "状态";
            this.ch7.Name = "ch7";
            this.ch7.ReadOnly = true;
            this.ch7.Visible = false;
            // 
            // ch8
            // 
            this.ch8.HeaderText = "链接";
            this.ch8.Name = "ch8";
            this.ch8.ReadOnly = true;
            this.ch8.Visible = false;
            // 
            // ch9
            // 
            this.ch9.HeaderText = "itemid";
            this.ch9.Name = "ch9";
            this.ch9.ReadOnly = true;
            this.ch9.Visible = false;
            // 
            // ch10
            // 
            this.ch10.HeaderText = "nodeid";
            this.ch10.Name = "ch10";
            this.ch10.ReadOnly = true;
            this.ch10.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 738);
            this.Controls.Add(this.stopBt);
            this.Controls.Add(this.timeTB);
            this.Controls.Add(this.timeL);
            this.Controls.Add(this.startBt);
            this.Controls.Add(this.logTB);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "优学院自动答题";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn account;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.TextBox logTB;
        private System.Windows.Forms.Button startBt;
        private System.Windows.Forms.Label timeL;
        private System.Windows.Forms.TextBox timeTB;
        private System.Windows.Forms.Button stopBt;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2;
        private System.Windows.Forms.DataGridViewTextBoxColumn c3;
        private System.Windows.Forms.DataGridViewTextBoxColumn c4;
        private System.Windows.Forms.DataGridViewTextBoxColumn c5;
        private System.Windows.Forms.DataGridViewTextBoxColumn c6;
        private System.Windows.Forms.DataGridViewTextBoxColumn u1;
        private System.Windows.Forms.DataGridViewTextBoxColumn u2;
        private System.Windows.Forms.DataGridViewTextBoxColumn u3;
        private System.Windows.Forms.DataGridViewTextBoxColumn u4;
        private System.Windows.Forms.DataGridViewTextBoxColumn u5;
        private System.Windows.Forms.DataGridViewTextBoxColumn u6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch10;
    }
}