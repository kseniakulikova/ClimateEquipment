using ClimateEquipment.DataBase;
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

namespace ClimateEquipment
{
    /// <summary>
    /// Логика взаимодействия для Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        public Customer(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadData();
        }
        private readonly CondiEntities _context = new CondiEntities();
        private readonly int _userId;
        private void LoadData()
        {
            var requests = _context.Bid.Where(r => r.UserID == _userId).ToList();
            BidListView.ItemsSource = requests;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddBid addWindow = new AddBid(new Bid(), _userId);
            addWindow.ShowDialog();
            LoadData();
        }

        private void editMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            Bid partners = menuItem.DataContext as Bid;
            AddBid addPartnerWindow = new AddBid(new Bid(), _userId);
            addPartnerWindow.ShowDialog();
            LoadData();
        }
    }
}
