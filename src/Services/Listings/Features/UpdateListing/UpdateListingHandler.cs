namespace Listings.Features.UpdateListing;

public class UpdateListingHandler : ICommandHandler<UpdateListingCommand, UpdateListingResult> {
  private readonly IDocumentSession _session;

  public UpdateListingHandler(IDocumentSession session) {
    _session = session;
  }

  public async Task<UpdateListingResult> Handle(UpdateListingCommand request, CancellationToken cancellationToken) {
    var listing = await _session.LoadAsync<Listing>(request.Id, cancellationToken);
    if (listing is null) return new UpdateListingResult(listing);

    listing.Name = request.Name;
    listing.Description = request.Description;
    listing.Price = request.Price;
    listing.City = request.City;
    listing.Country = request.Country;
    listing.State = request.State;
    listing.Street = request.Street;
    listing.Image = request.Image;
    listing.Notice = request.Notice;
    listing.BedroomNumber = request.BedroomNumber;
    listing.BathroomNumber = request.BathroomNumber;
    listing.KitchenNumber = request.KitchenNumber;
    listing.Category = request.Category;
    listing.Amenities = request.Amenities;
    listing.ReviewScore = request.ReviewScore;
    listing.CoordinateLat = request.CoordinateLat;
    listing.CoordinateLong = request.CoordinateLong;
    listing.UpdatedAt = DateTime.Now;

    _session.Update(listing);
    await _session.SaveChangesAsync(cancellationToken);

    return new UpdateListingResult(listing);
  }
}
