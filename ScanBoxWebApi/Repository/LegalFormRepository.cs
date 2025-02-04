﻿using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;

namespace ScanBoxWebApi.Repository
{
    public class LegalFormRepository : ICrudMethodRepository<LegalFormGetDTO, LegalFormPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public LegalFormRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<int> Create(LegalFormPostDTO legalFormDto)
        {
            var legalFormEntity = await _context.LegalForms.FirstOrDefaultAsync(x => x.LegalFormName.Equals(legalFormDto.LegalFormName));
            if (legalFormEntity == null)
            {
                legalFormEntity = _mapper.Map<LegalFormEntity>(legalFormDto);
                await _context.AddAsync(legalFormEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("legal_forms");
            }
            return legalFormEntity.Id;
        }

        public async Task<int> Delete(int legalFormId)
        {
            var legalFormEntity = await _context.LegalForms.FirstOrDefaultAsync(x => x.Id == legalFormId);

            int result = -1;
            if (legalFormEntity is not null)
            {
                result = legalFormEntity.Id;
                _context.Remove(legalFormEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("legal_forms");
            }
            return result;
        }

        public async Task<IEnumerable<LegalFormGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("legal_forms", out IEnumerable<LegalFormGetDTO>? legalForms))
            {
                if (legalForms is not null) return legalForms;
            }
            var legalFormEntity = await _context.LegalForms.Select(x => _mapper.Map<LegalFormGetDTO>(x)).ToListAsync();
            _cache.Set("legal_forms", legalFormEntity, TimeSpan.FromMinutes(30));
            return legalFormEntity;
        }

        public async Task<int> Update(LegalFormGetDTO legalFormDto)
        {
            var legalFormEntity = await _context.LegalForms.FirstOrDefaultAsync(x => x.Id == legalFormDto.Id);
            if (legalFormEntity != null)
            {
                legalFormEntity.LegalFormName = legalFormDto.LegalFormName;
                legalFormEntity.Description = legalFormDto.Description;

                await _context.SaveChangesAsync();
                _cache.Remove("legal_forms");
                return legalFormEntity.Id;
            }
            return -1;
        }
    }
}
