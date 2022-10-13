using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenzTest.Infrastructure;
using RenzTest.Repository;

namespace RenzTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public ProjectController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.projectRepository.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.projectRepository.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Project product)
        {
            var data = await unitOfWork.projectRepository.AddAsync(product);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.projectRepository.DeleteAsync(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Project product)
        {
            var data = await unitOfWork.projectRepository.UpdateAsync(product);
            return Ok(data);
        }
        [Route("Project/AddFormData")]
        [HttpPost]
        public async Task<IActionResult> AddFormData(FormData formData)
        {
            var data = await unitOfWork.projectRepository.AddFormDataAsync(formData);
            return Ok(data);
        }
    }
}
