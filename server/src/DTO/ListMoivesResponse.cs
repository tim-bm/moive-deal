namespace MovieDeal.DTO;

public class ListMoiveResponse
{
    public IList<MoiveDTO> CinemaWorld { get; set; } = [];
    public IList<MoiveDTO> FilmWorld { get; set; } = [];
}
