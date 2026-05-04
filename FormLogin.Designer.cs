namespace DBP2Concept
{
    partial class FormLogin
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
            label4 = new Label();
            label3 = new Label();
            maskedTextBox3 = new MaskedTextBox();
            maskedTextBox2 = new MaskedTextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Geologica Medium", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(248, 243);
            label4.Name = "label4";
            label4.Size = new Size(113, 33);
            label4.TabIndex = 27;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Geologica Medium", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(248, 204);
            label3.Name = "label3";
            label3.Size = new Size(71, 33);
            label3.TabIndex = 25;
            label3.Text = "Email";
            // 
            // maskedTextBox3
            // 
            maskedTextBox3.Location = new Point(372, 253);
            maskedTextBox3.Name = "maskedTextBox3";
            maskedTextBox3.Size = new Size(350, 23);
            maskedTextBox3.TabIndex = 24;
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Location = new Point(372, 213);
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(350, 23);
            maskedTextBox2.TabIndex = 23;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources.db_new;
            pictureBox1.Location = new Point(276, 111);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(152, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.left;
            pictureBox2.Location = new Point(2, -225);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(193, 900);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 22;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Geologica SemiBold", 25F, FontStyle.Bold);
            label1.Location = new Point(347, 124);
            label1.Name = "label1";
            label1.Size = new Size(445, 64);
            label1.TabIndex = 19;
            label1.Text = "Welcome back!";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Geologica", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(327, 295);
            button1.Name = "button1";
            button1.Size = new Size(350, 43);
            button1.TabIndex = 20;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(maskedTextBox3);
            Controls.Add(maskedTextBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormLogin";
            Text = "FormLogin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private MaskedTextBox maskedTextBox3;
        private MaskedTextBox maskedTextBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Button button1;
    }
}