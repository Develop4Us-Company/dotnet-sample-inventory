using System;
using AppProject.Models;
using AppProject.Core.Models.Inventory;

namespace AppProject.Core.Services.Inventory;

public interface IProductService
{
    Task<EntityResponse<Product>> GetEntityAsync(GetByIdRequest<Guid> request, CancellationToken cancellationToken = default);
    Task<EntitiesResponse<Product>> GetEntitiesAsync(CancellationToken cancellationToken = default);
    Task<KeyResponse<Guid>> PostEntityAsync(CreateOrUpdateRequest<Product> request, CancellationToken cancellationToken = default);
    Task<KeyResponse<Guid>> PutEntityAsync(CreateOrUpdateRequest<Product> request, CancellationToken cancellationToken = default);
    Task<EmptyResponse> DeleteEntityAsync(DeleteRequest<Guid> request, CancellationToken cancellationToken = default);
}
