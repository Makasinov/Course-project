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
                !error)
            {
                common.wannaToCreate = true;
                Hide();
                Close();
            }
            else MessageBox.Show("Некоторые поля не заполнены");

        }
    }
}
