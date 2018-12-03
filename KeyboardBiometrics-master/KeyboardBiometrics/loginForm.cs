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
    public partial class LoginForm : Form
    {
        bool isPasswordWritingStarted = false;
        List<int> totalTimeList = new List<int>();
        List<int> pressTimeList = new List<int>();
        List<int> seekTimeList = new List<int>();
        List<int> errorsCountList = new List<int>();
        String login;
        String password;
        Methods methods;

        List<Double> totalTime = new List<Double>();
        List<Double> HoldTime = new List<Double>();
        List<Double> seekTime = new List<Double>();
        List<Double> errorCount = new List<Double>();

        public LoginForm()
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

        private void pass1Box_TextChanged(object sender, EventArgs e)
        {
            pass1Box.Clear();
        }

        private void loginBox_Click(object sender, EventArgs e)
        {
            loginBox.Clear();
        }

        private void getFromDataBase()
        {
            // tu przypisac wyniki z bazy danych
            totalTime.Add(2545); // total time -300
            totalTime.Add(3245); // total time +400
            HoldTime.Add(59);  // hold time -10/15
            HoldTime.Add(79);  // hold time +10/15
            seekTime.Add(97);  // seek time -10/15
            seekTime.Add(122);  // seek time +15
            errorCount.Add(0); //error count -2
            errorCount.Add(2); //error count +2
            login = "Marta";   //login
            password = "MartaPiotrowska";   //password
        }

        private void submitLoginButton_Click(object sender, EventArgs e)
        {
            // tu porownanie czasow/ hasla/loginu z bazy z tymi z pola login

            var averageTotalTime = totalTimeList.Average();
            Console.WriteLine(averageTotalTime);
            var averagePressTime = pressTimeList.Average();
            Console.WriteLine(averagePressTime);
            var averageSeekTime = seekTimeList.Average();
            Console.WriteLine(averageSeekTime);
            var averageErrorsCount = errorsCountList.Average();
            Console.WriteLine(averageErrorsCount);
            getFromDataBase();
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
                                this.Hide();
                            }
                            else labelError.Text = "Incorrect time";

                        }
                        else labelError.Text = "Incorrect time";
                    }
                    else labelError.Text = "Incorrect time";

                }
                else labelError.Text = "Incorrect time";
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
