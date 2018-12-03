namespace KeyboardBiometrics
{
    partial class LoggedWindow
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
            this.labelHello = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelHello
            // 
            this.labelHello.AutoSize = true;
            this.labelHello.Font = new System.Drawing.Font("Centaur", 52F, System.Drawing.FontStyle.Bold);
            this.labelHello.Location = new System.Drawing.Point(163, 52);
            this.labelHello.Name = "labelHello";
            this.labelHello.Size = new System.Drawing.Size(186, 79);
            this.labelHello.TabIndex = 0;
            this.labelHello.Text = "Hello";
            this.labelHello.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Centaur", 52F, System.Drawing.FontStyle.Bold);
            this.labelName.Location = new System.Drawing.Point(163, 147);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(173, 79);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // buttonback
            // 
            this.buttonback.Location = new System.Drawing.Point(11, 11);
            this.buttonback.Margin = new System.Windows.Forms.Padding(2);
            this.buttonback.Name = "buttonback";
            this.buttonback.Size = new System.Drawing.Size(68, 28);
            this.buttonback.TabIndex = 3;
            this.buttonback.Text = "Back";
            this.buttonback.UseVisualStyleBackColor = true;
            this.buttonback.Click += new System.EventHandler(this.buttonback_Click);
            // 
            // LoggedWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.buttonback);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelHello);
            this.Name = "LoggedWindow";
            this.Text = "loggedWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHello;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonback;
    }
}