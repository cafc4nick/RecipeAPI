using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBusinessBase<TDomain, TPost, TPut, TGet>
    {
        Task<List<TDomain>> GetAll();
    }
}
