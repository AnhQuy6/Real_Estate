using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Real_App.Interfaces;
using Real_App.Model;

namespace Real_App.Data.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext _dc;
        public PropertyRepository(DataContext dc)
        {
            _dc = dc;
        }
        public void AddProperty(Property property)
        {
            throw new NotImplementedException();
        }

        public void DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync()
        {
            return await _dc.Properties.ToListAsync();
        }

    }
}
