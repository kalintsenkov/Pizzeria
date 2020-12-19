namespace Pizzeria.Server.Data.Models
{
    using System.Collections.Generic;
    using Common;

    public class Address : Entity
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public PizzeriaUser User { get; set; }

        public ICollection<Order> Orders { get; } = new HashSet<Order>();
    }
}
