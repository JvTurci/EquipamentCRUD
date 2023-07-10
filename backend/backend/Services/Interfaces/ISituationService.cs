using backend.Entities;

namespace backend.Services.Interfaces
{
    public interface ISituationService
    {
        Task<IEnumerable<Situation>> GetSituationsAsync();
    }
}
