using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IProductService
   {
      public IDataResult<List<Product>> GetAll();
   }
}
