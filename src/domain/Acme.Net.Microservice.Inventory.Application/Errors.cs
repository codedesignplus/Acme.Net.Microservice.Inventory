namespace Acme.Net.Microservice.Inventory.Application;

public class Errors: IErrorCodes
{    
    public const string UnknownError = "200 : UnknownError";

    public const string InvalidRequest = "201 : The request is invalid";
    public const string InventoryAlreadyExists = "202 : The inventory already exists";

    public const string InventoryNotFound = "203 : The inventory was not found";

    public const string ProductAlreadyExists = "204 : The product already exists";

    public const string ProductNotFound = "205 : The product was not found";
}
