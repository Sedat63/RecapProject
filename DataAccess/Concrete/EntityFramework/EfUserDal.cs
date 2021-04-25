using Core.DataAccess.EntityFramework;
using Core.Entities.Conrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfUserDal : EfEntityRepositoryBase<User, RecapCarContext>, IUserDal
	{
		public List<OperationClaim> GetClaims(User user)
		{
			using (var context =new RecapCarContext())
			{
				//var result=from operationClaim in context.OperationClaims
				//		   join UserOperationClaim in context.UserOperationClaims
				//		   on OperationClaim.Id equals UserOperationClaim.OperationClaimId
				//		   where UserOperationClaim.UserId==user.Id
				//		   select new OperationClaim
				throw new NotImplementedException();
			}
		}

		public UserDetailDto GetUserDetail(string userMail)
		{
			throw new NotImplementedException();
		}
	}
}
