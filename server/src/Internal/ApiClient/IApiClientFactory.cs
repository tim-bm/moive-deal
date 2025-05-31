using MovieDeal.DataSource;

namespace MovieDeal.Internal.ApiClient;

public interface IMovieDataApiClientFactory
{
    public MoiveDataSource GenerateApiClent();
}