using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Wishlist.Repositories;

public class CachedWishlistRepository : IDbRepository {
  private readonly IDbRepository _repository;
  private readonly IDistributedCache _cache;

  public CachedWishlistRepository(IDbRepository repository, IDistributedCache cache) {
    _repository = repository;
    _cache = cache;
  }

  public async Task<WishlistItem?> GetAsync(int id, CancellationToken cancellationToken) {
    var cachedWishlist = await _cache.GetStringAsync(id.ToString(), cancellationToken);

    if (!string.IsNullOrEmpty(cachedWishlist)) return JsonSerializer.Deserialize<WishlistItem>(cachedWishlist);

    var wishlistItem = await _repository.GetAsync(id, cancellationToken);
    await _cache.SetStringAsync(id.ToString(), JsonSerializer.Serialize(wishlistItem), cancellationToken);

    return wishlistItem;
  }

  public async Task<WishlistItem> UpdateAsync(WishlistItem wishlistItem, CancellationToken cancellationToken) {
    await _repository.UpdateAsync(wishlistItem, cancellationToken);
    await _cache.SetStringAsync(wishlistItem.Id.ToString(), JsonSerializer.Serialize(wishlistItem), cancellationToken);

    return wishlistItem;
  }

}
