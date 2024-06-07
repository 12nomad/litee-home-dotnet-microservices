namespace Wishlist.Features.GetWishlist;

public class GetWishlistEndpoint : ICarterModule {
  public void AddRoutes(IEndpointRouteBuilder app) {
    app.MapGet("/wishlist/{id}", async (int id, ISender sender) => {
      var query = new GetWishlistQuery(id);
      var result = await sender.Send(query);

      return Results.Ok(result);
    })
    .WithName("GetWishlist");
  }
}
