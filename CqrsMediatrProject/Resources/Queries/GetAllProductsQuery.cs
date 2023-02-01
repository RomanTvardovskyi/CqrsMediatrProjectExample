using CqrsMediatrProject.Models;
using MediatR;

namespace CqrsMediatrProject.Resources.Queries;

public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;