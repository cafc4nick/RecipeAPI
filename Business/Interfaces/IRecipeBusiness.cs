﻿using Business.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRecipeBusiness: 
        IBusinessBase<Recipe, PostRecipeDto, PutRecipeDto, GetRecipeDto>
    {
    }
}
