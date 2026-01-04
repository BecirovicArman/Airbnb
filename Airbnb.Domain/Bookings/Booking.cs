using Airbnb.Domain.Abstractions;
using Airbnb.Domain.Bookings.Events;
using Airbnb.Domain.Shared;

namespace Airbnb.Domain.Bookings;

public class Booking : Entity
{
    private Booking(Guid id,
        Guid apartmentId,
        Guid userId,
        DateRange duration,
        Money priceForPeriod,
        Money cleaningFee,
        Money amenitiesUpCharge,
        Money totalPrice,
        BookingStatus status,
        DateTime createdOnUtc)
        : base(id)
    {
        ApartmentId = apartmentId;
        UserId = userId;
        Duration = duration;
        PriceForPeriod = priceForPeriod;
        CleaningFee = cleaningFee;
        AmenitiesUpCharge = amenitiesUpCharge;
        TotalPrice = totalPrice;
        Status = status;
        CreatedOnUtc = createdOnUtc;
    }

    public Guid ApartmentId { get; private set; }
    public Guid UserId { get; private set; }
    public DateRange Duration { get; private set; }
    public Money PriceForPeriod { get; private set; }
    public Money CleaningFee { get; private set; }
    public Money AmenitiesUpCharge { get; private set; }
    public Money TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime ConfirmedOnUtc { get; private set; }
    public DateTime RejectedOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }
    public DateTime? CancelledOnUtc { get; private set; }

    public static Booking Reserve(
        Guid apartmentId,
        Guid userId,
        DateRange duration,
        DateTime utcNow,
        PricingDetails pricingDetails)
    {
        var booking = new Booking(
            Guid.NewGuid(),
            apartmentId,
            userId,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.CleaningFee,
            pricingDetails.AmenitiesUpCharge,
            pricingDetails.TotalPriceForPeriod,
            BookingStatus.Reserved,
            utcNow);

        booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));
        
        return booking;
    }
    
    public void Confirm(DateTime utcNow)
    {
        if (Status != BookingStatus.Reserved)
        {
            //return Result.Failure(BookingErrors.NotReserved);
        }

        Status = BookingStatus.Confirmed;
        ConfirmedOnUtc = utcNow;

        RaiseDomainEvent(new BookingConfirmedDomainEvent(Id));
    }

    public void Reject(DateTime utcNow)
    {
        if (Status != BookingStatus.Reserved)
        {
            //return Result.Failure(BookingErrors.NotReserved);
        }

        Status = BookingStatus.Rejected;
        RejectedOnUtc = utcNow;

        RaiseDomainEvent(new BookingRejectedDomainEvent(Id));
    }

    public void Complete(DateTime utcNow)
    {
        if (Status != BookingStatus.Confirmed)
        {
            //return Result.Failure(BookingErrors.NotConfirmed);
        }

        Status = BookingStatus.Completed;
        CompletedOnUtc = utcNow;

        RaiseDomainEvent(new BookingCompletedDomainEvent(Id));
    }

    public void Cancel(DateTime utcNow)
    {
        if (Status != BookingStatus.Confirmed)
        {
            //return Result.Failure(BookingErrors.NotConfirmed);
        }

        var currentDate = DateOnly.FromDateTime(utcNow);

        if (currentDate > Duration.Start)
        {
            //return Result.Failure(BookingErrors.AlreadyStarted);
        }

        Status = BookingStatus.Cancelled;
        CancelledOnUtc = utcNow;

        RaiseDomainEvent(new BookingCancelledDomainEvent(Id));
    }
}