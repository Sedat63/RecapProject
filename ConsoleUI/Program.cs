using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new InMemoryCarDal());

			foreach (var car in carManager.GetAll())
			{
				Console.WriteLine("Araçlar: " + car.CarName+" ÖZellikleri: "+car.Description);
			}

			//ProductManager productManager = new ProductManager(new InMemoryProductDal());

			//foreach (var product in productManager.GetAll())
			//{
			//	Console.WriteLine(product.ProductName);
			//}
		}
	}
}
