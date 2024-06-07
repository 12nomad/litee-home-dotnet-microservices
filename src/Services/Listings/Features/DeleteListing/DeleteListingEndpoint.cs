
namespace Listings.Features.DeleteListing;

public class DeleteListingEndpoint : ICarterModule {
  public void AddRoutes(IEndpointRouteBuilder app) {
    app.MapDelete("/listings/{id}", async (int id, ISender sender) => {
      var command = new DeleteListingCommand(id);
      var result = await sender.Send(command);

      return result.Listing is null ? Results.NotFound($"Listing by id {id} is not found...") : Results.Ok(result);
    })
    .WithName("DeleteListing")
    .Produces(StatusCodes.Status200OK)
    .ProducesProblem(StatusCodes.Status404NotFound);
  }
}
