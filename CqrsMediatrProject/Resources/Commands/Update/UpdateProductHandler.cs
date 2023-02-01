using CqrsMediatrProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatrProject.Resources.Commands.Update;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
{
    private readonly ProductDbContext _dbContext;

    public UpdateProductHandler(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(
            p => p.ProductId == request.ProductId, cancellationToken);

        product.Name = request.Name;
        product.Description = request.Description;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return product;
    }
}