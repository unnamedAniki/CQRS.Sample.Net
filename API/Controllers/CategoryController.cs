using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Category;
using Sample.Application.Category.GetAllUseCase;
using Sample.Application.Category.UpdateCategoryUseCase;

namespace Sample.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }


        /// <summary>
        /// Get all categories
        /// </summary>
        [HttpGet("")]
        [ProducesResponseType(typeof(List<CategoryResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllCategoriesQuery());
            return Ok(result);
        }

        /// <summary>
        /// Update the category
        /// </summary>
        [HttpPut("")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Update(UpdateCategoryRequest request)
        {
            await mediator.Send(new UpdateCategoryCommand(mapper.Map<Category>(request)));
            return Ok("Ok");
        }

    }
}

