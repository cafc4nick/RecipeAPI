using Business.DTOs.User;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserBusiness :
        IBusinessBase<User, PostUserDto, PutUserDto, GetUserDto>
    {
    }
}
