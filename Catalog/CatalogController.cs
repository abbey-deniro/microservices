using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [ApiController]
    [Route("catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly ItemDB _db;

        public CatalogController(ILogger<CatalogController> logger, ItemDB db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("abc")]
        public ActionResult<String> abc()
        {
            return "hello from abc";
        }

    }
}