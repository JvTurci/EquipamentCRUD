using backend.Entities;
using backend.Model;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class SituationService : ISituationService
    {
        private readonly DataBaseContext _dbContext;

        public SituationService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Situation>> GetSituationsAsync()
        {
            try
            {
                var situations = await _dbContext.Situation.ToListAsync();
                return situations;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
