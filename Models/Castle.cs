namespace knights_castles.Models
{
  public class Castle
  {

    public int Id { get; set; }
    public string? CastleName { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public int Dungeons { get; set; }
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }

  }
}