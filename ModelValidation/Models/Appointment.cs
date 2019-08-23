using System;
using System.ComponentModel.DataAnnotations;
using ModelValidation.Infrastructure;

namespace ModelValidation.Models
{
    public class Appointment
    {
        public string ClientName { get; set; }
        [UIHint("Date")]
        public DateTime Date { get; set; }
        [MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}