﻿using Business.Abstract;
using Core1.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class ColorManager:IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

  

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>( _colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult("Başarılı ! güncellendi !");
        }
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult("Başarılı ! Silindi !");
        }
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult("Başarılı ! Eklendi !");
        }


    }
}
