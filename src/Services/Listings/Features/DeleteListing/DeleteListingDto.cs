using Common.CQRS;
using Listings.Models;

namespace Listings.Features.DeleteListing;

public record DeleteListingCommand(
  int id
) : ICommand<DeleteListingResult>;
public record DeleteListingResult(
  Listing? Listing
);

public class DeleteListingCommandValidator : AbstractValidator<DeleteListingCommand> {
  public DeleteListingCommandValidator() {
    RuleFor(el => el.id).GreaterThanOrEqualTo(0).WithMessage("id is required");
  }
}
