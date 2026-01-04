namespace Airbnb.Domain.Users;

public record Email
{
    public Email(string Value)
    {
        if (string.IsNullOrWhiteSpace(Value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(Value));
        }
        
        this.Value = Value;
    }

    public string Value { get; private init; }
}