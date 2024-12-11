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
            _dc.Properties.Add(property);
        }

        public void DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync(int sellRent)
        {
            var properties = await _dc.Properties
                                   .Include(p => p.PropertyType)
                                   .Include(p => p.FurnishingType)
                                   .Include (p => p.City)
                                   .Where(p => p.SellRent == sellRent)
                                   .ToListAsync();
            return properties;
        }

        public async Task<Property> GetPropertyDetailAsync(int id)
        {
            var property = await _dc.Properties
                                .Include(p => p.PropertyType)       
                                .Include(p => p.FurnishingType)       
                                .Include(p => p.City)
                                .Where(p => p.Id == id)
                                .FirstAsync();
                            
            return property;
        }
    }
}
