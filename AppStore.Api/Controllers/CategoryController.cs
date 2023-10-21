using AppStore.Application.DTOs.Input;
using AppStore.Application.DTOs.Output;
using AppStore.Application.Interfaces;
using AppStore.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AppStore.Api.Controllers
{
    [Authorize]
    [Route("v1")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private string _categoriescache_key = "Categories";

        private readonly ICategoryService _categoryService;
        private readonly IMemoryCache _cache;

        public CategoryController(ICategoryService categoryService, IMemoryCache cache)
        {
            _categoryService = categoryService;
            _cache = cache;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            try
            {
                if (_cache.TryGetValue(_categoriescache_key, out IEnumerable<CategoryDtoCreateResult> existing))
                {
                    return Ok(existing);
                }

                existing = await _categoryService.GetAll(ct);

                var memoryCacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(90),
                    SlidingExpiration = TimeSpan.FromMinutes(30)
                };

                _cache.Set(_categoriescache_key, existing, memoryCacheEntryOptions);

                return Ok(new Notification<List<CategoryDtoCreateResult>>(existing));

            }
            catch
            {
                return StatusCode(500, new Notification<List<CategoryDtoCreateResult>>("Internal Server Error"));
            }
        }

        [HttpGet("categories/{categoryId}")]
        public async Task<IActionResult> Get(Guid categoryId, CancellationToken ct)
        {
            try
            {
                var existing = await _categoryService.GetId(categoryId, ct);

                if (existing is null)
                    return NoContent();

                return Ok(new Notification<CategoryDtoCreateResult>(existing));

            }
            catch
            {

                return StatusCode(500, new Notification<CategoryDtoCreateResult>("Internal Server Error"));
            }
        }

        [HttpPost("categories")]
        public async Task<IActionResult> Post(CategoryDtoCreate category)
        {
            try
            {
                var addCategory = await _categoryService.Add(category);

                if (addCategory is not null)
                    return Created($"categories/{addCategory.Id}", new Notification<CategoryDtoCreateResult>(addCategory));

                return BadRequest(new Notification<CategoryDtoCreate>("409 - Error version conflict"));
            }
            catch
            {
                return StatusCode(500, new Notification<CategoryDtoCreate>("Internal Server Error"));
            }
        }

        [HttpPut("categories/{categoryId}")]
        public async Task<IActionResult> Put(Guid categoryId, CategoryDtoCreate model, CancellationToken ct)
        {
            try
            {
                var existing = await _categoryService.GetId(categoryId, ct);

                if (existing is null)
                    return NotFound(new Notification<CategoryDtoCreateResult>("ID was not found"));

                await _categoryService.Update(categoryId, model);

                return Ok(new Notification<CategoryDtoCreateResult>(existing));
            }
            catch
            {
                return StatusCode(500, new Notification<CategoryDtoCreateResult>("Internal Server Error"));
            }

        }

        [HttpDelete("categories/{categoryId}")]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            try
            {
                var existing = await _categoryService.Delete(categoryId);

                if (existing is null)
                    return NotFound(new Notification<CategoryDtoCreateResult>("ID was not found"));

                return NoContent();
            }
            catch
            {
                return StatusCode(500, new Notification<CategoryDtoCreateResult>("Internal Server Error"));
            }
        }
    }
}
