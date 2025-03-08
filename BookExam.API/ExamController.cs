using Microsoft.AspNetCore.Mvc;
using BookExam.Application.Interfaces;
using BookExam.Application.DTOs.Exam;

namespace BookExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpPost]
        public async Task<IActionResult> StartExam([FromBody] StartExamDto startExamDto)
        {
            var exam = await _examService.StartExamAsync(startExamDto);
            return Ok(exam);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExam(int id)
        {
            var exam = await _examService.GetExamByIdAsync(id);
            if (exam == null)
                return NotFound();
            return Ok(exam);
        }

        [HttpPost("submit/{id}")]
        public async Task<IActionResult> SubmitExam(int id, [FromBody] SubmitExamDto submitExamDto)
        {
            var result = await _examService.SubmitExamAsync(id, submitExamDto);
            return Ok(result);
        }
    }
}
