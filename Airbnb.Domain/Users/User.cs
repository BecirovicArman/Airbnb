using Airbnb.Domain.Abstractions;
using Airbnb.Domain.Users.Events;

namespace Airbnb.Domain.Users;

public sealed class User : Entity
{
    private User(Guid id, string name, string email) : base(id)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }

    public static User Create(string name, string email)
    {
        var user = new User(Guid.NewGuid(), name, email);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}