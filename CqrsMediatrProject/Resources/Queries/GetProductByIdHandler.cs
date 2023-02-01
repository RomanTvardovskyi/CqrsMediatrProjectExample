using CqrsMediatrProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatrProject.Resources.Queries;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly ProductDbContext _dbContext;

    public GetProductByIdHandler(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    { 
        return await _dbContext.Products.FirstOrDefaultAsync(
            p => p.ProductId == request.ProductId, cancellationToken);
    }
}