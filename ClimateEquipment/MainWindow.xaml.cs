using ClimateEquipment.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ClimateEquipment
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private readonly CondiEntities _context = new CondiEntities();

        private void buttonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPass.Text;

            var user = _context.User.FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                switch (user.User_type)
                {
                    case "Администратор":
                        // Открываем окно для администратора
                        Admin adminWindow = new Admin();
                        adminWindow.Show();
                        this.Close(); // Закрыть текущее окно
                        break;
                    case "Заказчик":
                        // Открываем окно для обычного пользователя
                        Customer userWindow = new Customer(user.ID);
                        userWindow.Show();
                        this.Close(); // Закрыть текущее окно
                        break;
                    default:
                        MessageBox.Show("Неизвестная роль пользователя.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }

        }
    }
}
