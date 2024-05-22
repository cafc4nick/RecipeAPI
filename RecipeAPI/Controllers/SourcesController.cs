using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Entities;
using Business.DTOs.User;
using Business.Interfaces;
using Business.DTOs.Source;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SourcesController : BaseRecipeAppController<Source, PostSourceDto, PutSourceDto, GetSourceDto>
    {
        public SourcesController(
            ISourceBusiness business
        ) : base(business)
        { }
    }
}