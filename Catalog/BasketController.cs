using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [ApiController]
    [Route("basket")]

    public class BasketController : ControllerBase
    {
        private readonly ItemDB _db;
        Dictionary <Item, int> basket = new Dictionary<Item, int>();

        public BasketController(ILogger<BasketController> logger, ItemDB db)
        {
            _db = db;
        }

        [HttpGet]
        public string GetBasket()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(basket);
        }

        [HttpPost]
        [Route("addItem/{quantity}")]
        public async Task<IResult> addItem([FromBody] Item item, [FromQuery]int quantity)
        {
            basket.Add(item, quantity);
            return Results.Ok(item);
        }

        [HttpDelete]
        [Route("removeItem")]
        public async Task<IResult> RemoveItem(Item Id)
        {
            if(basket.ContainsKey(Id))
            {
                basket.Remove(Id);
                //basket.SaveChangesAsync();
                return Results.Ok(Id);
            }
            return Results.NotFound();
        }

        [HttpPut]
        [Route("changeQuantity")]
        public async Task<IResult> changeQuantity(Item basketItem, int newQuantity)
        {
            var newQ = basket.ContainsKey(basketItem);

            if(newQ == null){
                return Results.NotFound();
            }

            basket[basketItem] = newQuantity;
            //await basket.SaveChangesAsync();

            return Results.NoContent();
        }
    }
} 