using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.Models
{
    public class Notifications
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int TenantId { get; set; }
        [StringLength(255)]
        public string GuestMessage { get; set; }
        [StringLength(255)]
        public string ImgUrl { get; set; }
        [Required]
        public bool IsOpen { get; set; }

    }
}