using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Entities;
using Business.DTOs.Recipe;
using Business.DTOs.User;
using Business.Interfaces;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseRecipeAppController<User, PostUserDto, PutUserDto, GetUserDto>
    {
        public UsersController(
            IUserBusiness business
        ) : base(business)
        { }
    }
}
