using Airbnb.Common.BuildingBlocks;

namespace Airbnb.Domain.Apartments;

public static class ApartmentErrors
{
    public static Error NotFound(string id) => new(
        2001,
        $"The Apartment with the specified ID: {id} was not found.");
    
    public static Error BookingOverlap(string apartmentId, string date) => new(
        2002,
        $"The booking for apartmentId '{apartmentId}' overlaps with an existing booking '{date}'.");

}