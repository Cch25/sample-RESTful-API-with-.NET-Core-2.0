using System.Threading.Tasks;
using MoviesRESTfulAPI.Core;
using MoviesRESTfulAPI.DAL;

namespace MoviesRESTfulAPI.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IMovieRepository Movies { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
