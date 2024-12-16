using Microsoft.EntityFrameworkCore;
using Real_App.Interfaces;
using Real_App.Model;

namespace Real_App.Data.Repository
{
    public class FurnishingTypeRepository : IFurnishingTypeRepository
    {
        private readonly DataContext _dc;
        public FurnishingTypeRepository(DataContext dc)
        {
            _dc = dc;
        }
        

        public async Task<IEnumerable<FurnishingType>> GetFurnishingTypesAsync()
        {
            return await _dc.FurnishingTypes.ToListAsync();
        }
    }
}

