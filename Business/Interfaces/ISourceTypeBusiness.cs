using Business.DTOs.SourceType;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ISourceTypeBusiness :
        IBusinessBase<SourceType, PostSourceTypeDto, PutSourceTypeDto, GetSourceTypeDto>
    {
    }
}
