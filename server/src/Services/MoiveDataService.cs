
using Microsoft.Extensions.Caching.Memory;
using MovieDeal.DataSource;

namespace MovieDeal.Services;


static class CacheKey
{
    public static string ListFilmWorld { get; set; } = "ListFilmWorld";
    public static string ListCinemiWorld { get; set; } = "ListCinemiWorld";
    public static string GetMoiveFromFilmWorld { get; set; } = "GetMoiveFromFilmWorld";
    public static string GetMoiveFromCinemaWorld { get; set; } = "GetMoiveFromCinemaWorld";
}

public class MovieDataService : IMovieDataService
{
    private readonly MoiveDataSource _apiClient;
    private readonly IMemoryCache _memoryCache;
    private static readonly TimeSpan _expirationIn = new TimeSpan(0, 0, 10);
    public MovieDataService(MoiveDataSource apiClient, IMemoryCache memoryCache)
    {
        _apiClient = apiClient;
        _memoryCache = memoryCache;
    }
    public async Task<IList<DataSource.Models.Movie>> ListFilmWorld()
    {
        var movies = _memoryCache.Get<IList<DataSource.Models.Movie>>(CacheKey.ListFilmWorld);
        if (movies is null)
        {
            var res = await this._apiClient.Filmworld.Movies.GetAsync();
            if (res is null || res.Movies is null)
            {
                movies = [];
            }
            else
            {
                _memoryCache.Set(CacheKey.ListFilmWorld, res.Movies, _expirationIn);
                movies = res.Movies;
            }
        }
        return movies;
    }

    public async Task<IList<DataSource.Models.Movie>> ListCinemiWorld()
    {
        var movies = _memoryCache.Get<IList<DataSource.Models.Movie>>(CacheKey.ListCinemiWorld);
        if (movies is null)
        {
            var res = await this._apiClient.Cinemaworld.Movies.GetAsync();
            if (res is null || res.Movies is null)
            {
                movies = [];
            }
            else
            {
                _memoryCache.Set(CacheKey.ListCinemiWorld, res.Movies, _expirationIn);
                movies = res.Movies;
            }
        }
        return movies;
    }
    public async Task<DataSource.Models.MovieDetail?> GetMoiveFromFilmWorld(string id)
    {
        var movie = _memoryCache.Get<DataSource.Models.MovieDetail>($"{CacheKey.GetMoiveFromFilmWorld}/{id}");
        if (movie is null)
        {
            var res = await this._apiClient.Filmworld.Movie[id].GetAsync();
            if (res is null)
            {
                movie = null;
            }
            else
            {
                _memoryCache.Set($"{CacheKey.GetMoiveFromFilmWorld}/{id}", res, _expirationIn);
                movie = res;
            }
        }
        return movie;
    }
    public async Task<DataSource.Models.MovieDetail?> GetMoiveFromCinemaWorld(string id)
    {
        var movie = _memoryCache.Get<DataSource.Models.MovieDetail>($"{CacheKey.GetMoiveFromFilmWorld}/{id}");
        if (movie is null)
        {
            var res = await this._apiClient.Cinemaworld.Movie[id].GetAsync();
            if (res is null)
            {
                movie = null;
            }
            else
            {
                _memoryCache.Set($"{CacheKey.GetMoiveFromFilmWorld}/{id}", res, _expirationIn);
                movie = res;
            }
        }
        return movie;
    }
}
