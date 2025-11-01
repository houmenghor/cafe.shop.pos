namespace CafeShopManagement.Forms
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        // UI controls used by ReportsForm.cs
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.DataGridView dgvSummary;
        private System.Windows.Forms.DataGridView dgvTop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            lblFrom = new Label();
            dtFrom = new DateTimePicker();
            lblTo = new Label();
            dtTo = new DateTimePicker();
            lblGroup = new Label();
            cbGroup = new ComboBox();
            btnLoad = new Button();
            btnPrint = new Button();
            splitMain = new SplitContainer();
            dgvSummary = new DataGridView();
            dgvTop = new DataGridView();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSummary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTop).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(44, 62, 80);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblFrom);
            panelHeader.Controls.Add(dtFrom);
            panelHeader.Controls.Add(lblTo);
            panelHeader.Controls.Add(dtTo);
            panelHeader.Controls.Add(lblGroup);
            panelHeader.Controls.Add(cbGroup);
            panelHeader.Controls.Add(btnLoad);
            panelHeader.Controls.Add(btnPrint);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1150, 64);
            panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(151, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊  Reports";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.ForeColor = Color.White;
            lblFrom.Location = new Point(202, 23);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(50, 20);
            lblFrom.TabIndex = 1;
            lblFrom.Text = "From :";
            // 
            // dtFrom
            // 
            dtFrom.Format = DateTimePickerFormat.Short;
            dtFrom.Location = new Point(255, 20);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new Size(110, 27);
            dtFrom.TabIndex = 2;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.ForeColor = Color.White;
            lblTo.Location = new Point(393, 23);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(32, 20);
            lblTo.TabIndex = 3;
            lblTo.Text = "To :";
            // 
            // dtTo
            // 
            dtTo.Format = DateTimePickerFormat.Short;
            dtTo.Location = new Point(426, 20);
            dtTo.Name = "dtTo";
            dtTo.Size = new Size(110, 27);
            dtTo.TabIndex = 4;
            // 
            // lblGroup
            // 
            lblGroup.AutoSize = true;
            lblGroup.ForeColor = Color.White;
            lblGroup.Location = new Point(549, 23);
            lblGroup.Name = "lblGroup";
            lblGroup.Size = new Size(57, 20);
            lblGroup.TabIndex = 5;
            lblGroup.Text = "Group :";
            // 
            // cbGroup
            // 
            cbGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGroup.Location = new Point(609, 20);
            cbGroup.Name = "cbGroup";
            cbGroup.Size = new Size(130, 28);
            cbGroup.TabIndex = 6;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(52, 152, 219);
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.ForeColor = Color.White;
            btnLoad.Location = new Point(746, 18);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(80, 28);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(46, 204, 113);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(836, 18);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(80, 28);
            btnPrint.TabIndex = 8;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = false;
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 64);
            splitMain.Name = "splitMain";
            splitMain.Orientation = Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(dgvSummary);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(dgvTop);
            splitMain.Size = new Size(1150, 586);
            splitMain.SplitterDistance = 416;
            splitMain.TabIndex = 0;
            // 
            // dgvSummary
            // 
            dgvSummary.AllowUserToAddRows = false;
            dgvSummary.AllowUserToDeleteRows = false;
            dgvSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSummary.ColumnHeadersHeight = 29;
            dgvSummary.Dock = DockStyle.Fill;
            dgvSummary.Location = new Point(0, 0);
            dgvSummary.Name = "dgvSummary";
            dgvSummary.ReadOnly = true;
            dgvSummary.RowHeadersVisible = false;
            dgvSummary.RowHeadersWidth = 51;
            dgvSummary.Size = new Size(1150, 416);
            dgvSummary.TabIndex = 0;
            // 
            // dgvTop
            // 
            dgvTop.AllowUserToAddRows = false;
            dgvTop.AllowUserToDeleteRows = false;
            dgvTop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTop.ColumnHeadersHeight = 29;
            dgvTop.Dock = DockStyle.Fill;
            dgvTop.Location = new Point(0, 0);
            dgvTop.Name = "dgvTop";
            dgvTop.ReadOnly = true;
            dgvTop.RowHeadersVisible = false;
            dgvTop.RowHeadersWidth = 51;
            dgvTop.Size = new Size(1150, 166);
            dgvTop.TabIndex = 0;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1150, 650);
            Controls.Add(splitMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportsForm";
            Text = "ReportsForm";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSummary).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTop).EndInit();
            ResumeLayout(false);
        }
        #endregion
    }
}
