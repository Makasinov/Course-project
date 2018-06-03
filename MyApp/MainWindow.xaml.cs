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
using System.Diagnostics;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace MyApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyApp.Window1 win = new MyApp.Window1();
        addForm form = new addForm();
        TablesAddForm tablesAddForm;
        XFont titleFont = new XFont("Impact", 25);
        XFont font = new XFont("Times New Roman", 10);
        //XBrush brush = new XBrush();

        public class Data
        {
            public int id;
            public string login;
        }

        List<Data> idLogin = new List<Data>();
        
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

        public class MyItem2
        {
            public string Col1 { get; set; }
            public string Col2 { get; set; }
            public string Col3 { get; set; }
            public string Col4 { get; set; }
            public string Col5 { get; set; }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            distribute.Visibility = Visibility.Hidden;
            if ( common.nRole == "Admin" || common.nRole == "root" || 
                 common.nRole == "Teacher" || common.nRole == "Depot" )
            {
                ButtonAdd.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
                distribute.IsEnabled = true;
            }
            //Console.WriteLine(comboBoxTable.SelectedIndex);
            string req = "";
            switch(comboBoxTable.SelectedIndex)
            {
                case 0:
                    req = "edu_plan"; break;
                case 1:
                    req = "engaged_themes";
                    distribute.Visibility = Visibility.Visible;
                    break;
                case 2:
                    req = "groups"; break;
                case 3:
                    req = "specs"; break;
                case 4:
                    req = "students"; break;
                case 5:
                    req = "subjects"; break;
                case 6:
                    req = "themes"; break;
            }

            string connStr = connectionString.Text +
                    "user id=" + common.username +
                    ";password=" + common.password;
            //Console.WriteLine(connStr);
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Попытка подключения...");
                conn.Open();
                string sql = "call show_" + req;
                //Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                listViewTables.Items.Clear();
                string s1 = "", s2 = "", s3 = "", s4 = "", s5 = "";
                while (rdr.Read())
                {
                    try
                    {
                        s1 = rdr[0].ToString();
                        s2 = rdr[1].ToString();
                        s3 = rdr[2].ToString();
                        s4 = rdr[3].ToString();
                        s5 = rdr[4].ToString();
                    }
                    catch(Exception ex)
                    {
                        //Console.WriteLine(ex.ToString());
                    }

                    listViewTables.Items.Add(new MyItem2
                    {
                        Col1 = s1, Col2 = s2,
                        Col3 = s3, Col4 = s4,
                        Col5 = s5
                    });
                }
                rdr.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                //Console.WriteLine(ex.ToString());
            }
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

        private void Home_Copy_Click(object sender, RoutedEventArgs e) // Авторизация
        {
            win = new MyApp.Window1();
            win.Show();
        }

        public class MyItem
        {
            public string Login { get; set; }
            public string Role { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Gender { get; set; }
        }

        private void setParams(string connStr)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                //Console.WriteLine("Попытка подключения...");
                conn.Open();
                string sql = "getmyinfo('" + common.username + "')";
                MySqlCommand cmd    = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                string name    = "Console - No Answer";
                string surname = "Console - No Answer";
                string role    = "Console - No Answer";
                string gender  = "Console - No Answer";
                try
                {
                    name    = rdr[0].ToString();
                    surname = rdr[1].ToString();
                    role    = rdr[2].ToString();
                    gender  = rdr[3].ToString();
                }
                catch (Exception)
                {
                    Console.WriteLine("Пусто");
                }
                rdr.Close();
                //Console.WriteLine(name);
                Name_Copy.Content     = name;
                Surname_Copy.Content  = surname;
                Surname_Copy1.Content = role;
                Home_Copy.Content     = surname;
                rights.Content        = role;
                common.nRole          = role;

                if (gender == "Male")
                    try
                    {
                        Avatar.Source = new BitmapImage(
                            new Uri("pack://application:,,,/MyApp;component/icons/male.png"));
                        Avatar_Copy.Source = new BitmapImage(
                            new Uri("pack://application:,,,/MyApp;component/icons/male.png"));
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.ToString());
                        //Console.WriteLine(Avatar.Source.ToString());
                    }
                else if (gender == "Female")
                    try
                    {
                        Avatar.Source = new BitmapImage(
                            new Uri("pack://application:,,,/MyApp;component/icons/female.png"));
                        Avatar_Copy.Source = new BitmapImage(
                            new Uri("pack://application:,,,/MyApp;component/icons/female.png"));
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.ToString());
                        //Console.WriteLine(Avatar.Source.ToString());
                    }
                else try
                    {
                        Avatar.Source = new BitmapImage(
                            new Uri("pack://application:,,,/MyApp;component/icons/user.png"));
                        Avatar_Copy.Source = new BitmapImage(
                            new Uri("pack://application:,,,/MyApp;component/icons/user.png"));
                    }
                    catch (Exception ex)
                    {
                       // Console.WriteLine(ex.ToString());
                       // Console.WriteLine(Avatar.Source.ToString());
                    }

                if (common.nRole == "Admin" || common.nRole == "root")
                {
                    ButtonAdd2.IsEnabled = true;
                    ButtonDelete2.IsEnabled = true;
                    sql = "call show_users";
                    cmd = new MySqlCommand(sql, conn);
                    rdr = cmd.ExecuteReader();
                    listViewUsers.Items.Clear();
                    listViewTables.Items.Clear();
                    int counter = 0;
                    while (rdr.Read())
                        try
                        {
                            listViewUsers.Items.Add(new MyItem
                            {
                                Login   = rdr[0].ToString(),
                                Role    = rdr[1].ToString(),
                                Name    = rdr[2].ToString(),
                                Surname = rdr[3].ToString(),
                                Gender  = rdr[4].ToString()
                            });
                            Data it = new Data();
                            it.id = counter;
                            it.login = rdr[0].ToString();
                            idLogin.Add(it);
                            counter++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    rdr.Close();
                    conn.Close();
                } else {
                    ButtonAdd.IsEnabled     = false;
                    ButtonDelete.IsEnabled  = false;
                    ButtonAdd2.IsEnabled    = false;
                    ButtonDelete2.IsEnabled = false;
                    listViewUsers.Items.Clear();
                }
            } catch (Exception ex)
            {
               // Console.WriteLine(ex.ToString());
            }
        }

        private void setUsersTable(string connStr)
        {
            //Console.WriteLine("wannaToCreate" + common.username + "\t" + common.password);
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                //Console.WriteLine("Попытка подключения...");
                conn.Open();

                string sql = "call add_User('" +
                             common.nUsername +
                             "','" +
                             common.nPassword +
                             "','" +
                             common.nRole +
                             "','" +
                             common.nName +
                             "','" +
                             common.nSurname +
                             "','" +
                             common.nGender +
                             "')";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                rdr.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка добавления");
                Console.WriteLine(ex.ToString());
            }
        }

        private void addNewTheme(string connStr)
        {

        }

        private void Window_GotFocus(object sender, EventArgs e) // Обработчик
        {
            string connStr = connectionString.Text +
                      "user id=" + common.username +
                      ";password=" + common.password;
            if (common.wannaToConnect)
            {
                common.wannaToConnect = false;
                setParams(connStr);
            }
            else if (common.wannaToCreateUser)
            {
                common.wannaToCreateUser = false;
                setUsersTable(connStr);
                setParams(connStr);
            }
            else if (common.wannaToCreateTheme)
            {
                common.wannaToCreateTheme = false;
                addNewTheme(common.connectionString);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // Добавить кнопка
        {
            form = new addForm();
            form.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // Удалить кнопка
        {
            try
            {
                bool deleted = false;
                int id = listViewUsers.SelectedIndex;
                foreach (Data it in idLogin)
                    if (it.id == id && !deleted)
                        if (MessageBox.Show(
                            "Уверены что хотите удалить пользователя " + it.login + "?",
                            "Подтвердите ", 
                            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            string connStr = connectionString.Text +
                                      "user id=" + common.username +
                                      ";password=" + common.password;
                            MySqlConnection conn = new MySqlConnection(connStr);
                            try
                            {
                                Console.WriteLine("Попытка подключения...");
                                conn.Open();
                                string sql = "call rm_user('" + it.login + "')";
                                MySqlCommand cmd = new MySqlCommand(sql, conn);
                                MySqlDataReader rdr = cmd.ExecuteReader();
                                rdr.Read();
                                rdr.Close();
                                conn.Close();
                                MessageBox.Show("Пользователь " + it.login + " успешно удалён!");
                                listViewUsers.Items.RemoveAt(it.id);
                                deleted = true;
                            } catch (MySqlException ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Выберите пользователя для удаления","Ошибка");
                Console.WriteLine(ex.ToString());
            }
        }

        private void MainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            string connStr = connectionString.Text +
                      "user id=" + common.username +
                      ";password=" + common.password;
            if (comboBoxTable.SelectedValue != null)
                if (comboBoxTable.Text == "Занятые темы")
                {
                    tablesAddForm = new TablesAddForm(connStr, "add");
                    tablesAddForm.Show();
                } else
                {
                    AdaptiveWindow AW = new AdaptiveWindow(connStr, comboBoxTable.Text, "Добавить");
                    AW.Show();
                }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            string connStr = connectionString.Text +
                      "user id=" + common.username +
                      ";password=" + common.password;
            if (comboBoxTable.SelectedValue != null)
                if (comboBoxTable.Text == "Занятые темы")
                {
                    tablesAddForm = new TablesAddForm(connStr, "delete");
                    tablesAddForm.Show();
                } else
                {
                    AdaptiveWindow AW = new AdaptiveWindow(connStr, comboBoxTable.Text, "Удалить");
                    AW.Show();
                }
        }

        private void comboBoxRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void distribute_Click(object sender, RoutedEventArgs e)
        {

        }

        private void drawLines(XGraphics gfx, PdfPage page, int w1 = -1, int w2 = -1, int w3 = -1, int w4 = -1, int w5 = -1)
        {
            gfx.DrawLine(XPens.Black, w1, 50, w1, page.Height - 55);
            gfx.DrawLine(XPens.Black, w2, 50, w2, page.Height - 55);
            gfx.DrawLine(XPens.Black, w3, 50, w3, page.Height - 55);
            gfx.DrawLine(XPens.Black, w4, 50, w4, page.Height - 55);
            gfx.DrawLine(XPens.Black, w5, 50, w5, page.Height - 55);
        }

        private void drawTable(XGraphics gfx, PdfPage page)
        {
            gfx.DrawRectangle(XPens.Black, new XRect(25, 50, page.Width - 50, page.Height - 105));
            for (int i = 50; i < page.Height - 70; i += 15)
                gfx.DrawLine(XPens.Black, 25, i, page.Width - 25, i);
        }

        private void drawThemes(PdfPage page)
        {
            XGraphics gfx = XGraphics.FromPdfPage(page);
            drawTable(gfx, page);
            gfx.DrawString("Themes", titleFont, XBrushes.Black,
                new XRect(50, 10, page.Width, 100),
              XStringFormats.TopLeft);
            drawLines(gfx, page, 100,200);
        }

        private void drawEducationPlan(PdfPage page)
        {
            XGraphics gfx = XGraphics.FromPdfPage(page);
            drawTable(gfx, page);
            gfx.DrawString("Education Plan", titleFont, XBrushes.Black,
                new XRect(50, 10, page.Width, 100),
              XStringFormats.TopLeft);
            drawLines(gfx, page, 50);
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Report";

            // Create an empty page
            PdfPage page = document.AddPage();
            drawThemes(page);
            page = document.AddPage();
            drawEducationPlan(page);

            // Save the document...
            const string filename = "Report.pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
    }
}