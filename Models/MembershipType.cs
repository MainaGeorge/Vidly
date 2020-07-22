using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public short SignUpFee { get; set; }

        [Display(Name = "Subscription")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public static byte PayAsYouGo = 1;
        public static byte UnknownSubscription = 0;
    }
}