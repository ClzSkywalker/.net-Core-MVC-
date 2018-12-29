using System.Collections.Generic;
using System.Threading.Tasks;
using DemoCoreStudy.Models;

namespace DemoCoreStudy.Serivce
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetllAllAsync();//查询所有的Cinema值
        Task<Cinema> GetByIdAsync(int id);//查询指定ID的Cinema
        Task AddAsync(Cinema model);//创建Cinema值
    }
}
