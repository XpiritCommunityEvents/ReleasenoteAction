using EnvironmentSinkHole;

namespace EnvironmentSinkHole.Repository
{
    public interface IEnvironmentDataRepository
    {
        Task<bool> AddEnvironmentData(string jsonData);
        Task<IEnumerable<EnvData>> GetAllData();
    }
}