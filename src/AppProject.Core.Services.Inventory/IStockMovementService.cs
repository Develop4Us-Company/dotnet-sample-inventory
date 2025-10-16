using System;
using AppProject.Models;
using AppProject.Core.Models.Inventory;

namespace AppProject.Core.Services.Inventory;

public interface IStockMovementService
{
    Task<EntitiesResponse<StockMovement>> GetEntitiesAsync(GetByParentIdRequest<Guid> request, CancellationToken cancellationToken = default);
    Task<KeyResponse<Guid>> PostEntityAsync(CreateOrUpdateRequest<StockMovement> request, CancellationToken cancellationToken = default);
    Task<KeyResponse<Guid>> PutEntityAsync(CreateOrUpdateRequest<StockMovement> request, CancellationToken cancellationToken = default);
    Task<EmptyResponse> DeleteEntityAsync(DeleteRequest<Guid> request, CancellationToken cancellationToken = default);
    Task<int> GetProductBalanceAsync(Guid productId, CancellationToken cancellationToken = default);
}
