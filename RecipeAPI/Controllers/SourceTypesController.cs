using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Entities;
using Business.DTOs.UserType;
using Business.Interfaces;
using Business.DTOs.SourceType;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceTypesController : BaseRecipeAppController<SourceType, PostSourceTypeDto, PutSourceTypeDto, GetSourceTypeDto>
    {
        public SourceTypesController(
            ISourceTypeBusiness business
        ) : base(business)
        { }
    }
}