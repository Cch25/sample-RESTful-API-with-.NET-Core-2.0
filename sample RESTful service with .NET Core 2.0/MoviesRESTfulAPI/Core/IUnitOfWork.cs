using System.Threading.Tasks;

namespace MoviesRESTfulAPI.Core
{
    public interface IUnitOfWork
    {
        IMovieRepository Movies { get; }
        Task SaveChangesAsync();
    }
}
