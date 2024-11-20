using Real_App.Model;

namespace Real_App.Interfaces;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetCitiesAsync();
    void AddCity(City city);
    void DeleteCity(int id);
    Task<City> FindCity(int id);

}