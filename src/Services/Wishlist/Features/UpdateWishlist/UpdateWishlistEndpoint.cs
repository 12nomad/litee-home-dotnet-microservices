namespace Wishlist.Features.UpdateWishlist;

public record UpdateWishlistRequest(
  string UserId,
  List<int> ListingsIds,
  int Id
);

public class UpdateWishlistEndpoint : ICarterModule {
  public void AddRoutes(IEndpointRouteBuilder app) {
    app.MapPost("/wishlist", async (UpdateWishlistRequest request, ISender sender) => {
      var command = request.Adapt<UpdateWishlistCommand>();
      var result = await sender.Send(command);

      return Results.Ok(result);
    })
    .WithName("UpdateWishlist");
  }
}
