using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcmeSys.Dominio.Elements; 
using AcmeSys.Dominio.Interfaces;
using AcmeSys.Infra.EntityFrmwk; 

namespace AcmeSys.Infra.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly MyDbContext _context;

        public InventoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Inventory> GetByIdAsync(int id)
        {
            return await _context.Inventories.FindAsync(id);
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _context.Inventories.ToListAsync();
        }

        public async Task AddAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Inventory inventory)
        {
            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();
        }
    }
}
