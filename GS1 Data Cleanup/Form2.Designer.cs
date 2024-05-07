namespace GS1_Data_Cleanup
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScannerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Computer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbStartID = new System.Windows.Forms.TextBox();
            this.tbEndID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.CardIDsForTheTest = new System.Windows.Forms.RichTextBox();
            this.OrderAsc = new System.Windows.Forms.CheckBox();
            this.btnChangeIDs = new System.Windows.Forms.Button();
            this.btnPushUpdates = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CardID,
            this.ScannerName,
            this.Data,
            this.Expected,
            this.Computer});
            this.dataGridView1.Location = new System.Drawing.Point(0, 51);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(897, 580);
            this.dataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 125;
            // 
            // CardID
            // 
            this.CardID.HeaderText = "CardID";
            this.CardID.MinimumWidth = 6;
            this.CardID.Name = "CardID";
            this.CardID.ReadOnly = true;
            this.CardID.Width = 125;
            // 
            // ScannerName
            // 
            this.ScannerName.HeaderText = "Scanner Name";
            this.ScannerName.MinimumWidth = 6;
            this.ScannerName.Name = "ScannerName";
            this.ScannerName.ReadOnly = true;
            this.ScannerName.Width = 150;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.MinimumWidth = 6;
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Width = 200;
            // 
            // Expected
            // 
            this.Expected.HeaderText = "Expected";
            this.Expected.MinimumWidth = 6;
            this.Expected.Name = "Expected";
            this.Expected.ReadOnly = true;
            this.Expected.Width = 200;
            // 
            // Computer
            // 
            this.Computer.HeaderText = "Computer";
            this.Computer.MinimumWidth = 6;
            this.Computer.Name = "Computer";
            this.Computer.ReadOnly = true;
            this.Computer.Width = 125;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(164, 12);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(118, 31);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "Filter ECHO1";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1023, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 31);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(131, 31);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load Expected";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "CSV";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "CSV files|*.csv|All files|*.*";
            // 
            // tbStartID
            // 
            this.tbStartID.Location = new System.Drawing.Point(91, 25);
            this.tbStartID.Name = "tbStartID";
            this.tbStartID.Size = new System.Drawing.Size(125, 30);
            this.tbStartID.TabIndex = 4;
            // 
            // tbEndID
            // 
            this.tbEndID.Location = new System.Drawing.Point(91, 57);
            this.tbEndID.Name = "tbEndID";
            this.tbEndID.Size = new System.Drawing.Size(125, 30);
            this.tbEndID.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "StartID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "EndID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangeStatus);
            this.groupBox1.Controls.Add(this.tbStartID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbEndID);
            this.groupBox1.Location = new System.Drawing.Point(916, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 134);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unidentified cards";
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Location = new System.Drawing.Point(40, 97);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(176, 31);
            this.btnChangeStatus.TabIndex = 8;
            this.btnChangeStatus.Text = "Change Status";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // CardIDsForTheTest
            // 
            this.CardIDsForTheTest.Location = new System.Drawing.Point(920, 246);
            this.CardIDsForTheTest.Name = "CardIDsForTheTest";
            this.CardIDsForTheTest.Size = new System.Drawing.Size(265, 385);
            this.CardIDsForTheTest.TabIndex = 9;
            this.CardIDsForTheTest.Text = "";
            // 
            // OrderAsc
            // 
            this.OrderAsc.AutoSize = true;
            this.OrderAsc.Location = new System.Drawing.Point(935, 216);
            this.OrderAsc.Name = "OrderAsc";
            this.OrderAsc.Size = new System.Drawing.Size(186, 29);
            this.OrderAsc.TabIndex = 10;
            this.OrderAsc.Text = "Checked For Asc";
            this.OrderAsc.UseVisualStyleBackColor = true;
            this.OrderAsc.CheckedChanged += new System.EventHandler(this.OrderAsc_CheckedChanged);
            // 
            // btnChangeIDs
            // 
            this.btnChangeIDs.Location = new System.Drawing.Point(299, 12);
            this.btnChangeIDs.Name = "btnChangeIDs";
            this.btnChangeIDs.Size = new System.Drawing.Size(121, 31);
            this.btnChangeIDs.TabIndex = 11;
            this.btnChangeIDs.Text = "Change Id\'s";
            this.btnChangeIDs.UseVisualStyleBackColor = true;
            this.btnChangeIDs.Click += new System.EventHandler(this.btnChangeIDs_Click);
            // 
            // btnPushUpdates
            // 
            this.btnPushUpdates.Location = new System.Drawing.Point(607, 12);
            this.btnPushUpdates.Name = "btnPushUpdates";
            this.btnPushUpdates.Size = new System.Drawing.Size(194, 39);
            this.btnPushUpdates.TabIndex = 12;
            this.btnPushUpdates.Text = "Push To Database";
            this.btnPushUpdates.UseVisualStyleBackColor = true;
            this.btnPushUpdates.Visible = false;
            this.btnPushUpdates.Click += new System.EventHandler(this.btnPushUpdates_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 658);
            this.Controls.Add(this.btnPushUpdates);
            this.Controls.Add(this.btnChangeIDs);
            this.Controls.Add(this.OrderAsc);
            this.Controls.Add(this.CardIDsForTheTest);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "Raw data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScannerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Computer;
        private System.Windows.Forms.TextBox tbStartID;
        private System.Windows.Forms.TextBox tbEndID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.RichTextBox CardIDsForTheTest;
        private System.Windows.Forms.CheckBox OrderAsc;
        private System.Windows.Forms.Button btnChangeIDs;
        private System.Windows.Forms.Button btnPushUpdates;
    }
}