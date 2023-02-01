using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatrProject.Resources.Commands.Delete;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly ProductDbContext _dbContext;

    public DeleteProductHandler(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(
            p => p.ProductId == request.ProductId, cancellationToken);

        _dbContext.Remove(product);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}