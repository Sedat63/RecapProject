using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{	
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;

		public InMemoryCarDal()
		//Oracle, Sql Server gelen veriler gibi
		{
			_cars = new List<Car> 
			{ 
				new Car{CarId=1, CarName="Citroen Berlingo", BrandId=1,ColorId=1, ModelYear=2013, DailyPrice=90000, Description="Beyaz Berlingo Temiz 2013 model"},
				new Car{CarId=2, CarName="Mercedes Vito", BrandId=2, ColorId=2, ModelYear=2018, DailyPrice=100000, Description="Siyah Mercedes VIP araç"},
				new Car{CarId=3, CarName="Jetta", BrandId=3, ColorId=1, ModelYear=2015, DailyPrice=50000, Description="Beyaz Jetta VW 2015 sıfır araç"},
				new Car{CarId=4, CarName="Hundai", BrandId=4, ColorId=3, ModelYear=2020, DailyPrice=150000, Description="Gümüş Hundai Accent eski kasa"},
				new Car{CarId=5, CarName="Mercedes C180", BrandId=2, ColorId=2, ModelYear=2019, DailyPrice=110000, Description="Siyah Mercedes otomotik araç"},
				new Car{CarId=6, CarName="Renault Clio", BrandId=5, ColorId=1, ModelYear=2016, DailyPrice=60000, Description="Beyaz Renault Clio aile tipi araç"},
			};
		}
		public void Add(Car car)
		{

			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			_cars.Remove(carToDelete);
		}

		public void Update(Car car)
		{
			Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			carToUpdate.CarName = car.CarName;
			carToUpdate.ColorId = car.ColorId;
			carToUpdate.BrandId = car.BrandId;
			carToUpdate.DailyPrice = car.DailyPrice;
			carToUpdate.ModelYear = car.ModelYear;
			carToUpdate.Description = car.Description;
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAllByBrandId(int BrandId)
		{
			return _cars.Where(c => c.BrandId == BrandId).ToList();
		}

		public List<Car> GetAllByColorId(int ColorId)
		{
			return _cars.Where(c => c.ColorId == ColorId).ToList();
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}
	}
}
