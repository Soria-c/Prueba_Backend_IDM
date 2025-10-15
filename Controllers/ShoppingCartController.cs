using Microsoft.AspNetCore.Mvc;
using Models;
using Persistence;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class ShoppingCartController : ControllerBase
{

    [HttpPost]
    public IActionResult AddToCart([FromBody] AddToCartReq body)
    {
        GroupAttribute group = Persistence.DB.products!.GroupAttributes.First(g =>
            g.GroupAttributeId == body.GroupAttributeId
        );
        Models.Attribute product = group.Attributes.First(i => i.ProductId == body.ProductId);

        double unitPrice = product.PriceImpactAmount + Persistence.DB.products.Price;

        if (
            DB.shoppingCart.Groups.ContainsKey(group.GroupAttributeId)
            && DB.shoppingCart.Groups[group.GroupAttributeId].Items.ContainsKey(product.ProductId)
        )
        {
            if (
                DB.shoppingCart.Groups[group.GroupAttributeId].TotalItems
                == group.QuantityInformation!.GroupAttributeQuantity
            )
            {
                return BadRequest();
            }

            if (
                DB.shoppingCart.Groups[group.GroupAttributeId].Items[product.ProductId].Amount
                == product.MaxQuantity
            )
            {
                return BadRequest();
            }

            DB.shoppingCart.Groups[group.GroupAttributeId].Items[product.ProductId].Amount += 1;
            return Ok();
        }

        Item item = new Item()
        {
            Amount = 1,
            Name = product.Name,
            UnitPrice = unitPrice,
        };

        Group newGroup = new Group();
        newGroup.Items.Add(product.ProductId, item);
        DB.shoppingCart.Groups.Add(group.GroupAttributeId, newGroup);

        return Ok(DB.shoppingCart);
    }

    [HttpDelete]
    public IActionResult RemoveFromCart([FromBody] AddToCartReq body) {
        DB.shoppingCart.Groups[body.GroupAttributeId].Items.Remove(body.ProductId);
        DB.shoppingCart.Groups.Remove(body.GroupAttributeId);
        return Ok();
    }
}
