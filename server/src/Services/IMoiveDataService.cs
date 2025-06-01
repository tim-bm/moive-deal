namespace MovieDeal.Services;

public interface IMovieDataService
{
    public Task<IList<DataSource.Models.Movie>> ListFilmWorld();
    public Task<IList<DataSource.Models.Movie>> ListCinemiWorld();
    public Task<DataSource.Models.MovieDetail?> GetMoiveFromFilmWorld(string id);
    public Task<DataSource.Models.MovieDetail?> GetMoiveFromCinemaWorld(string id);
}