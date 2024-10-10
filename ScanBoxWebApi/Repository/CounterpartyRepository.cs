﻿using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class CounterpartyRepository : ICrudMethodRepository<CounterpartyGetDTO, CounterpartyPostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public CounterpartyRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;            
        }

        public int Create(CounterpartyPostDTO counterpartyDto)
        {
            var counterpartyEntity = _mapper.Map<CounterpartyEntity>(counterpartyDto);
            _context.Add(counterpartyEntity);
            _context.SaveChanges();
            return counterpartyEntity.Id;
        }

        public int Delete(int counterpartyId)
        {
            var counterpartyEntity = _context.Counterparties.FirstOrDefault(x => x.Id == counterpartyId);

            if (counterpartyEntity != null)
            {
                _context.Remove(counterpartyEntity);
                _context.SaveChanges();
                return counterpartyEntity.Id;
            }
            return -1;
        }

        public IEnumerable<CounterpartyGetDTO> GetElemetsList()
        {
            var counterpartyEntity = _context.Counterparties.Select(x => _mapper.Map<CounterpartyGetDTO>(x));
            return counterpartyEntity;
        }

        public int Update(CounterpartyGetDTO counterpartyDto)
        {
            var counterpartyEntity = _context.Counterparties.FirstOrDefault(x => x.Id == counterpartyDto.Id);

            if (counterpartyEntity != null)
            {
                counterpartyEntity.CounterpartyTypeId = counterpartyDto.CounterpartyTypeId;
                counterpartyEntity.Address = counterpartyDto.Address;
                counterpartyEntity.Phone = counterpartyDto.Phone;
                counterpartyEntity.Email = counterpartyDto.Email;

                _context.SaveChanges();
                return counterpartyEntity.Id;
            }
            return -1;
        }
    }
}
