namespace Acme.Net.Microservice.Inventory.Domain.ValueObjects;

public sealed partial class Category
{
    [GeneratedRegex(@"^0x[0-9]{32}$")]
    private static partial Regex Regex();

    public string Value { get; private set; }

    private Category(string value)
    {
        DomainGuard.IsNullOrEmpty(value, Errors.UnknownError);

        DomainGuard.IsFalse(Regex().IsMatch(value), Errors.UnknownError);

        this.Value = value;
    }

    public static Category Create(string value)
    {
        return new Category(value);
    }
}
