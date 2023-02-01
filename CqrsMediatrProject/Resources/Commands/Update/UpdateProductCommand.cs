using CqrsMediatrProject.Models;
using MediatR;

namespace CqrsMediatrProject.Resources.Commands.Update;

public record UpdateProductCommand(Guid ProductId, string Name, string Description) : IRequest<Product>;