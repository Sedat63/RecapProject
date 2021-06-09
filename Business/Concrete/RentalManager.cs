using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class RentalManager : IRentalService
	{
		IRentalDal _rentalDal;
		ICarService _carService;
		IFindeksService _findeksService;

		public RentalManager(IRentalDal rentalDal, ICarService carService, IFindeksService findeksService)
		{
			_rentalDal = rentalDal;
			_carService = carService;
			_findeksService = findeksService;
		}

		public IResult Add(Rental rental)
		{
			var result = BusinessRules.Run(IsRentable(rental), CheckFindeksScoreSufficiency(rental));
			if (result != null)
			{
				return result;
			}

			_rentalDal.Add(rental);
			return new SuccessResult(Messages.RentalAdded);
		}

		public IResult CheckFindeksScoreSufficiency(Rental rental)
		{
			var car = _carService.GetById(rental.CarId).Data;
			var findeks = _findeksService.GetByCustomerId(rental.CustomerId).Data;

			if (findeks == null) return new ErrorResult(Messages.FindeksNotFound);
			if (findeks.Score < car.MinFindeksScore) return new ErrorResult(Messages.FindeksNotEnoughForCar);

			return new SuccessResult();			
		}

		public IResult CheckReturnDateByCarId(int carId)
		{
			var result = _rentalDal.GetAll(x => x.CarId == carId && x.ReturnDate == null);
			if (result.Count > 0) return new ErrorResult(Messages.RentalUndeliveredCar);

			return new SuccessResult();
		}

		public IResult Delete(Rental rental)
		{
			_rentalDal.Delete(rental);

			return new SuccessResult(Messages.RentalDeleted);
		}

		public IDataResult<List<Rental>> GetAll()
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
		}

		public IDataResult<List<Rental>> GetAllByCarId(int carId)
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
		}

		public IDataResult<Rental> GetById(int id)
		{
			return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
		}

		public IResult IsRentable(Rental rental)
		{
			var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);
			if (result.Any(r=>r.RentEndDate>=rental.RentStartDate && r.RentStartDate<=rental.RentEndDate))
			{
				return new ErrorResult(Messages.RentalNotAvailable);
			}
			return new SuccessResult();
		}

		public IResult Update(Rental rental)
		{
			_rentalDal.Update(rental);

			return new SuccessResult(Messages.RentalUpdated);
		}
	}
}
