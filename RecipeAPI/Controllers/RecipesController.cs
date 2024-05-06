using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Entities;
using AutoMapper;
using Business.Interfaces;
using NuGet.Protocol.Plugins;
using Business.DTOs.Recipe;
using Business.Exceptions;
using Business;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : BaseRecipeAppController<Recipe, PostRecipeDto, PutRecipeDto, GetRecipeDto>
    {

        public RecipesController(
            IRecipeBusiness business
        ) : base( business ) { }

    }
}
