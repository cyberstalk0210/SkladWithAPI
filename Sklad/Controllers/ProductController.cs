using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sklad.Model;
using Sklad.Data;
namespace Sklad.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApiContext _context;

        public ProductController(ApiContext context)
        {
            _context = context;
        }

        //Create/edit

        [HttpPost]
        public JsonResult Add(Product product)
        {
            if (product.Id == 0)
            {
                _context.products.Add(product);
            }
            else { 
                var productId = _context.products.Find(product.Id);
                if (productId == null) {
                    return new JsonResult(NotFound());
                    productId = product;
                }
            }
            _context.SaveChanges();

            return new JsonResult(Ok(product));    

        }

        // GET
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.products.Find(id);
            if (result == null) {
                return new JsonResult(NotFound());
            }
            else
            {
                return new JsonResult(Ok(result));
            }
            _context.SaveChanges();

        }


        //Delete
        [HttpDelete]
        public JsonResult Delete(int id) {
            var result = _context.products.Find(id);
            if (result == null)
                return new JsonResult(NotFound());
            else
            {
                _context.products.Remove(result);
            }
                _context.SaveChanges();
                return new JsonResult(NoContent()); 

        }

        // GETALL
        [HttpGet("/GetAll")]

        public JsonResult GetAll() {
            var result = _context.products.ToList();
            return new JsonResult(Ok(result));
        }


    }
}
