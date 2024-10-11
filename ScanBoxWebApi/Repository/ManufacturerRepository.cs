﻿using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ManufacturerRepository : ICrudMethodRepository<ManufacturerGetDTO, ManufacturerPostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public ManufacturerRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(ManufacturerPostDTO manufacturerDto)
        {
            var manufacturerEntity = _context.Manufacturers.FirstOrDefault(x => x.CounterpartyId == manufacturerDto.CounterpartyId);
            if (manufacturerEntity == null)
            {
                manufacturerEntity = _mapper.Map<ManufacturerEntity>(manufacturerDto);
                _context.Add(manufacturerEntity);
                _context.SaveChanges();
            }
            return manufacturerEntity.Id;
        }

        public int Delete(int manufacturerId)
        {
            var manufacturerEntity = _context.Manufacturers.FirstOrDefault(x => x.Id == manufacturerId);
            if (manufacturerEntity != null)
            {
                _context.Remove(manufacturerEntity);
                _context.SaveChanges();
                return manufacturerEntity.Id;
            }
            return -1;
        }

        public IEnumerable<ManufacturerGetDTO> GetElemetsList()
        {
            var manufacturerEntity = _context.Manufacturers.Select(x => _mapper.Map<ManufacturerGetDTO>(x));
            return manufacturerEntity;
        }

        public int Update(ManufacturerGetDTO manufacturerDto)
        {
            var manufacturerEntity = _context.Manufacturers.FirstOrDefault(x => x.Id == manufacturerDto.Id);
            if (manufacturerEntity != null)
            {
                manufacturerEntity.CounterpartyId= manufacturerDto.CounterpartyId;
                
                _context.SaveChanges();
                return manufacturerEntity.Id;
            }
            return -1;
        }
    }
}
