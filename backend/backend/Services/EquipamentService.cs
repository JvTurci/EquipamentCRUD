using backend.Entities;
using backend.Model;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class EquipamentService : IEquipamentService
    {
        private readonly DataBaseContext _dbContext;

        public EquipamentService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<Equipament>> GetEquipamentsAsync()
        {
            try
            {
                var equipamets = await _dbContext.Equipament
                                            .Include(e => e.UfSource)
                                            .Include(e => e.UfDestination)
                                            .Include(e => e.ReadDirection)
                                            .Include(e=> e.Situation)
                                            .ToListAsync();

                return equipamets;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Equipament> GetEquipamentByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Equipament.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public  async Task<Equipament> CreateEquipamentAsync(Equipament equipament)
        {
            try
            {
                _dbContext.Equipament.Add(equipament);
                await _dbContext.SaveChangesAsync();

                return equipament;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Equipament> UpdateEquipamentAsync(int id, Equipament equipament)
        {
            try
            {
                var existingEquipament = await _dbContext.Equipament.FindAsync(id);

                if (existingEquipament == null)
                {
                    return null;
                }

                existingEquipament.Name = equipament.Name;
                existingEquipament.Situation = equipament.Situation;
                existingEquipament.UfSource = equipament.UfSource;
                existingEquipament.UfDestination = equipament.UfDestination;

                await _dbContext.SaveChangesAsync();

                return existingEquipament;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Equipament> DeleteEquipamentAsync(int id)
        {
            try
            {
                var equipament = await _dbContext.Equipament.FindAsync(id);

                if (equipament == null)
                {
                    return null;
                }

                _dbContext.Equipament.Remove(equipament);
                await _dbContext.SaveChangesAsync();

                return equipament;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
