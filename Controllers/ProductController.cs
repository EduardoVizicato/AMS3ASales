using AMS3ASales.API.Context;
using AMS3ASales.API.Domain;
using AMS3ASales.API.Domain.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace AMS3ASales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDataContext _context;
        public ProductController(ApplicationDataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Product.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var product = _context.Product.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult Post(ProductRequest productRequest)
        {

            var product = new Product()
            {
                Description = productRequest.Description,
                IsActive = true,
                ImageURL = productRequest.ImageURL,
                Stock = productRequest.Stock,
                Price = productRequest.Price,
            };
            _context.Product.Add(product);
            _context.SaveChanges();

            return Ok();

        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id ,[FromBody]ProductRequest productRequest) 
        {
            var productUpdate = _context.Product.FirstOrDefault(x => x.Id == id);
            productUpdate.ImageURL = productRequest.ImageURL;
            productUpdate.Stock = productRequest.Stock;
            productUpdate.Price = productRequest.Price;
            productUpdate.Description = productRequest.Description;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (Guid id)
        {
            var productUpdate = _context.Product.FirstOrDefault (x => x.Id == id);
            productUpdate.IsActive = false;
            _context.SaveChanges();
            return Ok();
        }
    }
}
