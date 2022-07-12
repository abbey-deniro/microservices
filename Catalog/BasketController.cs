using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [ApiController]
    [Route("basket")]

    public class BasketController : ControllersBase
    {
        private readonly ItemDB _db;
        Dictionary <Item, int> basket = new Dictionary<Item, int>();

        public BasketController(ILogger<BasketController> logger, ItemDB db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("addItem")]
        public Task<IResult> addItem(Item item, int quantity)
        {
            basket.Add(item, quantity);
            return Results.Ok(item);
        }

        [HttpDelete]
        [Route("removeItem")]
        public Task<IResult> RemoveItem(Item Id)
        {
            if(basket.Find(Id) is Item item)
            {
                basket.Remove(item);
                //basket.SaveChangesAsync();
                return Results.Ok(item);
            }
            return Results.NotFound();
        }

        [HttpPut]
        [Route("changeQuantity")]
        public Task<IResult> changeQuantity(Item basketItem, int newQuantity)
        {
            var newQ = basket.Find(basketItem.Id);

            if(newQ == null){
                return Results.NotFound();
            }

            basket["{Id}"] = newQuantity;
            //await basket.SaveChangesAsync();

            return Results.NoContent();
        }
    }
}