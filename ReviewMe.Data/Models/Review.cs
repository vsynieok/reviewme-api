using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReviewMe.Data.Models
{
    public class Review
    {
        public Guid? Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(0, 5)]
        public float Rating { get; set; }
        [Required]
        [MaxLength(255)]
        public string Comment { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
