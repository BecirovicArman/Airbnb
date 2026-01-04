using Airbnb.Common.BuildingBlocks;

namespace Airbnb.Domain.Users;

public static class UserErrors
{
    public static Error NotFound(string id) => new(
        1001,
        $"The user with the specified ID: {id} was not found.");

    public static Error UserExists(string email) => new(1002, $"User with email '{email}' already exists.");
}