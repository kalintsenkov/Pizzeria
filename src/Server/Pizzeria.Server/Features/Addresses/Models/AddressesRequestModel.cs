namespace Pizzeria.Server.Features.Addresses.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Address;
    using static Data.DataConstants.Common;

    public class AddressesRequestModel
    {
        [Required]
        [MaxLength(MaxCityLength)]
        public string City { get; set; }


        [Required]
        [MaxLength(MaxRegionLength)]
        public string Region { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [MinLength(MinPhoneNumberLength)]
        [MaxLength(MaxPhoneNumberLength)]
        [RegularExpression(PhoneNumberRegularExpression)]
        public string PhoneNumber { get; set; }
    }
}
