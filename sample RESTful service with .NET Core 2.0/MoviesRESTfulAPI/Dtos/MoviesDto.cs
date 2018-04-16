using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MoviesRESTfulAPI.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
        public byte AvailableInStock { get; set; }
        public string Description { get; set; }
        [Required]
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }
        public ICollection<int> Actors { get; set; }
        public MoviesDto()
        {
            Actors = new Collection<int>();
        }
    }
}
