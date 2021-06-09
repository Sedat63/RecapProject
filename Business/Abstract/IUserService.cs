using Core.Entities.Conrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IUserService
	{
		IDataResult<User> GetById(int id);
		IDataResult<List<User>> GetAll();
		IDataResult<List<OperationClaim>> GetClaims(User user);
		IDataResult<User> GetByMail(string userMail);
		IDataResult<UserDetailDto> GetUserDetailByMail(string userMail);
		IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate);
		IResult Add(User user);
		IResult Delete(User user);
		IResult Update(User user);
	}
}
