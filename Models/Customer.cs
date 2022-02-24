using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaWPF.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        [Column("idCustomer")]
        public int IdCustomer { get; set; }

        [Required(ErrorMessage = "Le champs Nom doit etre rempli.")]
        [Display(Name = "Le nom de famille")]
        [Column("lastname")]
        public string? Lastname { get; set; } = null;

        [Required(ErrorMessage = "Le champs Prénom doit etre rempli.")]
        [Display(Name = "Le prénom")]
        [Column("firstname")]
        public string? Firstname { get; set; } = null;

        [Required(ErrorMessage = "Le champs Email doit etre rempli.")]
        [Display(Name = "L'adresse email")]
        [EmailAddress(ErrorMessage = "Vous n'avez pas entré une adresse email.")]
        [Column("mail")]
        public string? Mail { get; set; } = null;

        [Required(ErrorMessage = "Le champs Numéro de téléphone doit etre rempli.")]
        [Display(Name = "Le numéro de téléphone")]
        [MinLength(10, ErrorMessage = "Le numéro doit comporter au moins 10 chiffres.")]
        [MaxLength(10, ErrorMessage = "Le numéro doit comporter maximum 10 chiffres.")]
        [Column("phoneNumber")]
        public string? PhoneNumber { get; set; } = null;

        [Required(ErrorMessage = "Le champs Budget doit etre rempli.")]
        [Display(Name = "Le budget en chiffres (sans le €)")]
        [Range(1, 1000, ErrorMessage = "Vous devez indiquer un chiffre si vous pensez être hors budget indiquez 9999")]
        [Column("budget")]
        public int? Budget { get; set; } // int? veut dire qu'il est nullable

        [InverseProperty(nameof(Appointment.IdCustomerNavigation))]
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
