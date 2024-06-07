namespace Listings.Features.GetListingById;

public class GetListingByIdEndpoint : ICarterModule {
  public void AddRoutes(IEndpointRouteBuilder app) {
    app.MapGet("/listings/{id}", async (int id, ISender sender) => {
      var query = new GetListingByIdQuery(id);
      var result = await sender.Send(query);

      return result.Listing is null ? Results.NotFound($"Listing by id {id} is not found...") : Results.Ok(result);
    })
    .WithName("GetListingById")
    .Produces(StatusCodes.Status200OK)
    .ProducesProblem(StatusCodes.Status404NotFound);
  }
}
