namespace Real_App.Interfaces;

public interface IUnitOfWork
{
    ICityRepository CityRepository { get; }
    Task<bool> SaveAsync();
}