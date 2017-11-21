using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScoreGames.AppService.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace ScoreGames.AuroraApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Score")]
    public class ScoreController : Controller
    {
        private readonly IScoreAppService _scoreAppService;
        public ScoreController(IScoreAppService scoreAppService)
        {
            _scoreAppService = scoreAppService;
        }

        // GET: api/Score
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public class AA
        {
            public int i1 { get; set; }
            public int i2 { get; set; }
        }
        [HttpGet]
        public AA Get(AA id)
        {
            return id;
        }

        // POST: api/Score
        [HttpPost]
        public IActionResult Post([FromBody]IEnumerable<int> move)
        {
            if (move == null || move.Count() == 0)
                return BadRequest();
            return Ok(_scoreAppService.GetScoresByMove(move));
        }

        // PUT: api/Score/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
