using System;
using System.Collections.Generic;
using System.Text;
using Business.Handlers.Categories.Commands;
using FluentValidation;

namespace Business.Handlers.Categories.ValidationRules
{
   public class CategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CategoryValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
        }
    }
}
