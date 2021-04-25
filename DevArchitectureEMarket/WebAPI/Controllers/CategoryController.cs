using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Handlers.Categories.Commands;
using Business.Handlers.Categories.Queries;
using Microsoft.AspNetCore.Authorization;
using Nest;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createCategory"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategory)
        {
            var result = await Mediator.Send(createCategory);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        /// <summary>
        /// List
        /// </summary>
        /// <returns></returns>
        [HttpGet("getList")]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetCategoryListQuery());
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// List
        /// </summary>
        /// <returns></returns>
        ///
        [AllowAnonymous]
        [HttpGet("getCategoryById")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var result = await Mediator.Send(new GetCategoryByIdQuery{Id = categoryId});
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
