using Marten.Pagination;

namespace Listings.Features.GetListingsByCategory;

public class GetListingsByCategoryHandler : IQueryHandler<GetListingsByCategoryQuery, GetListingsByCategoryResult> {
  private readonly IDocumentSession _session;
  private const int PAGE_SIZE = 5;

  public GetListingsByCategoryHandler(IDocumentSession session) {
    _session = session;
  }

  public async Task<GetListingsByCategoryResult> Handle(GetListingsByCategoryQuery request, CancellationToken cancellationToken) {

    var listings = await _session.Query<Listing>()
                                 .Where(el => el.Category == request.category)
                                 .OrderByDescending(el => el.CreatedAt)
                                 .ToPagedListAsync(request.pageNumber ?? 1, PAGE_SIZE, cancellationToken);
    return new GetListingsByCategoryResult(listings);
  }
}
