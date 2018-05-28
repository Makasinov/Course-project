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
    /// Логика взаимодействия для AdaptiveWindow.xaml
    /// </summary>
    public partial class AdaptiveWindow : Window
    {
        public string connStr;
        public string type;
        public string action;

        public AdaptiveWindow(string connStr, string type, string action)
        {
            InitializeComponent();
            Title = type;
            this.connStr = connStr;
            this.type = type;
            this.action = action;
            ActionButton.Content = action;
            if (type == "Темы" && action == "Добавить") gThemesAdd.Visibility    = Visibility.Visible;
            if (type == "Темы" && action == "Удалить")  gThemesDelete.Visibility = Visibility.Visible;
        }

        public void ThemesAdd()
        {

        }

        public void ThemesDelete()
        {

        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            if (type == "Темы" && action == "Добавить") ThemesAdd();
            if (type == "Темы" && action == "Удалить")  ThemesDelete();

            this.Hide();
            this.Close();
        }
    }
}
