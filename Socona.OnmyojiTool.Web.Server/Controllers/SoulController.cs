using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Socona.OnmyojiTool.Data;
using Socona.OnmyojiTool.Repository;

namespace Socona.OnmyojiTool.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoulController : ControllerBase
    {
        IOnmyojiToolRepository repository;

        public SoulController(IOnmyojiToolRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/Soul
        [HttpGet]
        public async Task<IEnumerable<SoulItem>> Get()
        {
            return await repository.Souls.GetAsync();
        }

        // GET: api/Soul/5
        [HttpGet("{id}", Name = "GetSoul")]

        public async Task<SoulItem> Get(Guid id)
        {
            return await repository.Souls.GetSingleAsync(id);
        }

        // POST: api/Soul
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Soul/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
