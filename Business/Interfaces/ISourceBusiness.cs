using Business.DTOs.Source;
using Business.DTOs.User;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ISourceBusiness :
        IBusinessBase<Source, PostSourceDto, PutSourceDto, GetSourceDto>
    {
    }
}
