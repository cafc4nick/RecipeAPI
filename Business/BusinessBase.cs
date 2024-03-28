using AutoMapper;
using Business.DTOs.Recipe;
using Business.Exceptions;
using Business.Interfaces;
using Database;
using Entities;
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

        public async Task<Guid> AddAsync(TPost entity)
        {
            var new_recipe = _context.Set<TDomain>().Add(
                _mapper.Map<TDomain>(entity)
                );
            await _context.SaveChangesAsync();
            return new_recipe.Entity.Id;
        }

        public async Task<TGet> FindAsync(Guid id)
        {
            return _mapper.Map<TGet>(await _context.Set<TDomain>().FindAsync(id));
        }

        public async Task<List<TGet>> GetAllAsync()
        {
            return _mapper.Map<List<TGet>>(await _context.Set<TDomain>().ToListAsync());
        }

        public async Task PutAsync(Guid id, TPut entity)
        {
            var domainEntity = _mapper.Map<TDomain>(entity);
            _context.Entry(domainEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomainExists(id))
                {
                    throw new NotFoundException();
                }
                else
                {
                    throw;
                }
            }
        }
        private bool DomainExists(Guid id)
        {
            return _context.Set<TDomain>().Any(e => e.Id == id);
        }
    }
}
