﻿using Microsoft.AspNetCore.Mvc;
using Sagdeev_kt4220.Database;
using Sagdeev_kt4220.Filters;
using Sagdeev_kt4220.Models;
using Sagdeev_kt4220.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Sagdeev_kt4220.Controllers
{
    [ApiController]
    [Route("controller")]
    public class PrepodController : ControllerBase
    {
        private readonly ILogger<PrepodController> _logger;
        private readonly IPrepodService _prepodService;
        private PrepodDbcontext _context;

        public PrepodController(ILogger<PrepodController> logger, IPrepodService prepodService, PrepodDbcontext context)
        {
            _logger = logger;
            _prepodService = prepodService;
            _context = context;
        }

        [HttpPost("GetPrepodsByKafedra", Name = "GetPrepodsByKafedra")]
        public async Task<IActionResult> GetPrepodsByKafedraAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = await _prepodService.GetPrepodsByKafedraAsync(filter, cancellationToken);

            return Ok(prepod);
        }

        //добавление для преподов
        [HttpPost("AddPrepod", Name = "AddPrepod")]
        public IActionResult CreatePrepod([FromBody] Prepod prepod)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            var gr = _context.Kafedra.FirstOrDefault(g => g.KafedraId == prepod.KafedraId);
            if (gr != null)
            {
                prepod.Kafedra = gr;
            }

            var deg = _context.Stepen.FirstOrDefault(d => d.StepenId == prepod.StepenId);
            if (deg != null)
            {
                prepod.Stepen = deg;
            }

            _context.Prepod.Add(prepod);
            _context.SaveChanges();
            return Ok(prepod);
        }

        [HttpPut("EditPrepod")]
        public IActionResult UpdatePrepod(string firstname, [FromBody] Prepod updatedPrepod)
        {
            var existingPrepod = _context.Prepod.FirstOrDefault(g => g.FirstName == firstname);

            if (existingPrepod == null)
            {
                return NotFound();
            }

            existingPrepod.FirstName = updatedPrepod.FirstName;
            existingPrepod.LastName = updatedPrepod.LastName;
            existingPrepod.MiddleName = updatedPrepod.MiddleName;
            existingPrepod.KafedraId = updatedPrepod.KafedraId;
            existingPrepod.StepenId = updatedPrepod.StepenId;
            _context.SaveChanges();

            return Ok();
        }

        //удаление для препода
        [HttpDelete("DeletePrepod")]
        public IActionResult DeletePrepod(string firstname, Sagdeev_kt4220.Models.Prepod updatedPrepod)
        {
            var existingPrepod = _context.Prepod.FirstOrDefault(g => g.FirstName == firstname);

            if (existingPrepod == null)
            {
                return NotFound();
            }
            _context.Prepod.Remove(existingPrepod);
            _context.SaveChanges();

            return Ok();
        }

        //добавление для кафедры
        [HttpPost("AddKafedra", Name = "AddKafedra")]
        public IActionResult CreateKafedra([FromBody] Sagdeev_kt4220.Models.Kafedra kafedra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Kafedra.Add(kafedra);
            _context.SaveChanges();
            return Ok(kafedra);
        }

        [HttpPut("EditKafedra")]
        public IActionResult UpdateKafedra(string kafedraname, [FromBody] Kafedra updatedKafedra)
        {
            var existingKafedra = _context.Kafedra.FirstOrDefault(g => g.KafedraName == kafedraname);

            if (existingKafedra == null)
            {
                return NotFound();
            }

            existingKafedra.KafedraName = updatedKafedra.KafedraName;
            _context.SaveChanges();

            return Ok();
        }
        //удаление для кафедры
        [HttpDelete("DeleteKafedra")]
        public IActionResult DeleteKafedra(string kafedraName, Sagdeev_kt4220.Models.Kafedra updatedKafedra)
        {
            var existingKafedra = _context.Kafedra.FirstOrDefault(g => g.KafedraName == kafedraName);

            if (existingKafedra == null)
            {
                return NotFound();
            }
            _context.Kafedra.Remove(existingKafedra);
            _context.SaveChanges();

            return Ok();
        }

    }
}