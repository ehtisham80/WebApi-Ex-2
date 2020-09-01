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
            Id= 100266,
            Name= "Weber non-stick spray",
            Description= "BBQ oljespray som motverker att råvaror fastnar på gallret",
            Price=99
            }
        };



        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }
    }
}
