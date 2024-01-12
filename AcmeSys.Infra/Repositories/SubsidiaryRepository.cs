using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcmeSys.Dominio.Elements; 
using AcmeSys.Dominio.Interfaces;
using AcmeSys.Infra.EntityFrmwk; 
namespace AcmeSys.Infra.Repositories
{
    public class SubsidiaryRepository : ISubsidiaryRepository
    {
        private readonly MyDbContext _context;

        public SubsidiaryRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Subsidiary> GetByIdAsync(int id)
        {
            return await _context.Subsidiaries.FindAsync(id);
        }

        public async Task<IEnumerable<Subsidiary>> GetAllAsync()
        {
            return await _context.Subsidiaries.ToListAsync();
        }

        public async Task AddAsync(Subsidiary subsidiary)
        {
            _context.Subsidiaries.Add(subsidiary);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Subsidiary subsidiary)
        {
            _context.Subsidiaries.Update(subsidiary);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Subsidiary subsidiary)
        {
            _context.Subsidiaries.Remove(subsidiary);
            await _context.SaveChangesAsync();
        }
    }
}
