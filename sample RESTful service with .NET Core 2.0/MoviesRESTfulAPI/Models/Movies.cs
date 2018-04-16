using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRESTfulAPI.Models
{
    public class Movies
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
        [Required]
        public byte AvailableInStock { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<MovieActors> Actors { get; set; }
        public Movies()
        {
            Actors = new Collection<MovieActors>();
        }
    }
}
