using AcmeSys.App.DTOs;
using AcmeSys.Dominio.Elements;
using AcmeSys.Dominio.Interfaces;
using AutoMapper;

namespace AcmeSys.App.Services
{
    public class SaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        // Obtener todas las ventas
        public async Task<IEnumerable<SaleDto>> GetAllSalesAsync()
        {
            var sales = await _saleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SaleDto>>(sales);
        }

        // Obtener una venta por ID
        public async Task<SaleDto> GetSaleByIdAsync(int id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            return _mapper.Map<SaleDto>(sale);
        }

        // Registrar una nueva venta
        public async Task AddSaleAsync(SaleDto saleDto)
        {
            var sale = _mapper.Map<Sale>(saleDto);
            await _saleRepository.AddAsync(sale);
        }

        // Eliminar una venta
        public async Task DeleteSaleAsync(int id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale != null)
            {
                await _saleRepository.DeleteAsync(sale);
            }
        }
    }
}
