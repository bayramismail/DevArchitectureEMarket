using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class ProductManager:IProductService
   {
       private IProductDal _productDal;

       public ProductManager(IProductDal productDal)
       {
           _productDal = productDal;
       }
       [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetAll()
       {
           var result=_productDal.GetList();
           return new SuccessDataResult<List<Product>>(result.ToList());
       }
    }
}
