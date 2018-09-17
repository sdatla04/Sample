using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly082018.Models;

namespace Vidly082018.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> GenreTypes { get; set; }
       // public Movie Movie { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter a movie name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        [Required]
        public byte InStock { get; set; }

 
        public string Title
        {
            get
            {
                return (Id != 0) ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            InStock = movie.InStock;
        }

    }
}