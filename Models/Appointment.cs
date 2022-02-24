using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaWPF.Models
{
    public partial class Appointment
    {
        [Key]
        [Column("idAppointment")]
        public int IdAppointment { get; set; }

        [Column("dateHour")]
        public DateTime DateHour { get; set; }

        [Column("subject")]
        public string Subject { get; set; } = null!;

        [Column("idCustomer")]
        public int IdCustomer { get; set; }

        [Column("idBroker")]
        public int IdBroker { get; set; }

        [ForeignKey(nameof(IdBroker))]
        public virtual Broker IdBrokerNavigation { get; set; } = null!;

        [ForeignKey(nameof(IdCustomer))]
        public virtual Customer IdCustomerNavigation { get; set; } = null!;
    }
}
