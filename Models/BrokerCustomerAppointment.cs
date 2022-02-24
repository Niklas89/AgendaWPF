using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaWPF.Models
{
    public partial class BrokerCustomerAppointment
    {
        public Broker BrokerVm { get; set; }
        public Customer CustomerVm { get; set; }
        public Appointment AppointmentVm { get; set; }
    }
}
