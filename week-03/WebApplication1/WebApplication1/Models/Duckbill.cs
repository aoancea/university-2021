using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Duckbill
    {
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}