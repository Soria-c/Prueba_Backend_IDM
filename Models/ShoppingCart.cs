namespace Models;

public class ShoppingCart
{
    public double TotalPrice
    {
        get { return this.Groups.Values.Sum(e => e.TotalPrice); }
    }
    public Dictionary<String, Group> Groups { get; set; } = new Dictionary<String, Group>();
}

public class Item
{
    public String Name { get; set; } = String.Empty;
    public int Amount { get; set; }
    public double UnitPrice { get; set; }
    public double TotalPrice
    {
        get { return UnitPrice * Amount; }
    }
}

public class Group
{
    public int TotalItems {
        get { return this.Items.Count(); }
    }
    public double TotalPrice
    {
        get { return this.Items.Values.Sum(e => e.TotalPrice); }
    }
    public Dictionary<String, Item> Items { get; set; } = new Dictionary<String, Item>();
}
