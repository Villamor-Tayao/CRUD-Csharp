namespace accountCreate {
    partial class Form2 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(118, 198);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 22;
            label7.Text = "EMAIL";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(69, 240);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 21;
            label6.Text = "CONTACT NO#";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(103, 159);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 20;
            label5.Text = "ADDRESS";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(127, 114);
            label4.Name = "label4";
            label4.Size = new Size(32, 20);
            label4.TabIndex = 11;
            label4.Text = "AGE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(86, 77);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 19;
            label3.Text = "FIRST NAME";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(353, 77);
            label2.Name = "label2";
            label2.Size = new Size(74, 19);
            label2.TabIndex = 12;
            label2.Text = "LAST NAME";
            // 
            // button2
            // 
            button2.BackColor = Color.LightBlue;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(400, 319);
            button2.Name = "button2";
            button2.Size = new Size(91, 43);
            button2.TabIndex = 24;
            button2.Text = "CANCEL";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.PaleGreen;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(191, 319);
            button1.Name = "button1";
            button1.Size = new Size(91, 43);
            button1.TabIndex = 23;
            button1.Text = "CREATE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(182, 74);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(131, 23);
            textBox1.TabIndex = 25;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(443, 74);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(131, 23);
            textBox2.TabIndex = 26;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(179, 111);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(53, 23);
            textBox3.TabIndex = 27;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(179, 156);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(131, 23);
            textBox4.TabIndex = 28;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(179, 195);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(131, 23);
            textBox5.TabIndex = 29;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(179, 237);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(131, 23);
            textBox6.TabIndex = 30;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(679, 400);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "Form2";
            Text = "CREATE FORM";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
    }
}