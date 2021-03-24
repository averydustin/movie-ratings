using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace MovieStorageAveryDustin.Models
{
    public class MovieResponse
    {
        [Key]
        public int MovieId { get; set; }
        [Required (ErrorMessage ="Please Enter a Category")]
        public string Category { get; set; }
        [Required (ErrorMessage = "Please Enter a Title")]
        public string Title { get; set; }
        [Required (ErrorMessage = "Please Enter a Start Year")]
        public int StartYear { get; set; }
        [Required (ErrorMessage = "Please Enter a Director Name")]
        public string DirectorName { get; set; }
        [Required(ErrorMessage = "Please Enter a Rating")]
        public string Rating { get; set; }

        public bool Edit { get; set; }
        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
    }
}
