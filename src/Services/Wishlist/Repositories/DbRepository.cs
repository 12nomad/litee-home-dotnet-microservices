namespace Wishlist.Repositories;

public class DbRepository : IDbRepository {
  private readonly IDbRepository _repository;

  public DbRepository(IDbRepository sepository) {
    _repository = sepository;
  }

  public async Task<WishlistItem?> GetAsync(int id, CancellationToken cancellationToken) {
    return await _repository.GetAsync(id, cancellationToken);
  }
  public async Task<WishlistItem> UpdateAsync(WishlistItem wishlistItem, CancellationToken cancellationToken) {
    return await _repository.UpdateAsync(wishlistItem, cancellationToken);
  }
}
