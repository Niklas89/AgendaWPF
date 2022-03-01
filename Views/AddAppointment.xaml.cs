using AgendaWPF.Data;
using AgendaWPF.Models;
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

namespace AgendaWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Page
    {
        public List<bool> errorList = new List<bool>();
        private readonly DbConnect _db;

        public AddAppointment()
        {
            InitializeComponent();

            // add clients to list from db
            _db = new DbConnect();

            BrokerName.ItemsSource = _db.Brokers.ToList();
            ClientName.ItemsSource = _db.Customers.ToList();
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            try
            {

                double hour = CheckTime(AppointmentHour.Text, "heures");
                double minute = CheckTime(AppointmentMinute.Text, "minutes");
                DateTime date = CheckDate(AppointmentDate.ToString(), "date");
                string subject = CheckString(AppointmentSubject.Text.Trim(), "sujet");
                int idcustomer = CheckId(ClientName.SelectedValue.ToString(), "identifiant-client");
                int idbroker = CheckId(BrokerName.SelectedValue.ToString(), "identifiant-courtier");

                //appointment.DateHour = Convert.ToDateTime(AppointmentDate.ToString()).AddHours(hour).AddMinutes(minute);
                appointment.DateHour = date.AddHours(hour).AddMinutes(minute);
                appointment.Subject = subject;
                appointment.IdCustomer = idcustomer;
                appointment.IdBroker = idbroker;

                if (errorList.Contains(false))
                {
                    errorList = new List<bool>();
                    return;
                }

                _db.Appointments.Add(appointment);
                _db.SaveChanges();

                NavigationService.Refresh();

                MessageBox.Show("Le rendez-vous a bien été ajouté.");

            }
            catch (Exception)
            {
                MessageBox.Show("Erreur d'ajout du rendez-vous, veuillez recommencer.");
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

        public int CheckId(object value, string name)
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

        public double CheckTime(object value, string name)
        {
            double myDouble;
            if (double.TryParse((string?)value, out myDouble))
            {
                return myDouble;
            }
            else
            {
                addTextBox(name);
                errorList.Add(false);
                return 0;
            }
        }

        public DateTime CheckDate(object value, string name)
        {
            DateTime tempDate;
            if (DateTime.TryParse((string?)value, out tempDate))
            {
                return tempDate;
            }
            else
            {
                addTextBox(name);
                errorList.Add(false);
            }
            return DateTime.Now;
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
