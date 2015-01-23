namespace CTTC_ITS_Manage.UserControl
{
    partial class StreetLineControl
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
            this.StreetLinegroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.StreetLinegroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StreetLinegroupBox
            // 
            this.StreetLinegroupBox.Controls.Add(this.label1);
            this.StreetLinegroupBox.Controls.Add(this.shapeContainer1);
            this.StreetLinegroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StreetLinegroupBox.Location = new System.Drawing.Point(0, 35);
            this.StreetLinegroupBox.Name = "StreetLinegroupBox";
            this.StreetLinegroupBox.Size = new System.Drawing.Size(1050, 593);
            this.StreetLinegroupBox.TabIndex = 2;
            this.StreetLinegroupBox.TabStop = false;
            this.StreetLinegroupBox.Text = "公交线路直线图";
            this.StreetLinegroupBox.Enter += new System.EventHandler(this.StreetLinegroupBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 18);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1044, 572);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.lineShape2.BorderWidth = 8;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 10;
            this.lineShape2.X2 = 1100;
            this.lineShape2.Y1 = 360;
            this.lineShape2.Y2 = 360;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.lineShape1.BorderWidth = 8;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 10;
            this.lineShape1.X2 = 1100;
            this.lineShape1.Y1 = 180;
            this.lineShape1.Y2 = 180;
            // 
            // StreetLineControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StreetLinegroupBox);
            this.Name = "StreetLineControl";
            this.Size = new System.Drawing.Size(1050, 628);
            this.Load += new System.EventHandler(this.StreetLineControl_Load);
            this.StreetLinegroupBox.ResumeLayout(false);
            this.StreetLinegroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox StreetLinegroupBox;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Label label1;
    }
}
