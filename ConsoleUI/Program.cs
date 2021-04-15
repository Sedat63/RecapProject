using Business.Concrete;
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


			CarManager carManager = new CarManager(new EfCarDal());

			//Car newCar = new Car
			//{
			//	CarId = 7,
			//	BrandId = 1,
			//	ColorId = 4,
			//	DailyPrice = 200000,
			//	ModelYear = 2020,
			//	Description = "Sıfır km fabrika çıkışlı absli hidrolik direksiyonlu C5",
			//	CarName = "Citroen"
			//};
			//carManager.AddCar(newCar);

			//foreach (var car in carManager.GetAll())
			//{
			//	Console.WriteLine("Daily Price: "+car.DailyPrice);
			//}

			//foreach (var car in carManager.GetAll())
			//{
			//	Console.WriteLine(car.CarName);
			//}

			//foreach (var car in carManager.GetCarsByBrandId(2))
			//{
			//	Console.WriteLine(car.CarName+" "+car.Description);
			//}

			foreach (var car in carManager.GetCarsByColorId(2))
			{
				Console.WriteLine(car.CarName + " " + car.Description);
			}

			//foreach (var car in carManager.GetAll())
			//{
			//	Console.WriteLine("Araçlar: " + car.CarName+" ÖZellikleri: "+car.Description);
			//}

			//ProductManager productManager = new ProductManager(new InMemoryProductDal());

			//foreach (var product in productManager.GetAll())
			//{
			//	Console.WriteLine(product.ProductName);
			//}
		}
	}
}
