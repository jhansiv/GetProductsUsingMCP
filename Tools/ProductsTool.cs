using GetProductsUsingMCP.Models;
using GetProductsUsingMCP.Services;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace GetProductsUsingMCP.Tools
{

    [McpServerToolType]
    public class ProductsTool
    {

            private readonly IProductRepository _repo;
    
            public ProductsTool(IProductRepository repo) => _repo = repo;
    
            [McpServerTool]
            [Description("Retrieves a list of all products.")]
            public IReadOnlyList<Product> GetAllProducts() => _repo.GetAll();

    }
}
