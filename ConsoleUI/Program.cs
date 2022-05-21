using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarTest();
            // ColorTest();
            //CarManager carManager = new CarManager(new EfCarDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 100,CompanyName="Koç" });
            
            //    carManager.Add(new Car { CarId=2,CarName = "Volvo", DailyPrice = 83252, BrandId = 100, ColorId = 2, Description = "Klasik araba", ModelYear = 1999 });
        //    var result = carManager.GetCarDetails();
        //    if (result.Success == true)
        //    {
        //        foreach (var item in result.Data)
        //        {
        //            Console.WriteLine("Araba adı = {0}, Rengi={1}, Markası={2}, Günlük Ücreti={3}", item.CarName, item.ColorName, item.BrandName, item.DailyPrice);
        //        }
        //    }
        //    Console.WriteLine(result.Message);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.ColorName);

            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { CarId = 14, CarName = "Volvo", DailyPrice = 19009, BrandId = 5, ColorId = 3, Description = "Kırmızı araba", ModelYear = 1999 });
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine(item.CarName);
            }
        }
    }
}
