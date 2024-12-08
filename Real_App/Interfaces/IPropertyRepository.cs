using Real_App.Model;

namespace Real_App.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetPropertiesAsync();
        void AddProperty(Property property);
        void DeleteProperty(int id);
    }
}
