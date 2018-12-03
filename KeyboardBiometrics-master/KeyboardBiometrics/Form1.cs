using System;
using System.Windows.Forms;

namespace KeyboardBiometrics
{
    public partial class KeyboardBiometrics : Form
    {
        public KeyboardBiometrics()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
            this.Hide();
        }
    }
}
