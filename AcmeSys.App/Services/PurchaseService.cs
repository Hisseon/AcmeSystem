using AcmeSys.App.DTOs;
using AcmeSys.Dominio.Elements;
using AcmeSys.Dominio.Interfaces;
using AutoMapper;

namespace AcmeSys.App.Services
{
    public class PurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public PurchaseService(IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        // Obtener todas las compras
        public async Task<IEnumerable<PurchaseDto>> GetAllPurchasesAsync()
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PurchaseDto>>(purchases);
        }

        // Obtener una venta por ID
        public async Task<PurchaseDto> GetPurchaseByIdAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            return _mapper.Map<PurchaseDto>(purchase);
        }

        // Registrar una nueva venta
        public async Task AddPurchaseAsync(PurchaseDto purchaseDto)
        {
            var purchase = _mapper.Map<Purchase>(purchaseDto);
            await _purchaseRepository.AddAsync(purchase);
        }

        // Eliminar una venta
        public async Task DeletePurchaseAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase != null)
            {
                await _purchaseRepository.DeleteAsync(purchase);
            }
        }
    }

}
