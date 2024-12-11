using Real_App.Data.Repository;

namespace Real_App.Interfaces;

public interface IUnitOfWork
{
    ICityRepository CityRepository { get; }
    IUserRepository UserRepository { get; }
    IPropertyRepository PropertyRepository { get; }
    IPropertyTypeRepository PropertyTypeRepository { get; }
    IFurnishingTypeRepository FurnishingTypeRepository { get; }
    Task<bool> SaveAsync();
}