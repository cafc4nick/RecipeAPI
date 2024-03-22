using AutoMapper;
using Business.DTOs.Recipe;
using Entities;

namespace Business.Mapping
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
