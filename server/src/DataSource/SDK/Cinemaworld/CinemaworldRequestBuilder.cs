// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using MovieDeal.DataSource.Cinemaworld.Movie;
using MovieDeal.DataSource.Cinemaworld.Movies;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace MovieDeal.DataSource.Cinemaworld
{
    /// <summary>
    /// Builds and executes requests for operations under \cinemaworld
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class CinemaworldRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The movie property</summary>
        public global::MovieDeal.DataSource.Cinemaworld.Movie.MovieRequestBuilder Movie
        {
            get => new global::MovieDeal.DataSource.Cinemaworld.Movie.MovieRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The movies property</summary>
        public global::MovieDeal.DataSource.Cinemaworld.Movies.MoviesRequestBuilder Movies
        {
            get => new global::MovieDeal.DataSource.Cinemaworld.Movies.MoviesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::MovieDeal.DataSource.Cinemaworld.CinemaworldRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CinemaworldRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/cinemaworld", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::MovieDeal.DataSource.Cinemaworld.CinemaworldRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CinemaworldRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/cinemaworld", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
