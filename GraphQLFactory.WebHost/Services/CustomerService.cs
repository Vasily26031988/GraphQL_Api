using GraphQLFactory.Core.Abstractions.Repositories;
using GraphQLFactory.Core.Domain.PromoCodeManagement;
using GraphQLFactory.WebHost.Mappers;
using GraphQLFactory.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLFactory.WebHost.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly IRepository<Customer> _customerRepository;
		private readonly IRepository<Preference> _preferenceRepository;

		public CustomerService(
			IRepository<Customer> customerRepository,
			IRepository<Preference> preferenceRepository)
		{
			_customerRepository = customerRepository;
			_preferenceRepository = preferenceRepository;
		}

		public async Task<IEnumerable<CustomerShortResponse>> GetAllAsync()
		{
			var customers = await _customerRepository.GetAllAsync();
			var response = customers
				.Select(x => new CustomerShortResponse()
				{
					Id = x.Id,
					Email = x.Email,
					FirstName = x.FirstName,
					LastName = x.LastName
				});

			return response;
		}

		public async Task<CustomerResponse> GetByIdAsync(Guid id)
		{
			var customer = await _customerRepository.GetByIdAsync(id);
			var response = customer != null ? new CustomerResponse(customer) : null;
			return response;
		}

		public async Task<CustomerResponse> CreateAsync(CreateOrEditCustomerRequest request)
		{
			var preferences =
				request.PreferenceIds is not null
				? await _preferenceRepository.GetRangeByIdsAsync(request.PreferenceIds)
				: null;
			var customer = CustomerMapper.MapFromModel(request, preferences);
			await _customerRepository.AddAsync(customer);
			var response = new CustomerResponse(customer);
			return response;
		}


		public async Task<bool> EditAsync(Guid id, CreateOrEditCustomerRequest request)
		{
			var customer = await _customerRepository.GetByIdAsync(id);
			if (customer is null)
				return false;
			
			var preference = request.PreferenceIds is not null
				? await _preferenceRepository.GetRangeByIdsAsync(request.PreferenceIds)
				: null;
			CustomerMapper.MapFromModel(request, preference, customer);
			await _customerRepository.UpdateAsync(customer);
			return true;
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var customer = await _customerRepository.GetByIdAsync(id);
			if (customer is null)
			{
				return false;
			}

			await _customerRepository.DeleteAsync(customer);
			return true;
		}
	}
}
