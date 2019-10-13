using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NEW.Models
{
    public class Entrances
    {
        [Key]
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int TenantId { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
    }
}