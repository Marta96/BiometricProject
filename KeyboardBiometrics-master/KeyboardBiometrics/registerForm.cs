using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardBiometrics
{
    public partial class RegisterForm : Form
    {
        bool isPasswordWritingStarted = false;
        
        List<int> totalTimeList = new List<int>();
        List<int> pressTimeList = new List<int>();
        List<int> seekTimeList = new List<int>();
        List<int> errorsCountList = new List<int>();
        Methods methods;

        public RegisterForm()
        {
            InitializeComponent();
            methods = new Methods(totalTimeList, pressTimeList, seekTimeList, errorsCountList,
             isPasswordWritingStarted);
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            KeyboardBiometrics keyboardBiometrics = new KeyboardBiometrics();
            this.Hide();
            keyboardBiometrics.Show();
        }

        

        private void AddRowToDataBase(string login, string pass, double totaltime, double presstime, double seektime, double errors)
        {
            // KeyboardBiometricsDatabaseDataSet db = new KeyboardBiometricsDatabaseDataSet();

            //Console.WriteLine(db.DataSetName);
            //KeyboardBiometricsDatabaseConnectionString
        }

        private void loginBox_Click(object sender, EventArgs e)
        {
            loginBox.Clear();
        }
        
        private void pass1Box_TextChanged(object sender, EventArgs e)
        {
            pass1Box.Clear();
        }

        private void pass2Box_TextChanged(object sender, EventArgs e)
        {
            pass2Box.Clear();
        }

        private void submitRegisterButton_Click(object sender, EventArgs e)
        {
            if(pass1Box.Text.Length < 12)
            {
                methods.ClearData();
                pass1Box.Text = "Password is too short";
            }
            else if(pass1Box.Text != pass2Box.Text)
            {
                methods.ClearData();
                pass1Box.Text = "Passwords must match";
                pass2Box.Text = "Passwords must match";

            }
            else if (loginBox.Text == null || loginBox.Text == "")
            {
                loginBox.Text = "Login cannot be empty";
            }
            else
            {
                var averageTotalTime = totalTimeList.Average();
                Console.WriteLine(averageTotalTime);
                var averagePressTime = pressTimeList.Average();
                Console.WriteLine(averagePressTime);
                var averageSeekTime = seekTimeList.Average();
                Console.WriteLine(averageSeekTime);
                var averageErrorsCount = errorsCountList.Average();
                Console.WriteLine(averageErrorsCount);
                AddRowToDataBase(loginBox.Text, pass1Box.Text, averageTotalTime, averagePressTime, averageSeekTime, averageErrorsCount);
                RegisteredWindow registeredWindow = new RegisteredWindow();
                this.Hide();
                registeredWindow.Show();
            }

        }

        private void pass1Box_KeyDown(object sender, KeyEventArgs e)
        {
            methods.KeyDown(e);
        }

        private void pass1Box_Leave(object sender, EventArgs e)
        {         
            methods.Leave();
        }

        private void pass1Box_KeyUp(object sender, KeyEventArgs e)
        {
            methods.KeyUp(e);
        }
    }
}
