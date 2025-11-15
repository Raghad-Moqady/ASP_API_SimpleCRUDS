using App1.Data;
using App1.DTOs.products;
using App1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ApplicationDbContext _context= new ApplicationDbContext();

        //Create
        [HttpPost("")]
        public IActionResult Create(CreateProductDTO request)
        {
            try
            {
                var product = new Product()
                {
                    Name= request.Name,
                    Description=request.Description,
                    Price=request.Price,
                    CategoryId=request.CategoryId
                 };
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(new {message="Success" });
            }
            catch (Exception ex) { 
             return BadRequest(ex.InnerException.Message);
            }

        }

        //Read all
        [HttpGet("")]
        public IActionResult GetAll()
        {
            try
            {
                var products = _context.Products.Select(p => new GetAllProductsDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.CategoryId
                }).ToList();
                return Ok(new { products });
            }
            catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }

        }
        //Read by id

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                var productDTO = new GetProductDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                };
                return Ok(new { product = productDTO });
            }
            catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }
        //update 

        [HttpPatch("{id}")]
        public IActionResult Update(UpdateProductDTO request,int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                product.Name= request.Name;
                product.Description= request.Description;
                product.Price= request.Price;
                product.CategoryId= request.CategoryId;
                _context.SaveChanges();
                return Ok(new { message= "success" });
            }
            catch (Exception ex) { 
             return BadRequest(ex.InnerException.Message);
            }
        }
        //delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try
            {
                var product = _context.Products.Find(id);
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok(new { message = "success" });
            }
            catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
            
        }
    }
}
