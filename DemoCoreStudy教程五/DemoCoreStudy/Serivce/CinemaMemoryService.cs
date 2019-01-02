using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCoreStudy.Models;

namespace DemoCoreStudy.Serivce
{
    public class CinemaMemoryService : ICinemaService
    {
        private readonly List<Cinema> _cinema=new List<Cinema>();

        public CinemaMemoryService()
        {
            _cinema.Add(new Cinema
            {
                Id = 1,
                Name ="天堂电影院",
                Location = "上海",
                Capacity = 1000
            });
            _cinema.Add(new Cinema
            {
                Id=2,
                Name = "疯人电影院",
                Location = "北京",
                Capacity = 10000
            });
        }

        public Task<IEnumerable<Cinema>> GetllAllAsync()
        {
            return Task.Run(() => _cinema.AsEnumerable());
        }

        public Task<Cinema> GetByIdAsync(int id)
        {
            return Task.Run(() => _cinema.SingleOrDefault(x => x.Id == id));
        }

        public Task AddAsync(Cinema model)
        {
            var maxId = _cinema.Max(x => x.Id);
            model.Id = maxId + 1;
            _cinema.Add(model);
            return Task.CompletedTask;
        }
    }
}
