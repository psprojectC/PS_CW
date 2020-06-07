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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using UserLogin;
using MySql.Data.MySqlClient;

namespace StudentInfoSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        public MainWindow(object data) : this()
        {
            MainFormVM mainFormVM = new MainFormVM
            {
                CurrentStudent = (Student)data
            };
            Title = mainFormVM.Title;
            this.DataContext = mainFormVM;
        }
        public List<string> StudStatusChoices { get; set; }
        private void ResetFields(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }
        private void DisableAll(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox textBox)
                {
                    textBox.IsEnabled = false;
                }
            }
        }
        private void EnableAll(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox textBox)
                {
                    textBox.IsEnabled = true;
                }
            }
        }
    }
}
