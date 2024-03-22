using AutoMapper;
using Business.DTOs;
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
        public async Task<List<TDomain>> GetAll()
        {
            _mapper.Map<List<GetRecipeDto>>(await _context.Recipes.ToListAsync());
            return await _context.Set<TDomain>().ToListAsync();
        }
    }
}
