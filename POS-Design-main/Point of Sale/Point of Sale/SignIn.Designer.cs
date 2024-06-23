namespace Point_of_Sale
{
    partial class SignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            panel1 = new Panel();
            pbExit = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            txtPassword = new TextBox();
            panel2 = new Panel();
            label2 = new Label();
            txtUsername = new TextBox();
            label3 = new Label();
            btnSignIn = new Button();
            label4 = new Label();
            linkSignUp = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbExit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSeaGreen;
            panel1.Controls.Add(pbExit);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-1, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(583, 215);
            panel1.TabIndex = 1;
            // 
            // pbExit
            // 
            pbExit.BackgroundImage = (Image)resources.GetObject("pbExit.BackgroundImage");
            pbExit.BackgroundImageLayout = ImageLayout.Stretch;
            pbExit.Location = new Point(520, 2);
            pbExit.Name = "pbExit";
            pbExit.Size = new Size(60, 60);
            pbExit.TabIndex = 34;
            pbExit.TabStop = false;
            pbExit.Click += pbExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(196, 148);
            label1.Name = "label1";
            label1.Size = new Size(182, 29);
            label1.TabIndex = 1;
            label1.Text = "Point of Sale";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(226, 28);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(119, 115);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkSlateGray;
            panel3.Location = new Point(71, 497);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(450, 5);
            panel3.TabIndex = 29;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.AliceBlue;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(71, 467);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Enter password";
            txtPassword.Size = new Size(450, 30);
            txtPassword.TabIndex = 27;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkSlateGray;
            panel2.Location = new Point(71, 398);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(450, 5);
            panel2.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LightSeaGreen;
            label2.Location = new Point(57, 432);
            label2.Name = "label2";
            label2.Size = new Size(144, 29);
            label2.TabIndex = 28;
            label2.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.AliceBlue;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(71, 368);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Enter username";
            txtUsername.Size = new Size(450, 30);
            txtUsername.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LightSeaGreen;
            label3.Location = new Point(57, 337);
            label3.Name = "label3";
            label3.Size = new Size(148, 29);
            label3.TabIndex = 24;
            label3.Text = "Username";
            // 
            // btnSignIn
            // 
            btnSignIn.BackColor = Color.LightSeaGreen;
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.Font = new Font("Verdana", 12F, FontStyle.Bold);
            btnSignIn.ForeColor = Color.White;
            btnSignIn.Location = new Point(111, 587);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(346, 50);
            btnSignIn.TabIndex = 30;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = false;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkSlateGray;
            label4.Location = new Point(111, 638);
            label4.Name = "label4";
            label4.Size = new Size(249, 25);
            label4.TabIndex = 32;
            label4.Text = "Don't have an account?";
            // 
            // linkSignUp
            // 
            linkSignUp.AutoSize = true;
            linkSignUp.Font = new Font("Verdana", 10F);
            linkSignUp.ForeColor = Color.LightSeaGreen;
            linkSignUp.LinkColor = Color.LightSeaGreen;
            linkSignUp.Location = new Point(367, 638);
            linkSignUp.Name = "linkSignUp";
            linkSignUp.Size = new Size(91, 25);
            linkSignUp.TabIndex = 33;
            linkSignUp.TabStop = true;
            linkSignUp.Text = "Sign Up";
            linkSignUp.LinkClicked += linkSignUp_LinkClicked;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(581, 833);
            Controls.Add(linkSignUp);
            Controls.Add(label4);
            Controls.Add(btnSignIn);
            Controls.Add(panel3);
            Controls.Add(txtPassword);
            Controls.Add(panel2);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(panel1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "SignIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SignIn";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbExit).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private TextBox txtPassword;
        private Panel panel2;
        private Label label2;
        private TextBox txtUsername;
        private Label label3;
        private Button btnSignIn;
        private Label label4;
        private LinkLabel linkSignUp;
        private PictureBox pbExit;
    }
}