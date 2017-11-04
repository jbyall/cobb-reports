using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CobbReports.Domain;

namespace CobbReports.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/LogInfos")]
    public class LogInfosController : Controller
    {
        private readonly CobbDbContext _context;

        public LogInfosController(CobbDbContext context)
        {
            _context = context;
        }

        // GET: api/LogInfos
        [HttpGet]
        public IEnumerable<LogInfo> GetLogInfos()
        {
            var result = _context.LogInfos;
            foreach (var item in result)
            {
                item.LogCount = _context.Logs.Count(l => l.LogInfoId == item.Id);
            }
            return result;
        }

        // GET: api/LogInfos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var logInfo = await _context.LogInfos.SingleOrDefaultAsync(m => m.Id == id);

            if (logInfo == null)
            {
                return NotFound();
            }

            return Ok(logInfo);
        }

        // PUT: api/LogInfos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogInfo([FromRoute] int id, [FromBody] LogInfo logInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(logInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogInfoExists(id))
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

        // POST: api/LogInfos
        [HttpPost]
        public async Task<IActionResult> PostLogInfo([FromBody] LogInfo logInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LogInfos.Add(logInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogInfo", new { id = logInfo.Id }, logInfo);
        }

        // DELETE: api/LogInfos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var logInfo = await _context.LogInfos.SingleOrDefaultAsync(m => m.Id == id);
            if (logInfo == null)
            {
                return NotFound();
            }

            _context.LogInfos.Remove(logInfo);
            await _context.SaveChangesAsync();

            return Ok(logInfo);
        }

        private bool LogInfoExists(int id)
        {
            return _context.LogInfos.Any(e => e.Id == id);
        }
    }
}