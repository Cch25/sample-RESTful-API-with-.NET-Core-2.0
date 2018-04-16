using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesRESTfulAPI.Models;

namespace MoviesRESTfulAPI.Core
{
    public interface IMovieRepository : IRepository<Movies>
    {
        Task<List<Movies>> GetAllMovies();
        Task<Movies> GetMovie(int id);
    }
}
