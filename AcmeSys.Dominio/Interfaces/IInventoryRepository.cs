using AcmeSys.Dominio.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSys.Dominio.Interfaces
{
    public interface IInventoryRepository
    {
        Task<Inventory> GetByIdAsync(int id);
        Task<IEnumerable<Inventory>> GetAllAsync();
        Task AddAsync(Inventory inventory);
        Task UpdateAsync(Inventory inventory);
        Task DeleteAsync(Inventory inventory);
    }

}
