using GenelogyApi.Domain.ViewModels.Pages;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.Filters;
using KodalibApi.Data.Response;
using Microsoft.AspNetCore.Mvc;

namespace KodalibApi.Controllers;

public class SearchController : Controller
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet(Name = "Search")]
    public async Task<IBaseResponse> GetPerson([FromQuery]FilmsFilters filmsFilters, PageParameters pageParameters)
    {
        var response = await _searchService.GetSearch(filmsFilters, pageParameters, HttpContext.RequestAborted);
        return response;
    }
}