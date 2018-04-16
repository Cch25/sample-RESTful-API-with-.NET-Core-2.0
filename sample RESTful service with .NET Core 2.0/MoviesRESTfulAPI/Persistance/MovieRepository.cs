using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesRESTfulAPI.Core;
using MoviesRESTfulAPI.DAL;
using MoviesRESTfulAPI.Models;

namespace MoviesRESTfulAPI.Persistance
{
    public class MovieRepository : Repository<Movies>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Movies>> GetAllMovies()
        {
            return await _context
                .Movies
                .Include(g => g.Genre)
                .Include(a=>a.Actors)
                .ThenInclude(ma=>ma.Actors)
                .ToListAsync();
        }

        public async Task<Movies> GetMovie(int id)
        {
            return await _context
                .Movies
                .Include(g => g.Genre)
                .Include(a => a.Actors)
                .ThenInclude(ma => ma.Actors)
                .SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}
