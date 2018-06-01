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
    public partial class TablesAddForm : Window
    {
        public class myList
        {
            public int id;
            public string name;
        }

        public int groupId;
        public int themeId;
        public int subjectId;
        public int studentId;

        public string action;

        List<myList> groups = new List<myList>();
        List<myList> themes = new List<myList>();
        List<myList> subjects = new List<myList>();
        List<myList> students = new List<myList>();

        private string myConnStr;

        public TablesAddForm(string connSqlString, string action)
        {
            InitializeComponent();

            this.action = action;
            this.myConnStr = connSqlString;
            MySqlConnection conn = new MySqlConnection(connSqlString);
            try
            {
                conn.Open();
                string sql = "SELECT id, name FROM groups";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    myList it = new myList();
                    try
                    {
                        it.id = Convert.ToInt32(rdr[0].ToString());
                        it.name = rdr[1].ToString();
                        groups.Add(it);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    Groups.Items.Add(rdr[1].ToString());
                }
                rdr.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn = new MySqlConnection(connSqlString);
            try
            {
                conn.Open();
                string sql = "SELECT id, name FROM subjects ORDER BY id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    myList it = new myList();
                    try
                    {
                        it.id = Convert.ToInt32(rdr[0].ToString());
                        it.name = rdr[1].ToString();
                        subjects.Add(it);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    Subjects.Items.Add(rdr[1].ToString());
                }
                rdr.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool error = false;
            if (Subjects.SelectedValue != null &&
                Themes.SelectedValue   != null &&
                Groups.SelectedValue   != null &&
                Students.SelectedValue != null)
            { 

                foreach (myList l in subjects)
                    if (l.name == Subjects.SelectedValue.ToString())
                        subjectId = l.id;

                foreach (myList l in themes)
                    if (l.name == Themes.SelectedValue.ToString())
                        themeId = l.id;
                
                foreach (myList l in groups)
                    if (l.name == Groups.SelectedValue.ToString())
                        groupId = l.id;
                     

                foreach (myList l in students)
                    if (l.name == Students.SelectedValue.ToString())
                        studentId = l.id;
                
                MySqlConnection conn = new MySqlConnection(myConnStr);
                try
                {
                    conn.Open();
                    string sql = "";
                    if (action == "add")
                        sql = "call add_engaged_themes(";
                    else if (action == "delete")
                        sql = "call rm_engaged_themes(";

                    sql += studentId + "," +
                        +groupId + "," +
                        +themeId + "," +
                        +subjectId + ")";
                    Console.WriteLine(sql);
                    bool ok = true;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        rdr.Read();
                        rdr.Close();
                    } catch(MySqlException ex)
                    {
                        ok = false;
                        Console.WriteLine(ex.ToString());
                        if (action == "add")
                            MessageBox.Show("Ошибка\nВозможно у данного студента уже есть тема");
                        else if (action == "delete")
                            MessageBox.Show("Ошибка\nВозможно у данного студента нет темы");
                        error = true;
                    }
                    conn.Close();
                    if (ok)
                    {
                        Hide();
                        Close();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Произошла непредвиденная ошибка");
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Некоторые поля не заполнены");
                error = true;
            }
            if (!error) MessageBox.Show("Операция успешно завершена!"); 
        }

        private void Groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Students.Items.Clear();
            string groupId = "";
            foreach (myList g in groups)
            {
                Console.WriteLine(g.name + "\t" + Groups.SelectedValue.ToString());
                if (g.name == Groups.SelectedValue.ToString())
                    groupId = g.id.ToString();
            }
            MySqlConnection conn = new MySqlConnection(myConnStr);
            try
            {
                conn.Open();
                string sql = "SELECT id, surname FROM students WHERE Groups_id = " + groupId;
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    myList it = new myList();
                    try
                    {
                        it.id = Convert.ToInt32(rdr[0].ToString());
                        it.name = rdr[1].ToString();
                        students.Add(it);
                    } catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    Students.Items.Add(rdr[1].ToString());
                }

                rdr.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Subjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //  SELECT id, name FROM mydb.themes WHERE Subjects_id = {var};
            Themes.Items.Clear();
            string subjectId = "";
            foreach (myList s in subjects)
            {
                Console.WriteLine(s.name + "\t" + Subjects.SelectedValue.ToString());
                if (s.name == Subjects.SelectedValue.ToString())
                    subjectId = s.id.ToString();
            }
            MySqlConnection conn = new MySqlConnection(myConnStr);
            try
            {
                conn.Open();
                string sql = "SELECT id, name FROM themes WHERE Subjects_id = " + subjectId;
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    myList it = new myList();
                    try
                    {
                        it.id = Convert.ToInt32(rdr[0].ToString());
                        it.name = rdr[1].ToString();
                        themes.Add(it);
                    } catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    Themes.Items.Add(rdr[1].ToString());
                }
                rdr.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
