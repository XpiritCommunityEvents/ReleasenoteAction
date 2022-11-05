using System.ComponentModel.DataAnnotations;

namespace EnvironmentSinkHole
{
    public class EnvData
    {
        [Key]
        public Guid EnvId { get; set; }
        public string? Environment { get; set; }
    }
}