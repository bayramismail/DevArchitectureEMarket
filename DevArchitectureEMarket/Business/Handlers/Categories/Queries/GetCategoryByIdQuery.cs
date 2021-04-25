using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Categories.Queries
{
    [SecuredOperation]
   public class GetCategoryByIdQuery:IRequest<IDataResult<Category>>
   {
        public int Id { get; set; }
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, IDataResult<Category>>
        {
            private readonly ICategoryRepository _categoryRepository;

            public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<IDataResult<Category>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<Category>(await _categoryRepository.GetAsync(x => x.Id == request.Id));
            }
        }
    }
}
