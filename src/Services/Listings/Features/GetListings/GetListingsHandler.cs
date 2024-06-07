using Marten.Pagination;

namespace Listings.Features.GetListings;

public class GetListingsHandler : IQueryHandler<GetListingsQuery, GetListingsResult> {
  private readonly IDocumentSession _session;
  private const int PAGE_SIZE = 5;

  public GetListingsHandler(IDocumentSession session) {
    _session = session;
  }

  public async Task<GetListingsResult> Handle(GetListingsQuery request, CancellationToken cancellationToken) {
    var listings = await _session.Query<Listing>()
                                 .OrderByDescending(el => el.CreatedAt)
                                 .ToPagedListAsync(request.pageNumber ?? 1, PAGE_SIZE, cancellationToken);
    return new GetListingsResult(listings);
  }
}
