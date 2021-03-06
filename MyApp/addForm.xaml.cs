﻿using System;
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
    /// Логика взаимодействия для addForm.xaml
    /// </summary>
    public partial class addForm : Window
    {
        public addForm()
        {
            InitializeComponent();
        }

        public bool checkString(string str)
        {
            foreach (char c in str)
                if (!System.Text.RegularExpressions.Regex.IsMatch(c.ToString(), "^[a-zA-Z]"))
                    return false;
            return true;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            //оптимизировать - достаточно регуляркой всю строку проверять, а один символ проверять неэффективно
            if (ok) ok = checkString(LoginEdit.Text.ToString());
            if (ok) ok = checkString(PasswordEdit.Text.ToString());
            if (ok) ok = checkString(NameEdit.Text.ToString());
            if (ok) ok = checkString(SurnameEdit.Text.ToString());

            bool error = false;
            try
            {
                common.nRole = RoleBox.SelectedValue.ToString();
                common.nGender = GenderBox.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                error = true;
            }
            common.nGender   = GenderBox.Text.ToString();
            common.nUsername = LoginEdit.Text.ToString();
            common.nPassword = PasswordEdit.Text.ToString();
            common.nName     = NameEdit.Text.ToString();
            common.nSurname  = SurnameEdit.Text.ToString();

            if (common.nUsername.ToString() != "" &&
                common.nPassword.ToString() != "" &&
                common.nName.ToString() != "" &&
                common.nSurname.ToString() != "" &&
                !error && ok)
            {
                common.wannaToCreateUser = true;
                Hide();
                Close();
            }
            else MessageBox.Show("Некоторые поля не заполнены или заполнены не верно");

        }
    }
}
