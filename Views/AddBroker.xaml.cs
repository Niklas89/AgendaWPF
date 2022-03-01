using AgendaWPF.Data;
using AgendaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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

namespace AgendaWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour AddBroker.xaml
    /// </summary>
    public partial class AddBroker : Page
    {
        public List<bool> errorList = new List<bool>();
        private readonly DbConnect _db;

        public AddBroker()
        {
            InitializeComponent();
            _db = new DbConnect();
        }

        private void AddBroker_Click(object sender, RoutedEventArgs e)
        {
            Broker broker = new Broker();
            try
            {
                broker.Firstname = CheckString(Firstname.Text.Trim(), "prénom");
                broker.Lastname = CheckString(Lastname.Text.Trim(), "nom");
                broker.PhoneNumber = CheckTelephoneNumber(PhoneNumber.Text.Trim(), "numéro de telephone");
                broker.Mail = CheckMail(Mail.Text.Trim(), "email");

                if (errorList.Contains(false))
                {
                    errorList = new List<bool>();
                    return;
                }

                _db.Brokers.Add(broker);
                _db.SaveChanges();

                NavigationService.Refresh();

                MessageBox.Show("Le courtier a bien été ajouté.");

            } catch(Exception)
            {
                MessageBox.Show("Erreur d'ajout du courtier, veuillez recommencer.");
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

        private void addTextBox(string value)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Le champs " + value + " n'est pas valide";
            textBlock.Foreground = new SolidColorBrush(Colors.Red);
            errorForm.Children.Add(textBlock);
        }
    }
}
