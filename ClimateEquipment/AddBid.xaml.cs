using ClimateEquipment.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Sockets;
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

namespace ClimateEquipment
{
    /// <summary>
    /// Логика взаимодействия для AddBid.xaml
    /// </summary>
    public partial class AddBid : Window
    {
        Bid _currentBid;
    
        public AddBid(Bid currentBid, int userId)
        {
            InitializeComponent();
            _userId = userId;
            DataContext = _currentBid;
                //Заполнение полей формы данными партнера
        }
        private readonly int _userId;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var context = new CondiEntities())
                {
                    // Получаем идентификатор текущего пользователя

                    // Создаём объект заявки
                    var bid = new Bid
                    {
                        Type = type.Text,
                        Model = model.Text,
                        Problem = problem.Text,
                        Date_added = date.Text,
                        Status = status.Text,
                        FIO = fio.Text,
                        Phone = phone.Text,
                        UserID = _userId // Привязка заявки к текущему пользователю
                    };

                    // Добавляем заявку в контекст и сохраняем изменения
                    context.Bid.Add(bid);
                    context.SaveChanges();

                    MessageBox.Show("Заявка успешно сохранена!", "Успех");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
