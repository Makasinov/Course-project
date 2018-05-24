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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MyApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyApp.Window1 win = new MyApp.Window1();
        addForm form = new addForm();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            this.closeButton.Height = this.closeButton.Height - 2;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            this.closeButton.Height = this.closeButton.Height + 2;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Image_MouseEnter_1(object sender, MouseEventArgs e)
        {
            this.Avatar.Height = this.Avatar.Height - 5;
        }

        private void Image_MouseLeave_1(object sender, MouseEventArgs e)
        {
            this.Avatar.Height = this.Avatar.Height + 5;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Tables_click");
            gHome.Visibility = Visibility.Hidden;
            gUser.Visibility = Visibility.Hidden;
            gUsers.Visibility = Visibility.Hidden;
            gSettings.Visibility = Visibility.Hidden;
            gTables.Visibility = Visibility.Visible;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Home_click");
            this.gUser.Visibility = Visibility.Hidden;
            this.gUsers.Visibility = Visibility.Hidden;
            this.gSettings.Visibility = Visibility.Hidden;
            this.gTables.Visibility = Visibility.Hidden;
            this.gHome.Visibility = Visibility.Visible;
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("User_click");
            this.gHome.Visibility = Visibility.Hidden;
            this.gUser.Visibility = Visibility.Hidden;
            this.gSettings.Visibility = Visibility.Hidden;
            this.gTables.Visibility = Visibility.Hidden;
            this.gUsers.Visibility = Visibility.Visible;
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Settings_click");
            this.gHome.Visibility = Visibility.Hidden;
            this.gUser.Visibility = Visibility.Hidden;
            this.gUsers.Visibility = Visibility.Hidden;
            this.gTables.Visibility = Visibility.Hidden;
            this.gSettings.Visibility = Visibility.Visible;
        }

        private void Avatar_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("User_click");
            this.gHome.Visibility = Visibility.Hidden;
            this.gUsers.Visibility = Visibility.Hidden;
            this.gTables.Visibility = Visibility.Hidden;
            this.gSettings.Visibility = Visibility.Hidden;
            this.gUser.Visibility = Visibility.Visible;
        }

        private void Home_Copy_Click(object sender, RoutedEventArgs e)
        {
            win = new MyApp.Window1();
            win.Show();
        }

        private void Window_GotFocus(object sender, EventArgs e)
        {
            if (common.wannaToConnect)
            {
                common.wannaToConnect = false;
                var connStr = connectionString.Text +
                    "user id=" + common.username +
                    ";password=" + common.password;

                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    Console.WriteLine("Попытка подключения...");
                    conn.Open();
                    string sql = "getmyinfo('" + common.username + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    string name = "Console - No Answer";
                    string surname = "Console - No Answer";
                    string role = "Console - No Answer";
                    string gender = "Console - No Answer";
                    try
                    {
                        name = rdr[0].ToString();
                        surname = rdr[1].ToString();
                        role = rdr[2].ToString();
                        gender = rdr[3].ToString();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Пусто");
                    }
                    Console.WriteLine(name);
                    Name_Copy.Content = name;
                    Surname_Copy.Content = surname;
                    Surname_Copy1.Content = role;
                    Home_Copy.Content = surname;
                    rights.Content = role;

                    if (gender == "male")
                        try
                        {
                            Avatar.Source = new BitmapImage(
                                new Uri("pack://application:,,,/MyApp;component/icons/male.png"));
                            Avatar_Copy.Source = new BitmapImage(
                                new Uri("pack://application:,,,/MyApp;component/icons/male.png"));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.WriteLine(Avatar.Source.ToString());
                        }
                    else if (gender == "female")
                        try
                        {
                            Avatar.Source = new BitmapImage(
                                new Uri("pack://application:,,,/MyApp;component/icons/female.png"));
                            Avatar_Copy.Source = new BitmapImage(
                                new Uri("pack://application:,,,/MyApp;component/icons/female.png"));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.WriteLine(Avatar.Source.ToString());
                        }
                    else try
                        {
                            Avatar.Source = new BitmapImage(
                                new Uri("pack://application:,,,/MyApp;component/icons/user.png"));
                            Avatar_Copy.Source = new BitmapImage(
                                new Uri("pack://application:,,,/MyApp;component/icons/user.png"));
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.WriteLine(Avatar.Source.ToString());
                        }
                    common.connectionString = connStr;
            }
                catch(MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Не существует пользователя с таким логином/паролем");
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }
            else if (common.wannaToCreate)
            {
                common.wannaToCreate = false;
                Console.WriteLine("wannaToCreate");

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            form = new addForm();
            form.Show();
        }
    }
}