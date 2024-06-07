namespace Wishlist.Repositories;

public interface IDbRepository {
  Task<WishlistItem?> GetAsync(int id, CancellationToken cancellationToken);
  Task<WishlistItem> UpdateAsync(WishlistItem wishlistItem, CancellationToken cancellationToken);
}
