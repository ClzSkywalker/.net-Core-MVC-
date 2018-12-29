using DemoCoreStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCoreStudy.Serivce
{
    public class MovieMemoryService : IMovieService
    {
        private readonly List<Movie> _movies=new List<Movie>();

        public MovieMemoryService()
        {
            _movie.Add(new Movie
            {
                Id = 1,
                CinemaId = 1,
                Name = "这个杀手不太冷",
                ReleseDate = new DateTime(2018, 1, 1),
                Starring = "Tommy"
            });
            _movie.Add(new Movie
            {
                Id = 2,
                CinemaId = 2,
                Name = "笑傲江湖",
                ReleseDate = new DateTime(2018, 1, 1),
                Starring = "Tommy"
            });
            _movie.Add(new Movie
            {
                Id = 2,
                CinemaId = 2,
                Name = "小萝莉与猴神大叔",
                ReleseDate = new DateTime(2018, 1, 1),
                Starring = "Tommy"
            });
        }

        public Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId)
        {
            return Task.Run(() => _movies.Where(x=>x.CinemaId==cinemaId));
        }

        public Task AddAsync(Movie model)
        {
            var maxId = _movies.Max(x => x.Id);

            model.Id = maxId + 1;
            _movies.Add(model);
            return Task.CompletedTask;
        }
    }
}
