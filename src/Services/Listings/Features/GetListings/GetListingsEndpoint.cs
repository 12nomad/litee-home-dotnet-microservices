namespace Listings.Features.GetListings;

public class GetListingsEndpoint : ICarterModule {
  public void AddRoutes(IEndpointRouteBuilder app) {
    app.MapGet("/listings", async (int? pageNumber, ISender sender) => {
      var command = new GetListingsQuery(pageNumber);
      var response = await sender.Send(command);
      return Results.Ok(response);
    })
    .WithName("GetListings");
  }
}
