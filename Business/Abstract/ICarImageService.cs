﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
	public interface ICarImageService
	{
		IDataResult<CarImage> GetById(int id);
		IDataResult<List<CarImage>> GetAll();
		IDataResult<List<CarImage>> GetImagesByCarId(int carId);
		IResult Add(CarImage carImage, IFormFile file);
		IResult Update(CarImage carImage, IFormFile file);
		IResult Delete(CarImage carImage);
	}
}
