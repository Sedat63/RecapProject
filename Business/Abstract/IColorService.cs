using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IColorService
	{
		List<Color> GetAll();
		List<Color> GetCarsByBrandId(int id);
		List<Color> GetCarsByColorId(int id);

		IResult AddCar(Color color);
		IResult DeleteCar(Color color);
		IResult UpdateCar(Color color);
	}
}
