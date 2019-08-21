using Microsoft.AspNetCore.Mvc;
using Socona.OnmyojiTool.Data;
using Socona.OnmyojiTool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socona.OnmyojiTool.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoukaiController:ControllerBase
    {


        IOnmyojiToolRepository repository;

        public YoukaiController(IOnmyojiToolRepository repository)
        {
            this.repository = repository;
        }
        public IList<YoukaiItem> Youkais { get; set; }


        // GET: api/StageFamily
        [HttpGet]
        public async Task<IEnumerable<YoukaiItem>> Get()
        {
            return await repository.Youkais.GetAsync();
        }

        // GET: api/Soul/5
        [HttpGet("{id}", Name = "GetYoukai")]

        public async Task<YoukaiItem> Get(Guid id)
        {
            return await repository.Youkais.GetSingleAsync(id);
        }
    }
}
