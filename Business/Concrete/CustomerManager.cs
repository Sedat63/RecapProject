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
	public class CustomerManager:ICustomerService
	{
		ICustomerDal _customerDal;
		public CustomerManager(ICustomerDal customerManager)
		{
			_customerDal = customerManager;
		}

		public IDataResult<Customer> GetById(int id)
		{
			return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id));
		}

		public IDataResult<List<Customer>> GetAll()
		{
			return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
		}

		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult(Messages.CustomerAdded);
		}

		public IResult Delete(Customer customer)
		{
			_customerDal.Delete(customer);
			return new SuccessResult(Messages.CustomerDeleted);
		}

		public IResult Update(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult(Messages.CustomerUpdated);
		}
	}
}
