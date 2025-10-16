using System;
using AppProject.Core.Infrastructure.Database;
using AppProject.Core.Infrastructure.Database.Entities.Inventory;
using AppProject.Core.Models.Inventory;
using AppProject.Models;
using Mapster;

namespace AppProject.Core.Services.Inventory;

public class ProductService : IProductService, IStockMovementService
{
    private readonly IDatabaseRepository databaseRepository;

    public ProductService(IDatabaseRepository databaseRepository)
    {
        this.databaseRepository = databaseRepository;
    }

    public async Task<EntityResponse<Product>> GetEntityAsync(GetByIdRequest<Guid> request, CancellationToken cancellationToken = default)
    {
        var product = await databaseRepository.GetFirstOrDefaultAsync<TbProduct, Product>(
            query => query.Where(x => x.Id == request.Id),
            cancellationToken);

        if (product == null)
        {
            throw new Exception("Entity not found");
        }

        return new EntityResponse<Product> { Entity = product };
    }

    public async Task<EntitiesResponse<Product>> GetEntitiesAsync(CancellationToken cancellationToken = default)
    {
        var products = await databaseRepository.GetByConditionAsync<TbProduct, Product>(
            query => query, cancellationToken);

        return new EntitiesResponse<Product> { Entities = products };
    }

    public async Task<KeyResponse<Guid>> PostEntityAsync(CreateOrUpdateRequest<Product> request, CancellationToken cancellationToken = default)
    {
        var tb = request.Entity.Adapt<TbProduct>();
        await databaseRepository.InsertAsync(tb, cancellationToken);
        await databaseRepository.SaveAsync(cancellationToken);
        return new KeyResponse<Guid> { Id = tb.Id };
    }

    public async Task<KeyResponse<Guid>> PutEntityAsync(CreateOrUpdateRequest<Product> request, CancellationToken cancellationToken = default)
    {
        var tb = await databaseRepository.GetFirstOrDefaultAsync<TbProduct>(
            query => query.Where(x => x.Id == request.Entity.Id), cancellationToken);

        if (tb == null)
        {
            throw new Exception("Entity not found");
        }

        request.Entity.Adapt(tb);
        await databaseRepository.UpdateAsync(tb, cancellationToken);
        await databaseRepository.SaveAsync(cancellationToken);

        return new KeyResponse<Guid> { Id = tb.Id };
    }

    public async Task<EmptyResponse> DeleteEntityAsync(DeleteRequest<Guid> request, CancellationToken cancellationToken = default)
    {
        var tb = await databaseRepository.GetFirstOrDefaultAsync<TbProduct>(
            query => query.Where(x => x.Id == request.Id), cancellationToken);

        if (tb == null)
        {
            throw new Exception("Entity not found");
        }

        await databaseRepository.DeleteAndSaveAsync(tb, cancellationToken);
        return new EmptyResponse();
    }

    public async Task<EntitiesResponse<StockMovement>> GetEntitiesAsync(GetByParentIdRequest<Guid> request, CancellationToken cancellationToken = default)
    {
        var movements = await databaseRepository.GetByConditionAsync<TbStockMovement, StockMovement>(
            q => q.Where(x => x.ProductId == request.ParentId), cancellationToken);

        return new EntitiesResponse<StockMovement> { Entities = movements };
    }

    public async Task<KeyResponse<Guid>> PostEntityAsync(CreateOrUpdateRequest<StockMovement> request, CancellationToken cancellationToken = default)
    {
        var tb = request.Entity.Adapt<TbStockMovement>();
        await databaseRepository.InsertAsync(tb, cancellationToken);
        await databaseRepository.SaveAsync(cancellationToken);
        return new KeyResponse<Guid> { Id = tb.Id };
    }

    public async Task<KeyResponse<Guid>> PutEntityAsync(CreateOrUpdateRequest<StockMovement> request, CancellationToken cancellationToken = default)
    {
        var tb = await databaseRepository.GetFirstOrDefaultAsync<TbStockMovement>(
            q => q.Where(x => x.Id == request.Entity.Id), cancellationToken);

        if (tb == null)
        {
            throw new Exception("Entity not found");
        }

        request.Entity.Adapt(tb);
        await databaseRepository.UpdateAsync(tb, cancellationToken);
        await databaseRepository.SaveAsync(cancellationToken);

        return new KeyResponse<Guid> { Id = tb.Id };
    }

    public async Task<int> GetProductBalanceAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        var movements = await databaseRepository.GetByConditionAsync<TbStockMovement, TbStockMovement>(
            q => q.Where(x => x.ProductId == productId), cancellationToken);

        var balance = movements.Sum(x => x.IsOut ? -x.Quantity : x.Quantity);
        return balance;
    }
}
