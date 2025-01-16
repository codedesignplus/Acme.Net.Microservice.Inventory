global using CodeDesignPlus.Net.Logger.Extensions;
global using CodeDesignPlus.Net.Mongo.Extensions;
global using CodeDesignPlus.Net.Observability.Extensions;
global using CodeDesignPlus.Net.RabbitMQ.Extensions;
global using CodeDesignPlus.Net.Redis.Extensions;
global using CodeDesignPlus.Net.Security.Extensions;
global using Mapster;
global using MapsterMapper;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using C = CodeDesignPlus.Net.Core.Abstractions.Models.Criteria;
global using CodeDesignPlus.Net.Serializers;









global using Acme.Net.Microservice.Inventory.Application.Inventory.Commands.UpdateInventory;
global using Acme.Net.Microservice.Inventory.Application.Inventory.Commands.CreateInventory;
global using Acme.Net.Microservice.Inventory.Application.Inventory.Commands.DeleteInvetory;
global using Acme.Net.Microservice.Inventory.Application.Inventory.Commands.AddProduct;
global using Acme.Net.Microservice.Inventory.Application.Inventory.Commands.RemoveProduct;
global using Acme.Net.Microservice.Inventory.Application.Inventory.Queries.GetInventoryById;
global using Acme.Net.Microservice.Inventory.Application.Inventory.Queries.GetAllInventories;
global using Acme.Net.Microservice.Inventory.Application.Inventory.Queries.GetProductsByInventory;
global using Acme.Net.Microservice.Inventory.Application.Product.Commands.UpdateProduct;
global using Acme.Net.Microservice.Inventory.Application.Product.Commands.CreateProduct;