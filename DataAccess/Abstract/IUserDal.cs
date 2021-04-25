﻿using Core.DataAccess;
using Core.Entities.Conrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
	public interface IUserDal:IEntityRepository<User>
	{
		List<OperationClaim> GetClaims(User user);
		UserDetailDto GetUserDetail(string userMail);
	}
}
