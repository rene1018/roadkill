﻿using System.Collections.Generic;
using System.Web.Http;
using Roadkill.Core.Mvc.ViewModels;
using Roadkill.Core.Services;

namespace Roadkill.Core.Mvc.WebApi
{
	[RoutePrefix("api/pages")]
	[ApiKeyAuthorize]
	public class PagesController : ApiController
	{
		private IPageService _pageService;

		public PagesController(IPageService pageService)
		{
			_pageService = pageService;
		}

		/// <summary>
		/// Retrieves all pages from the system, but without their text content.
		/// </summary>
		/// <returns>An array of page details.</returns>
		public IEnumerable<PageViewModel> Get()
		{
			return _pageService.AllPages();
		}

		/// <summary>
		/// Retrieves a page by its id, without any markup content.
		/// </summary>
		/// <param name="id">The id of the page.</param>
		/// <returns>The page details</returns>
		public PageViewModel Get(int id)
		{
			return _pageService.GetById(id);
		}

		/// <summary>
		/// Creates a new page in the database.
		/// </summary>
		/// <param name="model">The page details.</param>
		public void Post(PageViewModel model)
		{
			_pageService.AddPage(model);
		}

		/// <summary>
		/// Updates an existing page.
		/// </summary>
		/// <param name="model">The page details, which should contain a valid ID.</param>
		public void Put(PageViewModel model)
		{
			_pageService.UpdatePage(model);
		}
	}
}