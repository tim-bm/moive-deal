
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using MovieDeal.DataSource;

namespace MovieDeal.Internal.ApiClient;

public class MovieDataApiClientFactory : IMovieDataApiClientFactory
{
    private readonly string _apiKey;

    public MovieDataApiClientFactory(AppConfig appConfig)
    {
        this._apiKey = appConfig.ApiKey;
    }

    public MoiveDataSource GenerateApiClent()
    {
        var authProvider = new ApiKeyAuthenticationProvider(this._apiKey, "x-access-token", ApiKeyAuthenticationProvider.KeyLocation.Header);
        var requestAapter = new HttpClientRequestAdapter(authProvider);

        return new MoiveDataSource(requestAapter);
    }

}