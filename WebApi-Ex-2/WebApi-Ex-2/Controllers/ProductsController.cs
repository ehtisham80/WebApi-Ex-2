using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Ex_2.Models;

namespace WebApi_Ex_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>()
        {
            new Product{
            Id= 1006368,
            Name= "Austin and Barbeque AABQ Wifi food Thermometer",
            Description= "Thermometer med Wifi för an optimal innertempratur",
            Price=399
            },
            new Product
            {
            Id= 1009334,
            Name= "Anderson Electric Tändare ECL 1.1",
            Description= "Electrisk Störmsäker tänder helt utan gas och bränsle",
            Price=89
            },
            new Product{
            Id= 1002266,
            Name= "Weber non-stick spray",
            Description= "BBQ oljespray som motverker att råvaror fastnar på gallret",
            Price=99
            }
        };



        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = products.Find(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpGet("{id}")]
        public ActionResult Post([FromBody] Product product)
        {
            if(products.Exists(p => p.Id == product.Id))
            {
                return Conflict();
            }
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, products);
        }



        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Product>>Delete(int id)
        {
            var product = products.Where(p => p.Id == id);
            if  (product == null)
            {
                return NotFound();
            }
            products = products.Except(product).ToList();
            return products;
        }



        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Product>> Put (int id, [FromBody] Product product)
        {
           
            if(id != product.Id)
            {
                return BadRequest();
            }
            var existingProduct = products.Where(p => p.Id == id);
            products = products.Except(existingProduct).ToList();

            products.Add(product);

            return products;
        }

    }
}
