﻿using Business.Concrete;
using Core1.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int brandId);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
        IResult Add(Brand brand);


    }
}
