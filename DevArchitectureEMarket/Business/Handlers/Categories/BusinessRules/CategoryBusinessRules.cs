using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Business.Handlers.Categories.Queries;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.Handlers.Categories.BusinessRules
{
   public class CategoryBusinessRules : ICategoryBusinessRules
   {
       private readonly ICategoryRepository _categoryRepository;

       public CategoryBusinessRules(ICategoryRepository categoryRepository)
       {
           _categoryRepository = categoryRepository;
       }


       public async Task<IResult> NameControl(string name)
        {
           var result= await _categoryRepository.GetListAsync(c=>c.Name.ToUpper(new CultureInfo("en-US", false)) == name.ToUpper(new CultureInfo("en-US", false)));
            if (  result!=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
      
    }
}
