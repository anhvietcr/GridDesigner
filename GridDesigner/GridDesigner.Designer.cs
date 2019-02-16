namespace GridDesigner
{
    partial class GridDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridDesigner));
            this.txt_vertical_ruler = new System.Windows.Forms.Label();
            this.txt_horizontal_ruler = new System.Windows.Forms.Label();
            this.isan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_vertical_ruler
            // 
            this.txt_vertical_ruler.AutoSize = true;
            this.txt_vertical_ruler.BackColor = System.Drawing.Color.LawnGreen;
            this.txt_vertical_ruler.Font = new System.Drawing.Font("Times New Roman", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_vertical_ruler.ForeColor = System.Drawing.Color.Chartreuse;
            this.txt_vertical_ruler.Location = new System.Drawing.Point(0, 15);
            this.txt_vertical_ruler.Name = "txt_vertical_ruler";
            this.txt_vertical_ruler.Size = new System.Drawing.Size(0, 8);
            this.txt_vertical_ruler.TabIndex = 2;
            this.txt_vertical_ruler.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txt_vertical_ruler_MouseUp);
            // 
            // txt_horizontal_ruler
            // 
            this.txt_horizontal_ruler.AutoSize = true;
            this.txt_horizontal_ruler.BackColor = System.Drawing.Color.LawnGreen;
            this.txt_horizontal_ruler.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_horizontal_ruler.ForeColor = System.Drawing.Color.Chartreuse;
            this.txt_horizontal_ruler.Location = new System.Drawing.Point(20, 0);
            this.txt_horizontal_ruler.Name = "txt_horizontal_ruler";
            this.txt_horizontal_ruler.Size = new System.Drawing.Size(0, 14);
            this.txt_horizontal_ruler.TabIndex = 3;
            this.txt_horizontal_ruler.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txt_horizontal_ruler_MouseUp);
            // 
            // isan
            // 
            this.isan.AutoSize = true;
            this.isan.BackColor = System.Drawing.Color.LawnGreen;
            this.isan.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.isan.Font = new System.Drawing.Font("Wide Latin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isan.ForeColor = System.Drawing.Color.Red;
            this.isan.Location = new System.Drawing.Point(0, 0);
            this.isan.Name = "isan";
            this.isan.Size = new System.Drawing.Size(17, 19);
            this.isan.TabIndex = 4;
            this.isan.Text = "+";
            this.isan.DoubleClick += new System.EventHandler(this.isan_DoubleClick);
            this.isan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.isan_MouseDown);
            this.isan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.isan_MouseMove);
            // 
            // GridDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LawnGreen;
            this.ClientSize = new System.Drawing.Size(50, 50);
            this.Controls.Add(this.isan);
            this.Controls.Add(this.txt_horizontal_ruler);
            this.Controls.Add(this.txt_vertical_ruler);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "GridDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GridDesigner";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.LawnGreen;
            this.Deactivate += new System.EventHandler(this.GridDesigner_Deactivate);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridDesigner_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GridDesigner_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label txt_vertical_ruler;
        private System.Windows.Forms.Label txt_horizontal_ruler;
        private System.Windows.Forms.Label isan;
    }
}