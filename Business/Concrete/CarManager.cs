using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

		public IDataResult<Car> GetById(int id)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
		}

		public IDataResult<List<Car>> GetAll()
		{
			//iş kodları
			//İş kodlarından geçerse veri erişimi-data access çağrılmalı
			//Bir iş sınıfı başka bir iş sınıfını newleyemez!! Bu yüzden injection yaparız!!
			if (DateTime.Now.Hour == 22)
			{
				return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);

			}
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
		}

		public IDataResult<List<Car>> GetCarsByBrandId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
		}

		public IDataResult<List<Car>> GetCarsByColorId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string name)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandName == name));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string name)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorName == name));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandNameandColorName(string brandName, string colorName)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandName == brandName && c.ColorName == colorName));
		}

		public IResult AddCar(Car car)
		{
			if (car.CarName.Length >= 2 && car.DailyPrice > 0)
			{
				_carDal.Add(car);
				return new SuccessResult(Messages.CarAdded);
			}
			else
			{
				return new SuccessResult(Messages.CarNameInvalid);
			}
			
		}


		public IResult DeleteCar(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
			
		}

		public IResult UpdateCar(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}
		
	}
}

/*
 if (product.ProductName.Length<2)
			{
				return new ErrorResult(Messages.ProductNameInvalid);
			}
			_productDal.Add(product);

			return new SuccessResult(Messages.ProductAdded);
 */