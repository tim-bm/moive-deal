using System.Net;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using MovieDeal.DataSource;
using MovieDeal.Internal.ApiClient;
using MovieDeal.Services;
using Microsoft.Extensions.Caching.Memory;

namespace MovieDeal;

public class Startup
{
    private readonly AppConfig config = AppConfig.Build();
    private readonly IWebHostEnvironment env;

    public Startup(IWebHostEnvironment hostEnvironment)
    {
        this.env = hostEnvironment;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();
        services.AddMetrics();
        services.AddHealthChecks();
        services.AddSingleton(this.config);

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
            {
                Version = "v1",
                Title = "Movie Server Api",
                Description = "The spec for the local development server"

            });
            options.AddServer(new Microsoft.OpenApi.Models.OpenApiServer()
            {
                Description = "Local Development Server",
                Url = this.config.PublicOrigin,
            });

        });
        // For a stable solution, we should use redis stack to cache
        // For the demo perpose, I choose to the in memory cache
        services.AddMemoryCache(options =>
        {
            options.ExpirationScanFrequency = new TimeSpan(0, 1, 0);
        });

        services.AddSingleton(this.config);
        services.AddSingleton<IMovieDataApiClientFactory, MovieDataApiClientFactory>();
        services.AddSingleton<IMovieDataService, MovieDataService>();


        // Cross Origin policy to allow web to work with Clients from any origin.
        // This policy can be tuned to improve security.
        services.AddCors(o => o.AddPolicy("DefaultPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));


        services.AddHttpClient<MoiveDataSource, MoiveDataSource>(client =>
        {
            // The total time out has to be greater than attmpet timeout * retry counts
            client.Timeout = new TimeSpan(0, 1, 0);
            var authProvider = new ApiKeyAuthenticationProvider(this.config.ApiKey, "x-access-token", ApiKeyAuthenticationProvider.KeyLocation.Header);
            var requestAapter = new HttpClientRequestAdapter(authProvider, null, null, client);
            return new MoiveDataSource(requestAapter);
        })
        // The resilience mechanism is trigger at http1.1 while kiota client is on http2 so downgrade it.
        // https://github.com/microsoft/kiota-dotnet/issues/526#issuecomment-2721189446
        .AddHttpMessageHandler(() => new DowngrageHttpVersionHandler())
        .AddStandardResilienceHandler(options =>
        {
            options.AttemptTimeout.Timeout = new TimeSpan(0, 0, 5);
            options.Retry.MaxRetryAttempts = 3;
        });

        // Forwarded Headers that we will trust because this
        // app is deployed behind a TLS terminating proxy
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.All;
            options.ForwardLimit = null;
            options.KnownProxies.Add(IPAddress.Any);
            options.KnownNetworks.Add(new Microsoft.AspNetCore.HttpOverrides.IPNetwork(IPAddress.Any, 0));
        });

        // Add Automapper profiles
        services.AddAutoMapper(typeof(Startup).Assembly);

        // Add the custom exception handler
        // services.AddExceptionHandler<ExternalApiExceptionHandler>();
        // services.AddProblemDetails();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {

        if (this.env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Put the use UseSwagger before UseAuthentication and UseAuthorization so
        // the swagger UI is publicly accessible
        if (this.env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseForwardedHeaders();
        app.UseHealthChecks("/Health");
        app.UseRouting();
        app.UseCors("DefaultPolicy");
        app.UseAuthentication();
        app.UseAuthorization();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/health");

            endpoints.MapControllers();

            endpoints.MapGet("/", async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                await context.Response.WriteAsync("Movie Deal Api Server");
            });
        });
    }
}

