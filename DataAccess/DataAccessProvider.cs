using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ciberinfraestructura_tarea2_webserver_rest.Models;

namespace ciberinfraestructura_tarea2_webserver_rest.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly AppDbContext _context;

        public DataAccessProvider(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CatPersonal>> GetAllAsync()
        {
            return await _context.CatPersonales.AsNoTracking().ToListAsync();
        }

        public async Task<CatPersonal?> GetByIdAsync(int id)
        {
            return await _context.CatPersonales.FindAsync(id);
        }

        public async Task<CatPersonal> AddAsync(CatPersonal item)
        {
            var entity = (await _context.CatPersonales.AddAsync(item)).Entity;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}