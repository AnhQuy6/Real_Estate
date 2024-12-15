using Microsoft.EntityFrameworkCore;
using Real_App.Interfaces;
using Real_App.Model;

namespace Real_App.Data.Repository
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly DataContext _dc;
        public PropertyTypeRepository(DataContext dc)
        {
            _dc = dc;
        }
        public async Task<IEnumerable<PropertyType>> GetPropertyTypesAsync()
        {
            return await _dc.PropertyTypes.ToListAsync();
        }
    }
}
