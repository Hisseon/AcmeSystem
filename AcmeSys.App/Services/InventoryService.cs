using AcmeSys.App.DTOs;
using AcmeSys.Dominio.Elements;
using AcmeSys.Dominio.Interfaces;
using AutoMapper;

namespace AcmeSys.App.Services
{
    public class InventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        // Obtener todos los registros de inventario
        public async Task<IEnumerable<InventoryDto>> GetAllInventoryAsync()
        {
            var inventories = await _inventoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InventoryDto>>(inventories);
        }

        // Obtener un registro de inventario por ID
        public async Task<InventoryDto> GetInventoryByIdAsync(int id)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(id);
            return _mapper.Map<InventoryDto>(inventory);
        }

        // Agregar un nuevo registro de inventario
        public async Task AddInventoryAsync(InventoryDto inventoryDto)
        {
            var inventory = _mapper.Map<Inventory>(inventoryDto);
            await _inventoryRepository.AddAsync(inventory);
        }

        // Actualizar un registro de inventario existente
        public async Task UpdateInventoryAsync(InventoryDto inventoryDto)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(inventoryDto.InventoryId);
            if (inventory != null)
            {
                inventory.UpdateStock(inventoryDto.Stock); // Ejemplo de actualización de stock
                await _inventoryRepository.UpdateAsync(inventory);
            }
        }

        // Eliminar un registro de inventario
        public async Task DeleteInventoryAsync(int id)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(id);
            if (inventory != null)
            {
                await _inventoryRepository.DeleteAsync(inventory);
            }
        }
    }


}
