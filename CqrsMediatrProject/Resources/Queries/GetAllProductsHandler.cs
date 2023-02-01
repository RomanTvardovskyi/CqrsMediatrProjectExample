using CqrsMediatrProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatrProject.Resources.Queries;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly ProductDbContext _dbContext;

    public GetAllProductsHandler(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Products.ToListAsync(cancellationToken);
    }
}