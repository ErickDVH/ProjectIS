namespace MosquittoPubAndSub
{
    partial class AppB
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
            this.ON = new System.Windows.Forms.Button();
            this.OFF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ON
            // 
            this.ON.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ON.Location = new System.Drawing.Point(194, 98);
            this.ON.Name = "ON";
            this.ON.Size = new System.Drawing.Size(173, 85);
            this.ON.TabIndex = 0;
            this.ON.Text = "Light ON";
            this.ON.UseVisualStyleBackColor = true;
            this.ON.Click += new System.EventHandler(this.ON_Click);
            // 
            // OFF
            // 
            this.OFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OFF.Location = new System.Drawing.Point(194, 223);
            this.OFF.Name = "OFF";
            this.OFF.Size = new System.Drawing.Size(173, 85);
            this.OFF.TabIndex = 1;
            this.OFF.Text = "Light OFF";
            this.OFF.UseVisualStyleBackColor = true;
            // 
            // AppB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 411);
            this.Controls.Add(this.OFF);
            this.Controls.Add(this.ON);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AppB";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ON;
        private System.Windows.Forms.Button OFF;
    }
}

