namespace Listings.Features.UpdateListing;

public record UpdateListingRequest(
  int Id,
  string Name,
  string Description,
  decimal Price,
  string City,
  string Country,
  string State,
  string Street,
  string Image,
  string Notice,
  int BedroomNumber,
  int BathroomNumber,
  int KitchenNumber,
  string Category,
  List<string> Amenities,
  decimal ReviewScore,
  decimal CoordinateLong,
  decimal CoordinateLat
);

public class UpdateListingEndpoint : ICarterModule {
  public void AddRoutes(IEndpointRouteBuilder app) {
    app.MapPut("/listings", async (UpdateListingRequest request, ISender sender) => {
      var command = request.Adapt<UpdateListingCommand>();
      var result = await sender.Send(command);

      return result.Listing is null ? Results.NotFound($"Listing by id {request.Id} is not found...") : Results.Ok(result);
    })
    .WithName("UpdateListing")
    .Produces(StatusCodes.Status200OK)
    .ProducesProblem(StatusCodes.Status404NotFound);
  }
}
