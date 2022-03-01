using AgendaWPF.Data;
using AgendaWPF.Models;
using System;
using System.Collections;
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
    /// Logique d'interaction pour AppointmentsList.xaml
    /// </summary>
    public partial class AppointmentsList : Page
    {
        // Error messages list where we check which errors we got
        public List<bool> errorList = new List<bool>();

        private readonly DbConnect _db;
        // Dummy columns for layers 0 and 1:
        ColumnDefinition colOneCopyForLayer0;
        ColumnDefinition colTwoCopyForLayer0;
        ColumnDefinition colTwoCopyForLayer1;

        public AppointmentsList()
        {
            InitializeComponent();

            // Initialize the dummy (grouped) columns that are created during docking:
            colOneCopyForLayer0 = new ColumnDefinition();
            colOneCopyForLayer0.SharedSizeGroup = "column1";
            colTwoCopyForLayer0 = new ColumnDefinition();
            colTwoCopyForLayer0.SharedSizeGroup = "column2";
            colTwoCopyForLayer1 = new ColumnDefinition();
            colTwoCopyForLayer1.SharedSizeGroup = "column2";

            //panel1PinImg.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images/VerticalPin.png")));
            panel1PinImg.Source = new BitmapImage(new Uri("/Images/VerticalPin.png", UriKind.Relative));

            // add clients to list from db
            _db = new DbConnect();

            loadDataGrid();
        }

        public void btnView_Click(object sender, RoutedEventArgs e)
        {
            BrokerCustomerAppointment selectedAppointment = (BrokerCustomerAppointment)dataGrid.SelectedItem;

            txtIdAppointment.Text = selectedAppointment.AppointmentVm.IdAppointment + "";
            txtDateHour.Text = selectedAppointment.AppointmentVm.DateHour + "";
            txtSubject.Text = selectedAppointment.AppointmentVm.Subject;
            BrokerName.ItemsSource = _db.Brokers.ToList();
            ClientName.ItemsSource = _db.Customers.ToList();

        }


        // Toggle panel 1 between docked and undocked states
        public void panel1Pin_Click(object sender, RoutedEventArgs e)
        {
            if (btnOne.Visibility == Visibility.Collapsed)
                UndockPane(1);
            else
                DockPane(1);
        }

        // Make panel 1 visible when hovering over its button
        public void btnOne_MouseEnter(object sender, RoutedEventArgs e)
        {
            gridlayer1.Visibility = Visibility.Visible;

            // Adjust ZIndex order to ensure the pane is on top:
            parentGrid.Children.Remove(gridlayer1);
            parentGrid.Children.Add(gridlayer1);

        }

        // Hide any undocked panes when the mouse enters Layer 0
        public void layer0_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (btnOne.Visibility == Visibility.Visible)
                gridlayer1.Visibility = Visibility.Collapsed;
        }

        // Docks a pane and hides its button
        public void DockPane(int paneNumber)
        {

            btnOne.Visibility = Visibility.Collapsed;
            panel1PinImg.Source = new BitmapImage(new Uri("/Images/VerticalPin.png", UriKind.Relative));

            // Add the cloned column to layer 0:
            layer0.ColumnDefinitions.Add(colOneCopyForLayer0);


        }

        // Undocks a pane, which reveals the corresponding pane button
        public void UndockPane(int panelNbr)
        {

            gridlayer1.Visibility = Visibility.Collapsed;
            btnOne.Visibility = Visibility.Visible;
            panel1PinImg.Source = new BitmapImage(new Uri("/Images/HorizontalPin.png", UriKind.Relative));

            // Remove the cloned columns from layers 0 and 1:
            layer0.ColumnDefinitions.Remove(colOneCopyForLayer0);
            // This won't always be present, but Remove silently ignores bad columns:
            gridlayer1.ColumnDefinitions.Remove(colTwoCopyForLayer1);

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int idApp = CheckId(txtIdAppointment.Text, "identifiant-rendez-vous");

            try { 
                var appointment = _db.Appointments.Find(idApp);
                DateTime date = CheckDate(txtDateHour.Text, "date");

                appointment.DateHour = date;
                appointment.Subject = CheckString(txtSubject.Text.Trim(), "sujet");

                if(ClientName.SelectedValue == null || BrokerName.SelectedValue == null)
                {
                    addTextBox("client ou courtier n'est pas séléctionné.");
                    errorList.Add(false);
                }
               
                if (errorList.Contains(false))
                {
                    errorList = new List<bool>();
                    return;
                }

                appointment.IdCustomer = CheckId(ClientName.SelectedValue.ToString(), "identifiant-client");
                appointment.IdBroker = CheckId(BrokerName.SelectedValue.ToString(), "identifiant-courtier");

                _db.Appointments.Update(appointment);
                _db.SaveChanges();

                NavigationService.Refresh();

                MessageBox.Show("Le rendez-vous modifié avec succès !");

                loadDataGrid();
            }
            catch(Exception) 
            {
                MessageBox.Show("Erreur de modification du rendez-vous, veuillez recommencer.");
            }

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

        public string CheckString(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                addTextBox(name);
                errorList.Add(false);
            }

            return value;

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int idApp = CheckId(txtIdAppointment.Text, "identifiant-rendez-vous");

            try
            {
                var appointment = _db.Appointments.Find(idApp);

                _db.Appointments.Remove(appointment);
                _db.SaveChanges();

                MessageBox.Show("Rendez-vous supprimé avec succès !");

                loadDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Votre rendez-vous n'existe pas.");
            } 
        }

        private void addTextBox(string value)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Le champs " + value + " n'est pas valide";
            textBlock.Foreground = new SolidColorBrush(Colors.Red);
            errorForm.Children.Add(textBlock);
        }

        private void loadDataGrid()
        {
            IEnumerable<Appointment> Appointments = _db.Appointments;
            IEnumerable<Broker> Brokers = _db.Brokers;
            IEnumerable<Customer> Customers = _db.Customers;

            IEnumerable<BrokerCustomerAppointment> AppointmentList = from a in Appointments.ToList()
                                                                     join c in Customers.ToList() on a.IdCustomer equals c.IdCustomer
                                                                     join b in Brokers.ToList() on a.IdBroker equals b.IdBroker
                                                                     select new BrokerCustomerAppointment { AppointmentVm = a, CustomerVm = c, BrokerVm = b };
            dataGrid.ItemsSource = AppointmentList;
        }
    }
}
