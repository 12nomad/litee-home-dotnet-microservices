namespace Listings.Features.CreateListing;

// FIXME: shouls remove this later after input validation
public record CreateListingRequest(
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
  decimal CoordinateLong,
  decimal CoordinateLat
);

public class CreateListingEndpoint : ICarterModule {
  public void AddRoutes(IEndpointRouteBuilder app) {
    app.MapPost("/listings", async (CreateListingRequest request, ISender sender) => {
      var command = request.Adapt<CreateListingCommand>();
      var response = await sender.Send(command);

      return Results.Created($"/products/{response.Listing.Id}", response);
    })
    .WithName("CreateListing")
    .Produces(StatusCodes.Status201Created);
  }
}
