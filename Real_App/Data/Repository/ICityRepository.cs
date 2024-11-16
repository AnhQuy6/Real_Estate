using Real_App.Model;

namespace Real_App.Data.Repository;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetCitiesAsync();
    void AddCity(City city);
    void DeleteCity(int id);
    Task<bool> SaveAsync();
}