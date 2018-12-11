namespace KeyboardBiometrics
{
    partial class RegisterForm
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
            this.buttonback = new System.Windows.Forms.Button();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.pass1Box = new System.Windows.Forms.TextBox();
            this.pass2Box = new System.Windows.Forms.TextBox();
            this.submitRegisterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonback
            // 
            this.buttonback.Location = new System.Drawing.Point(12, 12);
            this.buttonback.Name = "buttonback";
            this.buttonback.Size = new System.Drawing.Size(102, 43);
            this.buttonback.TabIndex = 1;
            this.buttonback.Text = "Back";
            this.buttonback.UseVisualStyleBackColor = true;
            this.buttonback.Click += new System.EventHandler(this.buttonback_Click);
            // 
            // loginBox
            // 
            this.loginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loginBox.Location = new System.Drawing.Point(246, 89);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(299, 35);
            this.loginBox.TabIndex = 2;
            this.loginBox.Text = "Login";
            this.loginBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.loginBox.Click += new System.EventHandler(this.loginBox_Click);
            // 
            // pass1Box
            // 
            this.pass1Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pass1Box.Location = new System.Drawing.Point(246, 190);
            this.pass1Box.Name = "pass1Box";
            this.pass1Box.Size = new System.Drawing.Size(299, 35);
            this.pass1Box.TabIndex = 3;
            this.pass1Box.Text = "Password (min 12)";
            this.pass1Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pass1Box.Click += new System.EventHandler(this.pass1Box_TextChanged);
            this.pass1Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pass1Box_KeyDown);
            this.pass1Box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pass1Box_KeyUp);
            this.pass1Box.Leave += new System.EventHandler(this.pass1Box_Leave);
            // 
            // pass2Box
            // 
            this.pass2Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pass2Box.Location = new System.Drawing.Point(246, 244);
            this.pass2Box.Name = "pass2Box";
            this.pass2Box.Size = new System.Drawing.Size(299, 35);
            this.pass2Box.TabIndex = 4;
            this.pass2Box.Text = "Repeat password";
            this.pass2Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pass2Box.Click += new System.EventHandler(this.pass2Box_TextChanged);
            this.pass2Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pass1Box_KeyDown);
            this.pass2Box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pass1Box_KeyUp);
            this.pass2Box.Leave += new System.EventHandler(this.pass1Box_Leave);
            // 
            // submitRegisterButton
            // 
            this.submitRegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.submitRegisterButton.Location = new System.Drawing.Point(277, 340);
            this.submitRegisterButton.Name = "submitRegisterButton";
            this.submitRegisterButton.Size = new System.Drawing.Size(236, 65);
            this.submitRegisterButton.TabIndex = 5;
            this.submitRegisterButton.Text = "Register";
            this.submitRegisterButton.UseVisualStyleBackColor = true;
            this.submitRegisterButton.Click += new System.EventHandler(this.submitRegisterButton_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.submitRegisterButton);
            this.Controls.Add(this.pass2Box);
            this.Controls.Add(this.pass1Box);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.buttonback);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonback;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.TextBox pass1Box;
        private System.Windows.Forms.TextBox pass2Box;
        private System.Windows.Forms.Button submitRegisterButton;
    }
}