
using GetProductsUsingMCP.Models;

namespace GetProductsUsingMCP.Services;

public interface IProductRepository
{
    IReadOnlyList<Product> GetAll();
}

public sealed class ProductRepository : IProductRepository
{
    private static readonly IReadOnlyList<Product> _data = new List<Product>
    {
        new Product(1, "KB-001", "Contoso Keyboard", "Peripherals", "Wireless compact keyboard", 49.99m, true, 4.5),
        new Product(2, "MS-002", "Contoso Mouse", "Peripherals", "Ergonomic wireless mouse", 29.99m, true, 4.6),
        new Product(3, "MN-010", "Fabrikam Monitor", "Displays", "27\" QHD IPS monitor", 199.00m, false, 4.4),
        new Product(4, "DK-404", "Tailwind Dock", "Accessories", "USB-C 7-in-1 docking station", 129.50m, true, 4.2),
        new Product(5, "HS-020", "Aero Headset", "Audio", "Noise-cancelling over-ear headset", 89.00m, true, 4.1)
    };

    public IReadOnlyList<Product> GetAll() => _data;
}
