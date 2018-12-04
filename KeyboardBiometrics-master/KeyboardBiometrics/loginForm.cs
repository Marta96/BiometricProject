using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KeyboardBiometrics
{
    public partial class LoginForm : Form
    {
        bool isPasswordWritingStarted = false;
        List<int> totalTimeList = new List<int>();
        List<int> pressTimeList = new List<int>();
        List<int> seekTimeList = new List<int>();
        List<int> errorsCountList = new List<int>();
        string login;
        string password;
        Methods methods;

        List<double> totalTime = new List<double>();
        List<double> HoldTime = new List<double>();
        List<double> seekTime = new List<double>();
        List<double> errorCount = new List<double>();

        public LoginForm()
        {
            InitializeComponent();
            methods = new Methods(totalTimeList, pressTimeList, seekTimeList, errorsCountList,
             isPasswordWritingStarted);
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            KeyboardBiometrics keyboardBiometrics = new KeyboardBiometrics();
            Hide();
            keyboardBiometrics.Show();
        }

        private void pass1Box_TextChanged(object sender, EventArgs e)
        {
            pass1Box.Clear();
        }

        private void loginBox_Click(object sender, EventArgs e)
        {
            loginBox.Clear();
        }

        private void getFromDatabase()
        {
            // tu przypisac wyniki z bazy danych
            //totalTime.Add(2545); // total time -300
            //totalTime.Add(3245); // total time +400
            //HoldTime.Add(59);  // hold time -10/15
            //HoldTime.Add(79);  // hold time +10/15
            //seekTime.Add(97);  // seek time -10/15
            //seekTime.Add(122);  // seek time +15
            //errorCount.Add(0); //error count -2
            //errorCount.Add(2); //error count +2
            //login = "Marta";   //login
            //password = "MartaPiotrowska";   //password
        }

        private void submitLoginButton_Click(object sender, EventArgs e)
        {
            // tu porownanie czasow/ hasla/loginu z bazy z tymi z pola login

            var averageTotalTime = totalTimeList.Average();
            var averagePressTime = pressTimeList.Average();
            var averageSeekTime = seekTimeList.Average();
            var averageErrorsCount = errorsCountList.Average();

            getFromDatabase();

            if (loginBox.Text.Equals(login) && pass1Box.Text.Equals(password)) {
                if (averageTotalTime >= totalTime.First() && averageTotalTime <= totalTime.Last()) {
                    if (averagePressTime >= HoldTime.First() && averagePressTime <= HoldTime.Last())
                    {
                        if (averageSeekTime >= seekTime.First() && averageSeekTime <= seekTime.Last())
                        {
                            if (averageErrorsCount >= errorCount.First() && averageErrorsCount <= errorCount.Last())
                            {
                                LoggedWindow logged = new LoggedWindow(login);
                                logged.Show();
                                Hide();
                            }
                            else labelError.Text = "Failed biometrics validation";
                        }
                        else labelError.Text = "Failed biometrics validation";
                    }
                    else labelError.Text = "Failed biometrics validation";
                }
                else labelError.Text = "Failed biometrics validation";
            }
            else labelError.Text = "Incorrect login or password";
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
