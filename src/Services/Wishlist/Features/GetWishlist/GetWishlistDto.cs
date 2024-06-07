namespace Wishlist.Features.GetWishlist;

public record GetWishlistQuery(
  int id
) : IQuery<GetWishlistResult>;
public record GetWishlistResult(
  WishlistItem? Wishlist
);
