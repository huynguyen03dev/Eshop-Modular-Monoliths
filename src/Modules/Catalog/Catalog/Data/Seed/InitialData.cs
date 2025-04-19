namespace Catalog.Data.Seed;
public static class InitialData {
    public static IEnumerable<Product> Products => new List<Product> {
        Product.Create(
            Guid.NewGuid(),
            "iPhone 15 Pro Max",
            new List<string> { "Smartphone", "Apple" },
            "The iPhone 15 Pro Max features the A17 Pro chip, titanium design, and an upgraded camera system.",
            "iphone15promax.jpg",
            1299.99m
        ),
        Product.Create(
            Guid.NewGuid(),
            "Samsung Galaxy S24 Ultra",
            new List<string> { "Smartphone", "Samsung" },
            "Galaxy S24 Ultra offers a 6.8-inch AMOLED display and built-in S Pen for productivity.",
            "galaxys24ultra.jpg",
            1199.99m
        ),
        Product.Create(
            Guid.NewGuid(),
            "Xiaomi 14 Pro",
            new List<string> { "Smartphone", "Xiaomi" },
            "Xiaomi 14 Pro comes with the Snapdragon 8 Gen 3 chip and 120W fast charging.",
            "xiaomi14pro.jpg",
            899.99m
        ),
        Product.Create(
            Guid.NewGuid(),
            "Google Pixel 8 Pro",
            new List<string> { "Smartphone", "Google" },
            "Pixel 8 Pro features advanced AI photography and runs on clean Android 14 experience.",
            "pixel8pro.jpg",
            999.99m
        ),
    };
}
