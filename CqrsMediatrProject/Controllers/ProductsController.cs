using CqrsMediatrProject.Models;
using CqrsMediatrProject.Resources.Commands.Create;
using CqrsMediatrProject.Resources.Commands.Delete;
using CqrsMediatrProject.Resources.Commands.Update;
using CqrsMediatrProject.Resources.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrProject.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());

        return Ok(products);
    }

    [HttpGet("{productId:guid}")]
    public async Task<IActionResult> GetProductById(Guid productId)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(productId));

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(string name, string description)
    {
        var response = await _mediator.Send(new CreateProductCommand(name, description));

        return Ok(response);
    }

    [HttpPut("{productId:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid productId, string name, string description)
    {
        var product = await _mediator.Send(new UpdateProductCommand(productId, name, description));

        return Ok(product);
    }

    [HttpDelete("{productId:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        await _mediator.Send(new DeleteProductCommand(productId));

        return Ok();
    }
}