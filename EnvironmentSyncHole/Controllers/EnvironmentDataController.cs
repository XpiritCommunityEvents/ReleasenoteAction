using EnvironmentSinkHole.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EnvironmentSinkHole.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnvironmentDataController : ControllerBase
    {
        private readonly IEnvironmentDataRepository repo;
        private readonly ILogger<EnvironmentDataController> _logger;

        public EnvironmentDataController(IEnvironmentDataRepository repo, ILogger<EnvironmentDataController> logger)
        {
            this.repo = repo;
            _logger = logger;

        }

        [HttpPost(Name = "DumpEnvironment")]
        public async Task<bool> Post(string jsonData)
        {
            await repo.AddEnvironmentData(jsonData);
            return await Task.FromResult(true);
        }


        [HttpGet(Name = "GetData")]
        public async Task<IEnumerable<EnvData>> Get()
        {
            return await repo.GetAllData();
        }



    }
}