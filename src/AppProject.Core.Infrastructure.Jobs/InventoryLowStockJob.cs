using System;
using System.Linq;
using System.Text;
using AppProject.Core.Models.Inventory;
using AppProject.Core.Services.Inventory;
using AppProject.Core.Infrastructure.Email;
using AppProject.Resources;

namespace AppProject.Core.Infrastructure.Jobs;

public class InventoryLowStockJob : IJob
{
    private readonly IProductService productService;
    private readonly IStockMovementService stockMovementService;
    private readonly IEmailSender emailSender;

    public InventoryLowStockJob(IProductService productService, IStockMovementService stockMovementService, IEmailSender emailSender)
    {
        this.productService = productService;
        this.stockMovementService = stockMovementService;
        this.emailSender = emailSender;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        var productsResponse = await productService.GetEntitiesAsync(cancellationToken);
        var products = productsResponse.Entities;

        var lowProducts = new List<Product>();

        foreach (var product in products)
        {
            var balance = await stockMovementService.GetProductBalanceAsync(product.Id.GetValueOrDefault(), cancellationToken);
            if (balance < product.MinimumStockQuantity)
            {
                lowProducts.Add(product);
            }
        }

        if (!lowProducts.Any())
        {
            return;
        }

        var sb = new StringBuilder();
        foreach (var p in lowProducts)
        {
            sb.AppendLine($"- {p.Name} (code: {p.Code ?? ""}) - balance below {p.MinimumStockQuantity}");
        }

        var subject = Resources.InventoryLowStock_EmailSubject;
        var body = string.Format(Resources.InventoryLowStock_EmailBody, sb.ToString());

        await emailSender.SendEmailAsync(subject, body, to: null, cancellationToken: cancellationToken);
    }
}
