using AcmeSys.Dominio.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSys.Dominio.Interfaces
{
    public interface ISubsidiaryRepository
    {
        Task<Subsidiary> GetByIdAsync(int id);
        Task<IEnumerable<Subsidiary>> GetAllAsync();
        Task AddAsync(Subsidiary subsidiary);
        Task UpdateAsync(Subsidiary subsidiary);
        Task DeleteAsync(Subsidiary subsidiary);        
    }

}
