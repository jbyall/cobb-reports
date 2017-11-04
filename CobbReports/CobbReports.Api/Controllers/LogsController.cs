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

            var log = _context.Logs.Where(l => l.LogInfoId == id).OrderBy(l => l.Time).ToList();
            var rows = log.Count + 1;
            object[,] stuff = new object[rows, 3];
            stuff[0, 0] = "Time";
            stuff[0, 1] = "Boost Error";
            stuff[0, 2] = "Throttle";
            for (int i = 1; i < rows; i++)
            {
                stuff[i, 0] = log[i - 1].Time;
                stuff[i, 1] = log[i - 1].TDBoostError;
                stuff[i, 2] = log[i - 1].ThrottlePos;
            }

            

            var resultObject = new { chartData = stuff };

            //var result = JArray.FromObject(stuff);
            var result = JObject.FromObject(resultObject);
            return new JsonResult(result);
            if (log == null)
            {
                return NotFound();
            }

            return Ok(log);
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

       
    }

    public class TableData
    {
        public TableData()
        {
            this.RowCollection = new List<Row>();
            this.ColumnCollection = new List<Column>();
        }
        [JsonIgnore]
        public List<Row> RowCollection { get; set; }
        [JsonIgnore]
        public List<Column> ColumnCollection { get; set; }

        public Row[] rows { get { return this.RowCollection.ToArray(); } }
        public Column[] cols { get { return this.ColumnCollection.ToArray(); } }
    }

    public class Column
    {
        public string id { get; set; }
        public string label { get; set; }
        public string type { get; set; }
    }

    public class Row
    {
        public Row()
        {
            this.CellCollection = new List<Cell>();
        }
        [JsonIgnore]
        public List<Cell> CellCollection { get; set; }
        public Cell[] c { get { return this.CellCollection.ToArray(); } }

    }

    public class Cell
    {
        public object v { get; set; }
        public string f { get; set; }
    }

    public class HeaderRow
    {
        public HeaderRow()
        {

        }
        public string type { get; set; }
        public string label { get; set; }
    }
}