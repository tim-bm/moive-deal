using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieDeal.DTO;
using MovieDeal.Internal.ApiClient;
using MovieDeal.Services;

namespace MovieDeal.Controllers;

[ApiController]
[Route("[controller]")]
public class MoiveController : ControllerBase
{
    private readonly ILogger<MoiveController> _logger;
    private readonly IMovieDataService _movieService;
    private readonly IMapper _mapper;
    public MoiveController(IMovieDataService MovieDataService, ILogger<MoiveController> logger, IMapper mapper)
    {
        this._logger = logger;
        this._movieService = MovieDataService;
        this._mapper = mapper;
    }

    [HttpGet(Name = "ListMoive")]
    public async Task<ListMoiveResponse> List()
    {
        var cienmaMoives = await this._movieService.ListCinemiWorld();
        var filmMovies = await this._movieService.ListFilmWorld();

        return new ListMoiveResponse()
        {
            CinemaWorld = this._mapper.Map<IList<MoiveDTO>>(cienmaMoives),
            FilmWorld = this._mapper.Map<IList<MoiveDTO>>(filmMovies)
        };
    }

    [HttpGet("cinema/{Id}", Name = "GetByIdCinemaWorld")]
    public async Task<MoiveDTO> GetByIdCinemaWorld(string Id)
    {
        var moive = await this._movieService.GetMoiveFromCinemaWorld(Id);
        return this._mapper.Map<MoiveDTO>(moive);
    }

    [HttpGet("film/{Id}", Name = "GetByIdFilmWorld")]
    public async Task<MoiveDTO> GetByIdFilmWorld(string Id)
    {
        var moive = await this._movieService.GetMoiveFromFilmWorld(Id);
        return this._mapper.Map<MoiveDTO>(moive);
    }
}
