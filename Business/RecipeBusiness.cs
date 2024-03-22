using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RecipeBusiness:
        BusinessBase<Recipe, PostRecipeDto, PutRecipeDto, GetRecipeDto>,
        IRecipeBusiness
    {

        public RecipeBusiness(RecipeContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
