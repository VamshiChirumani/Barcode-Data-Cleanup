namespace GS1_Data_Cleanup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lbTests = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SymbolSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScannerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScannerData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComputerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnRaw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Connection:";
            // 
            // txtConnection
            // 
            this.txtConnection.Location = new System.Drawing.Point(123, 14);
            this.txtConnection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(488, 26);
            this.txtConnection.TabIndex = 2;
            this.txtConnection.Text = "Server=DESKTOP-N0T5PRC\\SQLEXPRESS;Database=gs1_2023;Trusted_Connection=True;";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(618, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(78, 35);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lbTests
            // 
            this.lbTests.FormattingEnabled = true;
            this.lbTests.ItemHeight = 20;
            this.lbTests.Location = new System.Drawing.Point(1108, 10);
            this.lbTests.Name = "lbTests";
            this.lbTests.Size = new System.Drawing.Size(186, 564);
            this.lbTests.TabIndex = 5;
            this.lbTests.DoubleClick += new System.EventHandler(this.lbTests_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 634);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Status:";
            // 
            // lbStatus
            // 
            this.lbStatus.FormattingEnabled = true;
            this.lbStatus.ItemHeight = 20;
            this.lbStatus.Location = new System.Drawing.Point(96, 634);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(1186, 44);
            this.lbStatus.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TestName,
            this.SymbolSet,
            this.ScannerName,
            this.DateTime,
            this.ScannerData,
            this.ComputerName});
            this.dataGridView1.Location = new System.Drawing.Point(12, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1078, 529);
            this.dataGridView1.TabIndex = 8;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 80;
            // 
            // TestName
            // 
            this.TestName.HeaderText = "Test Name";
            this.TestName.Name = "TestName";
            // 
            // SymbolSet
            // 
            this.SymbolSet.HeaderText = "Card ID";
            this.SymbolSet.Name = "SymbolSet";
            this.SymbolSet.Width = 110;
            // 
            // ScannerName
            // 
            this.ScannerName.HeaderText = "Scanner Name";
            this.ScannerName.Name = "ScannerName";
            this.ScannerName.Width = 75;
            // 
            // DateTime
            // 
            this.DateTime.HeaderText = "DateTime";
            this.DateTime.Name = "DateTime";
            this.DateTime.Width = 140;
            // 
            // ScannerData
            // 
            this.ScannerData.HeaderText = "Data";
            this.ScannerData.Name = "ScannerData";
            this.ScannerData.Width = 410;
            // 
            // ComputerName
            // 
            this.ComputerName.HeaderText = "Computer Name";
            this.ComputerName.Name = "ComputerName";
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(702, 10);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(111, 35);
            this.btnProcess.TabIndex = 9;
            this.btnProcess.Text = "(1) Load Test";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnReload
            // 
            this.btnReload.Enabled = false;
            this.btnReload.Location = new System.Drawing.Point(1108, 580);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(186, 36);
            this.btnReload.TabIndex = 10;
            this.btnReload.Text = "Update Tests";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnFix
            // 
            this.btnFix.Location = new System.Drawing.Point(957, 10);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(137, 35);
            this.btnFix.TabIndex = 11;
            this.btnFix.Text = "(3) Fix Card IDs";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "(2) Fix card IDs";
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(819, 10);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(132, 35);
            this.btnHide.TabIndex = 13;
            this.btnHide.Text = "(2b) Hide Cards";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnRaw
            // 
            this.btnRaw.Enabled = false;
            this.btnRaw.Location = new System.Drawing.Point(819, 51);
            this.btnRaw.Name = "btnRaw";
            this.btnRaw.Size = new System.Drawing.Size(132, 30);
            this.btnRaw.TabIndex = 14;
            this.btnRaw.Text = "Show Raw";
            this.btnRaw.UseVisualStyleBackColor = true;
            this.btnRaw.Click += new System.EventHandler(this.btnRaw_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 692);
            this.Controls.Add(this.btnRaw);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFix);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTests);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConnection);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GS1 Data Cleanup App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox lbTests;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SymbolSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScannerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScannerData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComputerName;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnRaw;
    }
}

