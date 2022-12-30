namespace MosquittoSubscriber
{
    partial class AppA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppA));
            this.light_on = new System.Windows.Forms.PictureBox();
            this.light_off = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.light_on)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.light_off)).BeginInit();
            this.SuspendLayout();
            // 
            // light_on
            // 
            this.light_on.Image = ((System.Drawing.Image)(resources.GetObject("light_on.Image")));
            this.light_on.Location = new System.Drawing.Point(131, 59);
            this.light_on.Name = "light_on";
            this.light_on.Size = new System.Drawing.Size(139, 145);
            this.light_on.TabIndex = 0;
            this.light_on.TabStop = false;
            this.light_on.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // light_off
            // 
            this.light_off.Image = ((System.Drawing.Image)(resources.GetObject("light_off.Image")));
            this.light_off.Location = new System.Drawing.Point(131, 59);
            this.light_off.Name = "light_off";
            this.light_off.Size = new System.Drawing.Size(139, 145);
            this.light_off.TabIndex = 1;
            this.light_off.TabStop = false;
            this.light_off.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // AppA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 274);
            this.Controls.Add(this.light_off);
            this.Controls.Add(this.light_on);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AppA";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.light_on)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.light_off)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox light_on;
        private System.Windows.Forms.PictureBox light_off;
    }
}

