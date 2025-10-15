namespace Models;

public class Product
{
    public String ProductId { get; set; } = String.Empty;
    public String Name { get; set; } = String.Empty;
    public double Price { get; set; }
    public IEnumerable<GroupAttribute> GroupAttributes { get; set; } =
        Enumerable.Empty<GroupAttribute>();
}

public class GroupAttribute
{
    public String GroupAttributeId { get; set; } = String.Empty;
    public GroupAttributeType? GroupAttributeType { get; set; }
    public String Description { get; set; } = String.Empty;
    public QuantityInformation? QuantityInformation { get; set; }
    public IEnumerable<Attribute> Attributes { get; set; } = Enumerable.Empty<Attribute>();
    public int Order { get; set; }
}

public class GroupAttributeType
{
    public String GroupAttributeTypeId { get; set; } = String.Empty;
    public String Name { get; set; } = String.Empty;
}

public class QuantityInformation
{
    public int GroupAttributeQuantity { get; set; }
    public Boolean ShowPricePerProduct { get; set; }
    public Boolean IsShown { get; set; }
    public Boolean IsEditable { get; set; }
    public Boolean IsVerified { get; set; }
    public String VerifyValue { get; set; } = String.Empty;
}

public class Attribute
{
    public String ProductId { get; set; } = String.Empty;
    public String AttributeId { get; set; } = String.Empty;
    public String Name { get; set; } = String.Empty;
    public int DefaultQuantity { get; set; }
    public int MaxQuantity { get; set; }
    public int PriceImpactAmount { get; set; }
    public Boolean IsRequired { get; set; }
    public String? NegativeAttributeId { get; set; }
    public int Order { get; set; }
    public String StatusId { get; set; } = String.Empty;
    public String? UrlImage { get; set; }
}
