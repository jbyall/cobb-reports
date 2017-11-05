using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CobbReports.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Reflection;

namespace CobbReports.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Logs")]
    public class LogsController : Controller
    {
        private readonly CobbDbContext _context;

        public LogsController(CobbDbContext context)
        {
            _context = context;
        }

        // GET: api/Logs
        [HttpGet]
        public IEnumerable<Log> GetLogs()
        {
            return _context.Logs.Take(3);
        }

        // GET: api/Logs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var log = _context.Logs
                .Where(l => l.LogInfoId == id)
                .OrderBy(l => l.Time)
                .Select(l => new { time=l.Time, throttlePos=l.ThrottlePos, gearPosition=l.GearPosition, tdBoostError=l.TDBoostError })
                .ToList();
            return Json(log);
            //var fields = new Dictionary<string, string>
            //{
            //    {"Time", "Time" },
            //    {"ThrottlePos", "Throttle" },
            //    {"GearPosition", "Gear" },
            //    {"TDBoostError", "Boost Error" },
            //};

            //var stuff = getChartDataArray(log, fields);
            //var resultObject = new { chartData = stuff };

            ////var result = JArray.FromObject(stuff);
            //var result = JObject.FromObject(resultObject);
            //return new JsonResult(result);
            //if (log == null)
            //{
            //    return NotFound();
            //}

            //return Ok(log);
        }


        // PUT: api/Logs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLog([FromRoute] int id, [FromBody] Log log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != log.Id)
            {
                return BadRequest();
            }

            _context.Entry(log).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogExists(id))
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

        // POST: api/Logs
        [HttpPost]
        public async Task<IActionResult> PostLog([FromBody] Log log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Logs.Add(log);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLog", new { id = log.Id }, log);
        }

        //// DELETE: api/Logs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteLog([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var log = await _context.Logs.SingleOrDefaultAsync(m => m.Id == id);
        //    if (log == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Logs.Remove(log);
        //    await _context.SaveChangesAsync();

        //    return Ok(log);
        //}

        private bool LogExists(int id)
        {
            return _context.Logs.Any(e => e.Id == id);
        }

        #region Helpers
        private object[,] getChartDataArray(List<Log> logs, Dictionary<string,string> fields)
        {
            var properties = typeof(Log).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var rowCount = logs.Count + 1;
            var columnCount = fields.Count;

            object[,] result = new object[rowCount, fields.Count];
            int f = 0;

            // Table headings
            foreach (var field in fields)
            {
                result[0, f] = field.Value;
                f++;
            }

            // Table rows
            for (int i = 1; i < rowCount; i++)
            {
                int j = 0;
                foreach (var kvp in fields)
                {
                    result[i, j] = typeof(Log).GetProperty(kvp.Key).GetValue(logs[i - 1]);
                    j++;
                }
                
            }

            return result;
        }
        #endregion

    }
}