using AgendaWPF.Models;
using AgendaWPF.Data;
using AgendaWPF.ViewModels;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace AgendaWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour CustomersList.xaml
    /// </summary>
    public partial class CustomersList : Page
    {
        // Error messages list where we check which errors we got
        public List<bool> errorList = new List<bool>();

        private readonly DbConnect _db;
        // Dummy columns for layers 0 and 1:
        ColumnDefinition colOneCopyForLayer0;
        ColumnDefinition colTwoCopyForLayer0;
        ColumnDefinition colTwoCopyForLayer1;

        //EditForm editform = new EditForm();

        public CustomersList()
        {
            InitializeComponent();
            //this.DataContext = editform;

            // Initialize the dummy (grouped) columns that are created during docking:
            colOneCopyForLayer0 = new ColumnDefinition();
            colOneCopyForLayer0.SharedSizeGroup = "column1";
            colTwoCopyForLayer0 = new ColumnDefinition();
            colTwoCopyForLayer0.SharedSizeGroup = "column2";
            colTwoCopyForLayer1 = new ColumnDefinition();
            colTwoCopyForLayer1.SharedSizeGroup = "column2";

            //panel1PinImg.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images/VerticalPin.png")));
            panel1PinImg.Source = new BitmapImage(new Uri("/Images/VerticalPin.png",UriKind.Relative));

            // add clients to list from db
            _db = new DbConnect();

            loadDataGrid();

            // add clients manually without db, using ViewModel
            //dataGrid.ItemsSource = CustomersListViewModel.GetCustomers();
        }

        public void btnView_Click(object sender, RoutedEventArgs e)
        {
            Customer selectedCustomer = (Customer)dataGrid.SelectedItem;
            //string message = selectedCustomer.Lastname + " " + selectedCustomer.Firstname + " " + selectedCustomer.Mail + " " + selectedCustomer.PhoneNumber + " " + selectedCustomer.Budget;
            // MessageBox.Show(message);

            txtIdCustomer.Text = selectedCustomer.IdCustomer + "";
            txtLastname.Text = selectedCustomer.Lastname;
            txtFirstname.Text = selectedCustomer.Firstname;
            txtMail.Text = selectedCustomer.Mail;
            txtPhonenumber.Text = selectedCustomer.PhoneNumber;
            txtBudget.Text = selectedCustomer.Budget + "";

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
            int idCust = CheckId(txtIdCustomer.Text, "identifiant-client");

            try { 
                var customer = _db.Customers.Find(idCust);

                customer.Lastname = CheckString(txtLastname.Text.Trim(), "nom");
                customer.Firstname = CheckString(txtFirstname.Text.Trim(), "prénom");
                customer.Mail = CheckMail(txtMail.Text.Trim(), "email");
                customer.PhoneNumber = CheckTelephoneNumber(txtPhonenumber.Text.Trim(), "numéro de telephone");
                customer.Budget = CheckBudget(txtBudget.Text.Trim(), "budget"); ;

                _db.Customers.Update(customer);
                _db.SaveChanges();

                MessageBox.Show("Client modifié avec succès !");

                loadDataGrid();

            } catch(Exception)
            {
                MessageBox.Show("Le client n'existe pas");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            int idCust = CheckId(txtIdCustomer.Text, "identifiant-client");

            try
            {
                var customer = _db.Customers.Find(idCust);

                _db.Customers.Remove(customer);
                _db.SaveChanges();

                MessageBox.Show("Client supprimé avec succès !");

                loadDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Le client n'existe pas");
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

        private void loadDataGrid()
        {
            IEnumerable<Customer> customers = _db.Customers;
            dataGrid.ItemsSource = customers.ToList();
        }
    }

}
