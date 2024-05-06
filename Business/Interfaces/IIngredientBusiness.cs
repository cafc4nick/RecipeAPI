using Business.DTOs.Ingredient;
using Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IIngredientBusiness :
        IBusinessBase<Ingredient, PostIngredientDto, PutIngredientDto, GetIngredientDto>
    {
    }
}
