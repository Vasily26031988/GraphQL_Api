using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQLFactory.Core.Abstractions.Repositories;
using GraphQLFactory.Core.Domain.PromoCodeManagement;
using GraphQLFactory.WebHost.Mappers;
using GraphQLFactory.WebHost.Models;
using HotChocolate;

namespace GraphQLFactory.WebHost.GraphQL
{
    public class Mutation
    {
        public async Task<CreateCustomerPayload> CreateCustomerAsync(
            CreateCustomerInput input,
            [Service] IRepository<Customer> customerRepository,
            [Service] IRepository<Preference> preferenceRepository)
        {
            var preferences =
                input.PreferenceIds is not null
                    ? await preferenceRepository.GetRangeByIdsAsync(input.PreferenceIds)
                    : null;
            var request = new CreateOrEditCustomerRequest()
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                PreferenceIds = input.PreferenceIds,
            };
            var customer = CustomerMapper.MapFromModel(request, preferences);
            await customerRepository.AddAsync(customer);

            return new CreateCustomerPayload(customer);
        }

        public async Task<EditCustomerPayload> EditCustomerAsync(
            EditCustomerInput input,
            [Service] IRepository<Customer> customerRepository,
            [Service] IRepository<Preference> preferenceRepository)
        {
            var customer = await customerRepository.GetByIdAsync(input.Id);
            if (customer is null)
                return new EditCustomerPayload(
                    new UserError($"Customer by identifier '{input.Id}' not found.", "NOT_FOUND"));

            var preferences =
                input.PreferenceIds is not null
                    ? await preferenceRepository.GetRangeByIdsAsync(input.PreferenceIds)
                    : null;
            var request = new CreateOrEditCustomerRequest()
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                PreferenceIds = input.PreferenceIds,
            };
            CustomerMapper.MapFromModel(request, preferences, customer);
            await customerRepository.UpdateAsync(customer);

            return new EditCustomerPayload(customer);
        }

        public async Task<DeleteCustomerPayload> DeleteCustomerAsync(
            DeleteCustomerInput input,
            [Service] IRepository<Customer> customerRepository)
        {
            var customer = await customerRepository.GetByIdAsync(input.Id);
            if (customer is null)
                return new DeleteCustomerPayload(
                    new UserError($"Customer by identifier '{input.Id}' not found.", "NOT_FOUND"));

            await customerRepository.DeleteAsync(customer);

            return new DeleteCustomerPayload(true);
        }
    }




}

