
using System;
using System.ComponentModel.DataAnnotations;

namespace PIT.Models
{
    public class Plant
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string ScientificName { get; set; } = string.Empty;

        [Range(0, 100)]
        public int Health { get; set; } = 100;

        public DateTime LastWatered { get; set; } = DateTime.Now;

        
        public DateTime? NextWatering { get; set; }

        public string? ImageUrl { get; set; }
    }
}

