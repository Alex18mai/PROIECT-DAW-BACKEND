using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROIECT_DAW.Managers;
using PROIECT_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoriesManager categoriesManager;
        public CategoryController(ICategoriesManager categoriesManager)
        {
            this.categoriesManager = categoriesManager;
        }


        [HttpGet("get-categories")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var category = categoriesManager.GetCategories().ToList();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("get-category-by-id/{id}")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetCategoryById([FromRoute] string id)
        {
            try
            {
                var category = categoriesManager.GetCategoryById(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }


        [HttpPost("create-category")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] CategoryCreationModel model)
        {
            try
            {
                categoriesManager.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpPut("update-category")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] CategoryCreationModel model)
        {
            try
            {
                categoriesManager.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpDelete("delete-category/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                categoriesManager.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }
    }
}
