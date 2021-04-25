using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;
		public BrandManager(IBrandDal carDal)
		{
			_brandDal = carDal;
		}

		public IDataResult<Brand> GetById(int id)
		{
			return new SuccessDataResult<Brand>(_brandDal.Get(c => c.BrandId == id));
		}

		public IDataResult<List<Brand>> GetAll()
		{
			return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
		}

		public void AddCar(Brand brand)
		{
			throw new NotImplementedException();
		} 

		public void DeleteCar(Brand brand)
		{
			throw new NotImplementedException();
		}

		

		public List<Brand> GetCarsByBrandId(int id)
		{
			throw new NotImplementedException();
		}

		public List<Brand> GetCarsByColorId(int id)
		{
			throw new NotImplementedException();
		}

		public void UpdateCar(Brand brand)
		{
			throw new NotImplementedException();
		}

		IResult IBrandService.AddCar(Brand brand)
		{
			throw new NotImplementedException();
		}

		IResult IBrandService.DeleteCar(Brand brand)
		{
			throw new NotImplementedException();
		}

		IResult IBrandService.UpdateCar(Brand brand)
		{
			throw new NotImplementedException();
		}

		List<Brand> IBrandService.GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
