using System.Collections.Generic;
using System.Threading.Tasks;
using ciberinfraestructura_tarea2_webserver_rest.Models;

namespace ciberinfraestructura_tarea2_webserver_rest.DataAccess
{
    public interface IDataAccessProvider
    {
        Task<IEnumerable<CatPersonal>> GetAllAsync();
        Task<CatPersonal?> GetByIdAsync(int id);
        Task<CatPersonal> AddAsync(CatPersonal item);
    }
}