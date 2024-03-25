using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using XpressMart.Application.Repositories.IRepositories;
using XpressMart.Core.Entities;
using XpressMart.Core.Models.Request;
using XpressMart.Core.Models.Response;

namespace XpressMart.API.Controllers
{
    /// <summary>
    /// Controller used to expose Category resources of the API
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        /// <summary>
        /// Initailizes a new instance of CategoriesController
        /// </summary>
        /// <param name="categoryRepository"></param>
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="request">The category request model.</param>
        /// <returns>A BaseResponse object containing the created category or validation errors.</returns>
        /// <response code="200">Returns the created category.</response>
        /// <response code="400">If the request model is invalid or there are validation errors.</response>
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<Category>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory([FromBody, Required] CategoryRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryRepository.CreateCategory(request);
                if (response.Success)
                {
                    return Created("", response);
                }
                return BadRequest(response);
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(new BaseResponse<string>(errors.ToList(), false));
        }

        /// <summary>
        /// Gets all category objects.
        /// </summary>
        /// <returns>A BaseResponse object containing list of categories or validation errors.</returns>
        /// <response code="200">Returns the list of categories available.</response>
        /// <response code="400">If there are validation errors.</response>
        [HttpGet]
        [ProducesResponseType(typeof(BaseResponse<List<Category>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCategories()
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryRepository.GetCategories();
                if (response.Success)
                    return Ok(response);

                return BadRequest(response);
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(new BaseResponse<string>(errors.ToList(), false));
        }

        /// <summary>
        /// Gets a particular category.
        /// </summary>
        /// <param name="categoryId">The category request Id.</param>
        /// <returns>A BaseResponse object containing the particular category or validation errors.</returns>
        /// <response code="200">Returns the particular category.</response>
        /// <response code="400">If the request Id is invalid or there are validation errors.</response>
        /// <response code="404">If no category exists with the request Id.</response>
        [HttpGet("{categoryId}")]
        [ProducesResponseType(typeof(BaseResponse<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategory([FromQuery, Required] int categoryId)
        {
            if (ModelState.IsValid)
            {
                if (!_categoryRepository.CategoryExists(categoryId))
                    return NotFound(new BaseResponse<string>(new List<string> { $"No category with that Id: {categoryId}" }, false));

                var response = await _categoryRepository.GetCategory(categoryId);
                if (response.Success)
                    return Ok(response);

                return BadRequest(response);
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(new BaseResponse<string>(errors.ToList(), false));
        }

        /// <summary>
        /// Updates a particular category.
        /// </summary>
        /// <param name="categoryId">The category request Id.</param>
        /// <returns>A BaseResponse object containing the updated category or validation errors.</returns>
        /// <response code="200">Returns the updated category.</response>
        /// <response code="400">If the request model is invalid or there are validation errors.</response>
        /// <response code="404">If no category exists with the request Id.</response>
        [HttpPut("{categoryId}")]
        [ProducesResponseType(typeof(BaseResponse<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCategory(CategoryRequestModel request)
        {
            if (ModelState.IsValid)
            {
                if (!_categoryRepository.CategoryExists(request.Id.GetValueOrDefault()))
                    return NotFound(new BaseResponse<string>(new List<string> { $"No category with that Id: {request.Id.GetValueOrDefault()}" }, false));

                var response = await _categoryRepository.UpdateCategory(request);
                if (response.Success)
                    return Ok(response);

                return BadRequest(response);
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(new BaseResponse<string>(errors.ToList(), false));
        }

        /// <summary>
        /// Deletes a particular category.
        /// </summary>
        /// <param name="categoryId">The category request Id.</param>
        /// <returns>A BaseResponse object containing success response or validation errors.</returns>
        /// <response code="200">Returns success message.</response>
        /// <response code="400">If the request Id is invalid or there are validation errors.</response>
        /// <response code="404">If no category exists with the request Id.</response>
        [HttpDelete("{categoryId}")]
        [ProducesResponseType(typeof(BaseResponse<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
        public IActionResult DeleteCategory(int categoryId)
        {
            try
            {
                if (!_categoryRepository.CategoryExists(categoryId))
                    return NotFound(new BaseResponse<string>(new List<string> { $"No category with that Id: {categoryId}" }, false));

                var response = _categoryRepository.DeleteCategory(categoryId);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(new BaseResponse<string>(new List<string> { ex.Message }, false));

            }
        }
    }
}
