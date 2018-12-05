using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        Methods methods;

        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader reader;

        struct RowData
        {
           public double averageTotalTime;
           public double averageSeekTime;
           public double averagePressTime;
           public double averageErrorsCount;
        }

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
            methods.ClearData();
        }

        private void loginBox_Click(object sender, EventArgs e)
        {
            loginBox.Clear();
        }

        private RowData getFromDatabase(string login, string password)
        {
            RowData rowData = new RowData();
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bartosz\Source\Repos\BiometricProject2\KeyboardBiometrics-master\KeyboardBiometrics\KeyboardDatabase.mdf;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("SELECT total_time, seek_time, press_time, errors_count FROM KeyboardData WHERE nickname=@nickname AND password=@password", con);
            cmd.Parameters.AddWithValue("@nickname", login);
            cmd.Parameters.AddWithValue("@password", password);

            reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                rowData.averageTotalTime = Convert.ToDouble(reader["total_time"]);
                rowData.averageSeekTime = Convert.ToDouble(reader["seek_time"]);
                rowData.averagePressTime = Convert.ToDouble(reader["press_time"]);
                rowData.averageErrorsCount = Convert.ToDouble(reader["errors_count"]);

            }

            return rowData;
        }

        private void submitLoginButton_Click(object sender, EventArgs e)
        {
            labelError.Text = "";

            RowData data = new RowData();

            data =  getFromDatabase(loginBox.Text, pass1Box.Text);
            if(data.averageTotalTime.Equals(0)) labelError.Text = "Incorrect login or password";
            else
            {
                if (!ValidateBiometricsData(data)) labelError.Text = "Failed biometrics validation";
                else
                {
                    LoggedWindow logged = new LoggedWindow(loginBox.Text);
                    logged.Show();
                    Hide();
                }
            }
            //methods.ClearData();
        }

        private bool ValidateBiometricsData(RowData data)
        {
            if (100 * Math.Abs(totalTimeList.Average() - data.averageTotalTime) / data.averageTotalTime > 30)
            {
                return false;
            }

            if (100 * Math.Abs(errorsCountList.Average() - data.averageErrorsCount) / (data.averageErrorsCount + 1) > 60)
            {
                return false;
            }

            if (100 * Math.Abs(pressTimeList.Average() - data.averagePressTime) / data.averagePressTime > 30)
            {
                return false;
            }

            if (100 * Math.Abs(seekTimeList.Average() - data.averageSeekTime) / data.averageSeekTime > 30)
            {
                return false;
            }

            return true;
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
