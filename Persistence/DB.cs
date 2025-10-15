using Models;

namespace Persistence;

public static class DB
{
    public static Product? products { get; set; }
    public static Models.ShoppingCart shoppingCart { get; set; } = new Models.ShoppingCart();
}
