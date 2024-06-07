namespace Listings.Models;

public class Listing {
  public int Id { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }
  public required decimal Price { get; set; }
  public required string City { get; set; }
  public required string Country { get; set; }
  public required string State { get; set; }
  public required string Street { get; set; }
  public required string Image { get; set; }
  public required int BedroomNumber { get; set; }
  public required int BathroomNumber { get; set; }
  public required int KitchenNumber { get; set; }
  public required string Category { get; set; }
  public required List<string> Amenities { get; set; }

  public required decimal CoordinateLong { get; set; }
  public required decimal CoordinateLat { get; set; }
  public string? Notice { get; set; }
  public decimal? ReviewScore { get; set; }
  public DateTime? CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}
