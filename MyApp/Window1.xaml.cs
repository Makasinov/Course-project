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


namespace MyApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            foreach (char c in username.Text.ToString())
                if (!System.Text.RegularExpressions.Regex.IsMatch(c.ToString(), "^[a-zA-Z]"))
                    ok = false;
            foreach (char c in password.Text.ToString())
                if (!System.Text.RegularExpressions.Regex.IsMatch(c.ToString(), "^[a-zA-Z]"))
                    ok = false;
            if (ok)
            {
                common.wannaToConnect = true;
                common.username = username.Text.ToString();
                common.password = password.Text.ToString();
                this.Hide();
                this.Close();
                Console.WriteLine("username - " + username.Text + "\n" + "password - " + password.Text);
            }
            else MessageBox.Show("Поля ввода заполнены не верно");
        }
    }
}
