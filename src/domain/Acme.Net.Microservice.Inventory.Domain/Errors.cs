namespace Acme.Net.Microservice.Inventory.Domain;

public class Errors : IErrorCodes
{
    public const string UnknownError = "100 : UnknownError";

    public const string IdInventoryIsInvalid = "101 : The inventory id is invalid";
    public const string NameInventoryIsInvalid = "102 : The inventory name is invalid";
    public const string CodeInventoryIsInvalid = "103 : The inventory code is invalid";
    public const string TenantInventoryIsInvalid = "104 : The inventory tenant is invalid";
    public const string IdUserIsInvalid = "105 : The user id is invalid";

    public const string ProductIsInvalid = "106 : The product is invalid";
    public const string NameProductIsInvalid = "107 : The product name is invalid";
    public const string PriceProductIsInvalid = "108 : The product price is invalid";
    public const string QuantityProductIsInvalid = "109 : The product quantity is invalid";

    public const string ProductNotFound = "110 : The product was not found";
}
