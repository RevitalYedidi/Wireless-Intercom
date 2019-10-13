using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.Models
{
    public class Building
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string City { get; set; }
        [Required]
        [StringLength(255)]
        public string Adress { get; set; }
        public string CyferCode { get; set; }
    }
}