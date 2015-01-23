namespace CTTC_ITS_Manage.UserControl
{
    partial class ModelInfoList
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
            this.InfoListlabel = new System.Windows.Forms.Label();
            this.DGVToShow = new System.Windows.Forms.DataGridView();
            this.ListgroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVToShow)).BeginInit();
            this.ListgroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoListlabel
            // 
            this.InfoListlabel.AutoSize = true;
            this.InfoListlabel.Location = new System.Drawing.Point(501, 23);
            this.InfoListlabel.Name = "InfoListlabel";
            this.InfoListlabel.Size = new System.Drawing.Size(38, 14);
            this.InfoListlabel.TabIndex = 0;
            this.InfoListlabel.Text = "label1";
            // 
            // DGVToShow
            // 
            this.DGVToShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVToShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVToShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVToShow.Location = new System.Drawing.Point(3, 18);
            this.DGVToShow.Name = "DGVToShow";
            this.DGVToShow.RowTemplate.Height = 23;
            this.DGVToShow.Size = new System.Drawing.Size(718, 471);
            this.DGVToShow.TabIndex = 1;
            // 
            // ListgroupBox
            // 
            this.ListgroupBox.Controls.Add(this.DGVToShow);
            this.ListgroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ListgroupBox.Location = new System.Drawing.Point(0, 65);
            this.ListgroupBox.Name = "ListgroupBox";
            this.ListgroupBox.Size = new System.Drawing.Size(724, 492);
            this.ListgroupBox.TabIndex = 2;
            this.ListgroupBox.TabStop = false;
            this.ListgroupBox.Text = "信息列表";
            // 
            // ModelInfoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListgroupBox);
            this.Controls.Add(this.InfoListlabel);
            this.Name = "ModelInfoList";
            this.Size = new System.Drawing.Size(724, 557);
            this.Load += new System.EventHandler(this.ModelInfoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVToShow)).EndInit();
            this.ListgroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoListlabel;
        private System.Windows.Forms.DataGridView DGVToShow;
        private System.Windows.Forms.GroupBox ListgroupBox;
    }
}
