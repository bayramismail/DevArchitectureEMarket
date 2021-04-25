using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Handlers.Categories.BusinessRules
{
    public interface ICategoryBusinessRules
    {
        Task<IResult> NameControl(string name);
    }
}
