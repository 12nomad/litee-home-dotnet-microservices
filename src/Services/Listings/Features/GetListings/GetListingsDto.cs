namespace Listings.Features.GetListings;

public record GetListingsQuery(
  int? pageNumber = 1
) : IQuery<GetListingsResult>;
public record GetListingsResult(
  IEnumerable<Listing> Listings
);


