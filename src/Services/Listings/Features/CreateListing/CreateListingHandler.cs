namespace Listings.Features.CreateListing;

public class CreateListingHandler : ICommandHandler<CreateListingCommand, CreateListingResult> {
  private readonly IDocumentSession _session;

  public CreateListingHandler(IDocumentSession session) {
    _session = session;
  }

  public async Task<CreateListingResult> Handle(CreateListingCommand request, CancellationToken cancellationToken) {
    var newListing = new Listing {
      BedroomNumber = request.BedroomNumber,
      Category = request.Category,
      Amenities = request.Amenities,
      City = request.City,
      Country = request.Country,
      Description = request.Description,
      Image = request.Image,
      KitchenNumber = request.KitchenNumber,
      BathroomNumber = request.BathroomNumber,
      Name = request.Name,
      Notice = request.Notice,
      Price = request.Price,
      State = request.State,
      Street = request.Street,
      CoordinateLat = request.CoordinateLat,
      CoordinateLong = request.CoordinateLong,
      ReviewScore = 0,
      CreatedAt = DateTime.Now,
      UpdatedAt = DateTime.Now,
    };

    _session.Store(newListing);
    await _session.SaveChangesAsync(cancellationToken);

    return new CreateListingResult(newListing);
  }
}
