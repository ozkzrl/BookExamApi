using Microsoft.AspNetCore.Mvc;
using BookExam.Application.Interfaces;
using BookExam.Application.DTOs.Question;

namespace BookExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionDto createQuestionDto)
        {
            var result = await _questionService.CreateQuestionAsync(createQuestionDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
                return NotFound();
            return Ok(question);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] UpdateQuestionDto updateQuestionDto)
        {
            var updatedQuestion = await _questionService.UpdateQuestionAsync(id, updateQuestionDto);
            return Ok(updatedQuestion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionService.DeleteQuestionAsync(id);
            return NoContent();
        }
    }
}
