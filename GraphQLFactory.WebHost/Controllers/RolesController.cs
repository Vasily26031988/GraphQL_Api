using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLFactory.Core.Abstractions.Repositories;
using GraphQLFactory.Core.Domain.Administration;
using GraphQLFactory.WebHost.Models;
using Microsoft.AspNetCore.Mvc;


namespace PromoCodeFactory.WebHost.Controllers
{
	/// <summary>
	/// Роли сотрудников
	/// </summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	public class RolesController
	{
		private readonly IRepository<Role> _rolesRepository;

		public RolesController(IRepository<Role> rolesRepository)
		{
			_rolesRepository = rolesRepository;
		}

		/// <summary>
		/// Получить все доступные роли сотрудников
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IEnumerable<RoleItemResponse>> GetRolesAsync()
		{
			var roles = await _rolesRepository.GetAllAsync();

			var rolesModelList = roles.Select(x =>
				new RoleItemResponse()
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description
				}).ToList();

			return rolesModelList;
		}
	}
}
