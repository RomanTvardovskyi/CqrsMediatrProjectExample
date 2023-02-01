using CqrsMediatrProject.Models;
using MediatR;

namespace CqrsMediatrProject.Resources.Queries;

public record GetProductByIdQuery(Guid ProductId) : IRequest<Product>;