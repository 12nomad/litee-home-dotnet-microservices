namespace Listings.Features.GetListingById;

public record GetListingByIdQuery(
  int id
) : IQuery<GetListingByIdResult>;

public record GetListingByIdResult(
  Listing? Listing
);
