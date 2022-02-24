using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgendaWPF.Data;

namespace AgendaWPF.Models
{
    public partial class Broker
    {
        public Broker()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        [Column("idBroker")]
        public int IdBroker { get; set; }

        [Required(ErrorMessage = "Le champs Nom doit etre rempli.")]
        [Display(Name = "Votre nom de famille")]
        [Column("lastname")]
        public string Lastname { get; set; } = null!;

        [Required(ErrorMessage = "Le champs Prénom doit etre rempli.")]
        [Display(Name = "Votre prénom")]
        [Column("firstname")]
        public string Firstname { get; set; } = null!;

        [Required(ErrorMessage = "Le champs Email doit etre rempli.")]
        [Display(Name = "Votre adresse email")]
        [EmailAddress(ErrorMessage = "Vous n'avez pas entré une adresse email.")]
        [Column("mail")]
        public string Mail { get; set; } = null!;

        [Required(ErrorMessage = "Le champs Numéro de téléphone doit etre rempli.")]
        [Display(Name = "Votre numéro de téléphone")]
        [MinLength(10, ErrorMessage = "Le numéro doit comporter au moins 10 chiffres.")]
        [MaxLength(10, ErrorMessage = "Le numéro doit comporter maximum 10 chiffres.")]
        [Column("phoneNumber")]
        public string PhoneNumber { get; set; } = null!;

        [InverseProperty(nameof(Appointment.IdBrokerNavigation))]
        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
