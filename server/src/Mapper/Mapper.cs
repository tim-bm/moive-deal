
using AutoMapper;
using MovieDeal.DataSource;
using MovieDeal.DTO;

namespace MovieDeal.Mapper;

class Mapper : Profile
{
    public Mapper()
    {
        this.CreateMap<DataSource.Models.Movie, MoiveDTO>();
        this.CreateMap<DataSource.Models.MovieDetail, MoiveDTO>();
    }
}