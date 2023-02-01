using MediatR;

namespace CqrsMediatrProject.Resources.Commands.Delete;

public record DeleteProductCommand(Guid ProductId): IRequest;