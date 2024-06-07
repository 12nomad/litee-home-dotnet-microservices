namespace Wishlist.Features.GetWishlist;

public class GetWishlistHandler : IQueryHandler<GetWishlistQuery, GetWishlistResult> {
  private readonly IDbRepository _repository;

  public GetWishlistHandler(IDbRepository repository) {
    _repository = repository;
  }

  public async Task<GetWishlistResult> Handle(GetWishlistQuery request, CancellationToken cancellationToken) {
    var wishlist = await _repository.GetAsync(request.id, cancellationToken);
    return new GetWishlistResult(wishlist);
  }
}
