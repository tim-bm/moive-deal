
using MovieDeal.DataSource;
using MovieDeal.Internal.ApiClient;

namespace MovieDeal.Services;


public class MovieDataService : IMovieDataService
{
    private readonly MoiveDataSource _apiClient;

    public MovieDataService(MoiveDataSource apiClient)
    {
        this._apiClient = apiClient;
    }

    public async Task<IList<DataSource.Models.Movie>> ListFilmWorld()
    {
        // TODO: add restry and cache
        var res = await this._apiClient.Filmworld.Movies.GetAsync();
        if (res is null || res.Movies is null)
        {
            return [];

        }

        return res.Movies;
    }

    public async Task<IList<DataSource.Models.Movie>> ListCinemiWorld()
    {
        // TODO: add restry and cache
        var res = await this._apiClient.Cinemaworld.Movies.GetAsync();
        if (res is null || res.Movies is null)
        {
            return [];

        }

        return res.Movies;
    }

    public async Task<DataSource.Models.MovieDetail> GetMoiveFromFilmWorld(string id)
    {
        var res = await this._apiClient.Filmworld.Movie[id].GetAsync();
        if (res is null)
        {
            return null;
        }
        return res;
    }

    public async Task<DataSource.Models.MovieDetail> GetMoiveFromCinemaWorld(string id)
    {
        var res = await this._apiClient.Cinemaworld.Movie[id].GetAsync();
        if (res is null)
        {
            return null;
        }
        return res;
    }


}