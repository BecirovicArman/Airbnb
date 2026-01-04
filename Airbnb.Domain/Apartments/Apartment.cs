using Airbnb.Common.Exceptions;
using Airbnb.Domain.Abstractions;
using Airbnb.Domain.Bookings;
using Airbnb.Domain.Shared;
using Airbnb.Domain.Users;

namespace Airbnb.Domain.Apartments;

public sealed class Apartment : Entity
{
    public Apartment(
        Guid id,
        Name name,
        Description description,
        Address address,
        Money price,
        Money cleaningFee,
        List<Amenity> amenities) : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        CleaningFee = cleaningFee;
        Amenities = amenities;
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public Money CleaningFee { get; private set; }
    public DateTime? LastBookedOnUtc { get; internal set; }
    public List<Amenity> Amenities { get; private set; } = new();
    private readonly List<Booking> _bookings = new();

    private static readonly IReadOnlyDictionary<Amenity, decimal> _amenitiesUpchargeMap =
        new Dictionary<Amenity, decimal>
        {
            { Amenity.GardenView, 0.05m },
            { Amenity.MountainView, 0.05m },
            { Amenity.AirConditioning, 0.01m },
            { Amenity.Parking, 0.01m },
        };

    private PricingDetails CalculatePrice(DateRange period)
    {
        var currency = Price.Currency;

        var priceForPeriod = new Money(
            Price.Amount * period.LengthInDays,
            currency);

        var percentageUpCharge =
            Amenities.Sum(amenity =>
                _amenitiesUpchargeMap.GetValueOrDefault(amenity, 0m));

        var amenitiesUpCharge = new Money(
            priceForPeriod.Amount * percentageUpCharge,
            currency);

        return new PricingDetails(priceForPeriod, CleaningFee, amenitiesUpCharge);
    }

    public Guid Book(
        DateOnly startDate,
        DateOnly endDate,
        User user,
        DateTime utcNow)
    {
        var duration = DateRange.Create(startDate, endDate);

        if (_bookings.Any(booking => booking.Duration == duration))
        {
            throw new UnprocessableException(ApartmentErrors.BookingOverlap(Id.ToString(), duration.ToString()));
        }
        
        var booking = Booking.Reserve(
            Id,
            user.Id,
            duration,
            utcNow,
            CalculatePrice(duration));
        
        _bookings.Add(booking);
        
        LastBookedOnUtc = utcNow;
        
        return booking.Id;
    }
}