using Microsoft.AspNetCore.Mvc;
using Services;
using Dto.Request;

namespace HogwartsApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all student entries in the data base.
        /// </summary>
        /// <response code="404">Something went wrong.</response>              
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.ListAsync());
        }

        /// <summary>
        /// Get a specific student given the id.
        /// </summary>              
        /// <response code="404">No student found with the given id.</response>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _service.GetByIdAsync(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Create a new student entry.
        /// </summary>              
        /// <response code="201">New student entry created successfully.</response>
        /// <response code="400">Some fields do not meet the requested format.</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DtoStudentRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _service.CreateAsync(request);

            return Created($"/{response}", new
            {
                Id = response
            });
        }

        /// <summary>
        /// Update an existing student entry.
        /// </summary>              
        /// <response code="202">Student entry updated successfully.</response>
        /// <response code="400">Some fields do not meet the requested format.</response>
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, DtoStudentRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _service.UpdateAsync(id, request);

            return Accepted(new
            {
                Id = response
            });
        }

        /// <summary>
        /// Deletes a specific student entry.
        /// </summary>
        /// <param name="id"></param>        
        /// <response code="202">Student deleted with the given id.</response>
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Accepted(new
            {
                Id = id
            });
        }
    }
}
