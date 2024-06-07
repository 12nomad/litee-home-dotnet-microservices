namespace Listings.Features.GetListingById;

public class GetListingByIdHandler : IQueryHandler<GetListingByIdQuery, GetListingByIdResult> {
  private readonly IDocumentSession _session;

  public GetListingByIdHandler(IDocumentSession session) {
    _session = session;
  }

  public async Task<GetListingByIdResult> Handle(GetListingByIdQuery request, CancellationToken cancellationToken) {
    var listing = await _session.LoadAsync<Listing>(request.id, cancellationToken);
    return new GetListingByIdResult(listing);
  }
}
