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

namespace AgendaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new System.Uri("/Views/CustomersList.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("/Views/AddCustomer.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void CustomersList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("/Views/CustomersList.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void AddBroker_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("/Views/AddBroker.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void BrokersList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("/Views/BrokersList.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("/Views/AddAppointment.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void AppointmentsList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("/Views/AppointmentsList.xaml",
             UriKind.RelativeOrAbsolute));
        }
    }
}
