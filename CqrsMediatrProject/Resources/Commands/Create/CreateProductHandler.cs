using CqrsMediatrProject.Models;
using MediatR;

namespace CqrsMediatrProject.Resources.Commands.Create;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly ProductDbContext _dbContext;

    public CreateProductHandler(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description
        };

        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return product;
    }
}