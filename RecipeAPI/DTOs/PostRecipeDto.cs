﻿using Entities;

namespace RecipeAPI.DTOs
{
    public class PostRecipeDto
    {
        public Guid UserId { get; set; }
        public Guid SourceId { get; set; }
        public string Name { get; set; }

    }
}