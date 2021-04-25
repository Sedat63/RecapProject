using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICarService
	{
		IDataResult<List<Car>> GetAll();
		IDataResult<Car> GetById(int id);
		IDataResult<List<CarDetailDto>> GetCarDetails();
		IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName);
		IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName);
		IDataResult<List<CarDetailDto>> GetCarDetailsByBrandNameandColorName(string brandName,string colorName);
		IResult AddCar(Car car);
		IResult DeleteCar(Car car);
		IResult UpdateCar(Car car);
		IDataResult<List<Car>> GetCarsByBrandId(int id);
		IDataResult<List<Car>> GetCarsByColorId(int id);
		

		

	}
}
