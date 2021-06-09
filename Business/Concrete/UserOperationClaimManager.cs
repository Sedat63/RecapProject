using Business.Abstract;
using Business.Constans;
using Core.Entities.Conrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class UserOperationClaimManager : IUserOperationClaimService
	{
		IOperationClaimService _operationClaimService;
		IUserOperationClaimDal _userOperationClaimDal;

		public UserOperationClaimManager(IOperationClaimService operationClaimService,
		IUserOperationClaimDal userOperationClaimDal)
		{
			_operationClaimService = operationClaimService;
			_userOperationClaimDal = userOperationClaimDal;
		}

		public IResult Add(UserOperationClaim userOperationClaim)
		{
			_userOperationClaimDal.Add(userOperationClaim);

			return new SuccessResult(Messages.UserOperationClaimAdded);
		}

		public IResult AddUserClaim(User user)
		{
			var operationClaim = _operationClaimService.GetByName("user").Data;
			var userOperationClaim = new UserOperationClaim { OperationClaimId = operationClaim.Id, UserId = user.Id };

			_userOperationClaimDal.Add(userOperationClaim);
			return new SuccessResult(Messages.UserOperationClaimAdded);
		}

		public IResult Delete(UserOperationClaim userOperationClaim)
		{
			_userOperationClaimDal.Delete(userOperationClaim);

			return new SuccessResult(Messages.UserOperationClaimDeleted);
		}

		public IDataResult<List<UserOperationClaim>> GetAll()
		{
			return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
		}

		public IDataResult<UserOperationClaim> GetById(int id)
		{
			return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id == id));
		}

		public IResult Update(UserOperationClaim userOperationClaim)
		{
			_userOperationClaimDal.Update(userOperationClaim);

			return new SuccessResult(Messages.UserOperationClaimUpdated);
		}
	}
}
