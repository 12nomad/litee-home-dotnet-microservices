namespace Listings.Features.UpdateListing;

public record UpdateListingCommand(
  int Id,
  string Name,
  string Description,
  decimal Price,
  string City,
  string Country,
  string State,
  string Street,
  string Image,
  string Notice,
  int BedroomNumber,
  int BathroomNumber,
  int KitchenNumber,
  string Category,
  List<string> Amenities,
  decimal ReviewScore,
  decimal CoordinateLong,
  decimal CoordinateLat
) : ICommand<UpdateListingResult>;

public record UpdateListingResult(
  Listing? Listing
);

public class UpadateListingCommandValidator : AbstractValidator<UpdateListingCommand> {
  public UpadateListingCommandValidator() {
    RuleFor(el => el.Id).NotEmpty().WithMessage("Id is required");
    RuleFor(el => el.Name).NotEmpty().WithMessage("Name is required");
    RuleFor(el => el.Description).NotEmpty().MinimumLength(12).WithMessage("Description is required");
    RuleFor(el => el.Price).GreaterThan(0).WithMessage("Price is required");
    RuleFor(el => el.City).NotEmpty().WithMessage("City is required");
    RuleFor(el => el.Country).NotEmpty().WithMessage("Country is required");
    RuleFor(el => el.State).NotEmpty().WithMessage("State is required");
    RuleFor(el => el.Street).NotEmpty().WithMessage("Street is required");
    RuleFor(el => el.Image).NotEmpty().WithMessage("Image is required");
    RuleFor(el => el.KitchenNumber).GreaterThanOrEqualTo(0).WithMessage("KitchenNumber is required");
    RuleFor(el => el.BedroomNumber).GreaterThanOrEqualTo(0).WithMessage("BedroomNumber is required");
    RuleFor(el => el.BathroomNumber).GreaterThanOrEqualTo(0).WithMessage("BathroomNumber is required");
    RuleFor(el => el.CoordinateLat).GreaterThan(0).WithMessage("CoordinateLat is required");
    RuleFor(el => el.CoordinateLong).GreaterThan(0).WithMessage("CoordinateLong is required");
    RuleFor(el => el.Category).NotEmpty().WithMessage("Category is required");
    RuleFor(el => el.Amenities).NotNull().WithMessage("Amenities is required");
    RuleFor(el => el.ReviewScore).GreaterThanOrEqualTo(0).LessThanOrEqualTo(5).WithMessage("ReviewScore is required");
  }
}
