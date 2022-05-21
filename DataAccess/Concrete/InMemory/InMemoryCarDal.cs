using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { BrandId = 1, ColorId = 2, DailyPrice = 50000, Description = "Blue", CarId = 100, ModelYear = 1999 },
                new Car { BrandId = 1, ColorId = 2, DailyPrice = 50000, Description = "Blue", CarId = 100, ModelYear = 1999 },

                new Car { BrandId = 1, ColorId = 2, DailyPrice = 50000, Description = "Blue", CarId = 100, ModelYear = 1999 },

                new Car { BrandId = 1, ColorId = 2, DailyPrice = 50000, Description = "Blue", CarId = 100, ModelYear = 1999 }

            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToRemove = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToRemove);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.Description = car.Description;
        }
    }
}