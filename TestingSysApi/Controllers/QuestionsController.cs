using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingSysApi.Contexts;
using TestingSysApi.Models;
namespace TestingSysApi.Controllers
{
    [EnableCors("AllowAny_Origin_Method_Header")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionContext _context;

        public QuestionsController(QuestionContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public IEnumerable<Question> GetQuestion()
        {
            return _context.Question;
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await _context.Question.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // GET: api/Questions/exam/5
        [HttpGet("exam/{id}")]
        public async Task<IActionResult> GetExamQuestion([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var question = await _context.Question.FindAsync(long.Parse(id));
            if (question == null)
            {
                return NotFound();
            }
            return Ok(new { Id=question.Id, question = question.question, answer1 = question.answer1, answer2 = question.answer2, answer3 = question.answer3, answer4 = question.answer4});
        }





        // GET: api/Questions/score/5
        [HttpGet("score/{data}")]
        public async Task<IActionResult> GetExamResult([FromRoute] string data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //q-q-q-aaa
            List<String> qlist = new List<string>(data.Split("-", StringSplitOptions.RemoveEmptyEntries));
            String answers = qlist[qlist.Count-1];
            int pass = int.Parse(qlist[0]);
            qlist.RemoveAt(qlist.Count - 1);
            qlist.RemoveAt(0);
            int current = 0, score = 0;
            foreach (String id in qlist)
            {
                var question = await _context.Question.FindAsync(long.Parse(id));
                if (question.Id == Int32.Parse(char.ToString(answers[current])))
                {
                    score++;
                }
                current++;
            }
            if (qlist == null)
            {
                return NotFound();
            }
            return Ok(new {score=score, result = (pass <= score) ? true : false });
        }










        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion([FromRoute] long id, [FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != question.Id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Questions
        [HttpPost]
        public async Task<IActionResult> PostQuestion([FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Question.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Question.Remove(question);
            await _context.SaveChangesAsync();

            return Ok(question);
        }

        private bool QuestionExists(long id)
        {
            return _context.Question.Any(e => e.Id == id);
        }
    }
}