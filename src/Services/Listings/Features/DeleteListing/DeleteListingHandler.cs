namespace Listings.Features.DeleteListing;

public class DeleteListingHandler : ICommandHandler<DeleteListingCommand, DeleteListingResult> {

  private readonly IDocumentSession _session;

  public DeleteListingHandler(IDocumentSession session) {
    _session = session;
  }
  public async Task<DeleteListingResult> Handle(DeleteListingCommand request, CancellationToken cancellationToken) {
    var listing = await _session.LoadAsync<Listing>(request.id, cancellationToken);
    if (listing is null) return new DeleteListingResult(listing);

    _session.Delete(listing);
    await _session.SaveChangesAsync(cancellationToken);

    return new DeleteListingResult(listing);
  }
}
