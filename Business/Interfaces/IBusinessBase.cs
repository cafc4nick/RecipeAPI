using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBusinessBase<TDomain, TPost, TPut, TGet>
    {
        Task<List<TGet>> GetAllAsync();
        Task<TGet> FindAsync(Guid id);
        Task<Guid> AddAsync(TPost post);
        Task PutAsync(Guid id, TPut entity);
    }
}
