namespace TestApplication
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
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.postButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.getProduct = new System.Windows.Forms.Button();
            this.list = new System.Windows.Forms.ListBox();
            this.price = new System.Windows.Forms.Label();
            this.category = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.getAllButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(202, 295);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 31;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(65, 339);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(366, 84);
            this.listBox1.TabIndex = 30;
            // 
            // postButton
            // 
            this.postButton.Location = new System.Drawing.Point(514, 294);
            this.postButton.Name = "postButton";
            this.postButton.Size = new System.Drawing.Size(119, 23);
            this.postButton.TabIndex = 29;
            this.postButton.Text = "POST (Create)";
            this.postButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(514, 339);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(119, 23);
            this.updateButton.TabIndex = 28;
            this.updateButton.Text = "PUT (Update)";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(514, 384);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(119, 23);
            this.deleteButton.TabIndex = 27;
            this.deleteButton.Text = "DEL (Delete)";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // getProduct
            // 
            this.getProduct.Location = new System.Drawing.Point(65, 294);
            this.getProduct.Name = "getProduct";
            this.getProduct.Size = new System.Drawing.Size(115, 23);
            this.getProduct.TabIndex = 26;
            this.getProduct.Text = "Get Data (?)";
            this.getProduct.UseVisualStyleBackColor = true;
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.ItemHeight = 16;
            this.list.Location = new System.Drawing.Point(65, 82);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(366, 180);
            this.list.TabIndex = 25;
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Location = new System.Drawing.Point(446, 197);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(49, 16);
            this.price.TabIndex = 24;
            this.price.Text = "Parent:";
            // 
            // category
            // 
            this.category.AutoSize = true;
            this.category.Location = new System.Drawing.Point(446, 159);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(92, 16);
            this.category.TabIndex = 23;
            this.category.Text = "Creation Data:";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(446, 118);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(55, 16);
            this.name.TabIndex = 22;
            this.name.Text = "Content:";
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(446, 82);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(21, 16);
            this.id.TabIndex = 21;
            this.id.Text = "Id:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(555, 118);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(222, 22);
            this.textBox4.TabIndex = 20;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(555, 191);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(555, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 17;
            // 
            // getAllButton
            // 
            this.getAllButton.Location = new System.Drawing.Point(65, 28);
            this.getAllButton.Name = "getAllButton";
            this.getAllButton.Size = new System.Drawing.Size(138, 23);
            this.getAllButton.TabIndex = 16;
            this.getAllButton.Text = " Get All Data";
            this.getAllButton.UseVisualStyleBackColor = true;
            this.getAllButton.Click += new System.EventHandler(this.getAllButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(555, 154);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(446, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Res Type:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(555, 228);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.postButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.getProduct);
            this.Controls.Add(this.list);
            this.Controls.Add(this.price);
            this.Controls.Add(this.category);
            this.Controls.Add(this.name);
            this.Controls.Add(this.id);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.getAllButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button postButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button getProduct;
        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label category;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button getAllButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
    }
}

