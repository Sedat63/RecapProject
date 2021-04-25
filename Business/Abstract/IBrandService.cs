using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IBrandService
	{
		List<Brand> GetAll();
		List<Brand> GetCarsByBrandId(int id);
		List<Brand> GetCarsByColorId(int id);

		IResult AddCar(Brand brand);
		IResult DeleteCar(Brand brand);
		IResult UpdateCar(Brand brand);
	}
}
