using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesRESTfulAPI.Dtos
{
    public class ActorsDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Bio { get; set; }
    }
}
