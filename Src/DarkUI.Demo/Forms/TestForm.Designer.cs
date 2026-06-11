namespace DarkUI.Demo.Forms
{
    partial class TestForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BTNDarkTheme = new DarkUI.Controls.DarkButton();
            this.BTNLightTheme = new DarkUI.Controls.DarkButton();
            this.BTNOpenMainForm = new DarkUI.Controls.DarkButton();
            this.darkTabControl1 = new DarkUI.Controls.DarkTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BTNSystemTheme = new DarkUI.Controls.DarkButton();
            this.darkDataGridView1 = new DarkUI.Controls.DarkDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.darkScrollBar1 = new DarkUI.Controls.DarkScrollBar();
            this.darkTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.darkDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BTNDarkTheme
            // 
            this.BTNDarkTheme.Location = new System.Drawing.Point(330, 12);
            this.BTNDarkTheme.Name = "BTNDarkTheme";
            this.BTNDarkTheme.Padding = new System.Windows.Forms.Padding(5);
            this.BTNDarkTheme.Size = new System.Drawing.Size(100, 40);
            this.BTNDarkTheme.TabIndex = 1;
            this.BTNDarkTheme.Text = "Dark Theme";
            this.BTNDarkTheme.Click += new System.EventHandler(this.BTNDarkTheme_Click);
            // 
            // BTNLightTheme
            // 
            this.BTNLightTheme.Location = new System.Drawing.Point(224, 12);
            this.BTNLightTheme.Name = "BTNLightTheme";
            this.BTNLightTheme.Padding = new System.Windows.Forms.Padding(5);
            this.BTNLightTheme.Size = new System.Drawing.Size(100, 40);
            this.BTNLightTheme.TabIndex = 2;
            this.BTNLightTheme.Text = "Light Theme";
            this.BTNLightTheme.Click += new System.EventHandler(this.BTNLightTheme_Click);
            // 
            // BTNOpenMainForm
            // 
            this.BTNOpenMainForm.Location = new System.Drawing.Point(12, 12);
            this.BTNOpenMainForm.Name = "BTNOpenMainForm";
            this.BTNOpenMainForm.Padding = new System.Windows.Forms.Padding(5);
            this.BTNOpenMainForm.Size = new System.Drawing.Size(100, 40);
            this.BTNOpenMainForm.TabIndex = 0;
            this.BTNOpenMainForm.Text = "Open MainForm";
            this.BTNOpenMainForm.Click += new System.EventHandler(this.BTNOpenMainForm_Click);
            // 
            // darkTabControl1
            // 
            this.darkTabControl1.Controls.Add(this.tabPage1);
            this.darkTabControl1.Controls.Add(this.tabPage2);
            this.darkTabControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkTabControl1.Location = new System.Drawing.Point(369, 385);
            this.darkTabControl1.Name = "darkTabControl1";
            this.darkTabControl1.SelectedIndex = 0;
            this.darkTabControl1.Size = new System.Drawing.Size(417, 53);
            this.darkTabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.tabPage1.Location = new System.Drawing.Point(1, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(415, 29);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.tabPage2.Location = new System.Drawing.Point(1, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(415, 29);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // BTNSystemTheme
            // 
            this.BTNSystemTheme.Location = new System.Drawing.Point(118, 12);
            this.BTNSystemTheme.Name = "BTNSystemTheme";
            this.BTNSystemTheme.Padding = new System.Windows.Forms.Padding(5);
            this.BTNSystemTheme.Size = new System.Drawing.Size(100, 40);
            this.BTNSystemTheme.TabIndex = 4;
            this.BTNSystemTheme.Text = "System Theme";
            this.BTNSystemTheme.Click += new System.EventHandler(this.BTNSystemTheme_Click);
            // 
            // darkDataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.darkDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.darkDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.darkDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.darkDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.darkDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.darkDataGridView1.Location = new System.Drawing.Point(243, 172);
            this.darkDataGridView1.Name = "darkDataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.darkDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.darkDataGridView1.RowTemplate.Height = 25;
            this.darkDataGridView1.Size = new System.Drawing.Size(363, 150);
            this.darkDataGridView1.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // darkScrollBar1
            // 
            this.darkScrollBar1.Location = new System.Drawing.Point(663, 273);
            this.darkScrollBar1.Name = "darkScrollBar1";
            this.darkScrollBar1.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal;
            this.darkScrollBar1.Size = new System.Drawing.Size(75, 85);
            this.darkScrollBar1.TabIndex = 6;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.darkScrollBar1);
            this.Controls.Add(this.darkDataGridView1);
            this.Controls.Add(this.BTNSystemTheme);
            this.Controls.Add(this.darkTabControl1);
            this.Controls.Add(this.BTNOpenMainForm);
            this.Controls.Add(this.BTNLightTheme);
            this.Controls.Add(this.BTNDarkTheme);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Name = "TestForm";
            this.ShowIcon = false;
            this.Text = "TestForm";
            this.darkTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.darkDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.DarkButton BTNDarkTheme;
        private Controls.DarkButton BTNLightTheme;
        private Controls.DarkButton BTNOpenMainForm;
        private Controls.DarkTabControl darkTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Controls.DarkButton BTNSystemTheme;
        private Controls.DarkDataGridView darkDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private Controls.DarkScrollBar darkScrollBar1;
    }
}