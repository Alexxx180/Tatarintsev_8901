using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Reload.xaml
    /// </summary>
    public partial class Reload : Window
    {
        public Reload(string en, string ru, string problem)
        {
            InitializeComponent();
            EN.Text = en;
            RU.Text = ru;
            Problem.Text = problem;
        }
        public static void Reloading()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
