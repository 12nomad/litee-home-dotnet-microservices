
namespace Wishlist.Features.UpdateWishlist;

public class UpdateWishlistHandler : ICommandHandler<UpdateWishlistCommand, UpdateWishlistResult> {
  private readonly IDbRepository _dbRepository;

  public UpdateWishlistHandler(IDbRepository dbRepository) {
    _dbRepository = dbRepository;
  }

  public async Task<UpdateWishlistResult> Handle(UpdateWishlistCommand request, CancellationToken cancellationToken) {
    var wishlist = new WishlistItem {
      UserId = request.UserId,
      Id = request.Id,
      ListingsIds = request.ListingsIds,
    };
    await _dbRepository.UpdateAsync(wishlist, cancellationToken);
    return new UpdateWishlistResult(wishlist, true);
  }
}
