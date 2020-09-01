using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ex_2_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ex_2_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1006368,
                Name = "Austin and Barbque AABQ Wifi food thrmometer",
                Description = "Thermometer med Wifi för an optimal inntertemperatur",
                Price = 399
            },
            new Product
            {
                Id = 1009334,
                Name = "Andersson Electrisk Tändare ECL 1.1",
                Description = "Electrisk Stromsäker tändare helt utan gas och bränsle",
                Price = 89
            },
            new Product
            {
                Id = 1002266,
                Name = "Weber Non-sticky Spray",
                Description = "BBQ-oljespray som motverker at råvaror fastnar på gallret",
                Price = 99
            }
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = products.Find(product => product.Id == id);
            return product;
        }

    }
}
