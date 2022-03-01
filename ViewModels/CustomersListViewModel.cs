using AgendaWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AgendaWPF.Views;
using AgendaWPF.Data;

namespace AgendaWPF.ViewModels
{


    public class CustomersListViewModel : INotifyPropertyChanged
    {
        private readonly DbConnect _db;

        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set
            {
                lastname = value;
                RaiseProperChanged();
            }
        }

        private string firstname;

        public string Firstname
        {
            get { return firstname; }
            set
            {
                firstname = value;
                RaiseProperChanged();
            }
        }

        private string mail;

        public string Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                RaiseProperChanged();
            }
        }

        private string phonenumber;

        public string PhoneNumber
        {
            get { return phonenumber; }
            set
            {
                phonenumber = value;
                RaiseProperChanged();
            }
        }

        private string budget;

        public string Budget
        {
            get { return budget; }
            set
            {
                budget = value;
                RaiseProperChanged();
            }
        }

        public static ObservableCollection<Customer> GetCustomers()
        {
            var customers = new ObservableCollection<Customer>();

            customers.Add(new Customer()
            {
                Lastname = "Ali",
                Firstname = "Minister",
                Mail = "qsdsqd@aze.com",
                PhoneNumber = "1209382",
                Budget = 213
            });

            customers.Add(new Customer()
            {
                Lastname = "Ed",
                Firstname = "Niklas",
                Mail = "qsdsqd@aze.com",
                PhoneNumber = "1209382",
                Budget = 213
            });

            return customers;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseProperChanged([CallerMemberName] string caller = "")
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
