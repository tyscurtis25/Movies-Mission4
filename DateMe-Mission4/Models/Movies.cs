using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DateMe_Mission4.Models
{
    public class Movies
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2050, ErrorMessage ="Must be later than 1900")]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Lent_to { get; set; }

        [StringLength(25, ErrorMessage ="Notes are limited to 25 characters.")]
        public string Notes { get; set; }

        // build foreign key relationship
        public int CategoryID { get; set; } // Foreign Key
        public Category Category { get; set; }

    }
}
