namespace Airbnb.Domain.Shared;

public record Currency
{
    internal static readonly Currency None = new Currency("");
    public static readonly Currency Usd = new Currency("USD");
    public static readonly Currency Eur = new Currency("EUR");

    public Currency(string code) => Code = code;
    public string Code { get; init; }

    public static readonly IReadOnlyCollection<Currency> AllCurrencies = new[]
    {
        Usd,
        Eur
    };
    
    public static Currency FromCode(string code)
    {
        return AllCurrencies.FirstOrDefault(x => x.Code == code) ??
               throw new ApplicationException("The currency code is invalid!");
    }
}