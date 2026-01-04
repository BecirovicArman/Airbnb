using Airbnb.Domain.Shared;

namespace Airbnb.Domain.Bookings;

public record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge)
{
    public Money TotalPriceForPeriod = PriceForPeriod + CleaningFee + AmenitiesUpCharge;
}