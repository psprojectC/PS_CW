using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginFormWindow.xaml
    /// </summary>
    public partial class LoginFormWindow : Window
    {

        public LoginFormWindow()
        {
            InitializeComponent();
        }
        public static void ShowActionErrorMessage(string errorMsg)
        {
            MessageBox.Show(errorMsg);
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = passwordBox.Password;
            LoginValidation validation = new LoginValidation(username, password, ShowActionErrorMessage);
            User user = new User();
            if(validation.ValidateUserInput(ref user))
            {
                try
                {
                    Student student = StudentValidation.GetStudentDataByUser(user);
                    MainWindow mainWindow = new MainWindow(student);
                    mainWindow.Show();
                    Close();
                } catch
                {
                    invalidCredentials();
                }
            }
        }
        private void invalidCredentials()
        {
            MessageBox.Show("Invalid username or password!");
            TextBox usernameBox = txtUsername;
            usernameBox.Clear();
            PasswordBox passBox = passwordBox;
            passBox.Clear();
        }
    }
}
