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
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace AgendaWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        public List<bool> errorList = new List<bool>();
        private readonly DbConnect _db;

        public AddCustomer()
        {
            InitializeComponent();
            _db = new DbConnect();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            errorForm.Children.Clear();
            Customer customer = new Customer();
            try
            {
                customer.Firstname = CheckString(Firstname.Text.Trim(), "prénom");
                customer.Lastname = CheckString(Lastname.Text.Trim(), "nom");
                customer.PhoneNumber = CheckTelephoneNumber(PhoneNumber.Text.Trim(), "numéro de telephone");
                customer.Mail = CheckMail(Mail.Text.Trim(), "email");
                customer.Budget = CheckBudget(Budget.Text.Trim(), "budget");

                if (errorList.Contains(false))
                {
                    errorList = new List<bool>();
                    return;
                }

                _db.Customers.Add(customer);
                _db.SaveChanges();

                NavigationService.Refresh();

                MessageBox.Show("Le client a bien été ajouté.");

            } catch(Exception)
            {
                MessageBox.Show("Erreur d'ajout du client, veuillez recommencer.");
            }
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public string CheckString(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                addTextBox(name);
                errorList.Add(false);
            }

            return value;

        }

        public string CheckTelephoneNumber(string value, string name)
        {
            Regex regex = new Regex(@"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$");
            Match match = regex.Match(value.ToString());
            if (value == string.Empty || match == Match.Empty)
            {
                addTextBox(name);
                errorList.Add(false);
            }
            return value;
        }

        public string CheckMail(string value, string name)
        {
            try
            {
                MailAddress mail = new MailAddress(value);
                return mail.ToString();
            }
            catch (FormatException)
            {
                addTextBox(name);
                errorList.Add(false);
            }

            return value;

        }

        public int CheckBudget(object value, string name)
        {
            int myInt;
            if (int.TryParse((string?)value, out myInt))
            {
                return myInt;
            }
            else
            {
                addTextBox(name);
                errorList.Add(false);
                return 0;
            }
        }

        private void addTextBox(string value)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Le champs " + value + " n'est pas valide";
            textBlock.Foreground = new SolidColorBrush(Colors.Red);
            errorForm.Children.Add(textBlock);
        }
    }
}
