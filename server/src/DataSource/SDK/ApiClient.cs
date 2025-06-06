// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Serialization.Form;
using Microsoft.Kiota.Serialization.Json;
using Microsoft.Kiota.Serialization.Multipart;
using Microsoft.Kiota.Serialization.Text;
using MovieDeal.DataSource.Cinemaworld;
using MovieDeal.DataSource.Filmworld;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace MovieDeal.DataSource
{
    /// <summary>
    /// The main entry point of the SDK, exposes the configuration and the fluent API.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class ApiClient : BaseRequestBuilder
    {
        /// <summary>The cinemaworld property</summary>
        public global::MovieDeal.DataSource.Cinemaworld.CinemaworldRequestBuilder Cinemaworld
        {
            get => new global::MovieDeal.DataSource.Cinemaworld.CinemaworldRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The filmworld property</summary>
        public global::MovieDeal.DataSource.Filmworld.FilmworldRequestBuilder Filmworld
        {
            get => new global::MovieDeal.DataSource.Filmworld.FilmworldRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::MovieDeal.DataSource.ApiClient"/> and sets the default values.
        /// </summary>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ApiClient(IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}", new Dictionary<string, object>())
        {
            ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<TextSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<FormSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<MultipartSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<TextParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<FormParseNodeFactory>();
            if (string.IsNullOrEmpty(RequestAdapter.BaseUrl))
            {
                RequestAdapter.BaseUrl = "https://webjetapitest.azurewebsites.net/api";
            }
            PathParameters.TryAdd("baseurl", RequestAdapter.BaseUrl);
        }
    }
}
#pragma warning restore CS0618
