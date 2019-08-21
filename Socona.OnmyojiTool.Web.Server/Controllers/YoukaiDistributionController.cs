using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Socona.OnmyojiTool.Data;
using Socona.OnmyojiTool.Repository;
using Socona.ToolBox.Specifications;

namespace Socona.OnmyojiTool.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoukaiDistributionController : ControllerBase
    {
        IOnmyojiToolRepository repository;

        public YoukaiDistributionController(IOnmyojiToolRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/YoukaiDistribution
        [HttpGet]
        public IEnumerable<YoukaiDistributionItem> Get()
        {
            return null;
        }

        // GET: api/YoukaiDistribution/5
        [HttpGet("{id}", Name = "GetYoukaiDistribution")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("youkai/{id}", Name = "GetYoukaiDistributionForYoukai")]
        public async Task<IEnumerable<YoukaiDistributionItem>> GetForYoukai(Guid id)
        {
            var specification = new Specification<YoukaiDistributionItem>(t => t.YoukaiId == id).OrderByDescending(t => t.Count);
            return await repository.YoukaiDistributions.GetAsync(specification);
        }
        // POST: api/YoukaiDistribution
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/YoukaiDistribution/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
