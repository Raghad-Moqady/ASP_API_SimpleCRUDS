using App1.Data;
using App1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ApplicationDbContext _context= new ApplicationDbContext();
        //create
        //read all
        [HttpGet("")]
        public IList<Category> GetAll()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }
        //read by id
        [HttpGet("{id}")]  
        public Category GetById(int id) {
            var category = _context.Categories.Find(id);
            return category;
        }
        //update
        //delete
    }
}
