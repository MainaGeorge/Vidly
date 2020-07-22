using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        // [Ensure18YearsOfAgeWithAnySubscription]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Subscribe to newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Please select a subscription")]
        [Display(Name = "Subscription")]
        public byte MembershipTypeId { get; set; }
    }
}