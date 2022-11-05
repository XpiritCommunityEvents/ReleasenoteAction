using EnvironmentSinkHole.DBContext;

namespace EnvironmentSinkHole.Repository;

public class EnvironmentDataRepository : IEnvironmentDataRepository
{
    private readonly EnvironmentDbContext _envDbContext;

    public EnvironmentDataRepository(EnvironmentDbContext eventDbContext)
    {
        _envDbContext = eventDbContext;
    }

    public async Task<bool> AddEnvironmentData(string jsonData)
    {
        _envDbContext.EnvironmentDump.Add(new EnvData()
        {
            Environment = jsonData,
            EnvId = new Guid()
        });

        await _envDbContext.SaveChangesAsync();
        return await Task.FromResult(true);
    }

    public async Task<IEnumerable<EnvData>> GetAllData()
    {
        var result = _envDbContext.EnvironmentDump.Where(env => !string.IsNullOrEmpty(env.Environment));
        return await Task.FromResult<IEnumerable<EnvData>>(result.ToList());
    }
}
