
namespace Listings.Features.GetListingsByCategory;

public class GetListingsByCategoryEndpoint : ICarterModule {
  public void AddRoutes(IEndpointRouteBuilder app) {
    app.MapGet("/listings/category/{category}", async (string category, int? pageNumber, ISender sender) => {
      var query = new GetListingsByCategoryQuery(category, pageNumber);
      var response = await sender.Send(query);

      return Results.Ok(response);
    })
    .WithName("GetListingsByCategory");
  }
}
