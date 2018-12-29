using System.Collections.Generic;
using System.Threading.Tasks;
using DemoCoreStudy.Models;

namespace DemoCoreStudy.Serivce
{
    public interface IMovieService
    {
        Task AddAsync(Movie model);
        Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId);
    }
}
