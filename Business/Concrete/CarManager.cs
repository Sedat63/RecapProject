using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal; //Soyut nesne ile bağlantı kurar. Business katmanının bildiği tek şey

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public void AddCar(Car car)
		{
			if (car.CarName.Length >= 2 && car.DailyPrice > 0)
			{
				_carDal.Add(car);
				Console.WriteLine("Araba veritabanına başarıyla eklendi.");
			}
			else
			{
				Console.WriteLine("Araba adı en az 2 karakterli veya günlük fiyat 0'dan büyük olmalı.");
			}
		}

		public void DeleteCar(Car car)
		{
			_carDal.Delete(car);
		}

		public void UpdateCar(Car car)
		{
			_carDal.Update(car);
		}

		public List<Car> GetAll()
		{
			//iş kodları
			//İş kodlarından geçerse veri erişimi-data access çağrılmalı
			//Bir iş sınıfı başka bir iş sınıfını newleyemez!! Bu yüzden injection yaparız!!
			return _carDal.GetAll();
		}

		public List<Car> GetCarsByBrandId(int id)
		{
			return _carDal.GetAll(c => c.BrandId == id);			
		}

		public List<Car> GetCarsByColorId(int id)
		{
			return _carDal.GetAll(c => c.ColorId == id);
		}
	}
}
