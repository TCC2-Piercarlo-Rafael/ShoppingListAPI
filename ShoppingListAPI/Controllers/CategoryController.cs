using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Dtos;
using ShoppingListAPI.Models;
using ShoppingListAPI.Services.CategoryService;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            return Ok(_categoryService.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetById(Guid id)
        {
            var Category = _categoryService.GetById(id);

            if (Category == null)
                return BadRequest("Category not found");

            return Ok(Category);
        }

        [HttpPost]
        public ActionResult<List<Category>> Add(CategoryDto request)
        {
            _categoryService.Add(request);

            return Ok(_categoryService.Get());
        }

        [HttpPut]
        public ActionResult<List<Category>> Update(Category request)
        {
            var category = _categoryService.GetById(request.Id);

            if (category == null)
                return BadRequest("Category not found");

            category.Description = request.Description;

            _categoryService.Update(category);

            return Ok(_categoryService.Get());
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Category>> Delete(Guid id)
        {
            var category = _categoryService.GetById(id);

            if (category == null)
                return BadRequest("Category not found");

            _categoryService.Delete(category);

            return Ok(_categoryService.Get());
        }
    }
}
