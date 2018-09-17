using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly082018.Models;

namespace Vidly082018.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Movie> Movies { get; set; }
    }
}