
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GetProductsUsingMCP.Services;

namespace GetProductsUsingMCP.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;

    public ProductsController(IProductRepository repo) => _repo = repo;

    [HttpGet]
    public IActionResult Get() => Ok(_repo.GetAll());
}
