using Marten.Schema;

namespace Wishlist.Models;

public class WishlistItem {
  public int Id { get; set; }

  [UniqueIndex(IndexType = UniqueIndexType.Computed)]
  public required string UserId { get; set; }

  public List<int>? ListingsIds { get; set; }
}
