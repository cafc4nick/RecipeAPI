using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Entities;
using Business.Interfaces;
using System.Dynamic;
using Business.DTOs.Ingredient;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : BaseRecipeAppController<Ingredient, PostIngredientDto, PutIngredientDto, GetIngredientDto>
    {
        public IngredientsController(
            IIngredientBusiness business
        ) : base(business) { }

    }
}
