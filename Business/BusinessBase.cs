using AutoMapper;
using Business.DTOs.Recipe;
using Business.Interfaces;
using Database;
using Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public abstract class BusinessBase<TDomain, TPost, TPut, TGet> : IBusinessBase<TDomain, TPost, TPut, TGet>
        where TDomain : EntityBase
    {

        private readonly RecipeContext _context;
        private readonly IMapper _mapper;
        protected BusinessBase(RecipeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TGet> FindAsync(Guid id)
        {
            return _mapper.Map<TGet>(await _context.Set<TDomain>().FindAsync(id));
        }

        public async Task<List<TGet>> GetAllAsync()
        {
            return _mapper.Map<List<TGet>>(await _context.Set<TDomain>().ToListAsync());
        }
    }
}
