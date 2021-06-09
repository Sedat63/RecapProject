using Business.Abstract;
using Business.Constans;
using Core.Entities.Conrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		 ICustomerDal _customerDal;
		 IFindeksDal _findeksDal;
		 IFindeksService _findeksService;
		 IUserDal _userDal;

		public UserManager(ICustomerDal customerDal, IFindeksDal findeksDal, IFindeksService findeksService, IUserDal userDal)
		{
			_customerDal = customerDal;
			_findeksDal = findeksDal;
			_findeksService = findeksService;
			_userDal = userDal;
		}

		public IResult Add(User user)
		{
			_userDal.Add(user);
			return new SuccessResult(Messages.UserAdded);
		}

		public IResult Delete(User user)
		{
			_userDal.Delete(user);
			return new SuccessResult(Messages.UserDeleted);
		}

		public IDataResult<List<User>> GetAll(int id)
		{
			return new SuccessDataResult<List<User>>(_userDal.GetAll());
		}

		public IDataResult<User> GetById(int id)
		{
			return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
		}

		public IDataResult<User> GetByMail(string email)
		{
			return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
		}

		public IDataResult<List<OperationClaim>> GetClaims(User user)
		{
			throw new NotImplementedException();
		}

		public IDataResult<UserDetailDto> GetUserDetailByMail(string userMail)
		{
			return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetail(userMail));
		}

		public IResult Update(User user)
		{
			_userDal.Update(user);
			return new SuccessResult(Messages.UserUpdated);
		}

		public IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate)
		{
			var user = GetById(userDetailForUpdate.Id).Data;

			//if (!HashingHelper.VerifyPasswordHash(userDetailForUpdate.CurrentPassword, user.PasswordHash,
			//	user.PasswordSalt)) return new ErrorResult(Messages.PasswordError);

			user.FirstName = userDetailForUpdate.FirstName;
			user.LastName = userDetailForUpdate.LastName;
			if (!string.IsNullOrEmpty(userDetailForUpdate.NewPassword))
			{
				//byte[] passwordHash, passwordSalt;
				//HashingHelper.CreatePasswordHash(userDetailForUpdate.NewPassword, out passwordHash, out passwordSalt);
				//user.PasswordHash = passwordHash;
				//user.PasswordSalt = passwordSalt;
			}

			_userDal.Update(user);

			var customer = _customerDal.Get(c => c.Id == userDetailForUpdate.CustomerId);
			customer.CompanyName = userDetailForUpdate.CompanyName;
			_customerDal.Update(customer);

			if (!string.IsNullOrEmpty(userDetailForUpdate.NationalIdentity))
			{
				var findeks = _findeksService.GetByCustomerId(userDetailForUpdate.CustomerId).Data;
				if (findeks == null)
				{
					//var newFindeks = new Findeks
					{
						//CustomerId = userDetailForUpdate.CustomerId,
						//NationalIdentity = userDetailForUpdate.NationalIdentity
					};
					//_findeksService.Add(newFindeks);
				}
				else
				{
					findeks.NationalIdentity = userDetailForUpdate.NationalIdentity;
					var newFindeks = _findeksService.CalculateFindeksScore(findeks).Data;
					_findeksDal.Update(newFindeks);
				}
			}

			return new SuccessResult(Messages.UserDetailsUpdated);
		}
	}
	
}
