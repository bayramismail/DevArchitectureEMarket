using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Business.Constants;
using Business.Handlers.Categories.BusinessRules;
using Business.Handlers.Categories.ValidationRules;
using Business.Handlers.UserClaims.Commands;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Categories.Commands
{
    [SecuredOperation]
    public class CreateCategoryCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IResult>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly ICategoryBusinessRules _categoryBusinessRules;
            public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _categoryBusinessRules = categoryBusinessRules;
            }

            [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
            public async Task<IResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = new Category
                {
                    Name = request.Name,
                    CreateDate = DateTime.Now,
                    Active = request.Active
                };
                //var categoryNameControl = new CategoryBusinessRules().NameControl(category.Name);
                var categoryNameControl = _categoryBusinessRules.NameControl(category.Name);
                var result = Core.Utilities.Business.BusinessRules.Run();
                if (result != null)
                {
                    return result;
                }
                _categoryRepository.Add(category);
                await _categoryRepository.SaveChangesAsync();

                return new SuccessResult(Messages.Added);
            }

        }
    }
}
