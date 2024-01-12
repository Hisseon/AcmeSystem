using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcmeSys.Dominio.Elements; 
using AcmeSys.Dominio.Interfaces;
using AcmeSys.Infra.EntityFrmwk; 
namespace AcmeSys.Infra.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly MyDbContext _context;

        public PurchaseRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            return await _context.Purchases.FindAsync(id);
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await _context.Purchases.ToListAsync();
        }

        public async Task AddAsync(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Purchase purchase)
        {
            _context.Purchases.Update(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Purchase purchase)
        {
            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();
        }
    }
}
