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
    /// Логика взаимодействия для addForm.xaml
    /// </summary>
    public partial class addForm : Window
    {
        public addForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int error = 0;
            try
            {
                common.nRole = RoleBox.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                error = 1;
            }
            try
            {
                common.nGender = GenderBox.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                error = 2;
            }

            if (common.nGender == Male.ToString())
            {
                common.nGender = common.nGender = "male";
            }
            else if (common.nGender == Female.ToString())
            {
                common.nGender = common.nGender = "female";
            }

            common.nUsername = LoginEdit.Text.ToString();
            common.nPassword = PasswordEdit.Text.ToString();
            common.nName = NameEdit.Text.ToString();
            common.nSurname = SurnameEdit.Text.ToString();
                switch (error)
                {
                    case 0:
                        if (common.nUsername.ToString() != "" &&
                        common.nPassword.ToString() != "" &&
                        common.nName.ToString() != "" &&
                        common.nSurname.ToString() != "")
                        {
                            common.wannaToCreate = true;
                            Hide();
                            Close();
                        } else
                        MessageBox.Show("Некоторые поля не заполнены");
                        break;
                    case 1:
                        MessageBox.Show("Роль не выбрана");
                        break;
                    case 2:
                        MessageBox.Show("Пол не выбран");
                        break;

                }
        }
}
