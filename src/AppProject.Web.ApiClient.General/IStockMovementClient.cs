using System;
using AppProject.Core.Models.Inventory;
using AppProject.Models;
using Refit;
using System.Threading;

namespace AppProject.Web.ApiClient.General;

public interface IStockMovementClient
{
    [Get("/api/general/StockMovement/GetByProductAsync")]
    Task<EntitiesResponse<StockMovement>> GetByProductAsync([Query] GetByParentIdRequest<Guid> request, CancellationToken cancellationToken = default);

    [Post("/api/general/StockMovement/PostAsync")]
    Task<KeyResponse<Guid>> PostAsync([Body] CreateOrUpdateRequest<StockMovement> request, CancellationToken cancellationToken = default);

    [Put("/api/general/StockMovement/PutAsync")]
    Task<KeyResponse<Guid>> PutAsync([Body] CreateOrUpdateRequest<StockMovement> request, CancellationToken cancellationToken = default);

    [Delete("/api/general/StockMovement/DeleteAsync")]
    Task<EmptyResponse> DeleteAsync([Query] DeleteRequest<Guid> request, CancellationToken cancellationToken = default);

    [Get("/api/general/StockMovement/GetAsync")]
    Task<KeyResponse<StockMovement>> GetAsync([Query] GetByIdRequest<Guid> request, CancellationToken cancellationToken = default);
}
