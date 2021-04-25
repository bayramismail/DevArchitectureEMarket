using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Business.Handlers.GroupClaims.Queries;
using Business.Handlers.Translates.Queries;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Categories.Queries
{
    public class GetCategoryListQuery :IRequest<IDataResult<IEnumerable<Category>>>
    {

        public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IDataResult<IEnumerable<Category>>>
        {
            private ICategoryRepository _categoryRepository;

            public GetCategoryListQueryHandler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<IDataResult<IEnumerable<Category>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
            {
                var list = _categoryRepository.GetListAsync();
                return new  SuccessDataResult<IEnumerable<Category>>(await list);
            }
        }

    }
}
