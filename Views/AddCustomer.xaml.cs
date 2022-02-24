using AgendaWPF.Data;
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
using AgendaWPF.Models;

namespace AgendaWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        private readonly DbConnect _db;

        public AddCustomer()
        {
            InitializeComponent();
            _db = new DbConnect();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            
            Customer customer = new Customer();

            customer.Firstname = Firstname.Text;
            customer.Lastname = Lastname.Text;
            customer.PhoneNumber = PhoneNumber.Text;
            customer.Mail = Mail.Text;
            

            int numberBudget;
            bool success = int.TryParse(Budget.Text, out numberBudget);
            if (success)
            {
                customer.Budget = numberBudget;
            }
            else
            {
                MessageBox.Show("Le budget doit être sous forme d'entiers !");
            }


            _db.Customers.Add(customer);
            _db.SaveChanges();
            MessageBox.Show("Le client a bien été ajouté.");
            // MessageBox.Show("Bonjour " + Firstname.Text + Lastname.Text + PhoneNumber.Text + Mail.Text + Budget.Text);
        }
    }
}
