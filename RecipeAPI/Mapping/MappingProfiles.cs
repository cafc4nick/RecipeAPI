using AutoMapper;
using Entities;
using RecipeAPI.DTOs;

namespace RecipeAPI.Mapping
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Recipe, GetRecipeDto>();
            CreateMap<PostRecipeDto, Recipe>();
        }
    }
}
