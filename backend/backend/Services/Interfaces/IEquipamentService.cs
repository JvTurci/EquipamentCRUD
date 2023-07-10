using backend.Entities;

namespace backend.Services.Interfaces
{
    public interface IEquipamentService
    {
        Task<IEnumerable<Equipament>> GetEquipamentsAsync();
        Task<Equipament> GetEquipamentByIdAsync(int id);
        Task<Equipament> CreateEquipamentAsync(Equipament product);
        Task<Equipament> UpdateEquipamentAsync(int id, Equipament product);
        Task<Equipament> DeleteEquipamentAsync(int id);
    }
}
