using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Entities;
using Business.DTOs.Source;
using Business.Interfaces;
using Business.DTOs.UserType;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : BaseRecipeAppController<UserType, PostUserTypeDto, PutUserTypeDto, GetUserTypeDto>
    {
        public UserTypesController(
            IUserTypeBusiness business
        ) : base(business)
        { }
    }
}
