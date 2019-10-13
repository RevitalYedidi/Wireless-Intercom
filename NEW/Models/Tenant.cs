using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.Models
{
    public class Tenant
    {
        public int BuildingId { get; set; }
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        public int ApartmentNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool Admin { get; set; }

    }
}