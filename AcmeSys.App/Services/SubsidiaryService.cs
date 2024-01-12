using AcmeSys.App.DTOs;
using AcmeSys.Dominio.Elements;
using AcmeSys.Dominio.Interfaces;
using AutoMapper;

namespace AcmeSys.App.Services
{
    public class SubsidiaryService
    {
        private readonly ISubsidiaryRepository _subsidiaryRepository;
        private readonly IMapper _mapper;

        public SubsidiaryService(ISubsidiaryRepository subsidiaryRepository, IMapper mapper)
        {
            _subsidiaryRepository = subsidiaryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubsidiaryDto>> GetAllSubsidiariesAsync()
        {
            var subsidiarys = await _subsidiaryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubsidiaryDto>>(subsidiarys);
        }

        public async Task<SubsidiaryDto> GetSubsidiaryByIdAsync(int id)
        {
            var subsidiary = await _subsidiaryRepository.GetByIdAsync(id);
            return _mapper.Map<SubsidiaryDto>(subsidiary);
        }

        public async Task AddSubsidiaryAsync(SubsidiaryDto subsidiaryDto)
        {
            var subsidiary = _mapper.Map<Subsidiary>(subsidiaryDto);
            await _subsidiaryRepository.AddAsync(subsidiary);
        }

        public async Task UpdateSubsidiaryAsync(SubsidiaryDto subsidiaryDto)
        {
            var subsidiary = _mapper.Map<Subsidiary>(subsidiaryDto);
            await _subsidiaryRepository.UpdateAsync(subsidiary);
        }

        public async Task DeleteSubsidiaryAsync(int id)
        {
            var subsidiary = await _subsidiaryRepository.GetByIdAsync(id);
            if (subsidiary != null)
            {
                await _subsidiaryRepository.DeleteAsync(subsidiary);
            }
        }

    }

}
