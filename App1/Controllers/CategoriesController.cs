using App1.Data;
using App1.DTOs.categories;
using App1.Models;
using Azure.Core;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ApplicationDbContext _context= new ApplicationDbContext();
        //create => api/Categories
        [HttpPost("")]
        public IActionResult Create (CreateDTO request)
        {
            try
            {
                var category = new Category()
                {
                    Name = request.Name
                };

                //mapester way (from dto to domain model)
                //var category= request.Adapt<Category>();

                _context.Categories.Add(category);
                _context.SaveChanges();
                return Ok(new { message = "Added Succeessfully!" ,category});
            }
            catch (Exception ex) { 
                return BadRequest(ex.InnerException.Message);
            }
          
        }

        //read all
        [HttpGet("")]
        public IActionResult GetAll()
        {
            //way1: 
            //var categories = _context.Categories.ToList();
            //var categoriesDto= new List<GetAllDTO>();
            //foreach (var category in categories) {
            //    categoriesDto.Add(new GetAllDTO()
            //    {
            //        Id = category.Id,
            //        Name = category.Name,
            //    });
            //} 
            //return Ok(new {categories= categoriesDto});

            //way2:
            try
            {
                var categoriesDto = _context.Categories.Select(c => new GetAllDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList();

                //way 3 : using mapester
                //var categories= _context.Categories.ToList();
                //var categoriesDto = categories.Adapt<List<GetAllDTO>>();
                return Ok(new { categories = categoriesDto });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
           
        }
        //read by id
        [HttpGet("{id}")]  
        public IActionResult GetById(int id) {
          
            try
            {
                var category = _context.Categories.Find(id);
                var categoryDto = new GetByIdDTO
                {
                    Name = category.Name,
                };
                return Ok(new { category = categoryDto });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
       
        
        //update
        [HttpPatch("{id}")]
        public IActionResult Update(UpdateDto request, int id) {
            try
            {
                var category = _context.Categories.Find(id);
                category.Name = request.Name;
                _context.SaveChanges();
                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try
            {
                var category = _context.Categories.Find(id);
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

    }
}
