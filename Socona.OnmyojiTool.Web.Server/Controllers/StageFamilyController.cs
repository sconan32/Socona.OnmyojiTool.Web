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
    public class StageFamilyController : ControllerBase
    {

        IOnmyojiToolRepository repository;

        public StageFamilyController(IOnmyojiToolRepository repository)
        {
            this.repository = repository;
        }
        public IList<StageFamilyItem> StageFamilyItem { get; set; }

        
        // GET: api/StageFamily
        [HttpGet]
        public async Task<IEnumerable<StageFamilyItem>> Get()
        {
            return await repository.StageFamilies.GetAsync();
        }

        // GET: api/StageFamily/5
        [HttpGet("{id}", Name = "GetStageFamily")]
        public async Task<StageFamilyItem> Get(Guid id)
        {
            return await repository.StageFamilies.GetSingleAsync(id);
        }

        // POST: api/StageFamily
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/StageFamily/5
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
