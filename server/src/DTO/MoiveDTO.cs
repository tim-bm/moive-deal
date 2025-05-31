

namespace MovieDeal.DTO;


public class MoiveDTO
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Year { get; set; }

    public required string Poster { get; set; }
    public string? Price { get; set; }
    

}