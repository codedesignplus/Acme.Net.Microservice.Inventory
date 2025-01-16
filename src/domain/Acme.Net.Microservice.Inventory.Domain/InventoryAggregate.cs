namespace Acme.Net.Microservice.Inventory.Domain;

public class InventoryAggregate(Guid id) : AggregateRoot(id)
{
    public string Name { get; private set; } = string.Empty;
    public string Code { get; private set; } = string.Empty;
    public List<ProductEntity> Products { get; private set; } = [];

    private InventoryAggregate(Guid id, string name, string code, Guid tenant, Guid createBy) : this(id)
    {
        Name = name;
        Code = code;
        Tenant = tenant;
        IsActive = true;
        CreatedBy = createBy;
        CreatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        AddEvent(InventoryCreatedDomainEvent.Create(Id, Name, Code, Tenant, IsActive, CreatedBy, CreatedAt));
    }

    public static InventoryAggregate Create(Guid id, string name, string code, Guid tenant, Guid createBy)
    {
        DomainGuard.GuidIsEmpty(id, Errors.IdInventoryIsInvalid);
        DomainGuard.IsNullOrEmpty(name, Errors.NameInventoryIsInvalid);
        DomainGuard.IsNullOrEmpty(code, Errors.CodeInventoryIsInvalid);
        DomainGuard.GuidIsEmpty(tenant, Errors.TenantInventoryIsInvalid);
        DomainGuard.GuidIsEmpty(createBy, Errors.IdUserIsInvalid);

        return new InventoryAggregate(id, name, code, tenant, createBy);
    }

    public void Update(string name, Guid updatedBy)
    {
        DomainGuard.IsNullOrEmpty(name, Errors.NameInventoryIsInvalid);
        DomainGuard.GuidIsEmpty(updatedBy, Errors.IdUserIsInvalid);

        Name = name;
        UpdatedBy = updatedBy;
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        AddEvent(InventoryUpdatedDomainEvent.Create(Id, Name, Code, Products, Tenant, IsActive, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt));
    }

    public void Delete(Guid updatedBy)
    {
        DomainGuard.GuidIsEmpty(updatedBy, Errors.IdUserIsInvalid);

        IsActive = false;
        UpdatedBy = updatedBy;
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        AddEvent(InventoryDeletedDomainEvent.Create(Id, Name, Code, Products, Tenant, IsActive, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt));
    }

    public void AddProduct(ProductEntity product, Guid updatedBy)
    {
        DomainGuard.IsNull(product, Errors.ProductIsInvalid);
        DomainGuard.GuidIsEmpty(product.Id, Errors.ProductIsInvalid);
        DomainGuard.IsNullOrEmpty(product.Name, Errors.NameProductIsInvalid);
        DomainGuard.IsLessThan(product.Price, 0, Errors.PriceProductIsInvalid);
        DomainGuard.IsLessThan(product.Quantity, 0, Errors.QuantityProductIsInvalid);

        Products.Add(product);
        UpdatedBy = updatedBy;
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        AddEvent(ProductAddedDomainEvent.Create(Id, product));
    }

    public void UpdateProduct(ProductEntity product, Guid updatedBy)
    {
        DomainGuard.IsNull(product, Errors.ProductIsInvalid);
        DomainGuard.GuidIsEmpty(product.Id, Errors.ProductIsInvalid);
        DomainGuard.IsNullOrEmpty(product.Name, Errors.NameProductIsInvalid);
        DomainGuard.IsLessThan(product.Price, 0, Errors.PriceProductIsInvalid);
        DomainGuard.IsLessThan(product.Quantity, 0, Errors.QuantityProductIsInvalid);

        var item = Products.FirstOrDefault(p => p.Id == product.Id);

        DomainGuard.IsNull(item, Errors.ProductNotFound);

        item.Name = product.Name;
        item.Price = product.Price;
        item.Quantity = product.Quantity;
        UpdatedBy = updatedBy;
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        AddEvent(ProductUpdatedDomainEvent.Create(Id, item));
    }

    public void RemovedProduct(Guid productId, Guid updatedBy)
    {
        DomainGuard.GuidIsEmpty(productId, Errors.ProductIsInvalid);

        var item = Products.FirstOrDefault(p => p.Id == productId);

        DomainGuard.IsNull(item, Errors.ProductNotFound);

        Products.Remove(item);
        UpdatedBy = updatedBy;
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        AddEvent(ProductRemovedDomainEvent.Create(Id, item));
    }
}
