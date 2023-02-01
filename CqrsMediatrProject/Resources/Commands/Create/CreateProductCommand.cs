using CqrsMediatrProject.Models;
using MediatR;

namespace CqrsMediatrProject.Resources.Commands.Create;

public record CreateProductCommand(string Name, string Description) : IRequest<Product>;