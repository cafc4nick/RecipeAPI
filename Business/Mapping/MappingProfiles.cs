using AutoMapper;
using Business.DTOs.Ingredient;
using Business.DTOs.Recipe;
using Entities;
using System.Dynamic;

namespace Business.Mapping
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Recipe, GetRecipeDto>();
            CreateMap<PostRecipeDto, Recipe>();
            CreateMap<PutRecipeDto, Recipe>();

            CreateMap<Ingredient, GetIngredientDto>();
            CreateMap<PostIngredientDto, Ingredient>();
            CreateMap<PutIngredientDto, Ingredient>();
        }
    }
}
