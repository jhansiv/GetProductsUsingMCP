
namespace GetProductsUsingMCP.Models;

public record Product
(
    int Id,
    string Sku,
    string Name,
    string Category,
    string Description,
    decimal Price,
    bool InStock,
    double Rating
);
