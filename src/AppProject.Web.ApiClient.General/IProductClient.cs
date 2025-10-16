using System;
using AppProject.Core.Models.Inventory;
using AppProject.Models;
using Refit;
using System.Threading;

namespace AppProject.Web.ApiClient.General;

public interface IProductClient
{
    [Get("/api/general/Product/GetAsync")]
    Task<KeyResponse<Product>> GetAsync([Query] GetByIdRequest<Guid> request, CancellationToken cancellationToken = default);

    [Get("/api/general/Product/GetListAsync")]
    Task<EntitiesResponse<Product>> GetListAsync(CancellationToken cancellationToken = default);

    [Post("/api/general/Product/PostAsync")]
    Task<KeyResponse<Guid>> PostAsync([Body] CreateOrUpdateRequest<Product> request, CancellationToken cancellationToken = default);

    [Put("/api/general/Product/PutAsync")]
    Task<KeyResponse<Guid>> PutAsync([Body] CreateOrUpdateRequest<Product> request, CancellationToken cancellationToken = default);

    [Delete("/api/general/Product/DeleteAsync")]
    Task<EmptyResponse> DeleteAsync([Query] DeleteRequest<Guid> request, CancellationToken cancellationToken = default);
}
