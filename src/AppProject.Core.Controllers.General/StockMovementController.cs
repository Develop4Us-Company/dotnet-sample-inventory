using System;
using AppProject.Core.Models.Inventory;
using AppProject.Core.Services.Inventory;
using AppProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppProject.Core.Controllers.General;

[Route("api/general/[controller]/[action]")]
[ApiController]
[Authorize]
public class StockMovementController(ProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetByProductAsync([FromQuery] GetByParentIdRequest<Guid> request, CancellationToken cancellationToken)
    {
        return this.Ok(await productService.GetEntitiesAsync(request, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CreateOrUpdateRequest<StockMovement> request, CancellationToken cancellationToken)
    {
        return this.Ok(await productService.PostEntityAsync(request, cancellationToken));
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] CreateOrUpdateRequest<StockMovement> request, CancellationToken cancellationToken)
    {
        return this.Ok(await productService.PutEntityAsync(request, cancellationToken));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromQuery] DeleteRequest<Guid> request, CancellationToken cancellationToken)
    {
        return this.Ok(await productService.DeleteEntityAsync(request, cancellationToken));
    }
}
