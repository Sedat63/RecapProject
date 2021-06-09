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
	public class OperationClaimManager : IOperationClaimService
	{
		IOperationClaimDal _operationClaimDal;
		public OperationClaimManager(IOperationClaimDal operationClaimDal)
		{
			_operationClaimDal = operationClaimDal;
	}
		public IResult Add(OperationClaim operationClaim)
		{
			_operationClaimDal.Add(operationClaim);
			return new SuccessResult(Messages.OperationClaimAdded);
		}

		public IResult Delete(OperationClaim operationClaim)
		{
			_operationClaimDal.Delete(operationClaim);
			return new SuccessResult(Messages.OperationClaimDeleted);
		}

		public IResult Update(OperationClaim operationClaim)
		{
			_operationClaimDal.Update(operationClaim);
			return new SuccessResult(Messages.OperationClaimUpdated);
		}

		public IDataResult<List<OperationClaim>> GetAll()
		{
			return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
		}

		public IDataResult<OperationClaim> GetById(int id)
		{
			return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Id == id));
		}

		public IDataResult<OperationClaim> GetByName(string name)
		{
			return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Name == name));
		}

		
	}
}
