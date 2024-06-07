
namespace Listings.Features.GetListingsByCategory;

public record GetListingsByCategoryQuery(
  string category,
  int? pageNumber = 1
) : IQuery<GetListingsByCategoryResult>;
public record GetListingsByCategoryResult(
  IEnumerable<Listing?> Listings
);