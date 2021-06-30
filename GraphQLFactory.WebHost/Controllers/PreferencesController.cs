using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLFactory.Core.Abstractions.Repositories;
using GraphQLFactory.Core.Domain.PromoCodeManagement;
using GraphQLFactory.WebHost.Models;
using Microsoft.AspNetCore.Mvc;


namespace PromoCodeFactory.WebHost.Controllers
{
	/// <summary>
	/// Предпочтения клиентов
	/// </summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	public class PreferencesController
		: ControllerBase
	{
		private readonly IRepository<Preference> _preferencesRepository;

		public PreferencesController(IRepository<Preference> preferencesRepository)
		{
			_preferencesRepository = preferencesRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<PreferenceResponse>>> GetPreferencesAsync()
		{
			var preferences = await _preferencesRepository.GetAllAsync();

			var response = preferences.Select(x => new PreferenceResponse()
			{
				Id = x.Id,
				Name = x.Name
			}).ToList();

			return Ok(response);
		}
	}
}
