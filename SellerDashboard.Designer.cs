namespace DBP2Concept
{
    partial class SellerDashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            button5 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(32, 90);
            listView1.Name = "listView1";
            listView1.Size = new Size(735, 328);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button5
            // 
            button5.Location = new Point(405, 29);
            button5.Name = "button5";
            button5.Size = new Size(176, 39);
            button5.TabIndex = 7;
            button5.Text = "UPDATE";
            button5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(591, 29);
            button1.Name = "button1";
            button1.Size = new Size(176, 39);
            button1.TabIndex = 8;
            button1.Text = "DELETE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(218, 29);
            button2.Name = "button2";
            button2.Size = new Size(176, 39);
            button2.TabIndex = 9;
            button2.Text = "SELECT";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(32, 29);
            button3.Name = "button3";
            button3.Size = new Size(176, 39);
            button3.TabIndex = 10;
            button3.Text = "INSERT";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button5);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private Button button5;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
