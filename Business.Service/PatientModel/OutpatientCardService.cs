using AutoMapper;
using Business.Enties.PatientModel;
using Business.Interop.PatientModel;
using Business.Repository.DataRepository.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel
{
    public class OutpatientCardService : IOutpatientCardService
    {
        private readonly IOutpatientCardRepository _outpatientCardRepository;
        private readonly IMapper _mapper;

        public OutpatientCardService(IOutpatientCardRepository outpatientCardRepository, IMapper mapper)
        {
            _outpatientCardRepository = outpatientCardRepository ?? throw new ArgumentNullException(nameof(outpatientCardRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(OutpatientCardDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            DateTime currentDate = new();
            if (entity.DateLastAdmission.Year > currentDate.Year)
                throw new ArgumentException(nameof(entity.DateLastAdmission.Year));
            if (entity.DateLastAdmission.Month > currentDate.Month)
                throw new ArgumentException(nameof(entity.DateLastAdmission.Month));
            if (entity.DateLastAdmission.Day >= currentDate.Day)
                throw new ArgumentException(nameof(entity.DateLastAdmission.Year));
            if (entity.Patient == null)
                throw new ArgumentNullException(nameof(entity.Patient));
        }

        public OutpatientCardDto Create(OutpatientCardDto entity)
        {
            CheckEntity(entity);
            OutpatientCard card = _mapper.Map<OutpatientCard>(entity);
            _outpatientCardRepository.Create(card);
            return _mapper.Map<OutpatientCardDto>(card);
        }

        public async Task<OutpatientCardDto> CreateAsync(OutpatientCardDto entity)
        {
            CheckEntity(entity);
            OutpatientCard card = _mapper.Map<OutpatientCard>(entity);
            await _outpatientCardRepository.CreateAsync(card);
            return _mapper.Map<OutpatientCardDto>(card);
        }

        public ICollection<OutpatientCardDto> GetAll()
        {
            return _mapper.Map<List<OutpatientCard>, ICollection<OutpatientCardDto>>(_outpatientCardRepository.Query());
        }

        public async Task<ICollection<OutpatientCardDto>> GetAllAsync()
        {
            return _mapper.Map<List<OutpatientCard>, ICollection<OutpatientCardDto>>(await _outpatientCardRepository.QueryAsync());
        }

        public OutpatientCardDto GetById(Guid id)
        {
            if(id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<OutpatientCardDto>(_outpatientCardRepository.Query().FirstOrDefault(e => e.Id == id)); 
        }

        public async Task<OutpatientCardDto> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            var list = await _outpatientCardRepository.QueryAsync();
            return _mapper.Map<OutpatientCardDto>(list.FirstOrDefault(e => e.Id == id));
        }

        public void Remove(OutpatientCardDto entity)
        {
            CheckEntity(entity);    
            if(entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity));
            OutpatientCard card = _mapper.Map<OutpatientCard>(entity);
            _outpatientCardRepository.Delete(card);
        }

        public OutpatientCardDto Update(OutpatientCardDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity));
            OutpatientCard card = _mapper.Map<OutpatientCard>(entity);
            _outpatientCardRepository.Update(card);
            return _mapper.Map<OutpatientCardDto>(card);
        }

        public async Task<OutpatientCardDto> UpdateAsync(OutpatientCardDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity));
            OutpatientCard card = _mapper.Map<OutpatientCard>(entity);
            await _outpatientCardRepository.CreateOrUpdateAsync(card);
            return _mapper.Map<OutpatientCardDto>(card);
        }
    }
}
