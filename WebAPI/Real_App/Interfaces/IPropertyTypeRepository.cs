using Real_App.Model;

namespace Real_App.Interfaces
{
    public interface IPropertyTypeRepository
    {
        Task<IEnumerable<PropertyType>> GetPropertyTypesAsync();
    }
}
