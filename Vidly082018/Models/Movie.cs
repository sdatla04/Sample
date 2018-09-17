using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly082018.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a movie name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Range(1,20)]
        [Display(Name = "Number In Stock")]
        public byte InStock { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

    }
}