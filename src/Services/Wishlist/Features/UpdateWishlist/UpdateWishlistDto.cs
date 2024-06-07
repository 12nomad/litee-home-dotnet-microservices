namespace Wishlist.Features.UpdateWishlist;

public record UpdateWishlistCommand(
  string UserId,
  List<int> ListingsIds,
  int Id
) : ICommand<UpdateWishlistResult>;

public record UpdateWishlistResult(
  WishlistItem WishlistItem,
  bool isSuccess
);

public class UpdateWishlistValidator : AbstractValidator<UpdateWishlistCommand> {
  public UpdateWishlistValidator() {
    RuleFor(el => el.UserId).NotEmpty().WithMessage("UserId is required");
  }
}
