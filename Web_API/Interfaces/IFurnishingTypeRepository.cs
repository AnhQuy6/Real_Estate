using Real_App.Model;

namespace Real_App.Interfaces
{
    public interface IFurnishingTypeRepository
    {
        Task<IEnumerable<FurnishingType>> GetFurnishingTypesAsync(); 
    }
}
