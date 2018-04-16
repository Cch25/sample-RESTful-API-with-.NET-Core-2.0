using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRESTfulAPI.Models
{
    public class MovieActors
    {
        public int ActorsId { get; set; }
        public int MoviesId { get; set; }
        public Movies Movies { get; set; }
        public Actors Actors { get; set; }
    }
}
