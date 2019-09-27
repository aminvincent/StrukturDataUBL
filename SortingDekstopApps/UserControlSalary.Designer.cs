namespace SortingDekstopApps
{
    partial class UserControlSalary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSalary));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridSalary = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdSortBySalary = new System.Windows.Forms.RadioButton();
            this.rdSortByName = new System.Windows.Forms.RadioButton();
            this.rdSortByCode = new System.Windows.Forms.RadioButton();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSalary)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator1,
            this.btnEdit,
            this.toolStripSeparator4,
            this.btnRefresh,
            this.toolStripSeparator2,
            this.btnDelete,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(681, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 22);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(47, 22);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(66, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.ToolTipText = "toolStripButton1";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 95);
            this.panel1.TabIndex = 4;
            // 
            // dataGridSalary
            // 
            this.dataGridSalary.AllowUserToAddRows = false;
            this.dataGridSalary.AllowUserToDeleteRows = false;
            this.dataGridSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridSalary.Location = new System.Drawing.Point(0, 120);
            this.dataGridSalary.Name = "dataGridSalary";
            this.dataGridSalary.ReadOnly = true;
            this.dataGridSalary.Size = new System.Drawing.Size(681, 219);
            this.dataGridSalary.TabIndex = 5;
            this.dataGridSalary.DoubleClick += new System.EventHandler(this.DataGridSalary_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdSortBySalary);
            this.groupBox1.Controls.Add(this.rdSortByName);
            this.groupBox1.Controls.Add(this.rdSortByCode);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 61);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Group Sorting Salary";
            // 
            // rdSortBySalary
            // 
            this.rdSortBySalary.AutoSize = true;
            this.rdSortBySalary.Location = new System.Drawing.Point(244, 25);
            this.rdSortBySalary.Name = "rdSortBySalary";
            this.rdSortBySalary.Size = new System.Drawing.Size(104, 17);
            this.rdSortBySalary.TabIndex = 7;
            this.rdSortBySalary.TabStop = true;
            this.rdSortBySalary.Text = "Sort by Salary";
            this.rdSortBySalary.UseVisualStyleBackColor = true;
            this.rdSortBySalary.CheckedChanged += new System.EventHandler(this.RdSortBySalary_CheckedChanged);
            // 
            // rdSortByName
            // 
            this.rdSortByName.AutoSize = true;
            this.rdSortByName.Location = new System.Drawing.Point(126, 25);
            this.rdSortByName.Name = "rdSortByName";
            this.rdSortByName.Size = new System.Drawing.Size(101, 17);
            this.rdSortByName.TabIndex = 6;
            this.rdSortByName.TabStop = true;
            this.rdSortByName.Text = "Sort by Name";
            this.rdSortByName.UseVisualStyleBackColor = true;
            this.rdSortByName.CheckedChanged += new System.EventHandler(this.RdSortByName_CheckedChanged);
            // 
            // rdSortByCode
            // 
            this.rdSortByCode.AutoSize = true;
            this.rdSortByCode.Location = new System.Drawing.Point(9, 25);
            this.rdSortByCode.Name = "rdSortByCode";
            this.rdSortByCode.Size = new System.Drawing.Size(98, 17);
            this.rdSortByCode.TabIndex = 5;
            this.rdSortByCode.TabStop = true;
            this.rdSortByCode.Text = "Sort by Code";
            this.rdSortByCode.UseVisualStyleBackColor = true;
            this.rdSortByCode.CheckedChanged += new System.EventHandler(this.RdSortByCode_CheckedChanged);
            // 
            // UserControlSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridSalary);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UserControlSalary";
            this.Size = new System.Drawing.Size(681, 339);
            this.Load += new System.EventHandler(this.UserControlSalary_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSalary)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridSalary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdSortBySalary;
        private System.Windows.Forms.RadioButton rdSortByName;
        private System.Windows.Forms.RadioButton rdSortByCode;
    }
}
