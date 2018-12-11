using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        SqlCommand cmd;
        SqlConnection con;
        
        public RegisterForm()
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

        

        private void AddRowToDataBase(string login, string pass, double totaltime, double presstime, double seektime, double errors)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bartosz\Source\Repos\BiometricProject2\KeyboardBiometrics-master\KeyboardBiometrics\KeyboardDatabase.mdf;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("INSERT INTO KeyboardData (nickname, password, total_time, seek_time, press_time, errors_count) " +
                "VALUES (@nickname, @password, @total_time, @seek_time, @press_time, @errors_count)", con);
            cmd.Parameters.AddWithValue("@nickname",login);
            cmd.Parameters.AddWithValue("@password", pass);
            cmd.Parameters.AddWithValue("@total_time", totaltime);
            cmd.Parameters.AddWithValue("@seek_time", seektime);
            cmd.Parameters.AddWithValue("@press_time", presstime);
            cmd.Parameters.AddWithValue("@errors_count", errors);
            cmd.ExecuteNonQuery();
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
                pass2Box.Text = "Password is too short";
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
                var averagePressTime = pressTimeList.Average();
                var averageSeekTime = seekTimeList.Average();
                var averageErrorsCount = errorsCountList.Average();
                AddRowToDataBase(loginBox.Text, pass1Box.Text, averageTotalTime, averagePressTime, averageSeekTime, averageErrorsCount);
                RegisteredWindow registeredWindow = new RegisteredWindow();
                Hide();
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
