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

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeBusiness _recipeBusiness;

        public RecipesController(
            IRecipeBusiness recipieBusiness
        )
        {
            _recipeBusiness = recipieBusiness;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetRecipeDto>>> GetRecipes()
        {
            var recipes = await _recipeBusiness.GetAllAsync();
            return recipes;
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRecipeDto>> GetRecipe(Guid id)
        {
            var recipe = await _recipeBusiness.FindAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(Guid id, PutRecipeDto recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }
            await _recipeBusiness.PutAsync(id, recipe);

            return NoContent();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guid>> PostRecipe(PostRecipeDto recipe)
        {
            var new_recipe_id = await _recipeBusiness.AddAsync(recipe);
            return CreatedAtAction("PostRecipe", new_recipe_id);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            try
            {
                await _recipeBusiness.DeleteAsync(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
