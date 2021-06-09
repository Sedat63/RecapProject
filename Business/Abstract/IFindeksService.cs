using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IFindeksService
	{
		IDataResult<Findeks> GetById(int id);
		IDataResult<Findeks> GetByCustomerId(int customerId);
		IDataResult<List<Findeks>> GetAll();
		IDataResult<Findeks> CalculateFindeksScore(Findeks findeks);

		IResult Add(Findeks findeks);
		IResult Delete(Findeks findeks);
		IResult Update(Findeks findeks);
	}
}
