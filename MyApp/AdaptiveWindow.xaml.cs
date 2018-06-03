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
        List<Data> list2 = new List<Data>();

        public bool done;
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
            if (type == "Распределить") gAuto.Visibility = Visibility.Visible;
            if (type == "Темы" && action == "Добавить") gThemesAdd.Visibility = Visibility.Visible;
            if (type == "Темы" && action == "Удалить") gThemesDelete.Visibility = Visibility.Visible;
            if (type == "Специальности" && action == "Добавить") gSpecAdd.Visibility = Visibility.Visible;
            if (type == "Специальности" && action == "Удалить") gSpecDelete.Visibility = Visibility.Visible;
            if (type == "Студенты" && action == "Добавить") gStudentAdd.Visibility = Visibility.Visible;
            if (type == "Студенты" && action == "Удалить") gStudentDelete.Visibility = Visibility.Visible;
            if (type == "Группы" && action == "Добавить") gGroupAdd.Visibility = Visibility.Visible;
            if (type == "Группы" && action == "Удалить") gGroupDelete.Visibility = Visibility.Visible;
            if (type == "Предметы" && action == "Добавить") gSubjectAdd.Visibility = Visibility.Visible;
            if (type == "Предметы" && action == "Удалить") gSubjectDelete.Visibility = Visibility.Visible;
            if (type == "Учебный план" && action == "Добавить") gEducationPlanAdd.Visibility = Visibility.Visible;
            if (type == "Учебный план" && action == "Удалить") gEducationPlanDelete.Visibility = Visibility.Visible;

            if (type == "Распределить") DistributeThemes();
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
        }

        public bool checkString(string str)
        {
            foreach (char c in str)
                if (!System.Text.RegularExpressions.Regex.IsMatch(c.ToString(), "^[a-zA-Z]"))
                {
                    Console.Write(c);
                    return false;
                }
            return true;
        }

        public void ThemesAdd()
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
                    gThemesAddSubject.Items.Add(d.name);
            }
            else
            {
                bool error = false;
                Console.WriteLine("checked string");
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    int id = 0;
                    foreach (Data d in list)
                        if (d.name == gThemesAddSubject.Text)
                            id = d.id;

                    conn.Open();
                    string sql = "call add_themes('" + gThemesAddName.Text.ToString() +
                                "','" + id + "')";
                    Console.WriteLine(sql);

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        cmd.ExecuteReader();
                    }
                    catch (MySqlException ex)
                    {
                        error = true;
                        MessageBox.Show("Ошибка добавления\n" + ex.ToString());
                    }
                }
                finally
                {
                    conn.Close();
                }
                if (!error) MessageBox.Show("Тема: " + gThemesAddName.Text + "\nуспешно добавлена!");
            }
        }

        public void ThemesDelete()
        {
            // List<object> list = new List<object>();
            if (!done)
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, name FROM subjects ORDER BY Id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    gThemesDeleteSubject.Items.Clear();
                    while (rdr.Read())
                    {
                        Data it = new Data();
                        try
                        {
                            it.id = Convert.ToInt32(rdr[0].ToString());
                            it.name = rdr[1].ToString();
                            /*list.Add(new {
                                id =Convert.ToInt32(rdr[0].ToString()),
                                name =rdr[1].ToString()
                            }); */
                            Console.WriteLine(it.id + it.name);
                            gThemesDeleteSubject.Items.Add(it.name);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                "Произошла ошибка\n"
                                + ex.ToString());
                        }
                        list.Add(it);
                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                bool error = false;
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    int id = 0;
                    int idSubject = 0;
                    foreach (Data d in list)
                        if (d.name == gThemesDeleteSubject.Text)
                            id = d.id;
                    foreach (Data d in list2)
                        if (d.name == gThemesDeleteName.Text)
                            idSubject = d.id;

                    conn.Open();
                    string sql = "call rm_themes('" + idSubject +
                                "','" + id + "')";
                    Console.WriteLine(sql);

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        cmd.ExecuteReader();
                    }
                    catch (MySqlException ex)
                    {
                        error = true;
                        MessageBox.Show("Ошибка удаления\n" + ex.ToString());
                    }
                }
                finally
                {
                    conn.Close();
                }
                if (!error)
                    MessageBox.Show("Тема: " +
                        gThemesAddName.Text +
                        "\nуспешно удалена!");
            }
        }

        public void SpecsAdd()
        {
            if (done)
            {
                bool error = false;
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    string sql = "call add_specs('" +
                        gSpecAddName.Text + "','" +
                        gSpecAddCode.Text + "')";
                    Console.WriteLine(sql);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        error = true;
                        MessageBox.Show("Ошибка добавления\n" + ex.ToString());
                    }
                }
                finally
                {
                    conn.Close();
                }
                if (!error) MessageBox.Show("Специальность " + gSpecAddName.Text + " успешно добавлена!");
            }
        }

        public void SpecsDelete()
        {   // gSpecDeleteName
            if (!done)
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT id, name FROM specs ORDER BY id";

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
                    gSpecDeleteName.Items.Add(d.name);
            }
            else
            {
                bool error = false;
                int id = 0;
                foreach (Data d in list)
                    if (d.name == gSpecDeleteName.Text)
                        id = d.id;

                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    string sql = "call rm_specs('" + id + "')";
                    Console.WriteLine(sql);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        error = true;
                        MessageBox.Show("Ошибка удаления\n" + ex.ToString());
                    }
                }
                finally
                {
                    conn.Close();
                }
                if (!error) MessageBox.Show("Специальность " + gSpecDeleteName.Text + " успешно добавлена!");
            }
        }

        public void StudentsAdd()
        {
            if (!done)
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, name FROM groups ORDER BY Id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Data it = new Data();
                        try
                        {
                            it.id = Convert.ToInt32(rdr[0].ToString());
                            it.name = rdr[1].ToString();
                            list.Add(it);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        gStudentAddGroup.Items.Add(it.name);
                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                int lastId = 0;
                int id = 0;
                bool error = false;
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    foreach (Data d in list)
                        if (d.name == gStudentAddGroup.Text)
                            id = d.id;

                    string sql = "SELECT max(id) FROM mydb.students WHERE groups_id = " + id;
                    Console.WriteLine(sql);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        rdr.Read();
                        try
                        {
                            lastId = Convert.ToInt32(rdr[0].ToString());
                        } catch (Exception ex)
                        {
                            //Console.WriteLine(ex.ToString());
                        }
                        lastId++;
                    }
                    catch (MySqlException ex)
                    {
                        error = true;
                        MessageBox.Show("Ошибка добавления\n" + ex.ToString());
                    }
                }
                finally
                {
                    conn.Close();
                }
                conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "call add_students('" +
                        lastId + "','" +
                        gStudentAddSurname.Text + "','" +
                        id + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    } catch (MySqlException ex)
                    {
                        error = true;
                        MessageBox.Show("Произошла ошибка:\n" + ex.ToString());
                    }

                    if (!error) MessageBox.Show("Cтудент " + gStudentAddSurname.Text + " успешно добавлен!");
                } finally
                {
                    conn.Close();
                }
            }
        }

        public void StudentsDelete()
        {
            // gStudentDeleteGroup    - группа
            // gStudentDeleteStudent  - студент
            if (!done)
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, name FROM groups ORDER BY Id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Data it = new Data();
                        try
                        {
                            it.id = Convert.ToInt32(rdr[0].ToString());
                            it.name = rdr[1].ToString();
                            list.Add(it);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        gStudentDeleteGroup.Items.Add(it.name);
                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                bool error = false;
                int myId = 0, groupsId = 0;
                foreach (Data d in list)
                    if (d.name == gStudentDeleteGroup.Text)
                        myId = d.id;
                foreach (Data d in list2)
                    if (d.name == gStudentDeleteStudent.Text)
                        groupsId = d.id;

                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql =
                        "call rm_students('" +
                        groupsId + "','" +
                        myId + "')";
                    Console.WriteLine(sql);
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    } catch (MySqlException ex)
                    {
                        error = true;
                        MessageBox.Show("Произошла ошибка:\n" + ex.ToString());
                    }
                }
                finally
                {
                    conn.Close();
                }
                if (!error) MessageBox.Show(
                    "Студент " +
                    gStudentDeleteStudent.Text +
                    " успешно удалён!");
            }
        }

        public void GroupsAdd()
        {
            if (!done)
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT id, name FROM specs GROUP BY id";

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
                            //Console.WriteLine(it.id + it.name);
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
                {
                    gGroupAddSpec.Items.Add(d.name);
                }
            } else {
                bool ok = checkString(gGroupAddName.Text.ToString());
                bool duplicate = false;
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    int id = 0;
                    foreach (Data d in list)
                        if (d.name == gGroupAddSpec.Text.ToString())
                            id = d.id;
                    conn.Open();
                    string sql = "call add_groups(" +
                        "'" + gGroupAddName.Text.ToString() + "'," +
                        "'" + id.ToString() + "')";
                    Console.WriteLine(sql);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    } catch (MySqlException ex)
                    {
                        duplicate = true;
                        Console.WriteLine(ex.ToString());
                    }
                }
                finally
                {
                    conn.Close();
                }
                if (!duplicate)
                    MessageBox.Show("Группа  " + gGroupAddName.Text + " успешно добавлена!");
                else MessageBox.Show("Группа " + gGroupAddName.Text + " уже существует");
            }
        }

        public void GroupsDelete()
        {
            if (!done)
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT id, name FROM groups GROUP BY id";

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
                            //Console.WriteLine(it.id + it.name);
                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine(ex.ToString());
                        }
                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
                foreach (Data d in list)
                {
                    gGroupDeleteGroup.Items.Add(d.name);
                }
            } else {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    int id = 0;
                    foreach (Data d in list)
                        if (d.name == gGroupDeleteGroup.Text.ToString())
                            id = d.id;
                    conn.Open();
                    string sql = "call rm_groups('" + id + "')";
                    Console.WriteLine(sql);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        //Console.WriteLine(ex.ToString());
                    }
                }
                finally
                {
                    conn.Close();
                }
                MessageBox.Show("Группа " + gGroupDeleteGroup.Text + " удалена");
            }
        }

        public void SubjectsAdd()
        {
            if (done)
            {
                bool error = false;
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "call add_subjects('" + gSubjectAddName.Text.ToString() + "')";
                    Console.WriteLine(sql);

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        cmd.ExecuteReader();
                    }
                    catch (MySqlException ex)
                    {
                        error = true;
                        MessageBox.Show("Ошибка добавления\n" + ex.ToString());
                    }
                }
                finally
                {
                    conn.Close();
                }
                if (!error) MessageBox.Show("Предмет: " + gSubjectAddName.Text + "\nуспешно добавлен!");
            }
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
                            MessageBox.Show("Произошла ошибка\n\n" + ex.ToString());
                            //Console.WriteLine(ex.ToString());
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
            // gEducationPlanAddSpec
            if (!done)
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, name FROM specs ORDER BY Id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Data it = new Data();
                        try
                        {
                            it.id = Convert.ToInt32(rdr[0].ToString());
                            it.name = rdr[1].ToString();
                            list.Add(it);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        gEducationPlanAddSpec.Items.Add(it.name);
                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
                conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, name FROM subjects ORDER BY Id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Data it = new Data();
                        try
                        {
                            it.id = Convert.ToInt32(rdr[0].ToString());
                            it.name = rdr[1].ToString();
                            list2.Add(it);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        gEducationPlanAddSubject.Items.Add(it.name);
                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                int specId = 0;
                int subjectId = 0;
                bool error = false;
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {   // gEducationPlanAddSubject
                    foreach (Data d in list)
                        if (d.name == gEducationPlanAddSpec.Text)
                            specId = d.id;
                    foreach (Data d in list2)
                        if (d.name == gEducationPlanAddSubject.Text)
                            subjectId = d.id;

                    string sql = "call add_edu_plan('" +
                        gEducationPlanAddSemester.Text + "','" +
                        gEducationPlanAddHours.Text + "','" +
                        gEducationPlanAddYear.Text + "','" +
                        specId + "','" +
                        subjectId + "')";
                    Console.WriteLine(sql);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        error = true;
                        MessageBox.Show("Ошибка добавления\n" + ex.ToString());
                    }
                }
                finally
                {
                    conn.Close();
                }
                if (!error) MessageBox.Show("Запись успешно добавлена!");
            }
        }

        public void EduPlanDelete()
        {
            if (!done)
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, name FROM specs ORDER BY Id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Data it = new Data();
                        try
                        {
                            it.id = Convert.ToInt32(rdr[0].ToString());
                            it.name = rdr[1].ToString();
                            list.Add(it);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        gEducationPlanDeleteSpec.Items.Add(it.name);
                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
                conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT Id, name FROM subjects ORDER BY Id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Data it = new Data();
                        try
                        {
                            it.id = Convert.ToInt32(rdr[0].ToString());
                            it.name = rdr[1].ToString();
                            list2.Add(it);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        gEducationPlanDeleteSubject.Items.Add(it.name);
                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                int specId = 0;
                int subjectId = 0;
                bool error = false;
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {   // gEducationPlanAddSubject
                    foreach (Data d in list)
                        if (d.name == gEducationPlanDeleteSpec.Text)
                            specId = d.id;
                    foreach (Data d in list2)
                        if (d.name == gEducationPlanDeleteSubject.Text)
                            subjectId = d.id;

                    string sql = "call rm_edu_plan('" +
                        gEducationPlanDeleteSemester.Text + "','" +
                        //gEducationPlanDeleteHours.Text + "','" +
                        gEducationPlanDeleteYear.Text + "','" +
                        specId + "','" +
                        subjectId + "')";
                    Console.WriteLine(sql);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        error = true;
                        MessageBox.Show("Ошибка удаления\n" + ex.ToString());
                    }
                }
                finally
                {
                    conn.Close();
                }
                if (!error) MessageBox.Show("Запись успешно удалена!");
            }
        }

        public bool IsSplittable(int groupId, int subjectId)
        {
            int students = 0, themes = 0;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = "call groupCount('" + groupId +"')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    try
                    {
                        students = Convert.ToInt32(rdr[0].ToString());
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine(ex.ToString());
                    }
                }
                rdr.Close();
            }
            finally
            {
                conn.Close();
            }

            conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = "call themeCount('" + subjectId + "')";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    try
                    {
                        themes = Convert.ToInt32(rdr[0].ToString());
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine(ex.ToString());
                    }
                }
                rdr.Close();
            }
            finally
            {
                conn.Close();
            }
            if (themes >= students) return true;
                else return false;
        }

        public void DistributeThemes()
        {
            if (!done)
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT id, name FROM groups ORDER BY id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Data it = new Data();
                        try
                        {
                            it.id = Convert.ToInt32(rdr[0].ToString());
                            it.name = rdr[1].ToString();
                            list.Add(it);
                        }
                        catch (Exception ex)
                        {
                            // Console.WriteLine(ex.ToString());
                        }
                        gAutoGroups.Items.Add(it.name);
                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }

                conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    string sql = "SELECT id, name FROM subjects ORDER BY id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Data it = new Data();
                        try
                        {
                            it.id = Convert.ToInt32(rdr[0].ToString());
                            it.name = rdr[1].ToString();
                            list2.Add(it);
                        }
                        catch (Exception ex)
                        {
                            // Console.WriteLine(ex.ToString());
                        }
                        gAutoSubject.Items.Add(it.name);
                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                int groupId = 0, subjectId = 0;
                foreach (Data d in list)
                    if (d.name == gAutoGroups.Text)
                        groupId = d.id;
                foreach (Data d in list2)
                    if (d.name == gAutoSubject.Text)
                        subjectId = d.id;
                bool error = false;
                if (IsSplittable(groupId,subjectId))
                {
                    MySqlConnection conn = new MySqlConnection(connStr);
                    try
                    {
                        conn.Open();
                        string sql = "call show_engaged_themes()";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            try
                            {
                                string studentName = rdr[1].ToString();
                                if (gAutoGroups.Text == rdr[0].ToString() &&
                                    gAutoSubject.Text == rdr[2].ToString())
                                {
                                    error = true;
                                    MessageBox.Show( "Студенту " + studentName + " уже назначена тема.\n" +
                                        "Все студенты группы не должны иметь тем.\n" +
                                        "Для успешного распределения удалите у " + studentName +  " тему " +
                                        rdr[3].ToString(), "Невозможно распределить темы");
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                // Console.WriteLine(ex.ToString());
                            }
                        }
                        rdr.Close();
                        if (!error)
                        {
                            
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    error = true;
                    MessageBox.Show("Невозможно распределить темы.\nСтудентов больше чем существует тем!");
                }
                if (!error) MessageBox.Show("Темы успешно распределены между студентами!");
            }
        }

        private void ActionButton_Click(object sender, RoutedEventArgs e) // все события 
        {
            done = true;
            if (type == "Распределить")                          DistributeThemes();
            if (type == "Темы" && action == "Добавить")          ThemesAdd();      // +
            if (type == "Темы" && action == "Удалить")           ThemesDelete();   // +
            if (type == "Специальности" && action == "Добавить") SpecsAdd();       // +
            if (type == "Специальности" && action == "Удалить")  SpecsDelete();    // +
            if (type == "Студенты" && action == "Добавить")      StudentsAdd();    // +
            if (type == "Студенты" && action == "Удалить")       StudentsDelete(); // +
            if (type == "Группы" && action == "Добавить")        GroupsAdd();      // +
            if (type == "Группы" && action == "Удалить")         GroupsDelete();   // +
            if (type == "Предметы" && action == "Добавить")      SubjectsAdd();    // +
            if (type == "Предметы" && action == "Удалить")       SubjectsDelete(); // +
            if (type == "Учебный план" && action == "Добавить")  EduPlanAdd();     // +
            if (type == "Учебный план" && action == "Удалить")   EduPlanDelete();  // +
                                                                 // Занятые темы   // +
                                                                 // Занятые темы   // +
            this.Hide();
            this.Close();
        }

        private void gThemesDeleteName_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                int myId = 0;
                foreach (Data d in list)
                {
                    Console.WriteLine(d.id + " - " + d.name + "  ?  " + gThemesDeleteSubject.Text);
                    if (gThemesDeleteSubject.Text == d.name)
                    {
                        Console.WriteLine("--> " + d.id + " - " + d.name);
                        myId = d.id;
                    }
                }
                conn.Open();
                string sql = "SELECT Id, name FROM themes " +
                             "WHERE subjects_id = " +
                             myId + " ORDER BY Id";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                gThemesDeleteName.Items.Clear();
                while (rdr.Read())
                {
                    try
                    {
                        Data it = new Data();
                        it.id = Convert.ToInt32(rdr[0].ToString());
                        it.name = rdr[1].ToString();
                        list2.Add(it);
                        gThemesDeleteName.Items.Add(it.name);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Произошла ошибка\n"
                            + ex.ToString());
                    }
                }
                rdr.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Произошла ошибка\n" + ex.ToString());
            }
        }

        private void gStudentDeleteStudent_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int groups_id = 0;
            foreach (Data d in list)
            {
                Console.WriteLine(d.id + d.name);
                if (d.name == gStudentDeleteGroup.Text)
                    groups_id = d.id;
            }

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = "SELECT id, surname from students " +
                    "where groups_id = '" + groups_id + 
                    "' ORDER BY Id";
                Console.WriteLine(sql);

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                gStudentDeleteStudent.Items.Clear();
                while (rdr.Read())
                {
                    Data it = new Data();
                    try
                    {
                        it.id = Convert.ToInt32(rdr[0].ToString());
                        it.name = rdr[1].ToString();
                        list2.Add(it);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    gStudentDeleteStudent.Items.Add(it.name);
                }
                rdr.Close();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
