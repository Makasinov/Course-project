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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MyApp
{
    public partial class AdaptiveWindow : Window
    {

        public class Data
        {
            public int id;
            public string name;
        }

        List<Data> list = new List<Data>();

        public bool   done;
        public string connStr;
        public string type;
        public string action;

        public AdaptiveWindow(string connStr, string type, string action)
        {
            InitializeComponent();

            done = false;
            Title = type;
            this.connStr = connStr;
            this.type = type;
            this.action = action;
            ActionButton.Content = action;
            if (type == "Темы" && action == "Добавить")          gThemesAdd.Visibility           = Visibility.Visible;
            if (type == "Темы" && action == "Удалить")           gThemesDelete.Visibility        = Visibility.Visible;
            if (type == "Специальности" && action == "Добавить") gSpecAdd.Visibility             = Visibility.Visible;
            if (type == "Специальности" && action == "Удалить")  gSpecDelete.Visibility          = Visibility.Visible;
            if (type == "Студенты" && action == "Добавить")      gStudentAdd.Visibility          = Visibility.Visible;
            if (type == "Студенты" && action == "Удалить")       gStudentDelete.Visibility       = Visibility.Visible;
            if (type == "Группы" && action == "Добавить")        gGroupAdd.Visibility            = Visibility.Visible;
            if (type == "Группы" && action == "Удалить")         gGroupDelete.Visibility         = Visibility.Visible;
            if (type == "Предметы" && action == "Добавить")      gSubjectAdd.Visibility          = Visibility.Visible;
            if (type == "Предметы" && action == "Удалить")       gSubjectDelete.Visibility       = Visibility.Visible;
            if (type == "Учебный план" && action == "Добавить")  gEducationPlanAdd.Visibility    = Visibility.Visible;
            if (type == "Учебный план" && action == "Удалить")   gEducationPlanDelete.Visibility = Visibility.Visible;

            if (type == "Темы" && action == "Добавить")          ThemesAdd();
            if (type == "Темы" && action == "Удалить")           ThemesDelete();
            if (type == "Специальности" && action == "Добавить") SpecsAdd();
            if (type == "Специальности" && action == "Удалить")  SpecsDelete();
            if (type == "Студенты" && action == "Добавить")      StudentsAdd();
            if (type == "Студенты" && action == "Удалить")       StudentsDelete();
            if (type == "Группы" && action == "Добавить")        GroupsAdd();
            if (type == "Группы" && action == "Удалить")         GroupsDelete();
            if (type == "Предметы" && action == "Добавить")      SubjectsAdd();
            if (type == "Предметы" && action == "Удалить")       SubjectsDelete();
            if (type == "Учебный план" && action == "Добавить")  EduPlanAdd();
            if (type == "Учебный план" && action == "Удалить")   EduPlanDelete();
        }

        public void ThemesAdd()
        {

        }

        public void ThemesDelete()
        {

        }

        public void SpecsAdd()
        {

        }

        public void SpecsDelete()
        {

        }

        public void StudentsAdd()
        {

        }

        public void StudentsDelete()
        {

        }

        public void GroupsAdd()
        {

        }

        public void GroupsDelete()
        {

        }

        public void SubjectsAdd()
        {
            
        }

        public void SubjectsDelete()
        {
            if (!done)
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, name FROM subjects ORDER BY Id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        try
                        {
                            Data it = new Data();
                            it.id = Convert.ToInt32(rdr[0].ToString());
                            it.name = rdr[1].ToString();
                            list.Add(it);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }

                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
                foreach (Data d in list)
                    gSubjectDeleteSubject.Items.Add(d.name);
            } else {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    int id = 0;
                    foreach (Data d in list)
                        if (d.name == gSubjectDeleteSubject.Text)
                            id = d.id;

                    conn.Open();
                    string sql = "call rm_subjects('" + id.ToString() + "')";
                    Console.WriteLine(sql);

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteReader();
                }
                finally
                {
                    conn.Close();
                }
                MessageBox.Show("Предмет " + gSubjectDeleteSubject.Text + " успешно удалён!");
            }
        }

        public void EduPlanAdd()
        {

        }

        public void EduPlanDelete()
        {

        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            done = true;
            if (type == "Темы" && action == "Добавить") ThemesAdd();
            if (type == "Темы" && action == "Удалить") ThemesDelete();
            if (type == "Специальности" && action == "Добавить") SpecsAdd();
            if (type == "Специальности" && action == "Удалить") SpecsDelete();
            if (type == "Студенты" && action == "Добавить") StudentsAdd();
            if (type == "Студенты" && action == "Удалить") StudentsDelete();
            if (type == "Группы" && action == "Добавить") GroupsAdd();
            if (type == "Группы" && action == "Удалить") GroupsDelete();
            if (type == "Предметы" && action == "Добавить") SubjectsAdd();
            if (type == "Предметы" && action == "Удалить") SubjectsDelete();
            if (type == "Учебный план" && action == "Добавить") EduPlanAdd();
            if (type == "Учебный план" && action == "Удалить") EduPlanDelete();

            this.Hide();
            this.Close();
        }
    }
}
